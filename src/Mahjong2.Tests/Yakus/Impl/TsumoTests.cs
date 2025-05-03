using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class TsumoTests
{
    [Fact]
    public void Name_門前清自摸和を返す()
    {
        // Arrange
        var tsumo = new Tsumo();

        // Act
        var actual = tsumo.Name;

        // Assert
        Assert.Equal("門前清自摸和", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var tsumo = new Tsumo();

        // Act
        var actual = tsumo.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var tsumo = new Tsumo();

        // Act
        var actual = tsumo.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var tsumo = new Tsumo();

        // Act
        var actual = tsumo.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_門前_ツモ和了_成立する()
    {
        // Arrange
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Tsumo.Valid(fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_門前_ロン和了_成立しない()
    {
        // Arrange
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = false };

        // Act
        var actual = Tsumo.Valid(fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_副露あり_ツモ和了_成立しない()
    {
        // Arrange
        var hand = new Hand([new(man: "234"), new(man: "567"), new(pin: "88")]);
        var fuuroList = new FuuroList([new Chi(new(sou: "345"))]);
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Tsumo.Valid(fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }
}