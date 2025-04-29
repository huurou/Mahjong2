using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Scores;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 立直
/// </summary>
public record Riichi : Yaku
{
    public override string Name => "立直";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, FuuroList fuuroList)
    {
        return situation.IsRiichi && !situation.IsDoubleRiichi && !fuuroList.HasOpen;
    }
}