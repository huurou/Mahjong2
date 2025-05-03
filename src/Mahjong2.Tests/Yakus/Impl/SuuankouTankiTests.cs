using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class SuuankouTankiTests
{
    [Fact]
    public void Name_四暗刻単騎待ちを返す()
    {
        // Arrange
        var suuankouTanki = new SuuankouTanki();

        // Act
        var actual = suuankouTanki.Name;

        // Assert
        Assert.Equal("四暗刻単騎", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var suuankouTanki = new SuuankouTanki();

        // Act
        var actual = suuankouTanki.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_26を返す()
    {
        // Arrange
        var suuankouTanki = new SuuankouTanki();

        // Act
        var actual = suuankouTanki.HanClosed;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var suuankouTanki = new SuuankouTanki();

        // Act
        var actual = suuankouTanki.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ダブル役満有効で四暗刻が成立しアガリ牌が雀頭_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(pin: "444"), new(sou: "55")]);
        var winGroup = new TileList(sou: "55");
        var winTile = winGroup[0]; // 雀頭の牌を取得
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = SuuankouTanki.Valid(hand, winGroup, winTile, fuuroList, winSituation, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ダブル役満無効_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(pin: "444"), new(sou: "55")]);
        var winGroup = new TileList(sou: "55");
        var winTile = winGroup[0]; // 雀頭の牌を取得
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { DoubleYakumanEnabled = false };

        // Act
        var actual = SuuankouTanki.Valid(hand, winGroup, winTile, fuuroList, winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_四暗刻が成立しない_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(man: "456"), new(sou: "55")]);
        var winGroup = new TileList(sou: "55");
        var winTile = winGroup[0]; // 雀頭の牌を取得
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = SuuankouTanki.Valid(hand, winGroup, winTile, fuuroList, winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_アガリ牌が雀頭でない_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(pin: "444"), new(sou: "55")]);
        var winGroup = new TileList(pin: "444");
        var winTile = winGroup[0]; // 暗刻の牌を取得
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = SuuankouTanki.Valid(hand, winGroup, winTile, fuuroList, winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }
}