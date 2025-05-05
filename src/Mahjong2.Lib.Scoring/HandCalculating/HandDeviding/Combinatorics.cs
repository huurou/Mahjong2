namespace Mahjong2.Lib.Scoring.HandCalculating.HandDeviding;

internal static class Combinatorics
{
    /// <summary>
    /// source の要素から長さ k の順列 (k-permutations) を遅延生成します。
    /// </summary>
    public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> source, int k) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(source);
        // ベースケース: k == 0 → 空の順列を 1 つ返す
        if (k == 0) { yield return []; }
        // 解なしケース: k が不適切 or 要素不足
        var list = source.ToList();
        if (k < 0 || k > list.Count) { yield break; ; }

        // 再帰ステップ：各要素を先頭に選んで残りで長さ k-1 の順列を生成
        for (var i = 0; i < list.Count; i++)
        {
            var head = list[i];
            // 残り要素を取得
            var tail = list.Take(i).Concat(list.Skip(i + 1));
            foreach (var perm in Permutations(tail, k - 1))
            {
                yield return [head, .. perm];
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> source, int k) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(source);
        // ベースケース: k == 0 → 空の組み合わせを 1 つ返す
        if (k == 0) { yield return Enumerable.Empty<T>(); }
        // 解なしケース: k が不適切 or 要素不足
        var list = source.ToList();
        if (k < 0 || k > list.Count) { yield break; }

        // 再帰ステップ：各要素を選ぶか選ばないかで組み合わせを生成
        for (var i = 0; i < list.Count; i++)
        {
            var head = list[i];
            var tail = list.Skip(i + 1);
            foreach (var combination in Combinations(tail, k - 1))
            {
                yield return [head, .. combination];
            }
        }
    }
}
