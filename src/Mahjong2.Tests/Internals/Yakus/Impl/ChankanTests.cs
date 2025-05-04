using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class ChankanTests
{
    [Fact]
    public void Number_5を返す()
    {
        // Arrange
        var chankan = Yaku.Chankan;
        // Act
        var actual = chankan.Number;
        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void Name_槍槓を返す()
    {
        // Arrange
        var chankan = Yaku.Chankan;

        // Act
        var actual = chankan.Name;

        // Assert
        Assert.Equal("槍槓", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var chankan = Yaku.Chankan;

        // Act
        var actual = chankan.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var chankan = Yaku.Chankan;
        // Act
        var actual = chankan.HanClosed;
        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
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