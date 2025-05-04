using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChantaTests
{
    [Fact]
    public void Number_21を返す()
    {
        // Arrange
        var chanta = Yaku.Chanta;
        // Act
        var actual = chanta.Number;
        // Assert
        Assert.Equal(21, actual);
    }

    [Fact]
    public void Name_混全帯么九を返す()
    {
        // Arrange
        var chanta = Yaku.Chanta;

        // Act
        var actual = chanta.Name;

        // Assert
        Assert.Equal("混全帯么九", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var chanta = Yaku.Chanta;

        // Act
        var actual = chanta.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_2を返す()
    {
        // Arrange
        var chanta = Yaku.Chanta;

        // Act
        var actual = chanta.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var chanta = Yaku.Chanta;

        // Act
        var actual = chanta.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_正常形_副露なし_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "789"), new(pin: "11"), new(sou: "789"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chanta.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_正常形_副露あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "11"), new(sou: "789")]);
        var fuuroList = new FuuroList([new Chi(new(man: "789")), new Pon(new(honor: "hhh"))]);

        // Act
        var actual = Chanta.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_順子なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "999"), new(pin: "11"), new(sou: "999"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chanta.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_么九牌を含まない面子あり_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "11"), new(sou: "789"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chanta.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_么九牌のみで字牌なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "789"), new(pin: "11"), new(sou: "123"), new(sou: "789")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chanta.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌のみで么九牌なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(honor: "ttt"), new(honor: "nnn"), new(honor: "sss"), new(honor: "ppp"), new(honor: "hh")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Chanta.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}