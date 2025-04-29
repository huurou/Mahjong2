using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 字一色
/// </summary>
public record Tsuuiisou : Yaku
{
    public override string Name => "字一色";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand)
    {
        return hand.SelectMany(x => x).All(x => x.IsHonor);
    }
}