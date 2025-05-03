using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class HonroutouTests
{
    [Fact]
    public void Number_22を返す()
    {
        // Arrange
        var honroutou = Yaku.Honrotou;
        // Act
        var actual = honroutou.Number;
        // Assert
        Assert.Equal(22, actual);
    }

    [Fact]
    public void Name_混老頭を返す()
    {
        // Arrange
        var honroutou = Yaku.Honrotou;

        // Act
        var actual = honroutou.Name;

        // Assert
        Assert.Equal("混老頭", actual);
    }

    [Fact]
    public void HanOpen_2を返す()
    {
        // Arrange
        var honroutou = Yaku.Honrotou;

        // Act
        var actual = honroutou.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_2を返す()
    {
        // Arrange
        var honroutou = Yaku.Honrotou;

        // Act
        var actual = honroutou.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var honroutou = Yaku.Honrotou;

        // Act
        var actual = honroutou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_么九牌のみ_副露なし_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "999"), new(pin: "111"), new(pin: "999"), new(honor: "東東")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Honroutou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_么九牌のみ_副露あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(honor: "東東東"), new(honor: "白白白")]);
        var fuuroList = new FuuroList([
            new Pon(new (man: "999")),
            new Daiminkan(new (honor: "中中中中")),
        ]);

        // Act
        var actual = Honroutou.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_中張牌がある_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "999"), new(pin: "234"), new(pin: "999"), new(honor: "東東")]);
        var fuuroList = new FuuroList();

        // Act
        var actual = Honroutou.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}