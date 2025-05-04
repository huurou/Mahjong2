using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class DaisuushiiDoubleTests
{
    [Fact]
    public void Number_44を返す()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();
        // Act
        var actual = daisuushiiDouble.Number;
        // Assert
        Assert.Equal(44, actual);
    }

    [Fact]
    public void Name_大四喜を返す()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.Name;

        // Assert
        Assert.Equal("大四喜", actual);
    }

    [Fact]
    public void HanOpen_26を返す()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.HanOpen;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void HanClosed_26を返す()
    {
        // Arrange
        var daisuushiiDouble = new DaisuushiiDouble();

        // Act
        var actual = daisuushiiDouble.HanClosed;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
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