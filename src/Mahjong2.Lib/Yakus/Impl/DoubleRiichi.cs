using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// ダブル立直
/// </summary>
public record DoubleRiichi : Yaku
{
    public override string Name => "ダブル立直";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation, FuuroList fuuroList)
    {
        return winSituation.IsDoubleRiichi && !fuuroList.HasOpen;
    }
}