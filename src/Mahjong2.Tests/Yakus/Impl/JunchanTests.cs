// filepath: d:\source\repos\Mahjong2\src\Mahjong2.Tests\Yakus\Impl\JunchanTests.cs
using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class JunchanTests
{
    [Fact]
    public void Name_純全帯么九が返る()
    {
        // Arrange
        var junchan = Yaku.Junchan;

        // Act
        var actual = junchan.Name;

        // Assert
        Assert.Equal("純全帯么九", actual);
    }

    [Fact]
    public void HanOpen_2が返る()
    {
        // Arrange
        var junchan = Yaku.Junchan;

        // Act
        var actual = junchan.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_3が返る()
    {
        // Arrange
        var junchan = Yaku.Junchan;

        // Act
        var actual = junchan.HanClosed;

        // Assert
        Assert.Equal(3, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var junchan = Yaku.Junchan;

        // Act
        var actual = junchan.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_正常形_副露なし_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "789"), new(pin: "11"), new(sou: "789"), new(pin: "123")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Junchan.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_正常形_副露あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(pin: "11"), new(sou: "789")]);
        var fuuroList = new FuuroList([
            new Chi(new (man: "789")),
            new Pon(new (pin: "999")),
        ]);

        // Act
        var actual = Junchan.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_順子なし_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "999"), new(pin: "11"), new(sou: "999"), new(pin: "111")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Junchan.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_么九牌を含まない面子あり_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "11"), new(sou: "789"), new(pin: "123")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Junchan.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "789"), new(pin: "11"), new(sou: "123"), new(honor: "ttt")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Junchan.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}