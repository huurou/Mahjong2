using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChunTests
{
    [Fact]
    public void Name_中が返る()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.Name;

        // Assert
        Assert.Equal("中", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var chun = Yaku.Chun;

        // Act
        var actual = chun.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
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
        var fuuroList = new FuuroList([new Daiminkan(new TileList(honor: "cccc"))]);

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