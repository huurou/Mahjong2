using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 国士無双十三面待ち
/// </summary>
public record Kokushimusou13menmachi : Yaku
{
    public override string Name => "国士無双十三面待ち";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, Tile winTile)
    {
        return Kokushimusou.Valid(hand) &&
            hand.SelectMany(x => x).Count(x => x == winTile) == 2;
    }
}