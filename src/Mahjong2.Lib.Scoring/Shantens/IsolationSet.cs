using Mahjong2.Lib.Scoring.Tiles;
using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Scoring.Shantens;

/// <summary>
/// 孤立牌の集合を表すクラスです。
/// 雀頭や面子、塔子などに含まれない牌を管理します。
/// </summary>
[CollectionBuilder(typeof(IsolationSetBuilder), "Create")]
internal record IsolationSet() : IEnumerable<Tile>
{
    /// <summary>
    /// 要素数を取得します。
    /// </summary>
    public int Count => tileSet_.Count;

    private readonly ImmutableHashSet<Tile> tileSet_ = [];

    /// <summary>
    /// 指定された牌のコレクションから新しい孤立牌セットを作成します。
    /// </summary>
    /// <param name="tiles">初期化に使用する牌のコレクション</param>
    public IsolationSet(IEnumerable<Tile> tiles) : this()
    {
        tileSet_ = [.. tiles];
    }

    /// <summary>
    /// 孤立牌セットの列挙子を取得します。
    /// </summary>
    /// <returns>孤立牌セットの列挙子</returns>
    public IEnumerator<Tile> GetEnumerator()
    {
        return tileSet_.GetEnumerator();
    }

    /// <summary>
    /// 非ジェネリックコレクションの列挙子を取得します。
    /// </summary>
    /// <returns>非ジェネリックコレクションの列挙子</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// IsolationSetのコレクションビルダーを提供するクラスです。
    /// </summary>
    internal static class IsolationSetBuilder
    {
        /// <summary>
        /// ReadOnlySpanからIsolationSetを作成します。
        /// </summary>
        /// <param name="values">IsolationSetに含める牌のReadOnlySpan</param>
        /// <returns>作成されたIsolationSet</returns>
        public static IsolationSet Create(ReadOnlySpan<Tile> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}