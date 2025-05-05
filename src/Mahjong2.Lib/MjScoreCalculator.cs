using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib;

public class MjScoreCalculator
{
    public static MjScore CalculateScore(
        IEnumerable<MjTileKind> tiles,
        MjTileKind? winTile,
        IEnumerable<MjFuuro> fuuros,
        IEnumerable<MjTileKind> doraIndicators,
        IEnumerable<MjTileKind> uradoraIndicators
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
