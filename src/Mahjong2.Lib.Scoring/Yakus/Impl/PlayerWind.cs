using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Games;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 自風牌
/// </summary>
internal record PlayerWind : Yaku
{
    public override int Number => 17;
    public override string Name => "自風牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, WinSituation winSituation)
    {
        return hand.CombineFuuro(fuuroList).IncludesKoutsu(winSituation.PlayerWind.ToTile());
    }
}