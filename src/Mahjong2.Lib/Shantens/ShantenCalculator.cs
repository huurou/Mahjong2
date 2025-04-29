using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Shantens;

/// <summary>
/// 手牌のシャンテン数を計算するクラス
/// </summary>
public record ShantenCalculator
{
    /// <summary>
    /// 和了を表すシャンテン数
    /// </summary>
    public const int AGARI_SHANTEN = -1;

    /// <summary>
    /// 手牌のシャンテン数を計算する
    /// </summary>
    /// <param name="tileList">シャンテン数を計算する手牌</param>
    /// <param name="useRegular">通常形で計算するかどうか</param>
    /// <param name="useChiitoitsu">七対子形で計算するかどうか</param>
    /// <param name="useKokushi">国士無双形で計算するかどうか</param>
    /// <returns>通常形、七対子形、国士無双形の中で最も小さいシャンテン数</returns>
    /// <exception cref="ArgumentException">手牌の数が14枚を超える場合</exception>
    public static int Calc(TileList tileList, bool useRegular = true, bool useChiitoitsu = true, bool useKokushi = true)
    {
        if (tileList.Count > 14) { throw new ArgumentException($"手牌の数が14個より多いです。tileList:{tileList}", nameof(tileList)); }
        if(!useRegular && !useChiitoitsu && !useKokushi) { throw new ArgumentException("最低でも1つの形を指定してください。"); }
        
        List<int> shantens = [];
        if (useRegular)
        {
            shantens.Add(CalcForRegular(tileList));
        }
        if (useChiitoitsu)
        {
            shantens.Add(CalcForChiitoitsu(tileList));
        }
        if (useKokushi)
        {
            shantens.Add(CalcForKokushimusou(tileList));
        }
        return shantens.Min();
    }

    /// <summary>
    /// 通常形（4面子1雀頭）のシャンテン数を計算する
    /// </summary>
    /// <param name="tileList">シャンテン数を計算する手牌</param>
    /// <returns>通常形のシャンテン数</returns>
    private static int CalcForRegular(TileList tileList)
    {
        var context = new ShantenContext(tileList);
        context = context.ScanHonor();
        context = context with
        {
            MentsuCount = context.MentsuCount + (14 - context.TileList.Count) / 3,
            KantsuNumbers = [.. Tile.Numbers.Where(x => context.TileList.CountOf(x) == 4)]
        };
        return context.ScanNumber();
    }

    /// <summary>
    /// 七対子形のシャンテン数を計算する
    /// </summary>
    /// <param name="tileList">シャンテン数を計算する手牌</param>
    /// <returns>七対子形のシャンテン数</returns>
    private static int CalcForChiitoitsu(TileList tileList)
    {
        var toitsuCount = tileList.Distinct().Count(x => tileList.CountOf(x) >= 2);
        var kindCount = tileList.Distinct().Count();
        return 6 - toitsuCount + Math.Max(0, 7 - kindCount);
    }

    /// <summary>
    /// 国士無双形のシャンテン数を計算する
    /// </summary>
    /// <param name="tileList">シャンテン数を計算する手牌</param>
    /// <returns>国士無双形のシャンテン数</returns>
    private static int CalcForKokushimusou(TileList tileList)
    {
        var yaochuuToitsuCount = Tile.All.Count(x => x.IsYaochu && tileList.CountOf(x) >= 2);
        var yaochuuCount = tileList.Distinct().Count(x => x.IsYaochu);
        return 13 - yaochuuCount - (yaochuuToitsuCount != 0 ? 1 : 0);
    }
}
