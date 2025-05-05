using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Lib.Scores;

public enum MjTileType
{
    Man1,
    Man2,
    Man3,
    Man4,
    Man5,
    Man6,
    Man7,
    Man8,
    Man9,
    Pin1,
    Pin2,
    Pin3,
    Pin4,
    Pin5,
    Pin6,
    Pin7,
    Pin8,
    Pin9,
    Sou1,
    Sou2,
    Sou3,
    Sou4,
    Sou5,
    Sou6,
    Sou7,
    Sou8,
    Sou9,
    Ton,
    Nan,
    Sha,
    Pei,
    Haku,
    Hatsu,
    Chun,
}

internal static class MjTileExtensions
{
    public static Tile ToTile(this MjTileType mjTile)
    {
        return mjTile switch
        {
            MjTileType.Man1 => Tile.Man1,
            MjTileType.Man2 => Tile.Man2,
            MjTileType.Man3 => Tile.Man3,
            MjTileType.Man4 => Tile.Man4,
            MjTileType.Man5 => Tile.Man5,
            MjTileType.Man6 => Tile.Man6,
            MjTileType.Man7 => Tile.Man7,
            MjTileType.Man8 => Tile.Man8,
            MjTileType.Man9 => Tile.Man9,
            MjTileType.Pin1 => Tile.Pin1,
            MjTileType.Pin2 => Tile.Pin2,
            MjTileType.Pin3 => Tile.Pin3,
            MjTileType.Pin4 => Tile.Pin4,
            MjTileType.Pin5 => Tile.Pin5,
            MjTileType.Pin6 => Tile.Pin6,
            MjTileType.Pin7 => Tile.Pin7,
            MjTileType.Pin8 => Tile.Pin8,
            MjTileType.Pin9 => Tile.Pin9,
            MjTileType.Sou1 => Tile.Sou1,
            MjTileType.Sou2 => Tile.Sou2,
            MjTileType.Sou3 => Tile.Sou3,
            MjTileType.Sou4 => Tile.Sou4,
            MjTileType.Sou5 => Tile.Sou5,
            MjTileType.Sou6 => Tile.Sou6,
            MjTileType.Sou7 => Tile.Sou7,
            MjTileType.Sou8 => Tile.Sou8,
            MjTileType.Sou9 => Tile.Sou9,
            MjTileType.Ton => Tile.Ton,
            MjTileType.Nan => Tile.Nan,
            MjTileType.Sha => Tile.Sha,
            MjTileType.Pei => Tile.Pei,
            MjTileType.Haku => Tile.Haku,
            MjTileType.Hatsu => Tile.Hatsu,
            MjTileType.Chun => Tile.Chun,
            _ => throw new NotImplementedException(),
        };
    }

    public static TileList ToTileList(this IEnumerable<MjTileType> mjTiles)
    {
        return [.. mjTiles.Select(x => x.ToTile())];
    }
}
