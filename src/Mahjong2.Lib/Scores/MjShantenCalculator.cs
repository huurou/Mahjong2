using Mahjong2.Lib.Internals.Shantens;

namespace Mahjong2.Lib.Scores;

public static class MjShantenCalculator
{
    /// <summary>
    /// 和了形のシャンテン数:-1
    /// </summary>
    public const int AGARI_SHANTEN = -1;

    public static int CalculateShanten(IEnumerable<MjTileType> tiles)
    {
        return ShantenCalculator.Calc(tiles.ToTileList());
    }
}
