using Mahjong2.Lib.Scoring.Fuuros;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Scoring.Tiles;

/// <summary>
/// 晒していない手牌 <see cref="TileListList"/>のラッパー
/// </summary>
[CollectionBuilder(typeof(HandBuilder), "Create")]
internal record Hand : TileListList
{
    /// <summary>
    /// 空の手牌を作成します
    /// </summary>
    public Hand() : base()
    {
    }

    /// <summary>
    /// 指定した<see cref="TileList"/>のコレクションから手牌を作成します
    /// </summary>
    /// <param name="tileLists"><see cref="TileList"/>のコレクション</param>
    public Hand(IEnumerable<TileList> tileLists) : base(tileLists)
    {
    }

    /// <summary>
    /// 手牌と副露を結合した<see cref="TileListList"/>を作成します
    /// </summary>
    /// <param name="fuuroList">結合する副露リスト</param>
    /// <returns>手牌と副露を結合した<see cref="TileListList"/></returns>
    public TileListList CombineFuuro(FuuroList fuuroList)
    {
        return new([.. this, .. fuuroList.TileLists]);
    }

    public List<TileList> GetWinGroups(Tile winTile)
    {
        return [.. this.Where(x => x.Contains(winTile)).Distinct()];
    }

    /// <summary>
    /// <see cref="HandBuilder"/>のコレクションビルダーを提供するクラスです
    /// </summary>
    internal static class HandBuilder
    {
        /// <summary>
        /// 指定した<see cref="TileList"/>の配列から新しい<see cref="HandBuilder"/>を作成します
        /// </summary>
        /// <param name="values">牌リストの配列</param>
        /// <returns>新しい<see cref="HandBuilder"/>オブジェクト</returns>
        public static Hand Create(ReadOnlySpan<TileList> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}
