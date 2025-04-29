using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 三暗刻
/// </summary>
public record Sanankou : Yaku
{
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