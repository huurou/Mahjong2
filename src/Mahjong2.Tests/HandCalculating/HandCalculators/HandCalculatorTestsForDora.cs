using Mahjong2.Lib.Internals.HandCalculating;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

public class HandCalculatorTestsForDora
{
    [Fact]
    public void Calc_ドラ_役リストにドラがドラの個数含まれる()
    {
        // Arrange
        var tileList = new TileList(sou: "11123444456789");
        var winTile = Tile.Sou4;
        var doraIndicators = new TileList(sou: "3");

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, doraIndicators: doraIndicators);

        // Assert
        Assert.Contains(Yaku.Dora, actual.YakuList);
        Assert.Equal(4, actual.YakuList.Count(x => x == Yaku.Dora));
    }

    [Fact]
    public void Calc_裏ドラ_役リストに裏ドラが裏ドラの個数含まれる()
    {
        // Arrange
        var tileList = new TileList(sou: "11123444456789");
        var winTile = Tile.Sou4;
        var uradoraIndicators = new TileList(sou: "3");

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, uradoraIndicators: uradoraIndicators);

        // Assert
        Assert.Contains(Yaku.Uradora, actual.YakuList);
        Assert.Equal(4, actual.YakuList.Count(x => x == Yaku.Uradora));
    }

    [Fact]
    public void Calc_赤ドラ_役リストに赤ドラが赤ドラの個数含まれる()
    {
        // Arrange
        var tileList = new TileList(sou: "11123455556789");
        var winTile = Tile.Sou1;
        var winSituation = new WinSituation { AkadoraCount = 2 };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Akadora, actual.YakuList);
        Assert.Equal(2, actual.YakuList.Count(x => x == Yaku.Akadora));
    }
}
