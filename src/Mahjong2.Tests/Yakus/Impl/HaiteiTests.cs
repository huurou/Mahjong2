using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class HaiteiTests
{
    [Fact]
    public void Name_海底撈月が返る()
    {
        // Arrange
        var haitei = Yaku.Haitei;

        // Act
        var actual = haitei.Name;

        // Assert
        Assert.Equal("海底撈月", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var haitei = Yaku.Haitei;

        // Act
        var actual = haitei.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var haitei = Yaku.Haitei;

        // Act
        var actual = haitei.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var haitei = Yaku.Haitei;

        // Act
        var actual = haitei.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_海底撈月である場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsHaitei = true };

        // Act
        var actual = Haitei.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_海底撈月でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsHaitei = false };

        // Act
        var actual = Haitei.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}