using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 四暗刻
/// </summary>
public record Suuankou : Yaku
{
    public override string Name => "四暗刻";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, TileList winGroup, FuuroList fuuroList, WinSituation winSituation)
    {
        var ankoTiles = winSituation.IsTsumo ? hand.Where(x => x.IsKoutsu) : hand.Where(x => x.IsKoutsu && x != winGroup);
        var ankanTiles = fuuroList.Where(x => x.IsAnkan).Select(x => x.TileList);
        return ankoTiles.Count() + ankanTiles.Count() == 4;
    }
}