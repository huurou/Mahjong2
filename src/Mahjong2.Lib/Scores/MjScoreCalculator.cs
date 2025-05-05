using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Scores;

public class MjScoreCalculator
{
    public static MjScore CalculateScore(
        IEnumerable<MjTileType> tiles,
        MjTileType? winTile,
        IEnumerable<MjFuuro> fuuros,
        IEnumerable<MjTileType> doraIndicators,
        IEnumerable<MjTileType> uradoraIndicators
    )
    {
        var fuuroList = fuuros.ToFuuroList();
        var result = HandCalculator.Calc(tiles.ToTileList(), winTile?.ToTile(), fuuroList, doraIndicators.ToTileList(), uradoraIndicators.ToTileList());
        return new(
            result.Fu, result.Han,
            [.. result.YakuList.Select(x => new MjYakuResult(x.ToMjYaku(), fuuroList.HasOpen ? x.HanOpen : x.HanClosed))],
            result.Score.Main, result.Score.Sub
        );
    }
}
