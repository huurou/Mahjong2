using Mahjong2.Lib.Scoring.Games;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 嶺上開花
/// </summary>
internal record Rinshan : Yaku
{
    public override int Number => 6;
    public override string Name => "嶺上開花";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsRinshan;
    }
}