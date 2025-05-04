using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class Kokushimusou13menmachiTests
{
    [Fact]
    public void Number_45を返す()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;
        // Act
        var actual = kokushimusou13menmachi.Number;
        // Assert
        Assert.Equal(45, actual);
    }

    [Fact]
    public void Name_国士無双十三面待ちを返す()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.Name;

        // Assert
        Assert.Equal("国士無双十三面待ち", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_26を返す()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.HanClosed;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_老頭牌が重複_成立する()
    {
        // Arrange
        var tileList = new TileList(man: "119", pin: "19", sou: "19", honor: "tnsphrc");
        var winTile = Tile.Man1;

        // Act
        var actual = Kokushimusou13menmachi.Valid(tileList, winTile);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌が重複_成立する()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = Tile.Ton;

        // Act
        var actual = Kokushimusou13menmachi.Valid(tileList, winTile);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_三元牌が重複_成立する()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "tnsphrcc");
        var winTile = Tile.Chun;

        // Act
        var actual = Kokushimusou13menmachi.Valid(tileList, winTile);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_和了牌が一枚しかない_成立しない()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "tnsphrc");
        var winTile = Tile.Man1;

        // Act
        var actual = Kokushimusou13menmachi.Valid(tileList, winTile);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_国士無双ではない_成立しない()
    {
        // Arrange
        var tileList = new TileList(man: "119", pin: "19", sou: "19", honor: "ttnsph");
        var winTile = Tile.Man1;

        // Act
        var actual = Kokushimusou13menmachi.Valid(tileList, winTile);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_中張牌が含まれる_成立しない()
    {
        // Arrange
        var tileList = new TileList(man: "159", pin: "19", sou: "19", honor: "tnsphrc");
        var winTile = Tile.Man5;

        // Act
        var actual = Kokushimusou13menmachi.Valid(tileList, winTile);

        // Assert
        Assert.False(actual);
    }
}