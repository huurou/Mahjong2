using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class HonitsuTests
{
    [Fact]
    public void Name_混一色が返る()
    {
        // Arrange
        var honitsu = Yaku.Honitsu;

        // Act
        var actual = honitsu.Name;

        // Assert
        Assert.Equal("混一色", actual);
    }

    [Fact]
    public void HanOpen_2が返る()
    {
        // Arrange
        var honitsu = Yaku.Honitsu;

        // Act
        var actual = honitsu.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_3が返る()
    {
        // Arrange
        var honitsu = Yaku.Honitsu;

        // Act
        var actual = honitsu.HanClosed;

        // Assert
        Assert.Equal(3, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var honitsu = Yaku.Honitsu;

        // Act
        var actual = honitsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_萬子と字牌_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(man: "789"), new(man: "99"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Honitsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_筒子と字牌_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(pin: "456"), new(pin: "789"), new(pin: "99")]);
        var fuuroList = new FuuroList([new Daiminkan(new TileList(honor: "hhhh"))]);

        // Act
        var actual = Honitsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_索子と字牌_成立する()
    {
        // Arrange
        var hand = new Hand([new(sou: "11"), new(sou: "456"), new(sou: "789")]);
        var fuuroList = new FuuroList([
            new Pon(new (honor: "ccc")),
            new Daiminkan(new (sou: "1111")),
        ]);

        // Act
        var actual = Honitsu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_複数の数牌_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "456"), new(sou: "789"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Honitsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(man: "789"), new(man: "999"), new(man: "11")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Honitsu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}