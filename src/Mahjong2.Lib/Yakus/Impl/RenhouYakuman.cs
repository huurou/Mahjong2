using Mahjong2.Lib.Scores;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 人和
/// </summary>
public record RenhouYakuman : Yaku
{
    public override string Name => "人和";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(WinSituation situation, GameRules gameRules)
    {
        return situation.IsRenhou && gameRules.RenhouAsYakumanEnabled;
    }
}