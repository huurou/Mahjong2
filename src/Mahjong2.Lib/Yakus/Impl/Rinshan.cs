using Mahjong2.Lib.Scores;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 嶺上開花
/// </summary>
public record Rinshan : Yaku
{
    public override string Name => "嶺上開花";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsRinshan;
    }
}