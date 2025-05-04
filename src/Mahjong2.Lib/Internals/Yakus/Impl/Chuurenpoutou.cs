using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Tiles.NumberTiles;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// 九蓮宝燈
/// </summary>
internal record Chuurenpoutou : Yaku
{
    public override int Number => 34;
    public override string Name => "九蓮宝燈";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand)
    {
        if (!new TileList(hand.SelectMany(x => x)).IsAllSameSuit) { return false; }
        var mans = hand.Where(x => x.IsAllMan);
        var pins = hand.Where(x => x.IsAllPin);
        var sous = hand.Where(x => x.IsAllSou);
        var suits = new[] { mans, pins, sous }.Where(x => x.Any());
        var nums = hand.SelectMany(x => x.OfType<NumberTile>(), (_, x) => x.Number).ToList();
        // numsは 1112345678999+1～9のいずれかになっているはず
        foreach (var n in new[] { 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9 })
        {
            if (!nums.Remove(n)) { return false; }
        }
        return nums.Count == 1;
    }
}