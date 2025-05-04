using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class IipeikouTests
{
    [Fact]
    public void Number_13を返す()
    {
        // Arrange
        var iipeikou = Yaku.Iipeikou;
        // Act
        var actual = iipeikou.Number;
        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void Name_一盃口を返す()
    {
        // Arrange
        var iipeikou = Yaku.Iipeikou;

        // Act
        var actual = iipeikou.Name;

        // Assert
        Assert.Equal("一盃口", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var iipeikou = Yaku.Iipeikou;

        // Act
        var actual = iipeikou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var iipeikou = Yaku.Iipeikou;

        // Act
        var actual = iipeikou.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var iipeikou = Yaku.Iipeikou;

        // Act
        var actual = iipeikou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同一順子が2つあり面前の場合_成立する()
    {
        // Arrange
        var hand = new Hand([
            new(man: "123"), // 同じ順子1つ目
            new(man: "123"), // 同じ順子2つ目
            new(pin: "456"),
            new(sou: "789"),
            new(honor: "tt"),
        ]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Iipeikou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_順子が2つあっても異なる順子の場合_成立しない()
    {
        // Arrange
        var hand = new Hand([
            new(man: "123"),
            new(man: "456"),
            new(pin: "789"),
            new(sou: "123"),
            new(honor: "tt"),
        ]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Iipeikou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同一順子が2つあっても鳴きがある場合_成立しない()
    {
        // Arrange
        var hand = new Hand([
            new(man: "123"),
            new(man: "123"),
            new(pin: "456"),
            new(honor: "tt"),
        ]);
        // 鳴きあり
        var fuuroList = new FuuroList([new Pon(new(sou: "999"))]);

        // Act
        var actual = Iipeikou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_順子が含まれていない場合_成立しない()
    {
        // Arrange
        var hand = new Hand([
            new(man: "111"),
            new(man: "222"),
            new(pin: "333"),
            new(sou: "444"),
            new(honor: "tt"),
        ]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Iipeikou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}