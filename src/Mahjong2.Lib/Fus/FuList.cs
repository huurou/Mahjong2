using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Fus;

/// <summary>
/// 符の集合を表現するクラス
/// </summary>
[CollectionBuilder(typeof(FuListBuilder), "Create")]
public record FuList() : IEnumerable<Fu>, IEquatable<FuList>
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
        : this.Contains(Fu.ChiitoitsuFu) ? 25
        : (this.Sum(x => x.Value) + 9) / 10 * 10; // 10の単位に切り上げる

    private readonly ImmutableList<Fu> fus_ = [];

    /// <summary>
    /// 指定された符のコレクションから新しい符リストを初期化します
    /// </summary>
    /// <param name="fus">符のコレクション</param>
    public FuList(IEnumerable<Fu> fus) : this()
    {
        fus_ = [.. fus];
    }

    public FuList Add(Fu fu)
    {
        return [.. fus_.Add(fu)];
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

    /// <summary>
    /// 指定されたFuListオブジェクトと現在のFuListオブジェクトが等しいかどうかを判断します
    /// </summary>
    /// <param name="other">比較対象のFuListオブジェクト</param>
    /// <returns>指定されたFuListが現在のFuListと等しい場合はtrue、それ以外の場合はfalse</returns>
    public virtual bool Equals(FuList? other)
    {
        if (other is null) { return false; }
        return this.SequenceEqual(other);
    }

    /// <summary>
    /// オブジェクトのハッシュコードを計算します
    /// </summary>
    /// <returns>このオブジェクトのハッシュコード</returns>
    public override int GetHashCode()
    {
        return fus_.Aggregate(0, (hash, tile) => hash * 31 + tile.GetHashCode());
    }

    public static class FuListBuilder
    {
        public static FuList Create(ReadOnlySpan<Fu> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0028 // コレクションの初期化を簡略化します
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0028 // コレクションの初期化を簡略化します
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}
