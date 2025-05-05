using Mahjong2.Lib.Scoring.Games;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 河底撈魚
/// </summary>
internal record Houtei : Yaku
{
    public override int Number => 8;
    public override string Name => "河底撈魚";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsHoutei;
    }
}