using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class HakuTests
{
    [Fact]
    public void Number_14を返す()
    {
        // Arrange
        var haku = Yaku.Haku;
        // Act
        var actual = haku.Number;
        // Assert
        Assert.Equal(14, actual);
    }

    [Fact]
    public void Name_白を返す()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.Name;

        // Assert
        Assert.Equal("白", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var haku = Yaku.Haku;

        // Act
        var actual = haku.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
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
        var fuuroList = new FuuroList([new Minkan(new TileList(honor: "hhhh"))]);

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