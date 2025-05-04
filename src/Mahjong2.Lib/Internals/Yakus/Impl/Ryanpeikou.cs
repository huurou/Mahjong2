using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// 二盃口
/// </summary>
internal record Ryanpeikou : Yaku
{
    public override int Number => 31;
    public override string Name => "二盃口";
    public override int HanOpen => 0;
    public override int HanClosed => 3;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        if (fuuroList.HasOpen) { return false; }
        var shuntsus = hand.Where(x => x.IsShuntsu);
        var counts = shuntsus.Select(x => shuntsus.Count(x.Equals));
        return counts.Count(x => x >= 2) == 4;
    }
}