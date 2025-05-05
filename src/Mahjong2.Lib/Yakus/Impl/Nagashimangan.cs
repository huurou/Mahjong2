using Mahjong2.Lib.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 流し満貫
/// </summary>
internal record Nagashimangan : Yaku
{
    public override int Number => 9;
    public override string Name => "流し満貫";
    public override int HanOpen => 5;
    public override int HanClosed => 5;
    public override bool IsYakuman => false;

    public static bool Valid( WinSituation winSituation)
    {
        return winSituation.IsNagashimangan;
    }
}