using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class ToitoihouTests
{
    [Fact]
    public void Number_23を返す()
    {
        // Arrange
        var toitoihou = Yaku.Toitoihou;

        // Act
        var actual = toitoihou.Number;

        // Assert
        Assert.Equal(23, actual);
    }

    [Fact]
    public void Name_対々和が返る()
    {
        // Arrange
        var toitoihou = Yaku.Toitoihou;

        // Act
        var actual = toitoihou.Name;

        // Assert
        Assert.Equal("対々和", actual);
    }

    [Fact]
    public void HanOpen_2が返る()
    {
        // Arrange
        var toitoihou = Yaku.Toitoihou;

        // Act
        var actual = toitoihou.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_2が返る()
    {
        // Arrange
        var toitoihou = Yaku.Toitoihou;

        // Act
        var actual = toitoihou.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var toitoihou = Yaku.Toitoihou;

        // Act
        var actual = toitoihou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_刻子4つと雀頭_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(honor: "ttt"), new(honor: "hh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Toitoihou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子を含む刻子4つと雀頭_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(pin: "333"), new(sou: "333")]);
        var fuuroList = new FuuroList([new Daiminkan(new(honor: "tttt")), new Pon(new(honor: "ccc"))]);

        // Act
        var actual = Toitoihou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_順子があると_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "222"), new(sou: "333"), new(honor: "ttt"), new(honor: "hh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Toitoihou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_刻子が3つしかない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(man: "45"), new(honor: "hh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Toitoihou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}