using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.HonotTiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 場風牌
/// </summary>
internal record RoundWind : Yaku
{
    public override int Number => 18;
    public override string Name => "場風牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, WinSituation winSituation)
    {
        WindTile windTile = winSituation.RoundWind switch
        {
            Wind.East => Tile.Ton,
            Wind.South => Tile.Nan,
            Wind.West => Tile.Sha,
            Wind.North => Tile.Pei,
            _ => throw new InvalidOperationException($"不明な風です。RoundWind:{winSituation.RoundWind}"),
        };
        return hand.CombineFuuro(fuuroList).IncludesKoutsu(windTile);
    }
}