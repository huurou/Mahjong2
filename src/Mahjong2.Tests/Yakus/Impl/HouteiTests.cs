using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class HouteiTests
{
    [Fact]
    public void Number_8を返す()
    {
        // Arrange
        var houtei = Yaku.Houtei;
        // Act
        var actual = houtei.Number;
        // Assert
        Assert.Equal(8, actual);
    }

    [Fact]
    public void Name_河底撈魚を返す()
    {
        // Arrange
        var houtei = Yaku.Houtei;

        // Act
        var actual = houtei.Name;

        // Assert
        Assert.Equal("河底撈魚", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var houtei = Yaku.Houtei;

        // Act
        var actual = houtei.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var houtei = Yaku.Houtei;

        // Act
        var actual = houtei.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var houtei = Yaku.Houtei;

        // Act
        var actual = houtei.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_河底撈魚である場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsHoutei = true };

        // Act
        var actual = Houtei.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_河底撈魚でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsHoutei = false };

        // Act
        var actual = Houtei.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}