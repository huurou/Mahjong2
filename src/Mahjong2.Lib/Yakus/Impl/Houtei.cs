using Mahjong2.Lib.Scores;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 河底撈魚
/// </summary>
public record Houtei : Yaku
{
    public override string Name => "河底撈魚";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation)
    {
        return situation.IsHoutei;
    }
}