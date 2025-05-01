using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class Kokushimusou13menmachiTests
{
    [Fact]
    public void Name_国士無双十三面待ちが返る()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.Name;

        // Assert
        Assert.Equal("国士無双十三面待ち", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_26が返る()
    {
        // Arrange
        var kokushimusou13menmachi = Yaku.Kokushimusou13menmachi;

        // Act
        var actual = kokushimusou13menmachi.HanClosed;

        // Assert
        Assert.Equal(26, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
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
        var hand = new Hand([new(man: "119", pin: "19", sou: "19", honor: "tnsphrc")]);
        var winTile = Tile.Man1;

        // Act
        var actual = Kokushimusou13menmachi.Valid(hand, winTile);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌が重複_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "19", pin: "19", sou: "19", honor: "ttnsphrc")]);
        var winTile = Tile.Ton;

        // Act
        var actual = Kokushimusou13menmachi.Valid(hand, winTile);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_三元牌が重複_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "19", pin: "19", sou: "19", honor: "tnsphrcc")]);
        var winTile = Tile.Chun;

        // Act
        var actual = Kokushimusou13menmachi.Valid(hand, winTile);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_和了牌が一枚しかない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "19", pin: "19", sou: "19", honor: "tnsphrc")]);
        var winTile = Tile.Man1;

        // Act
        var actual = Kokushimusou13menmachi.Valid(hand, winTile);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_国士無双ではない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "119", pin: "19", sou: "19", honor: "ttnsph")]);
        var winTile = Tile.Man1;

        // Act
        var actual = Kokushimusou13menmachi.Valid(hand, winTile);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_中張牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "159", pin: "19", sou: "19", honor: "tnsphrc")]);
        var winTile = Tile.Man5;

        // Act
        var actual = Kokushimusou13menmachi.Valid(hand, winTile);

        // Assert
        Assert.False(actual);
    }
}