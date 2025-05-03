using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class SanshokuTests
{
    [Fact]
    public void Name_三色同順が返る()
    {
        // Arrange
        var sanshoku = Yaku.Sanshoku;

        // Act
        var actual = sanshoku.Name;

        // Assert
        Assert.Equal("三色同順", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var sanshoku = Yaku.Sanshoku;

        // Act
        var actual = sanshoku.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_2が返る()
    {
        // Arrange
        var sanshoku = Yaku.Sanshoku;

        // Act
        var actual = sanshoku.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var sanshoku = Yaku.Sanshoku;

        // Act
        var actual = sanshoku.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_萬子筒子索子で同じ数の順子が揃う_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "123"), new(sou: "123"), new(man: "789"), new(pin: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshoku.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_萬子筒子索子で同じ数の順子が揃う_副露あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "123"), new(pin: "55"), new(man: "789")]);
        var fuuroList = new FuuroList([new Chi(new(sou: "123"))]);

        // Act
        var actual = Sanshoku.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_同じ数の順子が3種揃わない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "123"), new(sou: "456"), new(man: "789"), new(pin: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshoku.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同じ種類の牌のみ_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(man: "789"), new(man: "33"), new(pin: "11")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshoku.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_順子が3つない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "123"), new(man: "111"), new(sou: "111"), new(pin: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshoku.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}