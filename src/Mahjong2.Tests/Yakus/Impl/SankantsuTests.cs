using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class SankantsuTests
{
    [Fact]
    public void Number_25を返す()
    {
        // Arrange
        var sankantsu = Yaku.Sankantsu;

        // Act
        var actual = sankantsu.Number;

        // Assert
        Assert.Equal(25, actual);
    }

    [Fact]
    public void Name_三槓子が返る()
    {
        // Arrange
        var sankantsu = Yaku.Sankantsu;

        // Act
        var actual = sankantsu.Name;

        // Assert
        Assert.Equal("三槓子", actual);
    }

    [Fact]
    public void HanOpen_2が返る()
    {
        // Arrange
        var sankantsu = Yaku.Sankantsu;

        // Act
        var actual = sankantsu.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_2が返る()
    {
        // Arrange
        var sankantsu = Yaku.Sankantsu;

        // Act
        var actual = sankantsu.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var sankantsu = Yaku.Sankantsu;

        // Act
        var actual = sankantsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_槓子が3つある場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(pin: "234"),]);
        var fuuroList = new FuuroList([new Daiminkan(new(man: "5555")), new Ankan(new(pin: "2222")), new Daiminkan(new(sou: "8888"))]);

        // Act
        var actual = Sankantsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子が手牌と合わせて3つある場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "1111"), new(man: "456")]);
        var fuuroList = new FuuroList([new Daiminkan(new(pin: "2222")), new Daiminkan(new(sou: "8888"))]);

        // Act
        var actual = Sankantsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子が2つしかない場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "123"), new(pin: "456")]);
        var fuuroList = new FuuroList([new Daiminkan(new(pin: "2222")), new Daiminkan(new(sou: "8888"))]);

        // Act
        var actual = Sankantsu.Valid(hand, fuuroList);

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
        var actual = Sankantsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}