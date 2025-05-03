using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class RenhouTests
{
    [Fact]
    public void Name_人和を返す()
    {
        // Arrange
        var renhou = new Renhou();

        // Act
        var actual = renhou.Name;

        // Assert
        Assert.Equal("人和", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var renhou = new Renhou();

        // Act
        var actual = renhou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_5を返す()
    {
        // Arrange
        var renhou = new Renhou();

        // Act
        var actual = renhou.HanClosed;

        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var renhou = new Renhou();

        // Act
        var actual = renhou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_人和かつ役満扱いでない場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsRenhou = true };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = false };

        // Act
        var actual = Renhou.Valid(winSituation, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_人和だが役満扱いの場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsRenhou = true };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = true };

        // Act
        var actual = Renhou.Valid(winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_人和でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsRenhou = false };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = false };

        // Act
        var actual = Renhou.Valid(winSituation, gameRules);

        // Assert
        Assert.False(actual);
    }
}
