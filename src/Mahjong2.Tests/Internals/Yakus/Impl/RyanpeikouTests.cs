using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class RyanpeikouTests
{
    [Fact]
    public void Number_31を返す()
    {
        // Arrange
        var ryanpeikou = Yaku.Ryanpeikou;

        // Act
        var actual = ryanpeikou.Number;

        // Assert
        Assert.Equal(31, actual);
    }

    [Fact]
    public void Name_二盃口が返る()
    {
        // Arrange
        var ryanpeikou = Yaku.Ryanpeikou;

        // Act
        var actual = ryanpeikou.Name;

        // Assert
        Assert.Equal("二盃口", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var ryanpeikou = Yaku.Ryanpeikou;

        // Act
        var actual = ryanpeikou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_3が返る()
    {
        // Arrange
        var ryanpeikou = Yaku.Ryanpeikou;

        // Act
        var actual = ryanpeikou.HanClosed;

        // Assert
        Assert.Equal(3, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var ryanpeikou = Yaku.Ryanpeikou;

        // Act
        var actual = ryanpeikou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同じ順子が2組あり_面前の場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "123"), new(pin: "456"), new(pin: "456"), new(sou: "11")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ryanpeikou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_同じ順子が2組未満_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "123"), new(pin: "456"), new(pin: "678"), new(sou: "11")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ryanpeikou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同じ順子が2組あるが_副露がある場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "123"), new(pin: "456"), new(sou: "11")]);
        var fuuroList = new FuuroList([new Chi(new(pin: "456"))]);

        // Act
        var actual = Ryanpeikou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同じスーツの連続した順子_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "234"), new(pin: "123"), new(pin: "234"), new(sou: "11")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ryanpeikou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}