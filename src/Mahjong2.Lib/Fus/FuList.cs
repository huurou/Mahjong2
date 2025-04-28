using System.Collections;
using System.Collections.Immutable;

namespace Mahjong2.Lib.Fus;

/// <summary>
/// 符の集合を表現するクラス
/// </summary>
public record FuList : IEnumerable<Fu>
{
    /// <summary>
    /// 符の数を取得します
    /// </summary>
    public int Count => fus_.Count;

    /// <summary>
    /// 符の合計値を取得します
    /// 七対子の場合は25符固定、それ以外は10の単位に切り上げます
    /// </summary>
    public int Total =>
        Count == 0 ? 0
        : this.Contains(Fu.Chiitoitsu) ? 25
        : (this.Sum(x => x.Value) + 9) / 10 * 10; // 10の単位に切り上げる

    private readonly ImmutableList<Fu> fus_;

    public FuList()
    {
        fus_ = [];
    }

    /// <summary>
    /// 指定された符のコレクションから新しい符リストを初期化します
    /// </summary>
    /// <param name="fus">符のコレクション</param>
    public FuList(IEnumerable<Fu> fus)
    {
        fus_ = [.. fus];
    }

    /// <summary>
    /// 符リストの文字列表現を取得します
    /// 「合計符数 符1,符2,...」の形式で表示します
    /// </summary>
    /// <returns>符リストの文字列表現</returns>
    public sealed override string ToString()
    {
        return $"{Total}符 {string.Join(',', fus_)}";
    }

    public IEnumerator<Fu> GetEnumerator()
    {
        return fus_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
