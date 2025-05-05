using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 七対子
/// </summary>
internal record Chiitoitsu : Yaku
{
    public override int Number => 27;
    public override string Name => "七対子";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand)
    {
        return hand.Count == 7 && hand.All(x => x.IsToitsu);
    }
}