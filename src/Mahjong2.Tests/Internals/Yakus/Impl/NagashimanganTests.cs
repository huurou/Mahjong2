using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class NagashimanganTests
{
    [Fact]
    public void Number_9を返す()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.Number;

        // Assert
        Assert.Equal(9, actual);
    }

    [Fact]
    public void Name_流し満貫を返す()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.Name;

        // Assert
        Assert.Equal("流し満貫", actual);
    }

    [Fact]
    public void HanOpen_5を返す()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.HanOpen;

        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void HanClosed_5を返す()
    {
        // Arrange
        var nagashimangan = Yaku.Nagashimangan;

        // Act
        var actual = nagashimangan.HanClosed;

        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
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