using Mahjong2.Lib.Scoring.Tiles;
using Mahjong2.Lib.Scoring.Tiles.HonotTiles;

namespace Mahjong2.Lib.Scoring.Games;

/// <summary>
/// 風
/// </summary>
internal record Wind(int Number)
{
    public static Wind East { get; } = new(0);
    public static Wind South { get; } = new(1);
    public static Wind West { get; } = new(2);
    public static Wind North { get; } = new(3);

    public WindTile ToTile()
    {
        return Number switch
        {
            0 => Tile.Ton,
            1 => Tile.Nan,
            2 => Tile.Sha,
            3 => Tile.Pei,
            _ => throw new InvalidOperationException("不明な風牌です。"),
        };
    }
}
