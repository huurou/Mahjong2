using Mahjong2.Lib.Internals.HandCalculating;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

public class HandCalculatorTestsForShuntsu
{
    [Fact]
    public void Calc_平和_成立_役リストに平和が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "234", sou: "23444");
        var winTile = Tile.Pin4;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Pinfu, actual.YakuList);
    }

    [Fact]
    public void Calc_混全帯么九_成立_役リストに混全帯么九が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123789", pin: "123789", honor: "nn");
        var winTile = Tile.Man1;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Chanta, actual.YakuList);
    }

    [Fact]
    public void Calc_純全帯么九_成立_役リストに純全帯么九が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "123789", pin: "123", sou: "11123");
        var winTile = Tile.Man1;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Junchan, actual.YakuList);
    }

    [Fact]
    public void Calc_一盃口_成立_役リストに一盃口が含まれる()
    {
        // Arrange
        var tileList = new TileList(man: "112233", pin: "234", sou: "23444");
        var winTile = Tile.Sou4;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Contains(Yaku.Iipeikou, actual.YakuList);
    }

    [Fact]
    public void Calc_三色同順_3色同じ順子_役リストに三色同順が含まれる()
    {
        // Arrange
        // 123m 123p 123s 456s 77s（雀頭7s）→14枚
        var tileList = new TileList(man: "123", pin: "123", sou: "12345677");
        var winTile = Tile.Sou7;
        var winSituation = new WinSituation();

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Contains(Yaku.Sanshoku, actual.YakuList);
    }
}
