using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class DaisharinTests
{
    [Fact]
    public void Name_大車輪が返る()
    {
        // Arrange
        var daisharin = new Daisharin();

        // Act
        var actual = daisharin.Name;

        // Assert
        Assert.Equal("大車輪", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var daisharin = new Daisharin();

        // Act
        var actual = daisharin.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13が返る()
    {
        // Arrange
        var daisharin = new Daisharin();

        // Act
        var actual = daisharin.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueが返る()
    {
        // Arrange
        var daisharin = new Daisharin();

        // Act
        var actual = daisharin.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_大車輪形の手牌でルール有効_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "22"), new(pin: "33"), new(pin: "44"), new(pin: "55"), new(pin: "66"), new(pin: "77"), new(pin: "88")]);
        var gameRules = new GameRules { DaisharinEnabled = true };

        // Act
        var actual = Daisharin.Valid(hand, gameRules);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_大車輪形の手牌でルール無効_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "22"), new(pin: "33"), new(pin: "44"), new(pin: "55"), new(pin: "66"), new(pin: "77"), new(pin: "88")]);
        var gameRules = new GameRules { DaisharinEnabled = false };

        // Act
        var actual = Daisharin.Valid(hand, gameRules);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_大車輪形ではない手牌_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "22"), new(pin: "33"), new(pin: "44"), new(pin: "55"), new(pin: "66"), new(pin: "77"), new(man: "88")]);
        var gameRules = new GameRules { DaisharinEnabled = true };

        // Act
        var actual = Daisharin.Valid(hand, gameRules);

        // Assert
        Assert.False(actual);
    }
}