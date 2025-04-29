using Mahjong2.Lib.Scores;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 流し満貫
/// </summary>
public record Nagashimangan : Yaku
{
    public override string Name => "流し満貫";
    public override int HanOpen => 5;
    public override int HanClosed => 5;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation)
    {
        return situation.IsNagashimangan;
    }
}