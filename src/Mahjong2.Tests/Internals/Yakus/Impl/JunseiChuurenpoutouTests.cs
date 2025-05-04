using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class JunseiChuurenpoutouTests
{
    [Fact]
    public void Number_47を返す()
    {
        // Arrange
        var junseiChuurenpoutou = Yaku.JunseiChuurenpoutou;
        // Act
        var actual = junseiChuurenpoutou.Number;
        // Assert
        Assert.Equal(47, actual);
    }

    [Fact]
    public void Name_純正九蓮宝燈を返す()
    {
        // Arrange
        var junseiChuurenpoutou = Yaku.JunseiChuurenpoutou;

        // Act
        var actual = junseiChuurenpoutou.Name;

        // Assert
        Assert.Equal("純正九蓮宝燈", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var junseiChuurenpoutou = Yaku.JunseiChuurenpoutou;

        // Act
        var actual = junseiChuurenpoutou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_26を返す()
    {
        // Arrange
        var junseiChuurenpoutou = Yaku.JunseiChuurenpoutou;

        // Act
        var actual = junseiChuurenpoutou.HanClosed;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var junseiChuurenpoutou = Yaku.JunseiChuurenpoutou;

        // Act
        var actual = junseiChuurenpoutou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_純正九蓮形で1で和了_成立する()
    {
        // Arrange
        // 純正九蓮宝燈の形：1112345678999 + 1（和了牌）
        var hand = new Hand([new(man: "111"), new(man: "123"), new(man: "456"), new(man: "789"), new(man: "99")]);
        var winTile = Tile.Man1;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_純正九蓮形で9で和了_成立する()
    {
        // Arrange
        // 純正九蓮宝燈の形：1112345678999 + 9（和了牌）
        var hand = new Hand([new(pin: "11"), new(pin: "123"), new(pin: "456"), new(pin: "789"), new(pin: "999")]);
        var winTile = Tile.Pin9;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_純正九蓮形で5で和了_成立する()
    {
        // Arrange
        // 純正九蓮宝燈の形：1112345678999 + 5（和了牌）
        var hand = new Hand([new(sou: "111"), new(sou: "234"), new(sou: "55"), new(sou: "678"), new(sou: "999")]);
        var winTile = Tile.Sou5;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ダブル役満設定無効_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(man: "123"), new(man: "456"), new(man: "789"), new(man: "999")]);
        var winTile = Tile.Man1;
        var gameRules = new GameRules { DoubleYakumanEnabled = false }; // ダブル役満が無効

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_純正でない_成立しない()
    {
        // Arrange
        // 通常の九蓮宝燈の形（1112345678999）で純正ではない
        var hand = new Hand([new(man: "111"), new(man: "234"), new(man: "567"), new(man: "789"), new(man: "99")]);
        var winTile = Tile.Man2;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_複数のスートが混在_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "123"), new(man: "345"), new(man: "789"), new(pin: "99")]);
        var winTile = Tile.Man1;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "123"), new(man: "456"), new(man: "789"), new(honor: "tt")]);
        var winTile = Tile.Man1;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = JunseiChuurenpoutou.Valid(hand, winTile, gameRules);

        // Assert
        Assert.False(actual);
    }
}