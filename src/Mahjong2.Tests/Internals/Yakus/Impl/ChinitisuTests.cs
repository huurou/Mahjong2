using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class ChinitisuTests
{
    [Fact]
    public void Number_32を返す()
    {
        // Arrange
        var chinitsu = Yaku.Chinitsu;
        // Act
        var actual = chinitsu.Number;
        // Assert
        Assert.Equal(32, actual);
    }

    [Fact]
    public void Name_清一色を返す()
    {
        // Arrange
        var chinitsu = Yaku.Chinitsu;

        // Act
        var actual = chinitsu.Name;

        // Assert
        Assert.Equal("清一色", actual);
    }

    [Fact]
    public void HanOpen_5を返す()
    {
        // Arrange
        var chinitsu = Yaku.Chinitsu;

        // Act
        var actual = chinitsu.HanOpen;

        // Assert
        Assert.Equal(5, actual);
    }

    [Fact]
    public void HanClosed_6を返す()
    {
        // Arrange
        var chinitsu = Yaku.Chinitsu;

        // Act
        var actual = chinitsu.HanClosed;

        // Assert
        Assert.Equal(6, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var chinitsu = Yaku.Chinitsu;

        // Act
        var actual = chinitsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同一スートの牌のみ_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123456789")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chinitsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_同一スートの牌と副露_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "12345")]);
        var fuuroList = new FuuroList(
        [
            new Chi(new TileList(man: "678")),
            new Pon(new TileList(man: "999"))
        ]);

        // Act
        var actual = Chinitsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_複数のスートが混在_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "456")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chinitsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "11123456789"), new(honor: "ttt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chinitsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}