using Mahjong2.Lib.HandCalculating;
using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Games;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

public class HandCalculatorTestsForKoutsu
{
    [Fact]
    public void Calc_対々和_成立_役リストに対々和が含まれる()
    {
        // Arrange
        var tileList = new TileList(sou: "333444", honor: "cc");
        var fuuroList = new FuuroList([new Pon(new(man: "111")), new Pon(new(pin: "222"))]);
        var winTile = Tile.Sou3;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList);

        // Assert
        Assert.Contains(Yaku.Toitoihou, actual.YakuList);
    }

    [Fact]
    public void Calc_三暗刻_成立_役リストに三暗刻が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111", pin: "222", sou: "333345", honor: "cc");
        var winTile = Tile.Sou5;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Sanankou, actual.YakuList);
    }

    [Fact]
    public void Calc_三色同刻_成立_役リストに三色同刻が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "333", pin: "333", sou: "333345", honor: "cc");
        var winTile = Tile.Sou5;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Sanshokudoukou, actual.YakuList);
    }

    [Fact]
    public void Calc_小三元_成立_役リストに小三元が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111", pin: "234", honor: "hhhrrrcc");
        var winTile = Tile.Chun;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Shousangen, actual.YakuList);
    }

    [Fact]
    public void Calc_白_成立_役リストに白が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "123", sou: "12344", honor: "hhh");
        var winTile = Tile.Haku;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Haku, actual.YakuList);
    }

    [Fact]
    public void Calc_發_成立_役リストに發が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "123", sou: "12344", honor: "rrr");
        var winTile = Tile.Hatsu;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Hatsu, actual.YakuList);
    }

    [Fact]
    public void Calc_中_成立_役リストに中が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "123", sou: "12344", honor: "ccc");
        var winTile = Tile.Chun;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Chun, actual.YakuList);
    }

    [Fact]
    public void Calc_自風牌_成立_役リストに自風牌が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "123", sou: "12344", honor: "ttt");
        var winTile = Tile.Ton;
        var winSituation = new WinSituation { PlayerWind = Wind.East };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.PlayerWind, actual.YakuList);
    }

    [Fact]
    public void Calc_場風牌_成立_役リストに場風牌が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "123", sou: "12344", honor: "nnn");
        var winTile = Tile.Nan;
        var winSituation = new WinSituation { RoundWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.RoundWind, actual.YakuList);
    }

    [Fact]
    public void Calc_大三元_成立_役リストに大三元が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111", honor: "tthhhrrrccc");
        var winTile = Tile.Chun;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Daisangen, actual.YakuList);
    }

    [Fact]
    public void Calc_小四喜_成立_役リストに小四喜が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", honor: "tttnnnssspp");
        var winTile = Tile.Pei;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Shousuushii, actual.YakuList);
    }

    [Fact]
    public void Calc_大四喜_成立_役リストに大四喜が含まれる()
    {
        // Arrange
        var tileList = new TileList(honor: "tttnnnssspppcc");
        var winTile = Tile.Chun;
        var gameRules = new GameRules { DoubleYakumanEnabled = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.Daisuushii, actual.YakuList);
    }

    [Fact]
    public void Calc_大四喜ダブル_役リストに大四喜ダブルが含まれる()
    {
        // Arrange
        var tileList = new TileList(honor: "tttnnnssspppcc");
        var winTile = Tile.Chun;
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.DaisuushiiDouble, actual.YakuList);
    }

    [Fact]
    public void Calc_九蓮宝燈_成立_役リストに九蓮宝燈が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "11123456789999");
        var winTile = Tile.Man1;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Chuurenpoutou, actual.YakuList);
    }

    [Fact]
    public void Calc_純正九蓮宝燈_成立_役リストに純正九蓮宝燈が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "11123456789999");
        var winTile = Tile.Man9;
        var gameRules = new GameRules();

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.JunseiChuurenpoutou, actual.YakuList);
    }

    [Fact]
    public void Calc_四暗刻_成立_役リストに四暗刻が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111", pin: "222", sou: "333", honor: "hhhpp");
        var winTile = Tile.Haku;
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Suuankou, actual.YakuList);
    }

    [Fact]
    public void Calc_四暗刻_四暗刻単騎だがダブル役満無効_役リストに四暗刻が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111", pin: "222", sou: "333", honor: "hhhpp");
        var winTile = Tile.Haku;
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { DoubleYakumanEnabled = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.Suuankou, actual.YakuList);
    }

    [Fact]
    public void Calc_四暗刻単騎_成立_役リストに四暗刻単騎が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111", pin: "222", sou: "333", honor: "hhhpp");
        var winTile = Tile.Pei;
        var winSituation = new WinSituation { IsTsumo = false };
        var gameRules = new GameRules { DoubleYakumanEnabled = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.SuuankouTanki, actual.YakuList);
    }

    [Fact]
    public void Calc_清老頭_成立_役リストに清老頭が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "111999", pin: "11199", sou: "999");
        var winTile = Tile.Pin9;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Chinroutou, actual.YakuList);
    }

    [Fact]
    public void Calc_三槓子_成立_役リストに三槓子が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123", sou: "99");
        var winTile = Tile.Sou9;
        var fuuroList = new FuuroList([new Ankan(new(man: "5555")), new Minkan(new(pin: "5555")), new Ankan(new(sou: "5555"))]);

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList);

        // Assert
        Assert.Contains(Yaku.Sankantsu, actual.YakuList);
    }

    [Fact]
    public void Calc_四槓子_成立_役リストに四槓子が含まれる()
    {
        // Arrange
        var tileList = new TileList(honor: "cc");
        var winTile = Tile.Chun;
        var fuuroList = new FuuroList([new Ankan(new(man: "1111")), new Minkan(new(pin: "1111")), new Ankan(new(sou: "1111")), new Minkan(new(honor: "hhhh"))]);

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList);

        // Assert
        Assert.Contains(Yaku.Suukantsu, actual.YakuList);
    }
}
