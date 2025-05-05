using Mahjong2.Lib.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 純正九蓮宝燈
/// </summary>
internal record JunseiChuurenpoutou : Yaku
{
    public override int Number => 47;
    public override string Name => "純正九蓮宝燈";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, Tile winTile, GameRules gameRules)
    {
        if (!Chuurenpoutou.Valid(hand) || !gameRules.DoubleYakumanEnabled) { return false; }
        var nums = hand.SelectMany(x => x.OfType<NumberTile>(), (_, x) => x.Number).ToList();
        // 純正九蓮宝燈は和了牌以外が1112345678999で和了牌が1～9のいずれかが条件
        if (nums.Count(x => x == (winTile as NumberTile)?.Number) is not 2 and not 4) { return false; }
        if (nums.Count(x => x == 1) < 3 || nums.Count(x => x == 9) < 3) { return false; }
        nums.Remove(1);
        nums.Remove(1);
        nums.Remove(9);
        nums.Remove(9);
        foreach (var n in Enumerable.Range(1, 9))
        {
            nums.Remove(n);
        }
        return nums.Count == 1;
    }
}