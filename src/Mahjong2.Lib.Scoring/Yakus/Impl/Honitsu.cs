using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 混一色
/// </summary>
internal record Honitsu : Yaku
{
    public override int Number => 29;
    public override string Name => "混一色";
    public override int HanOpen => 2;
    public override int HanClosed => 3;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        var manCount = combined.Count(x => x.IsAllMan);
        var pinCount = combined.Count(x => x.IsAllPin);
        var souCount = combined.Count(x => x.IsAllSou);
        var honorCount = combined.Count(x => x.IsAllHonor);
        return new[] { manCount, pinCount, souCount }.Count(x => x != 0) == 1 && honorCount != 0;
    }
}