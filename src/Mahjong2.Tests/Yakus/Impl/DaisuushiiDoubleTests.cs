using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class DaisuushiiDoubleTests
{
    [Fact]
    public void Name_大四喜が返る()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.Name;

        // Assert
        Assert.Equal("大四喜", actual);
    }

    [Fact]
    public void HanOpen_26が返る()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.HanOpen;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void HanClosed_26が返る()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.HanClosed;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ダブル役満有効_大四喜の条件を満たす_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(honor: "ttt"), new(honor: "sss"), new(honor: "ppp")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "nnn"))]);
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = DaisuushiiDouble.Valid(hand, fuuroList, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ダブル役満無効_大四喜の条件を満たす_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(honor: "ttt"), new(honor: "sss"), new(honor: "ppp")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "nnn"))]);
        var gameRules = new GameRules { DoubleYakumanEnabled = false };

        // Act
        var actual = DaisuushiiDouble.Valid(hand, fuuroList, gameRules);

        // Assert
        Assert.False(actual);
    }
}