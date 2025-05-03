using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 門前清自摸和
/// </summary>
public record Tsumo : Yaku
{
    public override int Number => 3;
    public override string Name => "門前清自摸和";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(FuuroList fuuroList, WinSituation winSituation)
    {
        return !fuuroList.HasOpen && winSituation.IsTsumo;
    }
}