using Mahjong2.Lib;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests;

public class MjYakuTests
{
    [Fact]
    public void ToMjYaku_通常役を内部表現に変換_正しく変換される()
    {
        // Arrange
        var yaku = new Pinfu();

        // Act
        var mjYaku = yaku.ToMjYaku();

        // Assert
        Assert.Equal(MjYaku.Pinfu, mjYaku);
    }

    [Fact]
    public void ToMjYaku_役満を内部表現に変換_正しく変換される()
    {
        // Arrange
        var yaku = new Daisangen();

        // Act
        var mjYaku = yaku.ToMjYaku();

        // Assert
        Assert.Equal(MjYaku.Daisangen, mjYaku);
    }

    [Fact]
    public void ToMjYaku_ドラを内部表現に変換_正しく変換される()
    {
        // Arrange
        var yaku = new Dora();

        // Act
        var mjYaku = yaku.ToMjYaku();

        // Assert
        Assert.Equal(MjYaku.Dora, mjYaku);
    }

    [Fact]
    public void MjYakuResult_役と翻数を保持_正しく取得できる()
    {
        // Arrange
        var yaku = MjYaku.Pinfu;
        var han = 1;

        // Act
        var result = new MjYakuResult(yaku, han);

        // Assert
        Assert.Equal(yaku, result.Yaku);
        Assert.Equal(han, result.Han);
    }

    [Fact]
    public void ToMjYaku_一翻役を内部表現に変換_正しく変換される()
    {
        // 一翻役のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new Riichi(), MjYaku.Riichi },
            { new Tsumo(), MjYaku.Tsumo },
            { new Pinfu(), MjYaku.Pinfu },
            { new Tanyao(), MjYaku.Tanyao },
            { new Iipeikou(), MjYaku.Iipeikou },
            { new Haku(), MjYaku.Haku },
            { new Hatsu(), MjYaku.Hatsu },
            { new Chun(), MjYaku.Chun },
            { new PlayerWind(), MjYaku.PlayerWind },
            { new RoundWind(), MjYaku.RoundWind }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_二翻役を内部表現に変換_正しく変換される()
    {
        // 二翻役のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new DoubleRiichi(), MjYaku.DoubleRiichi },
            { new Chankan(), MjYaku.Chankan },
            { new Rinshan(), MjYaku.Rinshan },
            { new Haitei(), MjYaku.Haitei },
            { new Houtei(), MjYaku.Houtei },
            { new Sanshoku(), MjYaku.Sanshoku },
            { new Ittsuu(), MjYaku.Ittsuu },
            { new Chanta(), MjYaku.Chanta },
            { new Honroutou(), MjYaku.Honroutou },
            { new Toitoihou(), MjYaku.Toitoihou },
            { new Sanankou(), MjYaku.Sanankou },
            { new Sankantsu(), MjYaku.Sankantsu },
            { new Sanshokudoukou(), MjYaku.Sanshokudoukou },
            { new Chiitoitsu(), MjYaku.Chiitoitsu },
            { new Shousangen(), MjYaku.Shousangen }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_三翻以上の役を内部表現に変換_正しく変換される()
    {
        // 三翻以上の役のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new Honitsu(), MjYaku.Honitsu },
            { new Junchan(), MjYaku.Junchan },
            { new Ryanpeikou(), MjYaku.Ryanpeikou },
            { new Chinitsu(), MjYaku.Chinitsu }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_役満種類をすべて内部表現に変換_正しく変換される()
    {
        // 役満のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new Kokushimusou(), MjYaku.Kokushimusou },
            { new Chuurenpoutou(), MjYaku.Chuurenpoutou },
            { new Suuankou(), MjYaku.Suuankou },
            { new Daisangen(), MjYaku.Daisangen },
            { new Shousuushii(), MjYaku.Shousuushii },
            { new Daisuushii(), MjYaku.Daisuushii },
            { new Ryuuiisou(), MjYaku.Ryuuiisou },
            { new Suukantsu(), MjYaku.Suukantsu },
            { new Tsuuiisou(), MjYaku.Tsuuiisou },
            { new Chinroutou(), MjYaku.Chinroutou },
            { new Daisharin(), MjYaku.Daisharin },
            { new Tenhou(), MjYaku.Tenhou },
            { new Chiihou(), MjYaku.Chiihou }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_特殊役満を内部表現に変換_正しく変換される()
    {
        // 特殊役満のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new DaisuushiiDouble(), MjYaku.DaisuushiiDouble },
            { new Kokushimusou13menmachi(), MjYaku.Kokushimusou13menmachi },
            { new SuuankouTanki(), MjYaku.SuuankouTanki },
            { new JunseiChuurenpoutou(), MjYaku.JunseiChuurenpoutou },
            { new RenhouYakuman(), MjYaku.RenhouYakuman }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_ドラ系を内部表現に変換_正しく変換される()
    {
        // ドラ系のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new Dora(), MjYaku.Dora },
            { new Uradora(), MjYaku.Uradora },
            { new Akadora(), MjYaku.Akadora }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_その他の特殊役を内部表現に変換_正しく変換される()
    {
        // その他の特殊役のペアをテスト
        var testCases = new Dictionary<Yaku, MjYaku>
        {
            { new Ippatsu(), MjYaku.Ippatsu },
            { new Nagashimangan(), MjYaku.Nagashimangan },
            { new Renhou(), MjYaku.Renhou }
        };

        foreach (var testCase in testCases)
        {
            // Act
            var mjYaku = testCase.Key.ToMjYaku();

            // Assert
            Assert.Equal(testCase.Value, mjYaku);
        }
    }

    [Fact]
    public void ToMjYaku_未実装の役で変換_例外がスローされる()
    {
        // Arrange
        var yaku = new DummyYaku();

        // Act && Assert
        var exception = Assert.Throws<InvalidOperationException>(() => yaku.ToMjYaku());

        Assert.Contains("不明な役です。", exception.Message);
    }

    record DummyYaku : Yaku
    {
        public override int Number { get; }
        public override string Name { get; } = "";
        public override int HanOpen { get; }
        public override int HanClosed { get; }
        public override bool IsYakuman { get; }
    }
}
