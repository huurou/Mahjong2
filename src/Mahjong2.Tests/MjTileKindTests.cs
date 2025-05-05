using Mahjong2.Lib;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests;

public class MjTileKindTests
{
    [Fact]
    public void ToTileList_全種類の牌を内部表現に変換_正しく変換される()
    {
        // Arrange
        var mjTiles = new List<MjTileKind>
        {
            MjTileKind.Man1, MjTileKind.Man2, MjTileKind.Man3, MjTileKind.Man4, MjTileKind.Man5,
            MjTileKind.Man6, MjTileKind.Man7, MjTileKind.Man8, MjTileKind.Man9,
            MjTileKind.Pin1, MjTileKind.Pin2, MjTileKind.Pin3, MjTileKind.Pin4, MjTileKind.Pin5,
            MjTileKind.Pin6, MjTileKind.Pin7, MjTileKind.Pin8, MjTileKind.Pin9,
            MjTileKind.Sou1, MjTileKind.Sou2, MjTileKind.Sou3, MjTileKind.Sou4, MjTileKind.Sou5,
            MjTileKind.Sou6, MjTileKind.Sou7, MjTileKind.Sou8, MjTileKind.Sou9,
            MjTileKind.Ton, MjTileKind.Nan, MjTileKind.Sha, MjTileKind.Pei,
            MjTileKind.Haku, MjTileKind.Hatsu, MjTileKind.Chun
        };

        var expectedTiles = new List<Tile>
        {
            Tile.Man1, Tile.Man2, Tile.Man3, Tile.Man4, Tile.Man5,Tile.Man6, Tile.Man7, Tile.Man8, Tile.Man9,
            Tile.Pin1, Tile.Pin2, Tile.Pin3, Tile.Pin4, Tile.Pin5,Tile.Pin6, Tile.Pin7, Tile.Pin8, Tile.Pin9,
            Tile.Sou1, Tile.Sou2, Tile.Sou3, Tile.Sou4, Tile.Sou5,Tile.Sou6, Tile.Sou7, Tile.Sou8, Tile.Sou9,
            Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei, Tile.Haku, Tile.Hatsu, Tile.Chun
        };

        // Act
        var tileList = mjTiles.ToTileList();

        // Assert
        Assert.Equal(34, tileList.Count);
        for (var i = 0; i < 34; i++)
        {
            Assert.Equal(expectedTiles[i], tileList[i]);
        }
    }
}