using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// ダブル立直
/// </summary>
internal record DoubleRiichi : Yaku
{
    public override int Number => 2;
    public override string Name => "ダブル立直";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation, FuuroList fuuroList)
    {
        return winSituation.IsDoubleRiichi && !fuuroList.HasOpen;
    }
}