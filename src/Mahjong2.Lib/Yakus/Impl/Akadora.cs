using Mahjong2.Lib.HandCalculating.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 赤ドラ
/// </summary>
internal record Akadora : Yaku
{
    public override int Number => 53;
    public override string Name => "赤ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.AkadoraCount > 0;
    }
}
