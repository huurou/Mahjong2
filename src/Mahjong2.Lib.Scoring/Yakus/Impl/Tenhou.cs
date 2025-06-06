using Mahjong2.Lib.Scoring.Games;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 天和
/// </summary>
internal record Tenhou : Yaku
{
    public override int Number => 48;
    public override string Name => "天和";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsTenhou;
    }
}