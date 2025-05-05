using Mahjong2.Lib.Games;
using Mahjong2.Lib.HandCalculating;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

public class HandCalculatorTestsForFormless
{
    [Fact]
    public void Calc_ツモ_面前かつツモ_役リストにツモが含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "123", sou: "12344");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Tsumo, actual.YakuList);
    }

    [Fact]
    public void Calc_立直_成立_役リストに立直が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRiichi = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Riichi, actual.YakuList);
    }

    [Fact]
    public void Calc_ダブル立直_成立_役リストにダブル立直が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsDoubleRiichi = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.DoubleRiichi, actual.YakuList);
    }

    [Fact]
    public void Calc_断么九_成立_役リストに断么九が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "234567", pin: "234", sou: "23444");
        var winTile = Tile.Sou4;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Tanyao, actual.YakuList);
    }

    [Fact]
    public void Calc_一発_成立_役リストに一発が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRiichi = true, IsIppatsu = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Ippatsu, actual.YakuList);
    }

    [Fact]
    public void Calc_槍槓_成立_役リストに槍槓が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsChankan = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Chankan, actual.YakuList);
    }

    [Fact]
    public void Calc_嶺上開花_成立_役リストに嶺上開花が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsTsumo = true, IsRinshan = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Rinshan, actual.YakuList);
    }

    [Fact]
    public void Calc_海底撈月_成立_役リストに海底撈月が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsTsumo = true, IsHaitei = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Haitei, actual.YakuList);
    }

    [Fact]
    public void Calc_河底撈魚_成立_役リストに河底撈魚が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsTsumo = false, IsHoutei = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Houtei, actual.YakuList);
    }

    [Fact]
    public void Calc_人和_成立_役リストに人和が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRenhou = true, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Renhou, actual.YakuList);
    }

    [Fact]
    public void Calc_混一色_成立_役リストに混一色が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456789", honor: "pppnn");
        var winTile = Tile.Man6;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Honitsu, actual.YakuList);
    }

    [Fact]
    public void Calc_清一色_正しい構成_役リストに清一色が含まれる()
    {
        // Arrange
        var tileList = new TileList(pin: "11223345678999");
        var winTile = Tile.Pin4;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Chinitsu, actual.YakuList);
    }

    [Fact]
    public void Calc_字一色_成立_役リストに字一色が含まれる()
    {
        // Arrange
        var tileList = new TileList(honor: "tttnnnssshhhcc");
        var winTile = Tile.Chun;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Tsuuiisou, actual.YakuList);
    }

    [Fact]
    public void Calc_字一色七対子版_成立_役リストに字一色が含まれ七対子は含まれない()
    {
        // Arrange
        var tileList = new TileList(honor: "ttnnsspphhrrcc");
        var winTile = Tile.Chun;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Tsuuiisou, actual.YakuList);
    }

    [Fact]
    public void Calc_混老頭_成立_役リストに混老頭が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111999", pin: "111", sou: "999", honor: "tt");
        var winTile = Tile.Man1;
        var winSituation = new WinSituation();

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Honroutou, actual.YakuList);
    }

    [Fact]
    public void Calc_緑一色_成立_役リストに緑一色が含まれる()
    {
        // Arrange
        var tileList = new TileList(sou: "22334466888", honor: "rrr");
        var winTile = Tile.Sou6;
        var winSituation = new WinSituation();

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Ryuuiisou, actual.YakuList);
    }

    [Fact]
    public void Calc_地和_成立_役リストに地和が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsChiihou = true, IsTsumo = true, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Chiihou, actual.YakuList);
    }

    [Fact]
    public void Calc_人和役満_成立_役リストに人和役満が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRenhou = true, IsTsumo = false, PlayerWind = Wind.South };
        var gameRules = new GameRules { RenhouAsYakumanEnabled = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.RenhouYakuman, actual.YakuList);
    }
}
