using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 大四喜
/// </summary>
internal record Daisuushii : Yaku
{
    public override int Number => 38;
    public override string Name => "大四喜";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        return combined.Count(x => (x.IsKoutsu || x.IsKantsu) && x.IsAllWind) == 4;
    }
}