using Mahjong2.Lib.Internals.Fus;

namespace Mahjong2.Tests.Internals.Fus
{
    /// <summary>
    /// Fuクラスとその派生クラスのテスト
    /// </summary>
    public class FuTests
    {
        [Theory]
        [InlineData(nameof(Fu.Futei), 1)]
        [InlineData(nameof(Fu.MenzenFu), 2)]
        [InlineData(nameof(Fu.ChiitoitsuFu), 3)]
        [InlineData(nameof(Fu.FuteiOpenPinfu), 4)]
        [InlineData(nameof(Fu.TsumoFu), 5)]
        [InlineData(nameof(Fu.WaitKanchan), 6)]
        [InlineData(nameof(Fu.WaitPenchan), 7)]
        [InlineData(nameof(Fu.WaitTanki), 8)]
        [InlineData(nameof(Fu.JantouPlayerWind), 9)]
        [InlineData(nameof(Fu.JantouRoundWind), 10)]
        [InlineData(nameof(Fu.JantouDragon), 11)]
        [InlineData(nameof(Fu.MinkoChuchan), 12)]
        [InlineData(nameof(Fu.MinkoYaochu), 13)]
        [InlineData(nameof(Fu.AnkoChuchan), 14)]
        [InlineData(nameof(Fu.AnkoYaochu), 15)]
        [InlineData(nameof(Fu.MinkanChuchan), 16)]
        [InlineData(nameof(Fu.MinkanYaochu), 17)]
        [InlineData(nameof(Fu.AnkanChuchan), 18)]
        [InlineData(nameof(Fu.AnkanYaochu), 19)]
        public void Fuクラス_番号取得_期待値を返す(string propertyName, int expectedValue)
        {
            // Arrange
            var fu = typeof(Fu).GetProperty(propertyName)?.GetValue(null) as Fu ?? throw new InvalidOperationException($"プロパティ {propertyName} が見つかりませんでした。");

            // Act
            var number = fu.Number;

            // Assert
            Assert.Equal(expectedValue, number);
        }

        [Theory]
        [InlineData(nameof(Fu.Futei), 20)]
        [InlineData(nameof(Fu.MinkoChuchan), 2)]
        [InlineData(nameof(Fu.MinkoYaochu), 4)]
        [InlineData(nameof(Fu.AnkoChuchan), 4)]
        [InlineData(nameof(Fu.AnkoYaochu), 8)]
        [InlineData(nameof(Fu.MinkanChuchan), 8)]
        [InlineData(nameof(Fu.MinkanYaochu), 16)]
        [InlineData(nameof(Fu.AnkanChuchan), 16)]
        [InlineData(nameof(Fu.AnkanYaochu), 32)]
        [InlineData(nameof(Fu.JantouPlayerWind), 2)]
        [InlineData(nameof(Fu.JantouRoundWind), 2)]
        [InlineData(nameof(Fu.JantouDragon), 2)]
        [InlineData(nameof(Fu.WaitKanchan), 2)]
        [InlineData(nameof(Fu.WaitPenchan), 2)]
        [InlineData(nameof(Fu.WaitTanki), 2)]
        [InlineData(nameof(Fu.MenzenFu), 10)]
        [InlineData(nameof(Fu.TsumoFu), 2)]
        [InlineData(nameof(Fu.FuteiOpenPinfu), 30)]
        [InlineData(nameof(Fu.ChiitoitsuFu), 25)]
        public void Fuクラス_値取得_期待値を返す(string propertyName, int expectedValue)
        {
            // Arrange
            var fu = typeof(Fu).GetProperty(propertyName)?.GetValue(null) as Fu ?? throw new InvalidOperationException($"プロパティ {propertyName} が見つかりませんでした。");

            // Act
            var value = fu.Value;

            // Assert
            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void ToString_フォーマット確認_正しい形式の文字列を返す()
        {
            // Arrange
            var futei = Fu.Futei;
            var futeiOpenPinfu = Fu.FuteiOpenPinfu;
            var chiitoitsu = Fu.ChiitoitsuFu;
            var minkoChuchan = Fu.MinkoChuchan;
            var minkoYaochu = Fu.MinkoYaochu;
            var ankoChuchan = Fu.AnkoChuchan;
            var ankoYaochu = Fu.AnkoYaochu;
            var minkanChuchan = Fu.MinkanChuchan;
            var minkanYaochu = Fu.MinkanYaochu;
            var ankanChuchan = Fu.AnkanChuchan;
            var ankanYaochu = Fu.AnkanYaochu;
            var jantouPlayerWind = Fu.JantouPlayerWind;
            var jantouRoundWind = Fu.JantouRoundWind;
            var jantouDragon = Fu.JantouDragon;
            var waitKanchan = Fu.WaitKanchan;
            var waitPenchan = Fu.WaitPenchan;
            var waitTanki = Fu.WaitTanki;
            var menzenFu = Fu.MenzenFu;
            var tsumoFu = Fu.TsumoFu;

            // Act
            var futeiString = futei.ToString();
            var futeiOpenPinfuString = futeiOpenPinfu.ToString();
            var chiitoitsuString = chiitoitsu.ToString();
            var minkoChuchanString = minkoChuchan.ToString();
            var minkoYaochuString = minkoYaochu.ToString();
            var ankoChuchanString = ankoChuchan.ToString();
            var ankoYaochuString = ankoYaochu.ToString();
            var minkanChuchanString = minkanChuchan.ToString();
            var minkanYaochuString = minkanYaochu.ToString();
            var ankanChuchanString = ankanChuchan.ToString();
            var ankanYaochuString = ankanYaochu.ToString();
            var jantouPlayerWindString = jantouPlayerWind.ToString();
            var jantouRoundWindString = jantouRoundWind.ToString();
            var jantouDragonString = jantouDragon.ToString();
            var waitKanchanString = waitKanchan.ToString();
            var waitPenchanString = waitPenchan.ToString();
            var waitTankiString = waitTanki.ToString();
            var menzenFuString = menzenFu.ToString();
            var tsumoFuString = tsumoFu.ToString();

            // Assert
            Assert.Equal("副底:20符", futeiString);
            Assert.Equal("副底(食い平和):30符", futeiOpenPinfuString);
            Assert.Equal("七対子:25符", chiitoitsuString);
            Assert.Equal("中張牌の明刻:2符", minkoChuchanString);
            Assert.Equal("么九牌の明刻:4符", minkoYaochuString);
            Assert.Equal("中張牌の暗刻:4符", ankoChuchanString);
            Assert.Equal("么九牌の暗刻:8符", ankoYaochuString);
            Assert.Equal("中張牌の明槓:8符", minkanChuchanString);
            Assert.Equal("么九牌の明槓:16符", minkanYaochuString);
            Assert.Equal("中張牌の暗槓:16符", ankanChuchanString);
            Assert.Equal("么九牌の暗槓:32符", ankanYaochuString);
            Assert.Equal("自風の雀頭:2符", jantouPlayerWindString);
            Assert.Equal("場風の雀頭:2符", jantouRoundWindString);
            Assert.Equal("三元牌の雀頭:2符", jantouDragonString);
            Assert.Equal("カンチャン待ち:2符", waitKanchanString);
            Assert.Equal("ペンチャン待ち:2符", waitPenchanString);
            Assert.Equal("単騎待ち:2符", waitTankiString);
            Assert.Equal("門前加符:10符", menzenFuString);
            Assert.Equal("ツモ符:2符", tsumoFuString);
        }
    }
}