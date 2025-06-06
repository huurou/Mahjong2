using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Games;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 三暗刻
/// </summary>
internal record Sanankou : Yaku
{
    public override int Number => 24;
    public override string Name => "三暗刻";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;
    public static bool Valid(Hand hand, TileList winGroup, FuuroList fuuroList, WinSituation winSituation)
    {
        var ankoTiles = winSituation.IsTsumo ? hand.Where(x => x.IsKoutsu) : hand.Where(x => x.IsKoutsu && x != winGroup);
        var ankanTiles = fuuroList.Where(x => x.IsAnkan).Select(x => x.TileList);
        return ankoTiles.Count() + ankanTiles.Count() == 3;
    }
}