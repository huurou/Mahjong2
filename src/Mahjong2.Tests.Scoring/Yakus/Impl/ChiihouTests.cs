using Mahjong2.Lib.Scoring.Games;
using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class ChiihouTests
{
    [Fact]
    public void Number_49を返す()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;
        // Act
        var actual = chiihou.Number;
        // Assert
        Assert.Equal(49, actual);
    }

    [Fact]
    public void Name_地和を返す()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.Name;

        // Assert
        Assert.Equal("地和", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var chiihou = Yaku.Chiihou;

        // Act
        var actual = chiihou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
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