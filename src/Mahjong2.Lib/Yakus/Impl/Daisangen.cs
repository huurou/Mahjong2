using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 大三元
/// </summary>
public record Daisangen : Yaku
{
    public override string Name => "大三元";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        return combined.Count(x => (x.IsKoutsu || x.IsKantsu) && x.All(x => x.IsDragon)) == 3;
    }
}