using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class RoundWindTests
{
    [Fact]
    public void Number_18が返る()
    {
        // Arrange
        var roundWind = Yaku.RoundWind;

        // Act
        var actual = roundWind.Number;

        // Assert
        Assert.Equal(18, actual);
    }

    [Fact]
    public void Name_場風牌が返る()
    {
        // Arrange
        var roundWind = Yaku.RoundWind;

        // Act
        var actual = roundWind.Name;

        // Assert
        Assert.Equal("場風牌", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var roundWind = Yaku.RoundWind;

        // Act
        var actual = roundWind.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var roundWind = Yaku.RoundWind;

        // Act
        var actual = roundWind.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var roundWind = Yaku.RoundWind;

        // Act
        var actual = roundWind.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_東場で東の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "ttt")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = Wind.East };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_南場で南の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "nnn")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = Wind.South };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_西場で西の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "sss")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = Wind.West };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_北場で北の刻子あり_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "ppp")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = Wind.North };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_場風が含まれていない場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "hhh")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = Wind.East };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_場風の牌はあるが刻子になっていない場合_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234"), new(honor: "tt")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = Wind.East };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_副露で場風牌の刻子を作っている場合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(sou: "234")]);
        var fuuroList = new FuuroList([new Pon(new(honor: "ttt"))]);
        var winSituation = new WinSituation { RoundWind = Wind.East };

        // Act
        var actual = RoundWind.Valid(hand, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_不明な風あり_例外がでる()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(man: "234"), new(pin: "234"), new(sou: "234"), new(honor: "ttt")]);
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { RoundWind = (Wind)4 };

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => RoundWind.Valid(hand, fuuroList, winSituation));
        Assert.Contains($"不明な風です。RoundWind:{winSituation.RoundWind}", exception.Message);
    }
}