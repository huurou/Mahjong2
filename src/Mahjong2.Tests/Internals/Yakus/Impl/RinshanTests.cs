using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class RinshanTests
{
    [Fact]
    public void Number_6を返す()
    {
        // Arrange
        var rinshan = Yaku.Rinshan;

        // Act
        var actual = rinshan.Number;

        // Assert
        Assert.Equal(6, actual);
    }

    [Fact]
    public void Name_嶺上開花が返る()
    {
        // Arrange
        var rinshan = Yaku.Rinshan;

        // Act
        var actual = rinshan.Name;

        // Assert
        Assert.Equal("嶺上開花", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var rinshan = Yaku.Rinshan;

        // Act
        var actual = rinshan.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var rinshan = Yaku.Rinshan;

        // Act
        var actual = rinshan.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var rinshan = Yaku.Rinshan;

        // Act
        var actual = rinshan.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_嶺上開花である場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsRinshan = true };

        // Act
        var actual = Rinshan.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_嶺上開花でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsRinshan = false };

        // Act
        var actual = Rinshan.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}