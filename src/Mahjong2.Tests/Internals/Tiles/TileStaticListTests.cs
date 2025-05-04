using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Tiles.NumberTiles;

namespace Mahjong2.Tests.Internals.Tiles;

/// <summary>
/// Tileクラスの静的リストに関するテスト
/// </summary>
public class TileStaticListTests
{
    [Fact]
    public void All_要素数の確認_34種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(34, Tile.All.Count);
    }

    [Fact]
    public void Numbers_要素数の確認_27種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(27, Tile.Numbers.Count);
    }

    [Fact]
    public void Mans_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Mans.Count);
    }

    [Fact]
    public void Pins_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Pins.Count);
    }

    [Fact]
    public void Sous_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Sous.Count);
    }

    [Fact]
    public void Honors_要素数の確認_7種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(7, Tile.Honors.Count);
    }

    [Fact]
    public void Winds_要素数の確認_4種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(4, Tile.Winds.Count);
    }

    [Fact]
    public void Dragons_要素数の確認_3種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(3, Tile.Dragons.Count);
    }

    [Fact]
    public void Chuchans_リストの確認_中張牌のみを含む()
    {
        // Arrange & Act
        var expected = 21; // 3色 × (2から8の7種)

        // Assert
        Assert.Equal(expected, Tile.Chuchans.Count);
        Assert.All(Tile.Chuchans, tile => Assert.True(tile.IsChuchan));
    }

    [Fact]
    public void Yaochus_リストの確認_么九牌のみを含む()
    {
        // Arrange & Act
        var expected = 13; // 数牌の1,9 (3色×2種=6種) + 字牌(7種)

        // Assert
        Assert.Equal(expected, Tile.Yaochus.Count);
        Assert.All(Tile.Yaochus, tile => Assert.True(tile.IsYaochu));
    }

    [Fact]
    public void Tile_リスト内容の確認_重複がなく漏れもない()
    {
        // Arrange & Act & Assert
        // 全ての牌の確認
        Assert.Equal(Tile.Numbers.Count + Tile.Honors.Count, Tile.All.Count);
        Assert.All(Tile.Numbers, tile => Assert.Contains(tile, Tile.All));
        Assert.All(Tile.Honors, tile => Assert.Contains(tile, Tile.All));

        // 数牌の確認
        Assert.Equal(Tile.Mans.Count + Tile.Pins.Count + Tile.Sous.Count, Tile.Numbers.Count);
        Assert.All(Tile.Mans, tile => Assert.Contains(tile, Tile.Numbers));
        Assert.All(Tile.Pins, tile => Assert.Contains(tile, Tile.Numbers));
        Assert.All(Tile.Sous, tile => Assert.Contains(tile, Tile.Numbers));

        // 字牌の確認
        Assert.Equal(Tile.Winds.Count + Tile.Dragons.Count, Tile.Honors.Count);
        Assert.All(Tile.Winds, tile => Assert.Contains(tile, Tile.Honors));
        Assert.All(Tile.Dragons, tile => Assert.Contains(tile, Tile.Honors));

        // 中張牌の確認
        Assert.All(Tile.Chuchans, tile =>
        {
            Assert.True(tile.IsNumber);
            Assert.True(tile.Number >= 2 && tile.Number <= 8);
        });

        // 么九牌の確認
        Assert.All(Tile.Yaochus, tile => Assert.True(tile.IsHonor || tile is NumberTile { Number: 1 } || tile is NumberTile { Number: 9 }));

        // 老頭牌の確認
        Assert.All(Tile.Routous, tile =>
        {
            Assert.True(tile.IsNumber);
            Assert.True(tile.Number == 1 || tile.Number == 9);
        });
    }

    [Fact]
    public void Mans_リスト内容の確認_すべての萬子が重複なく含まれている()
    {
        // Arrange
        Tile[] allMans = [Tile.Man1, Tile.Man2, Tile.Man3, Tile.Man4, Tile.Man5, Tile.Man6, Tile.Man7, Tile.Man8, Tile.Man9];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allMans.Length, Tile.Mans.Count);

        // すべての萬子が含まれているか
        foreach (var man in allMans)
        {
            Assert.Contains(man, Tile.Mans);
        }

        // 萬子以外の牌が含まれていないか
        Assert.All(Tile.Mans, tile => Assert.True(tile.IsMan));

        // 重複がないか
        Assert.Equal(Tile.Mans.Count, Tile.Mans.Distinct().Count());
    }

    [Fact]
    public void Pins_リスト内容の確認_すべての筒子が重複なく含まれている()
    {
        // Arrange
        Tile[] allPins = [Tile.Pin1, Tile.Pin2, Tile.Pin3, Tile.Pin4, Tile.Pin5, Tile.Pin6, Tile.Pin7, Tile.Pin8, Tile.Pin9];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allPins.Length, Tile.Pins.Count);

        // すべての筒子が含まれているか
        foreach (var pin in allPins)
        {
            Assert.Contains(pin, Tile.Pins);
        }

        // 筒子以外の牌が含まれていないか
        Assert.All(Tile.Pins, tile => Assert.True(tile.IsPin));

        // 重複がないか
        Assert.Equal(Tile.Pins.Count, Tile.Pins.Distinct().Count());
    }

    [Fact]
    public void Sous_リスト内容の確認_すべての索子が重複なく含まれている()
    {
        // Arrange
        Tile[] allSous = [Tile.Sou1, Tile.Sou2, Tile.Sou3, Tile.Sou4, Tile.Sou5, Tile.Sou6, Tile.Sou7, Tile.Sou8, Tile.Sou9];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allSous.Length, Tile.Sous.Count);

        // すべての索子が含まれているか
        foreach (var sou in allSous)
        {
            Assert.Contains(sou, Tile.Sous);
        }

        // 索子以外の牌が含まれていないか
        Assert.All(Tile.Sous, tile => Assert.True(tile.IsSou));

        // 重複がないか
        Assert.Equal(Tile.Sous.Count, Tile.Sous.Distinct().Count());
    }

    [Fact]
    public void Winds_リスト内容の確認_すべての風牌が重複なく含まれている()
    {
        // Arrange
        Tile[] allWinds = [Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allWinds.Length, Tile.Winds.Count);

        // すべての風牌が含まれているか
        foreach (var wind in allWinds)
        {
            Assert.Contains(wind, Tile.Winds);
        }

        // 風牌以外の牌が含まれていないか
        Assert.All(Tile.Winds, tile => Assert.True(tile.IsWind));

        // 重複がないか
        Assert.Equal(Tile.Winds.Count, Tile.Winds.Distinct().Count());
    }

    [Fact]
    public void Dragons_リスト内容の確認_すべての三元牌が重複なく含まれている()
    {
        // Arrange
        Tile[] allDragons = [Tile.Haku, Tile.Hatsu, Tile.Chun];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allDragons.Length, Tile.Dragons.Count);

        // すべての三元牌が含まれているか
        foreach (var dragon in allDragons)
        {
            Assert.Contains(dragon, Tile.Dragons);
        }

        // 三元牌以外の牌が含まれていないか
        Assert.All(Tile.Dragons, tile => Assert.True(tile.IsDragon));

        // 重複がないか
        Assert.Equal(Tile.Dragons.Count, Tile.Dragons.Distinct().Count());
    }
}
