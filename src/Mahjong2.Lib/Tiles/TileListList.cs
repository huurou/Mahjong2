using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 牌の集合の集合を表現するクラス
/// </summary>
[CollectionBuilder(typeof(TileListListBuilder), "Create")]
internal record TileListList() : IEnumerable<TileList>, IEquatable<TileListList>, IComparable<TileListList>
{
    /// <summary>
    /// 要素数を取得します
    /// </summary>
    public int Count => tileLists_.Count;

    /// <summary>
    /// 指定したインデックスの<see cref="TileList"/>を取得します
    /// </summary>
    /// <param name="index">インデックス</param>
    /// <returns>指定したインデックスの<see cref="TileList"/></returns>
    public TileList this[int index] => tileLists_[index];

    private readonly ImmutableList<TileList> tileLists_ = [];

    /// <summary>
    /// 指定した牌リストのコレクションから新しい<see cref="TileListList"/>を作成します
    /// </summary>
    /// <param name="tileLists">牌リストのコレクション</param>
    public TileListList(IEnumerable<TileList> tileLists) : this()
    {
        tileLists_ = [.. tileLists];
    }

    /// <summary>
    /// 指定した牌の刻子か槓子が含まれているかどうかを判定します
    /// </summary>
    /// <param name="tile">検索する牌</param>
    /// <returns>刻子または槓子が含まれている場合はtrue、それ以外の場合はfalse</returns>
    public bool IncludesKoutsu(Tile tile)
    {
        return this.Any(x => (x.IsKoutsu || x.IsKantsu) && x[0] == tile);
    }

    public TileListList Remove(TileList combs)
    {
        return [.. tileLists_.Remove(combs)];
    }

    /// <summary>
    /// オブジェクトの文字列表現を返します
    /// </summary>
    /// <returns>オブジェクトの文字列表現</returns>
    public sealed override string ToString()
    {
        return string.Join("", this.Select(x => $"[{x}]"));
    }

    /// <summary>
    /// コレクションの列挙子を返します
    /// </summary>
    /// <returns>コレクションの列挙子</returns>
    public IEnumerator<TileList> GetEnumerator()
    {
        return tileLists_.GetEnumerator();
    }

    /// <summary>
    /// コレクションの列挙子を返します
    /// </summary>
    /// <returns>コレクションの列挙子</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// 指定したオブジェクトが現在のオブジェクトと等しいかどうかを判定します
    /// </summary>
    /// <param name="other">比較するオブジェクト</param>
    /// <returns>等しい場合はtrue、それ以外の場合はfalse</returns>
    public virtual bool Equals(TileListList? other)
    {
        return other is not null && this.OrderBy(x => x).SequenceEqual(other.OrderBy(x => x));
    }

    /// <summary>
    /// オブジェクトのハッシュコードを計算します
    /// </summary>
    /// <returns>このオブジェクトのハッシュコード</returns>
    public override int GetHashCode()
    {
        return tileLists_.Aggregate(0, (hash, tileList) => hash * 31 + tileList.GetHashCode());
    }

    public int CompareTo(TileListList? other)
    {
        if (other is null) { return 1; }
        var min = Math.Min(Count, other.Count);
        for (var i = 0; i < min; i++)
        {
            if (this[i] > other[i]) { return 1; }
            if (this[i] < other[i]) { return -1; }
        }
        return Count.CompareTo(other.Count);
    }

    /// <summary>
    /// TileListListのコレクションビルダーを提供するクラスです
    /// </summary>
    internal static class TileListListBuilder
    {
        /// <summary>
        /// 指定した牌リストの配列から新しい<see cref="TileListList"/>を作成します
        /// </summary>
        /// <param name="values">牌リストの配列</param>
        /// <returns>新しい<see cref="TileListList"/>オブジェクト</returns>
        public static TileListList Create(ReadOnlySpan<TileList> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}
