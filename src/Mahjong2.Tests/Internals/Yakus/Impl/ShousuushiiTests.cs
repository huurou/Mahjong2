using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class ShousuushiiTests
{
    [Fact]
    public void Number_37を返す()
    {
        // Arrange
        var shousuushii = new Shousuushii();

        // Act
        var actual = shousuushii.Number;

        // Assert
        Assert.Equal(37, actual);
    }

    [Fact]
    public void Name_小四喜が返る()
    {
        // Arrange
        var shousuushii = new Shousuushii();

        // Act
        var actual = shousuushii.Name;

        // Assert
        Assert.Equal("小四喜", actual);
    }

    [Fact]
    public void HanOpen_13が返る()
    {
        // Arrange
        var shousuushii = new Shousuushii();

        // Act
        var actual = shousuushii.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var shousuushii = new Shousuushii();

        // Act
        var actual = shousuushii.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var shousuushii = new Shousuushii();

        // Act
        var actual = shousuushii.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌の刻子3種と風牌の対子1種_手牌のみ_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(honor: "ttt"), new(honor: "sss"), new(honor: "nnn"), new(honor: "pp")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousuushii.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌の刻子3種と風牌の対子1種_副露あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(honor: "ttt"), new(honor: "pp")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "sss")), new Pon(new(honor: "nnn"))]);

        // Act
        var actual = Shousuushii.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌の刻子2種と槓子1種と風牌の対子1種_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(honor: "ttt"), new(honor: "pp")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "sss")), new Minkan(new(honor: "nnnn"))]);

        // Act
        var actual = Shousuushii.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌の刻子4種_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "ttt"), new(honor: "sss"), new(honor: "nnn"), new(honor: "ppp")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousuushii.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_風牌の刻子2種と風牌の対子1種_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(pin: "234"), new(honor: "ttt"), new(honor: "nnn"), new(honor: "pp")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousuushii.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_風牌以外の対子_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "ttt"), new(honor: "nnn"), new(honor: "sss"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Shousuushii.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}