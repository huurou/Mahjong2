using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class IttsuuTests
{
    [Fact]
    public void Number_20を返す()
    {
        // Arrange
        var ittsuu = Yaku.Ittsuu;
        // Act
        var actual = ittsuu.Number;
        // Assert
        Assert.Equal(20, actual);
    }

    [Fact]
    public void Name_一気通貫を返す()
    {
        // Arrange
        var ittsuu = Yaku.Ittsuu;

        // Act
        var actual = ittsuu.Name;

        // Assert
        Assert.Equal("一気通貫", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var ittsuu = Yaku.Ittsuu;

        // Act
        var actual = ittsuu.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_2を返す()
    {
        // Arrange
        var ittsuu = Yaku.Ittsuu;

        // Act
        var actual = ittsuu.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var ittsuu = Yaku.Ittsuu;

        // Act
        var actual = ittsuu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_手牌のみで萬子の一気通貫_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(man: "789"), new(pin: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_手牌のみで筒子の一気通貫_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "123"), new(pin: "456"), new(pin: "789"), new(man: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_手牌のみで索子の一気通貫_成立する()
    {
        // Arrange
        var hand = new Hand([new(sou: "123"), new(sou: "456"), new(sou: "789"), new(man: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_手牌と副露で一気通貫_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(honor: "tt"), new(pin: "111")]);
        var fuuroList = new FuuroList([new Chi(new(man: "789"))]);

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_123も456も789も揃っているが異なる種類_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "456"), new(sou: "789"), new(man: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同一種類だが123と456と789ではない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "234"), new(man: "456"), new(man: "789"), new(pin: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_123と456と789が揃わない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "345"), new(man: "789"), new(pin: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_順子が3つない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(man: "111"), new(pin: "111"), new(honor: "tt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Ittsuu.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}