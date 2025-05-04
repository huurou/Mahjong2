using Mahjong2.Lib.Internals.HandCalculating;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

public class HandCalculatorTestsForKokushimusou
{
    [Fact]
    public void Calc_国士無双_成立_役リストに国士無双が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = Tile.Man1;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Kokushimusou, actual.YakuList);
    }

    [Fact]
    public void Calc_国士無双十三面待ち_成立_役リストに国士無双十三面待ちが含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = Tile.Ton;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Kokushimusou13menmachi, actual.YakuList);
    }

    [Fact]
    public void Calc_国士無双かつ天和_役リストに国士無双と天和のみが含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = null as Tile;
        var winSituation = new WinSituation { IsTenhou = true, IsTsumo = true, PlayerWind = Wind.East };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal([Yaku.Kokushimusou, Yaku.Tenhou], actual.YakuList);
    }

    [Fact]
    public void Calc_国士無双かつ地和_役リストに国士無双と地和のみが含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = Tile.Man1;
        var winSituation = new WinSituation { IsChiihou = true, IsTsumo = true, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal([Yaku.Kokushimusou, Yaku.Chiihou], actual.YakuList);
    }

    [Fact]
    public void Calc_国士無双かつ人和役満_役リストに国士無双と人和役満のみが含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = Tile.Man1;
        var winSituation = new WinSituation { IsRenhou = true, IsTsumo = false, PlayerWind = Wind.South };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation, gameRules: gameRules);

        // Assert
        Assert.Equal([Yaku.Kokushimusou, Yaku.RenhouYakuman], actual.YakuList);
    }

    [Fact]
    public void Calc_国士無双かつ役満でない人和_成立_役リストに国士無双のみが含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "19", pin: "19", sou: "19", honor: "ttnsphrc");
        var winTile = Tile.Man1;
        var winSituation = new WinSituation { IsRenhou = true, IsTsumo = false, PlayerWind = Wind.South };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation, gameRules: gameRules);

        // Assert
        Assert.Equal([Yaku.Kokushimusou], actual.YakuList);
    }
}
