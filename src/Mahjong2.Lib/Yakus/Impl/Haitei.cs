using Mahjong2.Lib.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 海底摸月
/// </summary>
internal record Haitei : Yaku
{
    public override int Number => 7;
    public override string Name => "海底撈月";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsHaitei;
    }
}