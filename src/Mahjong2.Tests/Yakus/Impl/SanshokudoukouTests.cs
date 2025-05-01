using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class SanshokudoukouTests
{
    [Fact]
    public void Name_三色同刻が返る()
    {
        // Arrange
        var sanshokudoukou = Yaku.Sanshokudoukou;

        // Act
        var actual = sanshokudoukou.Name;

        // Assert
        Assert.Equal("三色同刻", actual);
    }

    [Fact]
    public void HanOpen_2が返る()
    {
        // Arrange
        var sanshokudoukou = Yaku.Sanshokudoukou;

        // Act
        var actual = sanshokudoukou.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_2が返る()
    {
        // Arrange
        var sanshokudoukou = Yaku.Sanshokudoukou;

        // Act
        var actual = sanshokudoukou.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var sanshokudoukou = Yaku.Sanshokudoukou;

        // Act
        var actual = sanshokudoukou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

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
            new Daiminkan(new (sou: "3333")),
        ]);

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_異なる数字の三色同刻_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "777"), new(pin: "777"), new(man: "55")]);
        var fuuroList = new FuuroList([
            new Ankan(new TileList(sou: "7777")),
            new Pon(new(pin: "222")),
        ]);

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_刻子が3つあるが三色同刻ではない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "333"), new(pin: "555"), new(sou: "777"), new(man: "789"), new(man: "22")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
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

    [Fact]
    public void Valid_刻子が3つない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "333"), new(pin: "333"), new(sou: "123"), new(pin: "789"), new(man: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_刻子3つ_萬子がない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "222"), new(pin: "333"), new(sou: "333"), new(pin: "789"), new(man: "55")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Sanshokudoukou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);

    }
}