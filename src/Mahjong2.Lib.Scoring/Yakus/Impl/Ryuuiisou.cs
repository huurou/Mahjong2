using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 緑一色
/// </summary>
internal record Ryuuiisou : Yaku
{
    public override int Number => 39;
    public override string Name => "緑一色";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var greens = new TileList(sou: "23468", honor: "r");
        return hand.CombineFuuro(fuuroList).SelectMany(x => x).All(x => greens.Contains(x));
    }
}