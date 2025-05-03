using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;
using System.Reflection;

namespace Mahjong2.Lib.HandCalculating.HandDeviding;

/// <summary>
/// 手牌を分解するクラス
/// </summary>
public partial record HandDevider
{
    /// <summary>
    /// 牌リストを実現可能な組み合わせに分解し、組み合わせのリストを返します
    /// </summary>
    /// <param name="tileList">分解する牌リスト</param>
    /// <returns>可能な手牌の組み合わせのリスト</returns>
    public static List<Hand> Devide(TileList tileList)
    {
        var requiredMentsuCount = tileList.Count / 3 + 1;
        var toitsuTiles = FindToitsuTiles(tileList);
        var hands = new List<Hand>();
        foreach (var toitsuTile in toitsuTiles)
        {
            var copiedTileList = tileList;
            copiedTileList = copiedTileList.Remove(toitsuTile, 2);
            var man = FindValidCombinations(copiedTileList, typeof(ManTile));
            var pin = FindValidCombinations(copiedTileList, typeof(PinTile));
            var sou = FindValidCombinations(copiedTileList, typeof(SouTile));
            TileListList honor = [.. Tile.Honors.Where(x => copiedTileList.CountOf(x) == 3).Select(x => new TileList(Enumerable.Repeat(x, 3)))];
            List<List<TileListList>> suits = [[[[.. Enumerable.Repeat(toitsuTile, 2)]]]];
            if (man.Count != 0) { suits.Add(man); }
            if (pin.Count != 0) { suits.Add(pin); }
            if (sou.Count != 0) { suits.Add(sou); }
            if (honor.Count != 0) { suits.Add([honor]); }
            foreach (var prod in Product(suits))
            {
                var h = prod.SelectMany(x => x);
                if (h.Count() == requiredMentsuCount)
                {
                    h = h.OrderBy(x => x[0]);
                    hands.Add([.. h]);
                }
            }
        }
        var resultHands = new List<Hand>();
        foreach (var h in hands)
        {
            if (resultHands.All(x => !x.SequenceEqual([.. h.OrderBy(x => x)])))
            {
                resultHands.Add(h);
            }
        }
        if (toitsuTiles.Count == 7)
        {
            resultHands.Add([.. toitsuTiles.Select(x => new TileList(Enumerable.Repeat(x, 2)))]);
        }
        resultHands.Sort();
        return resultHands;
    }

    /// <summary>
    /// 雀頭候補となる牌のリストを取得する
    /// </summary>
    /// <param name="tileList">牌の集合</param>
    /// <returns>雀頭候補となる牌のリスト</returns>
    private static TileList FindToitsuTiles(TileList tileList)
    {
        // 字牌の同種は2枚のときのみ対子になり得る
        return [.. tileList.Distinct().Where(x => x.IsHonor && tileList.CountOf(x) == 2 || !x.IsHonor && tileList.CountOf(x) >= 2)];
    }

    /// <summary>
    /// 指定された牌種類の有効な面子の組み合わせを探す
    /// </summary>
    /// <param name="tileList">雀頭候補を除いた牌リスト</param>
    /// <param name="tileType">探索する牌の種類</param>
    /// <returns>有効な面子の組み合わせのリスト</returns>
    private static List<TileListList> FindValidCombinations(TileList tileList, Type tileType)
    {
        // 指定の牌種類のTileListを作成する
        var specifiedTypeTileList = new TileList(tileList.Where(tileType.IsInstanceOfType).OrderBy(x => x));
        // nC3全組み合わせを列挙する
        // [1,2,3,4,4]=>[[1,2,3],[1,2,4],[1,3,2],[1,3,4],[1,4,2],[1,4,3],[1,4,4],...]
        var combinations = Combinatorics.Combinations(specifiedTypeTileList, 3).Select(x => new TileList(x));
        var uniqueCombs = combinations.Select(x => new TileList(x.OrderBy(x => x)));
        // 面子だけを抽出
        var validCombs = new TileListList(combinations.Where(x => x.IsShuntsu || x.IsKoutsu));
        if (validCombs.Count == 0) { return []; }
        var neededCombsCount = specifiedTypeTileList.Count / 3;
        // すでに4つ存在する順子は削除する
        foreach (var combs in validCombs.Where(x => x.IsShuntsu).ToList())
        {
            while (true)
            {
                var setsCount = validCombs.Count(x => x == combs);
                if (setsCount > 4) { validCombs = validCombs.Remove(combs); }
                else { break; }
            }
        }
        // 可能な組み合わせを探す
        var combinationsResults = new List<TileListList>();
        var indexCombs = Combinatorics.Combinations(Enumerable.Range(0, validCombs.Count), neededCombsCount);
        foreach (var comb in Combinatorics.Combinations(Enumerable.Range(0, validCombs.Count), neededCombsCount))
        {
            // 各組み合わせが元の牌リストと一致するか検証
            var result = comb.SelectMany(x => validCombs[x]).OrderBy(x => x);
            if (result.SequenceEqual(specifiedTypeTileList))
            {
                var results = new TileListList(comb.Select(x => validCombs[x]));
                if (!combinationsResults.Contains(results))
                {
                    combinationsResults.Add(results);
                }
            }
        }
        return combinationsResults;
    }

    /// <summary>
    /// 複数のリストの直積を計算する
    /// </summary>
    /// <param name="suits">面子の組み合わせのリスト</param>
    /// <returns>直積の結果</returns>
    private static List<List<TileListList>> Product(List<List<TileListList>> suits)
    {
        return suits.Count switch
        {
            1 => suits,
            2 => [.. suits[0].SelectMany(s0 => suits[1].Select(s1 => new[] { s0, s1 }.ToList()))],
            3 => [.. suits[0].SelectMany(s0 => suits[1].SelectMany(s1 => suits[2].Select(s2 => new[] { s0, s1, s2 }.ToList())))],
            4 => [.. suits[0].SelectMany(s0 => suits[1].SelectMany(s1 => suits[2].SelectMany(s2 => suits[3].Select(s3 => new[] { s0, s1, s2, s3 }.ToList()))))],
            5 => [.. suits[0].SelectMany(s0 => suits[1].SelectMany(s1 => suits[2].SelectMany(s2 => suits[3].SelectMany(s3 => suits[4].Select(s4 => new[] { s0, s1, s2, s3, s4 }.ToList())))))],
            _ => [],
        };
    }
}
