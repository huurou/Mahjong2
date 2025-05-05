using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChiitoitsuTests
{
    [Fact]
    public void Number_27を返す()
    {
        // Arrange
        var chiitoitsu = Yaku.Chiitoitsu;
        // Act
        var actual = chiitoitsu.Number;
        // Assert
        Assert.Equal(27, actual);
    }

    [Fact]
    public void Name_七対子を返す()
    {
        // Arrange
        var chiitoitsu = Yaku.Chiitoitsu;

        // Act
        var actual = chiitoitsu.Name;

        // Assert
        Assert.Equal("七対子", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var chiitoitsu = Yaku.Chiitoitsu;

        // Act
        var actual = chiitoitsu.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_2を返す()
    {
        // Arrange
        var chiitoitsu = Yaku.Chiitoitsu;

        // Act
        var actual = chiitoitsu.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var chiitoitsu = Yaku.Chiitoitsu;

        // Act
        var actual = chiitoitsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_7つの対子がある場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(man: "22"), new(pin: "33"), new(pin: "44"), new(sou: "55"), new(sou: "66"), new(honor: "tt")]);

        // Act
        var actual = Chiitoitsu.Valid(hand);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_対子が7つではない場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(man: "22"), new(pin: "33"), new(pin: "44"), new(sou: "55"), new(sou: "66")]);

        // Act
        var actual = Chiitoitsu.Valid(hand);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_対子ではない組み合わせが含まれる場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "11"), new(man: "22"), new(pin: "33"), new(pin: "44"), new(sou: "55"), new(sou: "66"), new(man: "123")]);

        // Act
        var actual = Chiitoitsu.Valid(hand);

        // Assert
        Assert.False(actual);
    }
}