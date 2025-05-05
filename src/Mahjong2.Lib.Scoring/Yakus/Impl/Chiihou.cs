using Mahjong2.Lib.Scoring.Games;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 地和
/// </summary>
internal record Chiihou : Yaku
{
    public override int Number => 49;
    public override string Name => "地和";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsChiihou;
    }
}