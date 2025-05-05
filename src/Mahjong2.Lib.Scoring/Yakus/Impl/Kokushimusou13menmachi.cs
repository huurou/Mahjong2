using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 国士無双十三面待ち
/// </summary>
internal record Kokushimusou13menmachi : Yaku
{
    public override int Number => 45;
    public override string Name => "国士無双十三面待ち";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(TileList tileList, Tile winTile)
    {
        return Kokushimusou.Valid(tileList) && tileList.Count(x => x == winTile) == 2;
    }
}