using Mahjong2.Lib.Scoring.Tiles;
using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Scoring.Fuuros;

/// <summary>
/// 副露の集合を表現するクラス
/// </summary>
[CollectionBuilder(typeof(FuuroListBuilder), "Create")]
internal record FuuroList() : IEnumerable<Fuuro>
{
    public int Count => fuuros_.Count;
    /// <summary>
    /// 門前でない副露が存在するかどうかを取得します
    /// 空の場合はfalse
    /// </summary>
    public bool HasOpen => fuuros_.Any(x => x.IsOpen);

    /// <summary>
    /// TileListのリストを取得します
    /// </summary>
    public ImmutableList<TileList> TileLists => [.. fuuros_.Select(x => x.TileList)];

    /// <summary>
    /// 副露のコレクションを保持する不変リスト
    /// </summary>
    private readonly ImmutableList<Fuuro> fuuros_ = [];

    /// <summary>
    /// 指定された副露のコレクションから副露リストを作成します
    /// </summary>
    /// <param name="fuuros">副露のコレクション</param>
    public FuuroList(IEnumerable<Fuuro> fuuros) : this()
    {
        fuuros_ = [.. fuuros];
    }

    /// <summary>
    /// 副露リストの列挙子を取得します
    /// </summary>
    /// <returns>副露リストの列挙子</returns>
    public IEnumerator<Fuuro> GetEnumerator()
    {
        return fuuros_.GetEnumerator();
    }

    /// <summary>
    /// 副露リストの列挙子を取得します
    /// </summary>
    /// <returns>副露リストの列挙子</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// 副露リストの文字列表現を取得します
    /// </summary>
    /// <returns>副露リストの文字列表現</returns>
    public override string ToString()
    {
        return string.Join(" ", fuuros_);
    }

    /// <summary>
    /// 副露リストを構築するためのビルダークラス
    /// </summary>
    internal static class FuuroListBuilder
    {
        /// <summary>
        /// 指定された副露の配列から副露リストを作成します
        /// </summary>
        /// <param name="values">副露の配列</param>
        /// <returns>副露リスト</returns>
        public static FuuroList Create(ReadOnlySpan<Fuuro> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}
