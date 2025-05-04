using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class HatsuTests
{
    [Fact]
    public void Number_15を返す()
    {
        // Arrange
        var hatsu = Yaku.Hatsu;
        // Act
        var actual = hatsu.Number;
        // Assert
        Assert.Equal(15, actual);
    }

    [Fact]
    public void Name_發を返す()
    {
        // Arrange
        var hatsu = Yaku.Hatsu;

        // Act
        var actual = hatsu.Name;

        // Assert
        Assert.Equal("發", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var hatsu = Yaku.Hatsu;

        // Act
        var actual = hatsu.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var hatsu = Yaku.Hatsu;

        // Act
        var actual = hatsu.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var hatsu = Yaku.Hatsu;

        // Act
        var actual = hatsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_發の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "rrr")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Hatsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_發の槓子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234")]);
        var fuuroList = new FuuroList([new Daiminkan(new TileList(honor: "rrrr"))]);

        // Act
        var actual = Hatsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_發の刻子なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Hatsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}