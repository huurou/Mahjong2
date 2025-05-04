using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class SuukantsuTests
{
    [Fact]
    public void Number_40を返す()
    {
        // Arrange
        var suukantsu = Yaku.Suukantsu;

        // Act
        var actual = suukantsu.Number;

        // Assert
        Assert.Equal(40, actual);
    }

    [Fact]
    public void Name_四槓子が返る()
    {
        // Arrange
        var suukantsu = Yaku.Suukantsu;

        // Act
        var actual = suukantsu.Name;

        // Assert
        Assert.Equal("四槓子", actual);
    }

    [Fact]
    public void HanOpen_13が返る()
    {
        // Arrange
        var suukantsu = Yaku.Suukantsu;

        // Act
        var actual = suukantsu.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var suukantsu = Yaku.Suukantsu;

        // Act
        var actual = suukantsu.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var suukantsu = Yaku.Suukantsu;

        // Act
        var actual = suukantsu.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子が4つある場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11")]);
        var fuuroList = new FuuroList([
            new Daiminkan(new (man: "5555")),
            new Ankan(new (pin: "2222")),
            new Daiminkan(new (sou: "8888")),
            new Ankan(new (honor: "tttt")),
        ]);

        // Act
        var actual = Suukantsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子が手牌と合わせて4つある場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "1111")]);
        var fuuroList = new FuuroList([
            new Daiminkan(new (pin: "2222")),
            new Daiminkan(new (sou: "8888")),
            new Ankan(new (honor: "hhhh")),
        ]);

        // Act
        var actual = Suukantsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子が3つしかない場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "123")]);
        var fuuroList = new FuuroList([
            new Daiminkan(new (pin: "2222")),
            new Daiminkan(new (sou: "8888")),
            new Ankan(new (honor: "nnnn")),
        ]);

        // Act
        var actual = Suukantsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_槓子が0個の場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "456"), new(sou: "789"), new(honor: "tt"), new(man: "111")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Suukantsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}