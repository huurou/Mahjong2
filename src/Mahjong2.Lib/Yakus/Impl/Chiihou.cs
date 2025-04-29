using Mahjong2.Lib.Scores;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 地和
/// </summary>
public record Chiihou : Yaku
{
    public override string Name => "地和";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(WinSituation winSituation)
    {
        return winSituation.IsChiihou;
    }
}