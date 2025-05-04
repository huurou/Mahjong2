using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 一発
/// </summary>
internal record Ippatsu : Yaku
{
    public override int Number => 4;
    public override string Name => "一発";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation, FuuroList fuuroList)
    {
        return (Riichi.Valid(winSituation, fuuroList) || DoubleRiichi.Valid(winSituation, fuuroList)) &&
            winSituation.IsIppatsu;
    }
}