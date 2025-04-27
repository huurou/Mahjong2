using Mahjong2.Lib.Fus;
using Xunit;

namespace Mahjong2.Tests.Fus
{
    /// <summary>
    /// Fuクラスとその派生クラスのテスト
    /// </summary>
    public class FuTests
    {
        [Fact]
        public void Futei_値取得_20が返る()
        {
            // Arrange  
            var futei = Fu.Futei;

            // Act  
            var value = futei.Value;

            // Assert  
            Assert.Equal(20, value);
        }

        [Fact]
        public void Shuntsu_値取得_0が返る()
        {
            // Arrange  
            var shuntsu = Fu.Shuntsu;

            // Act  
            var value = shuntsu.Value;

            // Assert  
            Assert.Equal(0, value);
        }

        [Fact]
        public void MinkoChuchan_値取得_2が返る()
        {
            // Arrange  
            var minkoChuchan = Fu.MinkoChuchan;

            // Act  
            var value = minkoChuchan.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void MinkoYaochu_値取得_4が返る()
        {
            // Arrange  
            var minkoYaochu = Fu.MinkoYaochu;

            // Act  
            var value = minkoYaochu.Value;

            // Assert  
            Assert.Equal(4, value);
        }

        [Fact]
        public void AnkoChuchan_値取得_4が返る()
        {
            // Arrange  
            var ankoChuchan = Fu.AnkoChuchan;

            // Act  
            var value = ankoChuchan.Value;

            // Assert  
            Assert.Equal(4, value);
        }

        [Fact]
        public void AnkoYaochu_値取得_8が返る()
        {
            // Arrange  
            var ankoYaochu = Fu.AnkoYaochu;

            // Act  
            var value = ankoYaochu.Value;

            // Assert  
            Assert.Equal(8, value);
        }

        [Fact]
        public void MinkanChuchan_値取得_8が返る()
        {
            // Arrange  
            var minkanChuchan = Fu.MinkanChuchan;

            // Act  
            var value = minkanChuchan.Value;

            // Assert  
            Assert.Equal(8, value);
        }

        [Fact]
        public void MinkanYaochu_値取得_16が返る()
        {
            // Arrange  
            var minkanYaochu = Fu.MinkanYaochu;

            // Act  
            var value = minkanYaochu.Value;

            // Assert  
            Assert.Equal(16, value);
        }

        [Fact]
        public void AnkanChuchan_値取得_16が返る()
        {
            // Arrange  
            var ankanChuchan = Fu.AnkanChuchan;

            // Act  
            var value = ankanChuchan.Value;

            // Assert  
            Assert.Equal(16, value);
        }

        [Fact]
        public void AnkanYaochu_値取得_32が返る()
        {
            // Arrange  
            var ankanYaochu = Fu.AnkanYaochu;

            // Act  
            var value = ankanYaochu.Value;

            // Assert  
            Assert.Equal(32, value);
        }

        [Fact]
        public void JantoNumber_値取得_0が返る()
        {
            // Arrange  
            var jantoNumber = Fu.JantoNumber;

            // Act  
            var value = jantoNumber.Value;

            // Assert  
            Assert.Equal(0, value);
        }

        [Fact]
        public void JantoOtherWind_値取得_0が返る()
        {
            // Arrange  
            var jantoOtherWind = Fu.JantoOtherWind;

            // Act  
            var value = jantoOtherWind.Value;

            // Assert  
            Assert.Equal(0, value);
        }

        [Fact]
        public void JantouPlayerWind_値取得_2が返る()
        {
            // Arrange  
            var jantouPlayerWind = Fu.JantouPlayerWind;

            // Act  
            var value = jantouPlayerWind.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void JantouRoundWind_値取得_2が返る()
        {
            // Arrange  
            var jantouRoundWind = Fu.JantouRoundWind;

            // Act  
            var value = jantouRoundWind.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void JantouDragon_値取得_2が返る()
        {
            // Arrange  
            var jantouDragon = Fu.JantouDragon;

            // Act  
            var value = jantouDragon.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void WaitRyanmen_値取得_0が返る()
        {
            // Arrange  
            var waitRyanmen = Fu.WaitRyanmen;

            // Act  
            var value = waitRyanmen.Value;

            // Assert  
            Assert.Equal(0, value);
        }

        [Fact]
        public void WaitShanpon_値取得_0が返る()
        {
            // Arrange  
            var waitShanpon = Fu.WaitShanpon;

            // Act  
            var value = waitShanpon.Value;

            // Assert  
            Assert.Equal(0, value);
        }

        [Fact]
        public void WaitKanchan_値取得_2が返る()
        {
            // Arrange  
            var waitKanchan = Fu.WaitKanchan;

            // Act  
            var value = waitKanchan.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void WaitPenchan_値取得_2が返る()
        {
            // Arrange  
            var waitPenchan = Fu.WaitPenchan;

            // Act  
            var value = waitPenchan.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void WaitTanki_値取得_2が返る()
        {
            // Arrange  
            var waitTanki = Fu.WaitTanki;

            // Act  
            var value = waitTanki.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void MenzenFu_値取得_10が返る()
        {
            // Arrange  
            var menzenFu = Fu.MenzenFu;

            // Act  
            var value = menzenFu.Value;

            // Assert  
            Assert.Equal(10, value);
        }

        [Fact]
        public void TsumoFu_値取得_2が返る()
        {
            // Arrange  
            var tsumoFu = Fu.TsumoFu;

            // Act  
            var value = tsumoFu.Value;

            // Assert  
            Assert.Equal(2, value);
        }

        [Fact]
        public void FuteiOpenPinfu_値取得_30が返る()
        {
            // Arrange  
            var futeiOpenPinfu = Fu.FuteiOpenPinfu;

            // Act  
            var value = futeiOpenPinfu.Value;

            // Assert  
            Assert.Equal(30, value);
        }

        [Fact]
        public void Chiitoitsu_値取得_25が返る()
        {
            // Arrange  
            var chiitoitsu = Fu.Chiitoitsu;

            // Act  
            var value = chiitoitsu.Value;

            // Assert  
            Assert.Equal(25, value);
        }

        [Fact]
        public void ToString_フォーマット確認_正しい形式の文字列が返る()
        {
            // Arrange  
            var futei = Fu.Futei;
            var futeiOpenPinfu = Fu.FuteiOpenPinfu;
            var chiitoitsu = Fu.Chiitoitsu;
            var shuntsu = Fu.Shuntsu;
            var minkoChuchan = Fu.MinkoChuchan;
            var minkoYaochu = Fu.MinkoYaochu;
            var ankoChuchan = Fu.AnkoChuchan;
            var ankoYaochu = Fu.AnkoYaochu;
            var minkanChuchan = Fu.MinkanChuchan;
            var minkanYaochu = Fu.MinkanYaochu;
            var ankanChuchan = Fu.AnkanChuchan;
            var ankanYaochu = Fu.AnkanYaochu;
            var jantoNumber = Fu.JantoNumber;
            var jantoOtherWind = Fu.JantoOtherWind;
            var jantouPlayerWind = Fu.JantouPlayerWind;
            var jantouRoundWind = Fu.JantouRoundWind;
            var jantouDragon = Fu.JantouDragon;
            var waitRyanmen = Fu.WaitRyanmen;
            var waitShanpon = Fu.WaitShanpon;
            var waitKanchan = Fu.WaitKanchan;
            var waitPenchan = Fu.WaitPenchan;
            var waitTanki = Fu.WaitTanki;
            var menzenFu = Fu.MenzenFu;
            var tsumoFu = Fu.TsumoFu;

            // Act  
            var futeiString = futei.ToString();
            var futeiOpenPinfuString = futeiOpenPinfu.ToString();
            var chiitoitsuString = chiitoitsu.ToString();
            var shuntsuString = shuntsu.ToString();
            var minkoChuchanString = minkoChuchan.ToString();
            var minkoYaochuString = minkoYaochu.ToString();
            var ankoChuchanString = ankoChuchan.ToString();
            var ankoYaochuString = ankoYaochu.ToString();
            var minkanChuchanString = minkanChuchan.ToString();
            var minkanYaochuString = minkanYaochu.ToString();
            var ankanChuchanString = ankanChuchan.ToString();
            var ankanYaochuString = ankanYaochu.ToString();
            var jantoNumberString = jantoNumber.ToString();
            var jantoOtherWindString = jantoOtherWind.ToString();
            var jantouPlayerWindString = jantouPlayerWind.ToString();
            var jantouRoundWindString = jantouRoundWind.ToString();
            var jantouDragonString = jantouDragon.ToString();
            var waitRyanmenString = waitRyanmen.ToString();
            var waitShanponString = waitShanpon.ToString();
            var waitKanchanString = waitKanchan.ToString();
            var waitPenchanString = waitPenchan.ToString();
            var waitTankiString = waitTanki.ToString();
            var menzenFuString = menzenFu.ToString();
            var tsumoFuString = tsumoFu.ToString();

            // Assert  
            Assert.Equal("副底:20符", futeiString);
            Assert.Equal("副底(食い平和):30符", futeiOpenPinfuString);
            Assert.Equal("七対子:25符", chiitoitsuString);
            Assert.Equal("順子:0符", shuntsuString);
            Assert.Equal("中張牌の明刻:2符", minkoChuchanString);
            Assert.Equal("么九牌の明刻:4符", minkoYaochuString);
            Assert.Equal("中張牌の暗刻:4符", ankoChuchanString);
            Assert.Equal("么九牌の暗刻:8符", ankoYaochuString);
            Assert.Equal("中張牌の明槓:8符", minkanChuchanString);
            Assert.Equal("么九牌の明槓:16符", minkanYaochuString);
            Assert.Equal("中張牌の暗槓:16符", ankanChuchanString);
            Assert.Equal("么九牌の暗槓:32符", ankanYaochuString);
            Assert.Equal("数牌の雀頭:0符", jantoNumberString);
            Assert.Equal("客風の雀頭:0符", jantoOtherWindString);
            Assert.Equal("自風の雀頭:2符", jantouPlayerWindString);
            Assert.Equal("場風の雀頭:2符", jantouRoundWindString);
            Assert.Equal("三元牌の雀頭:2符", jantouDragonString);
            Assert.Equal("両面待ち:0符", waitRyanmenString);
            Assert.Equal("シャンポン待ち:0符", waitShanponString);
            Assert.Equal("カンチャン待ち:2符", waitKanchanString);
            Assert.Equal("ペンチャン待ち:2符", waitPenchanString);
            Assert.Equal("単騎待ち:2符", waitTankiString);
            Assert.Equal("門前加符:10符", menzenFuString);
            Assert.Equal("ツモ符:2符", tsumoFuString);
        }
    }
}