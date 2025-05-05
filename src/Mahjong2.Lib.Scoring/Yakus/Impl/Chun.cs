using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 中
/// </summary>
internal record Chun : Yaku
{
    public override int Number => 16;
    public override string Name => "中";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.CombineFuuro(fuuroList).IncludesKoutsu(Tile.Chun);
    }
}