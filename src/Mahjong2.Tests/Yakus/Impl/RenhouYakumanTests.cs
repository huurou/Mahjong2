using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class RenhouYakumanTests
{
    [Fact]
    public void Name_人和を返す()
    {
        // Arrange
        var renhouYakuman = new RenhouYakuman();

        // Act
        var actual = renhouYakuman.Name;

        // Assert
        Assert.Equal("人和", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var renhouYakuman = new RenhouYakuman();

        // Act
        var actual = renhouYakuman.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var renhouYakuman = new RenhouYakuman();

        // Act
        var actual = renhouYakuman.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var renhouYakuman = new RenhouYakuman();

        // Act
        var actual = renhouYakuman.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_人和かつ役満扱いの場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsRenhou = true };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = true };

        // Act
        var actual = RenhouYakuman.Valid(winSituation, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_人和だが役満扱いでない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsRenhou = true };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = false };

        // Act
        var actual = RenhouYakuman.Valid(winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_人和でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsRenhou = false };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = true };

        // Act
        var actual = RenhouYakuman.Valid(winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }
}