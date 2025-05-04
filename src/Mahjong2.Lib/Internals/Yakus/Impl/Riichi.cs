using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// 立直
/// </summary>
internal record Riichi : Yaku
{
    public override int Number => 1;
    public override string Name => "立直";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation, FuuroList fuuroList)
    {
        return winSituation.IsRiichi && !winSituation.IsDoubleRiichi && !fuuroList.HasOpen;
    }
}