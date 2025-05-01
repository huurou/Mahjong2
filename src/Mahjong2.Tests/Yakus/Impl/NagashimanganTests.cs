using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class NagashimanganTests
{
    [Fact]
    public void Name_流し満貫が返る()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.Name;

        // Assert
        Assert.Equal("流し満貫", actual);
    }

    [Fact]
    public void HanOpen_5が返る()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.HanOpen;

        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void HanClosed_5が返る()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.HanClosed;

        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_流し満貫である場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsNagashimangan = true };

        // Act
        var actual = Nagashimangan.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_流し満貫でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsNagashimangan = false };

        // Act
        var actual = Nagashimangan.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}