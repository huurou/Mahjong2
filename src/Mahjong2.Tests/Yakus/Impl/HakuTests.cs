using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class HakuTests
{
    [Fact]
    public void Name_白が返る()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.Name;

        // Assert
        Assert.Equal("白", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_白の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Haku.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_白の槓子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234")]);
        var fuuroList = new FuuroList([new Daiminkan(new TileList(honor: "hhhh"))]);

        // Act
        var actual = Haku.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_白の刻子なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "ccc")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Haku.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}