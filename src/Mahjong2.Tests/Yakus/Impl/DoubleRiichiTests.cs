using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class DoubleRiichiTests
{
    [Fact]
    public void Number_2を返す()
    {
        // Arrange
        var doubleRiichi = Yaku.DoubleRiichi;
        // Act
        var actual = doubleRiichi.Number;
        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void Name_ダブル立直を返す()
    {
        // Arrange
        var doubleRiichi = Yaku.DoubleRiichi;

        // Act
        var actual = doubleRiichi.Name;

        // Assert
        Assert.Equal("ダブル立直", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var doubleRiichi = Yaku.DoubleRiichi;

        // Act
        var actual = doubleRiichi.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_2を返す()
    {
        // Arrange
        var doubleRiichi = Yaku.DoubleRiichi;

        // Act
        var actual = doubleRiichi.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var doubleRiichi = Yaku.DoubleRiichi;

        // Act
        var actual = doubleRiichi.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_ダブル立直のとき_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsDoubleRiichi = true };
        var fuuroList = new FuuroList();

        // Act
        var actual = DoubleRiichi.Valid(winSituation, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ダブル立直でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsDoubleRiichi = false };
        var fuuroList = new FuuroList();

        // Act
        var actual = DoubleRiichi.Valid(winSituation, fuuroList);

        // Assert
        Assert.False(actual);
    }
}