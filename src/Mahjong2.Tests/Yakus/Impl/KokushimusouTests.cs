using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class KokushimusouTests
{
    [Fact]
    public void Name_国士無双が返る()
    {
        // Arrange
        var kokushimusou = Yaku.Kokushimusou;

        // Act
        var actual = kokushimusou.Name;

        // Assert
        Assert.Equal("国士無双", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var kokushimusou = Yaku.Kokushimusou;

        // Act
        var actual = kokushimusou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var kokushimusou = Yaku.Kokushimusou;

        // Act
        var actual = kokushimusou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var kokushimusou = Yaku.Kokushimusou;

        // Act
        var actual = kokushimusou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_老頭牌が重複_成立する()
    {
        // Arrange
        var tileList = new TileList(man: "119", pin: "19", sou: "19", honor: "tnsphrc");

        // Act
        var actual = Kokushimusou.Valid(tileList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌が重複_成立する()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");

        // Act
        var actual = Kokushimusou.Valid(tileList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_三元牌が重複_成立する()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "tnsphrcc");

        // Act
        var actual = Kokushimusou.Valid(tileList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_全ての么九牌が揃っていない_成立しない()
    {
        // Arrange
        var tileList = new TileList(man: "119", pin: "19", sou: "19", honor: "tnsphr");

        // Act
        var actual = Kokushimusou.Valid(tileList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_中張牌が含まれる_成立しない()
    {
        // Arrange
        var tileList = new TileList(man: "159", pin: "19", sou: "19", honor: "tnsphrc");

        // Act
        var actual = Kokushimusou.Valid(tileList);

        // Assert
        Assert.False(actual);
    }
}