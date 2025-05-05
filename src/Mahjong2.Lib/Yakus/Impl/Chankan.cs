using Mahjong2.Lib.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 槍槓
/// </summary>
internal record Chankan : Yaku
{
    public override int Number => 5;
    public override string Name => "槍槓";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsChankan;
    }
}
