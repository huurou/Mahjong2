using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 清老頭
/// </summary>
public record Chinroutou : Yaku
{
    public override string Name => "清老頭";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.CombineFuuro(fuuroList).All(x => x.All(y => y.IsRoutou));
    }
}