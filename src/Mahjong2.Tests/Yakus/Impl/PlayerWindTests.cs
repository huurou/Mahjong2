using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class PlayerWindTests
{
    [Fact]
    public void Number_17が返る()
    {
        // Arrange
        var playerWind = Yaku.PlayerWind;

        // Act
        var actual = playerWind.Number;

        // Assert
        Assert.Equal(17, actual);
    }

    [Fact]
    public void Name_自風牌が返る()
    {
        // Arrange
        var playerWind = Yaku.PlayerWind;

        // Act
        var actual = playerWind.Name;

        // Assert
        Assert.Equal("自風牌", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var playerWind = Yaku.PlayerWind;

        // Act
        var actual = playerWind.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var playerWind = Yaku.PlayerWind;

        // Act
        var actual = playerWind.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var playerWind = Yaku.PlayerWind;

        // Act
        var actual = playerWind.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_東家で東の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "ttt")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { PlayerWind = Wind.East };

        // Act
        var actual = PlayerWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_南家で南の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "nnn")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { PlayerWind = Wind.South };

        // Act
        var actual = PlayerWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_西家で西の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "sss")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { PlayerWind = Wind.West };

        // Act
        var actual = PlayerWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_北家で北の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "ppp")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { PlayerWind = Wind.North };

        // Act
        var actual = PlayerWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_東家で自風牌以外の刻子_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "nnn")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { PlayerWind = Wind.East };

        // Act
        var actual = PlayerWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_東家で東の槓子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234")]);
        var fuuroList = new FuuroList([new Daiminkan(new TileList(honor: "tttt"))]);
        var winSituation = new WinSituation { PlayerWind = Wind.East };

        // Act
        var actual = PlayerWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_不明な風_例外がでる()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(pin: "234"), new(sou: "234"), new(honor: "ttt")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { PlayerWind = (Wind)4 };

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => PlayerWind.Valid(hand, fuuroList, winSituation));
        Assert.Contains($"不明な風です。PlayerWind:{winSituation.PlayerWind}", exception.Message);
    }
}