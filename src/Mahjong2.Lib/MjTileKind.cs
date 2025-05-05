using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Lib;

public enum MjTileKind
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

internal static class MjTileKindExtensions
{
    public static Tile ToTile(this MjTileKind mjTile)
    {
        return mjTile switch
        {
            MjTileKind.Man1 => Tile.Man1,
            MjTileKind.Man2 => Tile.Man2,
            MjTileKind.Man3 => Tile.Man3,
            MjTileKind.Man4 => Tile.Man4,
            MjTileKind.Man5 => Tile.Man5,
            MjTileKind.Man6 => Tile.Man6,
            MjTileKind.Man7 => Tile.Man7,
            MjTileKind.Man8 => Tile.Man8,
            MjTileKind.Man9 => Tile.Man9,
            MjTileKind.Pin1 => Tile.Pin1,
            MjTileKind.Pin2 => Tile.Pin2,
            MjTileKind.Pin3 => Tile.Pin3,
            MjTileKind.Pin4 => Tile.Pin4,
            MjTileKind.Pin5 => Tile.Pin5,
            MjTileKind.Pin6 => Tile.Pin6,
            MjTileKind.Pin7 => Tile.Pin7,
            MjTileKind.Pin8 => Tile.Pin8,
            MjTileKind.Pin9 => Tile.Pin9,
            MjTileKind.Sou1 => Tile.Sou1,
            MjTileKind.Sou2 => Tile.Sou2,
            MjTileKind.Sou3 => Tile.Sou3,
            MjTileKind.Sou4 => Tile.Sou4,
            MjTileKind.Sou5 => Tile.Sou5,
            MjTileKind.Sou6 => Tile.Sou6,
            MjTileKind.Sou7 => Tile.Sou7,
            MjTileKind.Sou8 => Tile.Sou8,
            MjTileKind.Sou9 => Tile.Sou9,
            MjTileKind.Ton => Tile.Ton,
            MjTileKind.Nan => Tile.Nan,
            MjTileKind.Sha => Tile.Sha,
            MjTileKind.Pei => Tile.Pei,
            MjTileKind.Haku => Tile.Haku,
            MjTileKind.Hatsu => Tile.Hatsu,
            MjTileKind.Chun => Tile.Chun,
            _ => throw new NotImplementedException(),
        };
    }

    public static TileList ToTileList(this IEnumerable<MjTileKind> mjTiles)
    {
        return [.. mjTiles.Select(x => x.ToTile())];
    }
}
