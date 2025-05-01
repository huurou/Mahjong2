namespace Mahjong2.Lib.HandCalculating;

public static class Combinatorics
{
    /// <summary>
    /// source の要素から長さ k の順列 (k-permutations) を遅延生成します。
    /// 重複する値を区別しない順列を生成します。
    /// </summary>
    public static IEnumerable<IEnumerable<T>> PermutationsUnique<T>(IEnumerable<T> source, int k) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(source);
        // ベースケース: k == 0 → 空の順列を 1 つ返す
        if (k == 0) { return [[]]; }
        // 解なしケース: k が不適切 or 要素不足
        var list = source.ToList();
        if (k < 0 || k > list.Count) { return []; }

        // 再帰ステップ：各要素の個数の辞書を作成しその辞書の値をそれぞれ先頭に選んで残りで長さ k-1 の順列を生成する
        // 辞書にすることで重複する数字を区別しないようにする
        var countDict = new Dictionary<T, int>();
        foreach (var num in source)
        {
            countDict[num] = countDict.GetValueOrDefault(num) + 1;
        }
        return PermutationsUniqueRec(countDict, k);

        static IEnumerable<IEnumerable<U>> PermutationsUniqueRec<U>(Dictionary<U, int> countDict, int k) where U : notnull
        {
            if (k == 0)
            {
                yield return [];
                yield break;
            }
            // 解なし: 要素不足
            if (countDict.Values.Sum() < k) { yield break; }
            foreach (var pair in countDict)
            {
                if (pair.Value == 0) { continue; }
                countDict[pair.Key]--;
                foreach (var tail in PermutationsUniqueRec(countDict, k - 1))
                {
                    yield return [pair.Key, .. tail];
                }
                countDict[pair.Key]++;
            }
        }
    }
}
