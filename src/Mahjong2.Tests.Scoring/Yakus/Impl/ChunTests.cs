using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class ChunTests
{
    [Fact]
    public void Number_16を返す()
    {
        // Arrange
        var chun = Yaku.Chun;
        // Act
        var actual = chun.Number;
        // Assert
        Assert.Equal(16, actual);
    }

    [Fact]
    public void Name_中を返す()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.Name;

        // Assert
        Assert.Equal("中", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_中の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "ccc")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chun.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_中の槓子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234")]);
        var fuuroList = new FuuroList([new Minkan(new TileList(honor: "cccc"))]);

        // Act
        var actual = Chun.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_中の刻子なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chun.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}