using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class ShousangenTests
{
    [Fact]
    public void Number_28を返す()
    {
        // Arrange
        var shousangen = Yaku.Shousangen;

        // Act
        var actual = shousangen.Number;

        // Assert
        Assert.Equal(28, actual);
    }

    [Fact]
    public void Name_小三元が返る()
    {
        // Arrange
        var shousangen = Yaku.Shousangen;

        // Act
        var actual = shousangen.Name;

        // Assert
        Assert.Equal("小三元", actual);
    }

    [Fact]
    public void HanOpen_2が返る()
    {
        // Arrange
        var shousangen = Yaku.Shousangen;

        // Act
        var actual = shousangen.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_2が返る()
    {
        // Arrange
        var shousangen = Yaku.Shousangen;

        // Act
        var actual = shousangen.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var shousangen = Yaku.Shousangen;

        // Act
        var actual = shousangen.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_三元牌の対子と2組の刻子_手牌のみ_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(pin: "456"), new(honor: "hh"), new(honor: "rrr"), new(honor: "ccc")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousangen.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_三元牌の対子と2組の刻子_副露あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(pin: "456"), new(honor: "hh")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "rrr")), new Pon(new(honor: "ccc"))]);

        // Act
        var actual = Shousangen.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_対子が三元牌で手牌と副露に三元牌の刻子が1種ずつある場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(pin: "456"), new(honor: "hh"), new(honor: "rrr")]);
        var fuuroList = new FuuroList([new Daiminkan(new(honor: "cccc"))]);

        // Act
        var actual = Shousangen.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_三元牌の刻子が3組_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "hhh"), new(honor: "rrr"), new(honor: "ccc")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousangen.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_三元牌の刻子が1組と対子が1組_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(pin: "234"), new(pin: "567"), new(pin: "789"), new(honor: "hh")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "rrr"))]);

        // Act
        var actual = Shousangen.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_三元牌以外の対子_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(man: "234"), new(honor: "rrr"), new(honor: "ccc")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousangen.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}