using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Yakus.Impl;

public class DaisangenTests
{
    [Fact]
    public void Number_36を返す()
    {
        // Arrange
        var daisangen = new Daisangen();
        // Act
        var actual = daisangen.Number;
        // Assert
        Assert.Equal(36, actual);
    }

    [Fact]
    public void Name_大三元を返す()
    {
        // Arrange
        var daisangen = new Daisangen();

        // Act
        var actual = daisangen.Name;

        // Assert
        Assert.Equal("大三元", actual);
    }

    [Fact]
    public void HanOpen_13を返す()
    {
        // Arrange
        var daisangen = new Daisangen();

        // Act
        var actual = daisangen.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var daisangen = new Daisangen();

        // Act
        var actual = daisangen.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var daisangen = new Daisangen();

        // Act
        var actual = daisangen.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_白發中の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "hhh"), new(honor: "rrr"), new(honor: "ccc")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Daisangen.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_白發中の槓子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "hhh")]);
        var fuuroList = new FuuroList([
            new Ankan(new TileList(honor: "rrrr")),
            new Minkan(new TileList(honor: "cccc"))
        ]);

        // Act
        var actual = Daisangen.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_白發中の刻子と槓子の混合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "hhh"), new(honor: "rrr")]);
        var fuuroList = new FuuroList([
            new Minkan(new TileList(honor: "cccc"))
        ]);

        // Act
        var actual = Daisangen.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_二色の三元牌の刻子と雀頭_成立しない()
    {
        // Arrange
        var hand = new Hand([new(honor: "hh"), new(honor: "rrr"), new(honor: "ccc"), new(pin: "234"), new(sou: "234")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Daisangen.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_三元牌の刻子が一つだけ_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "hhh"), new(man: "234"), new(sou: "234"), new(pin: "456")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Daisangen.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}