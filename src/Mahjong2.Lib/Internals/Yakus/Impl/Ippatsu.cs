using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

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