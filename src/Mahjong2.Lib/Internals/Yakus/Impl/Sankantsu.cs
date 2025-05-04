using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// 三槓子
/// </summary>
internal record Sankantsu : Yaku
{
    public override int Number => 25;
    public override string Name => "三槓子";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.CombineFuuro(fuuroList).Count(x => x.IsKantsu) == 3;
    }
}