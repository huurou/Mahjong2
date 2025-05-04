using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// 字一色
/// </summary>
internal record Tsuuiisou : Yaku
{
    public override int Number => 41;
    public override string Name => "字一色";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.CombineFuuro(fuuroList).SelectMany(x => x).All(x => x.IsHonor);
    }
}