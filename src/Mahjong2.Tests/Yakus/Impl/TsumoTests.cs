using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class TsumoTests
{
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