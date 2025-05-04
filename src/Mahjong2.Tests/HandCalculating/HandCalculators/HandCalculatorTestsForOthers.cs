using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

/// <summary>
/// 流し満貫 七対子など特殊な役のテスト
/// </summary>
public class HandCalculatorTestsForOthers
{
    [Fact]
    public void Calc_流し満貫_成立_役リストに流し満貫のみが含まれる()
    {
        // Arrange
        // 手牌が非和了形13枚でも流し満貫だけは成立する必要がある
        var tileList = new TileList(man: "13579", pin: "135", sou: "12344");
        var winTile = null as Tile;
        var winSituation = new WinSituation { IsNagashimangan = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal([Yaku.Nagashimangan], actual.YakuList);
    }

    [Fact]
    public void Calc_七対子_成立_役リストに七対子が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "1133", pin: "2244", sou: "3355", honor: "tt");
        var winTile = Tile.Sou5;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Chiitoitsu, actual.YakuList);
    }

    [Fact]
    public void Calc_大車輪_成立_役リストに大車輪が含まれる()
    {
        // Arrange
        var tileList = new TileList(pin: "22334455667788");
        var winTile = Tile.Pin2;
        var gameRules = new GameRules { DaisharinEnabled = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, gameRules: gameRules);

        // Assert
        Assert.Contains(Yaku.Daisharin, actual.YakuList);
    }

    [Fact]
    void Calc_複数の役リストに取れる_点数が高い方が返される()
    {
        // Arrange
        // 七対子とも二盃口とも取れる
        var tileList = new TileList(man: "112233", pin: "44778899");
        var winTile = Tile.Pin4;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        // 二盃口の方が高い
        Assert.Equal([Yaku.Ryanpeikou], actual.YakuList);
    }

    [Fact]
    void Calc_役無し()
    {
        // Arrange
        var tileList = new TileList(man: "123", honor: "ppphh");
        var winTile = Tile.Man3;
        var fuuroList = new FuuroList([new Chi(new(man: "456")), new Pon(new(pin: "777"))]);

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList);

        // Assert
        Assert.Equal("役がありません。", actual.ErrorMessage);
    }
}
