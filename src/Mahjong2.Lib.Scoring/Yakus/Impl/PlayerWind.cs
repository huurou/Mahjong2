using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Games;
using Mahjong2.Lib.Scoring.Tiles;
using Mahjong2.Lib.Scoring.Tiles.HonotTiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 自風牌
/// </summary>
internal record PlayerWind : Yaku
{
    public override int Number => 17;
    public override string Name => "自風牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, WinSituation winSituation)
    {
        WindTile windTile = winSituation.PlayerWind switch
        {
            Wind.East => Tile.Ton,
            Wind.South => Tile.Nan,
            Wind.West => Tile.Sha,
            Wind.North => Tile.Pei,
            _ => throw new InvalidOperationException($"不明な風です。PlayerWind:{winSituation.PlayerWind}"),
        };
        return hand.CombineFuuro(fuuroList).IncludesKoutsu(windTile);
    }
}