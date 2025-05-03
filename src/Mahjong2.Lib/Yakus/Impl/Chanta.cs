using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 混全帯么九
/// </summary>
public record Chanta : Yaku
{
    public override int Number => 21;
    public override string Name => "混全帯么九";
    public override int HanOpen => 1;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        var shuntsuCount = combined.Count(x => x.IsShuntsu);
        var routouCount = combined.Count(x => x.Any(y => y.IsRoutou));
        var honorCount = combined.Count(x => x.IsAllHonor);
        return shuntsuCount != 0 && routouCount + honorCount == 5 && routouCount != 0 && honorCount != 0;
    }
}