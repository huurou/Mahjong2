using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class ChuurenpoutouTests
{
    [Fact]
    public void Number_34を返す()
    {
        // Arrange
        var chuurenpoutou = Yaku.Chuurenpoutou;
        // Act
        var actual = chuurenpoutou.Number;
        // Assert
        Assert.Equal(34, actual);
    }

    [Fact]
    public void Name_九蓮宝燈を返す()
    {
        // Arrange
        var chuurenpoutou = Yaku.Chuurenpoutou;

        // Act
        var actual = chuurenpoutou.Name;

        // Assert
        Assert.Equal("九蓮宝燈", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var chuurenpoutou = Yaku.Chuurenpoutou;

        // Act
        var actual = chuurenpoutou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var chuurenpoutou = Yaku.Chuurenpoutou;

        // Act
        var actual = chuurenpoutou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var chuurenpoutou = Yaku.Chuurenpoutou;

        // Act
        var actual = chuurenpoutou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_同一スートで1112345678999と任意の数牌_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "234"), new(man: "567"), new(man: "88"), new(man: "999")]);

        // Act
        var actual = Chuurenpoutou.Valid(hand);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_同一スートで1112345678999と任意の数牌_別パターン_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "111"), new(pin: "234"), new(pin: "567"), new(pin: "789"), new(pin: "99")]);

        // Act
        var actual = Chuurenpoutou.Valid(hand);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_複数のスートが混在_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "234"), new(man: "567"), new(man: "88"), new(pin: "999")]);

        // Act
        var actual = Chuurenpoutou.Valid(hand);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_同一スートだが九蓮宝燈の形でない_成立しない()
    {
        // Arrange
        var hand = new Hand([new(sou: "111"), new(sou: "234"), new(sou: "345"), new(sou: "789"), new(sou: "99")]);

        // Act
        var actual = Chuurenpoutou.Valid(hand);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_字牌が含まれる_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "234"), new(man: "567"), new(man: "789"), new(honor: "tt")]);

        // Act
        var actual = Chuurenpoutou.Valid(hand);

        // Assert
        Assert.False(actual);
    }
}
