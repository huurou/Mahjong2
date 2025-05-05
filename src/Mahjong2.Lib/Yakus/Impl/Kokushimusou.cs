using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 国士無双
/// </summary>
internal record Kokushimusou : Yaku
{
    public override int Number => 33;
    public override string Name => "国士無双";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(TileList tileList)
    {
        var tiles = tileList.ToList();
        foreach (var yaochuu in Tile.Yaochus)
        {
            if (!tiles.Remove(yaochuu)) { return false; }
        }
        return tiles.Count == 1 && tiles[0].IsYaochu;
    }
}