using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChinroutouTests
{
    [Fact]
    public void Number_42を返す()
    {
        // Arrange
        var chinroutou = new Chinroutou();
        // Act
        var actual = chinroutou.Number;
        // Assert
        Assert.Equal(42, actual);
    }

    [Fact]
    public void Name_清老頭を返す()
    {
        // Arrange
        var chinroutou = new Chinroutou();

        // Act
        var actual = chinroutou.Name;

        // Assert
        Assert.Equal("清老頭", actual);
    }

    [Fact]
    public void HanOpen_13を返す()
    {
        // Arrange
        var chinroutou = new Chinroutou();

        // Act
        var actual = chinroutou.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var chinroutou = new Chinroutou();

        // Act
        var actual = chinroutou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var chinroutou = new Chinroutou();

        // Act
        var actual = chinroutou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_全ての牌が老頭牌_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "999"), new(sou: "11")]);
        var fuuroList = new FuuroList([new Pon(new(sou: "999")), new Pon(new(man: "999"))]);

        // Act
        var actual = Chinroutou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_中張牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "999"), new(sou: "11")]);
        var fuuroList = new FuuroList([new Pon(new(sou: "555")), new Pon(new(man: "999"))]);

        // Act
        var actual = Chinroutou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "999"), new(sou: "11")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "ccc")), new Pon(new(man: "999"))]);

        // Act
        var actual = Chinroutou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}