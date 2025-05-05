using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class RyuuiisouTests
{
    [Fact]
    public void Number_39を返す()
    {
        // Arrange
        var ryuuiisou = Yaku.Ryuuiisou;

        // Act
        var actual = ryuuiisou.Number;

        // Assert
        Assert.Equal(39, actual);
    }

    [Fact]
    public void Name_緑一色が返る()
    {
        // Arrange
        var ryuuiisou = Yaku.Ryuuiisou;

        // Act
        var actual = ryuuiisou.Name;

        // Assert
        Assert.Equal("緑一色", actual);
    }

    [Fact]
    public void HanOpen_13が返る()
    {
        // Arrange
        var ryuuiisou = Yaku.Ryuuiisou;

        // Act
        var actual = ryuuiisou.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var ryuuiisou = Yaku.Ryuuiisou;

        // Act
        var actual = ryuuiisou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var ryuuiisou = Yaku.Ryuuiisou;

        // Act
        var actual = ryuuiisou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_緑の牌のみの場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(sou: "222"), new(sou: "333"), new(sou: "444"), new(sou: "666"), new(honor: "rr")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ryuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_緑の牌のみで副露を含む場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(sou: "222"), new(sou: "333"), new(honor: "rr")]);
        var fuuroList = new FuuroList([new Pon(new(sou: "444")), new Chi(new(sou: "234"))]);

        // Act
        var actual = Ryuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_緑以外の牌が含まれる場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(sou: "222"), new(sou: "333"), new(sou: "444"), new(sou: "666"), new(sou: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ryuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_緑以外の牌が副露に含まれる場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(sou: "222"), new(sou: "333"), new(honor: "rr")]);
        var fuuroList = new FuuroList([new Pon(new(sou: "444")), new Chi(new(man: "123"))]);

        // Act
        var actual = Ryuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}