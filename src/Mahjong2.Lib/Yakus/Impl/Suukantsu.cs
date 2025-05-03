using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 四槓子
/// </summary>
public record Suukantsu : Yaku
{
    public override int Number => 40;
    public override string Name => "四槓子";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.CombineFuuro(fuuroList).Count(x => x.IsKantsu) == 4;
    }
}