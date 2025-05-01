using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 緑一色
/// </summary>
public record Ryuuiisou : Yaku
{
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