using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class SanshokudoukouTests
{
    [Fact]
    public void Valid_手牌内で三色同刻_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "333"), new(pin: "333"), new(sou: "333"), new(pin: "789"), new(man: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_手牌と副露で三色同刻_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "333"), new(pin: "333"), new(man: "55")]);
        var fuuroList = new FuuroList([new Pon(new(sou: "333"))]);

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槓子を含む三色同刻_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "333"), new(man: "55")]);
        var fuuroList = new FuuroList([
            new Pon(new(pin: "333")),
            new Daiminkan(new TileList(sou: "3333")),
        ]);

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_二色のみ_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "333"), new(pin: "333"), new(sou: "789"), new(pin: "789"), new(man: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_三色の同数字だが順子_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "123"), new(sou: "123"), new(pin: "789"), new(man: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}