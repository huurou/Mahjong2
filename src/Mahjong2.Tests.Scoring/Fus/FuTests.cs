using Mahjong2.Lib.Scoring.Fus;

namespace Mahjong2.Tests.Scoring.Fus
{
    /// <summary>
    /// Fuクラスとその派生クラスのテスト
    /// </summary>
    public class FuTests
    {
        [Theory]
        [InlineData(nameof(Fu.FuteiFu), 1)]
        [InlineData(nameof(Fu.MenzenFu), 2)]
        [InlineData(nameof(Fu.ChiitoitsuFu), 3)]
        [InlineData(nameof(Fu.FuteiOpenPinfuFu), 4)]
        [InlineData(nameof(Fu.TsumoFu), 5)]
        [InlineData(nameof(Fu.WaitKanchanFu), 6)]
        [InlineData(nameof(Fu.WaitPenchanFu), 7)]
        [InlineData(nameof(Fu.WaitTankiFu), 8)]
        [InlineData(nameof(Fu.JantouPlayerWindFu), 9)]
        [InlineData(nameof(Fu.JantouRoundWindFu), 10)]
        [InlineData(nameof(Fu.JantouDragonFu), 11)]
        [InlineData(nameof(Fu.MinkoChuchanFu), 12)]
        [InlineData(nameof(Fu.MinkoYaochuFu), 13)]
        [InlineData(nameof(Fu.AnkoChuchanFu), 14)]
        [InlineData(nameof(Fu.AnkoYaochuFu), 15)]
        [InlineData(nameof(Fu.MinkanChuchanFu), 16)]
        [InlineData(nameof(Fu.MinkanYaochuFu), 17)]
        [InlineData(nameof(Fu.AnkanChuchanFu), 18)]
        [InlineData(nameof(Fu.AnkanYaochuFu), 19)]
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
        [InlineData(nameof(Fu.FuteiFu), 20)]
        [InlineData(nameof(Fu.MinkoChuchanFu), 2)]
        [InlineData(nameof(Fu.MinkoYaochuFu), 4)]
        [InlineData(nameof(Fu.AnkoChuchanFu), 4)]
        [InlineData(nameof(Fu.AnkoYaochuFu), 8)]
        [InlineData(nameof(Fu.MinkanChuchanFu), 8)]
        [InlineData(nameof(Fu.MinkanYaochuFu), 16)]
        [InlineData(nameof(Fu.AnkanChuchanFu), 16)]
        [InlineData(nameof(Fu.AnkanYaochuFu), 32)]
        [InlineData(nameof(Fu.JantouPlayerWindFu), 2)]
        [InlineData(nameof(Fu.JantouRoundWindFu), 2)]
        [InlineData(nameof(Fu.JantouDragonFu), 2)]
        [InlineData(nameof(Fu.WaitKanchanFu), 2)]
        [InlineData(nameof(Fu.WaitPenchanFu), 2)]
        [InlineData(nameof(Fu.WaitTankiFu), 2)]
        [InlineData(nameof(Fu.MenzenFu), 10)]
        [InlineData(nameof(Fu.TsumoFu), 2)]
        [InlineData(nameof(Fu.FuteiOpenPinfuFu), 30)]
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
            var futei = Fu.FuteiFu;
            var futeiOpenPinfu = Fu.FuteiOpenPinfuFu;
            var chiitoitsu = Fu.ChiitoitsuFu;
            var minkoChuchan = Fu.MinkoChuchanFu;
            var minkoYaochu = Fu.MinkoYaochuFu;
            var ankoChuchan = Fu.AnkoChuchanFu;
            var ankoYaochu = Fu.AnkoYaochuFu;
            var minkanChuchan = Fu.MinkanChuchanFu;
            var minkanYaochu = Fu.MinkanYaochuFu;
            var ankanChuchan = Fu.AnkanChuchanFu;
            var ankanYaochu = Fu.AnkanYaochuFu;
            var jantouPlayerWind = Fu.JantouPlayerWindFu;
            var jantouRoundWind = Fu.JantouRoundWindFu;
            var jantouDragon = Fu.JantouDragonFu;
            var waitKanchan = Fu.WaitKanchanFu;
            var waitPenchan = Fu.WaitPenchanFu;
            var waitTanki = Fu.WaitTankiFu;
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