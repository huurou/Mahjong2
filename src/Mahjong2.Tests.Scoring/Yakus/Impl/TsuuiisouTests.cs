using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class TsuuiisouTests
{
    [Fact]
    public void Number_41を返す()
    {
        // Arrange
        var tsuuiisou = Yaku.Tsuuiisou;

        // Act
        var actual = tsuuiisou.Number;

        // Assert
        Assert.Equal(41, actual);
    }

    [Fact]
    public void Name_字一色が返る()
    {
        // Arrange
        var tsuuiisou = Yaku.Tsuuiisou;

        // Act
        var actual = tsuuiisou.Name;

        // Assert
        Assert.Equal("字一色", actual);
    }

    [Fact]
    public void HanOpen_13が返る()
    {
        // Arrange
        var tsuuiisou = Yaku.Tsuuiisou;

        // Act
        var actual = tsuuiisou.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var tsuuiisou = Yaku.Tsuuiisou;

        // Act
        var actual = tsuuiisou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var tsuuiisou = Yaku.Tsuuiisou;

        // Act
        var actual = tsuuiisou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_字牌のみの場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(honor: "ttt"), new(honor: "sss"), new(honor: "ppp"), new(honor: "hhh"), new(honor: "rr")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Tsuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_字牌のみで副露を含む場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(honor: "ttt"), new(honor: "hhh"), new(honor: "rr")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "sss")), new Pon(new(honor: "ppp"))]);

        // Act
        var actual = Tsuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_字牌以外が含まれる場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(honor: "ttt"), new(honor: "sss"), new(honor: "ppp"), new(man: "123"), new(honor: "rr")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Tsuuiisou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}