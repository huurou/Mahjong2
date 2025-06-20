using System.Security.Cryptography;

namespace Mahjong2.Lib;

internal interface IWallGenerator
{
    Wall Generate(string? seed = null);
}

internal record WallGeneratorTenhou : IWallGenerator
{
    private const int MTRAND_N = 624;  // Mersenne Twister のシード長
    private const int BLOCK_COUNT = 9; // SHA512でハッシュするブロック数 全部で136個の乱数が欲しいので16*9=144個MT乱数を生成する

    private bool initialized_ = false;
    private readonly Mt19937 mt_ = new();

    public Wall Generate(string? seed = null)
    {
        if (!initialized_)
        {
            var MTseed = new byte[2496];
            if (string.IsNullOrEmpty(seed))
            {
                RandomNumberGenerator.Create().GetBytes(MTseed);
            }
            else
            {
                MTseed = Convert.FromBase64String(seed);
            }
            var RTseed = new uint[MTRAND_N];
            for (var i = 0; i < MTRAND_N; i++)
            {
                var offset = i * 4;
                var temp = new byte[4];
                Array.Copy(MTseed, offset, temp, 0, 4);
                //ConvertEndian(temp, 0, 4); 元のC言語では書いてあったが、C#では不要だった
                RTseed[i] = BitConverter.ToUInt32(temp, 0);
            }
            // ルートMTを初期化
            mt_.InitByArray(RTseed);
            initialized_ = true;
        }

        var hashLen = 64; // SHA512のハッシュバイトサイズ
        var rnd = new uint[hashLen / sizeof(uint) * BLOCK_COUNT]; // 要素数:16*9=144
        var src = new uint[rnd.Length * 2]; // 要素数:288

        for (var i = 0; i < src.Length; i++)
        {
            src[i] = mt_.GenRandUInt32();
        }
        // SHA512で128byteごとにハッシュ
        for (var i = 0; i < BLOCK_COUNT; i++)
        {
            var input = new byte[128];
            Buffer.BlockCopy(src, i * (hashLen * 2), input, 0, 128);
            var hash = SHA512.HashData(input);
            Buffer.BlockCopy(hash, 0, rnd, i * hashLen, hashLen);
        }
        // 牌山配列を初期化 (0～135)
        var yama = Enumerable.Range(0, 136).Select(i => new Tile(i)).ToArray();
        // Fisher-Yates アルゴリズムでシャッフル
        for (var i = 0; i < yama.Length - 1; i++)
        {
            var j = i + (int)(rnd[i] % (yama.Length - i));
            (yama[i], yama[j]) = (yama[j], yama[i]);
        }
        return new(yama);
    }

    /// <summary>
    /// C# 用 Mersenne Twister (MT19937) 実装
    /// </summary>
    class Mt19937
    {
        private const int N = 624;
        private const int M = 397;
        private const uint MATRIX_A = 0x9908b0dfU;
        private const uint UPPER_MASK = 0x80000000U;
        private const uint LOWER_MASK = 0x7fffffffU;

        private readonly uint[] mt_ = new uint[N];
        private int mti = N + 1;

        /// <summary>単一シード初期化 (init_genrand)</summary>
        public void InitGenRand(uint s)
        {
            mt_[0] = s;
            for (mti = 1; mti < N; mti++)
            {
                mt_[mti] = (uint)(1812433253U * (mt_[mti - 1] ^ (mt_[mti - 1] >> 30)) + mti);
            }
        }

        /// <summary>
        /// 配列シード初期化 (init_by_array)
        /// </summary>
        public void InitByArray(uint[] initKey)
        {
            InitGenRand(19650218U);
            int i = 1, j = 0;
            var k = Math.Max(N, initKey.Length);
            for (; k > 0; k--)
            {
                mt_[i] = (uint)((mt_[i] ^ ((mt_[i - 1] ^ (mt_[i - 1] >> 30)) * 1664525U)) + initKey[j] + j);
                i++; j++;
                if (i >= N) { mt_[0] = mt_[N - 1]; i = 1; }
                if (j >= initKey.Length)
                {
                    j = 0;
                }
            }
            for (k = N - 1; k > 0; k--)
            {
                mt_[i] = (uint)((mt_[i] ^ ((mt_[i - 1] ^ (mt_[i - 1] >> 30)) * 1566083941U)) - i);
                i++;
                if (i >= N) { mt_[0] = mt_[N - 1]; i = 1; }
            }
            mt_[0] = 0x80000000U;
        }

        /// <summary>32bit 乱数生成 (genrand_int32)</summary>
        public uint GenRandUInt32()
        {
            uint y;
            uint[] mag01 = [0U, MATRIX_A];
            if (mti >= N)
            {
                int kk;
                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt_[kk] & UPPER_MASK) | (mt_[kk + 1] & LOWER_MASK);
                    mt_[kk] = mt_[kk + M] ^ (y >> 1) ^ mag01[y & 1U];
                }
                for (; kk < N - 1; kk++)
                {
                    y = (mt_[kk] & UPPER_MASK) | (mt_[kk + 1] & LOWER_MASK);
                    mt_[kk] = mt_[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 1U];
                }
                y = (mt_[N - 1] & UPPER_MASK) | (mt_[0] & LOWER_MASK);
                mt_[N - 1] = mt_[M - 1] ^ (y >> 1) ^ mag01[y & 1U];
                mti = 0;
            }
            y = mt_[mti++];
            // tempering
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9d2c5680U;
            y ^= (y << 15) & 0xefc60000U;
            y ^= (y >> 18);
            return y;
        }
    }
}
