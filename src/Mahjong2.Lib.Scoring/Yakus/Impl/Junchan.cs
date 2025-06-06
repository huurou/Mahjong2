using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 純全帯么九
/// </summary>
internal record Junchan : Yaku
{
    public override int Number => 30;
    public override string Name => "純全帯么九";
    public override int HanOpen => 2;
    public override int HanClosed => 3;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        var shuntsus = combined.Count(x => x.IsShuntsu);
        var routous = combined.Count(x => x.Any(x => x.IsRoutou));
        return shuntsus != 0 && routous == 5;
    }
}