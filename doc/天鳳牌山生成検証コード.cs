// http://integral001.blog.fc2.com/blog-entry-42.html
using System.Security.Cryptography;

/// <summary>
/// Tenhou牌山生成検証プログラム (C#版)
/// Mersenne Twister による乱数生成＋SHA512ハッシュで牌山をシャッフル
/// 生成される牌山は王牌側から出力される
/// </summary>
internal class Program
{
    private const int MTRAND_N = 624;  // Mersenne Twister のシード長
    private const int BLOCK_COUNT = 9; // SHA512でハッシュするブロック数 全部で136個の乱数が欲しいので16*9=144個MT乱数を生成する

    // 牌種表示用文字列配列
    private static readonly string[] haiDisp_ = [
        "<1m>", "<2m>", "<3m>", "<4m>", "<5m>", "<6m>", "<7m>", "<8m>", "<9m>",
        "<1p>", "<2p>", "<3p>", "<4p>", "<5p>", "<6p>", "<7p>", "<8p>", "<9p>",
        "<1s>", "<2s>", "<3s>", "<4s>", "<5s>", "<6s>", "<7s>", "<8s>", "<9s>",
        "<東>", "<南>", "<西>", "<北>", "<白>", "<發>", "<中>"
    ];

    /// <summary>
    /// バイト配列の指定区間をエンディアン変換 (逆順に並べかえ)
    /// </summary>
    static void ConvertEndian(byte[] data, int index, int length)
    {
        Array.Reverse(data, index, length);
    }

    static void Main()
    {
        // Base64でエンコードされたMTシード文字列
        var MTseed_b64 = @"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";
        // Base64 -> バイト列にデコード
        var MTseed = Convert.FromBase64String(MTseed_b64);
        // バイト列からuintシード配列に変換
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
        var mt = new Mt19937();
        mt.InitByArray(RTseed);
        // 10ゲーム分ループ
        for (var nGame = 0; nGame < 10; nGame++)
        {
            var hashLen = SHA512.Create().HashSize / 8; // 64bytes
            var rnd = new uint[hashLen / sizeof(uint) * BLOCK_COUNT]; // 要素数:16*9=144
            var src = new uint[rnd.Length * 2]; // 要素数:288
            // ローカルMTから乱数取得
            for (var i = 0; i < src.Length; i++)
            {
                src[i] = mt.GenRandUInt32();
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
            var yama = Enumerable.Range(0, 136).Select(i => (byte)i).ToArray();
            // Fisher-Yates アルゴリズムでシャッフル
            for (var i = 0; i < yama.Length - 1; i++)
            {
                var j = i + (int)(rnd[i] % (yama.Length - i));
                (yama[i], yama[j]) = (yama[j], yama[i]);
            }
            // 結果表示
            Console.WriteLine($"--------Game {nGame}--------");
            Console.WriteLine("yama =");
            for (var i = 0; i < 136; i++)
            {
                Console.Write(haiDisp_[yama[i] / 4]);
                if ((i + 1) % 17 == 0)
                {
                    Console.WriteLine();
                }

                if (i == 83)
                {
                    Console.Write("  "); // 配牌区切り
                }
            }
            Console.WriteLine();

            // サイコロ目 (1～6)
            var dice0 = (int)(rnd[135] % 6) + 1;
            var dice1 = (int)(rnd[136] % 6) + 1;
            Console.WriteLine($"dice0 = {dice0}, dice1 = {dice1}\n");
        }
    }
}

/// <summary>
/// C# 用 Mersenne Twister (MT19937) 実装
/// </summary>
public class Mt19937
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

    /// <summary>配列シード初期化 (init_by_array)</summary>
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
