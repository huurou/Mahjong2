using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChiihouTests
{
    [Fact]
    public void Name_地和が返る()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.Name;

        // Assert
        Assert.Equal("地和", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_地和成立時_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsChiihou = true };

        // Act
        var actual = Chiihou.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_地和不成立時_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsChiihou = false };

        // Act
        var actual = Chiihou.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}