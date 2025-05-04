using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class TenhouTests
{
    [Fact]
    public void Number_48を返す()
    {
        // Arrange
        var tenhou = Yaku.Tenhou;

        // Act
        var actual = tenhou.Number;

        // Assert
        Assert.Equal(48, actual);
    }

    [Fact]
    public void Name_天和が返る()
    {
        // Arrange
        var tenhou = Yaku.Tenhou;

        // Act
        var actual = tenhou.Name;

        // Assert
        Assert.Equal("天和", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var tenhou = Yaku.Tenhou;

        // Act
        var actual = tenhou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var tenhou = Yaku.Tenhou;

        // Act
        var actual = tenhou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var tenhou = Yaku.Tenhou;

        // Act
        var actual = tenhou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_天和成立時_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsTenhou = true };

        // Act
        var actual = Tenhou.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_天和不成立時_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsTenhou = false };

        // Act
        var actual = Tenhou.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}