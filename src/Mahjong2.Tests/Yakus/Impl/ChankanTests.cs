using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChankanTests
{
    [Fact]
    public void Name_槍槓が返る()
    {
        // Arrange
        var chankan = Yaku.Chankan;

        // Act
        var actual = chankan.Name;

        // Assert
        Assert.Equal("槍槓", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var chankan = Yaku.Chankan;

        // Act
        var actual = chankan.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var chankan = Yaku.Chankan;
        // Act
        var actual = chankan.HanClosed;
        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var chankan = Yaku.Chankan;

        // Act
        var actual = chankan.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_槍槓の場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsChankan = true };

        // Act
        var actual = Chankan.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槍槓でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsChankan = false };

        // Act
        var actual = Chankan.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}