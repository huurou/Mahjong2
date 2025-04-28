using Mahjong2.Lib.Tiles.HonotTiles;
using Mahjong2.Lib.Tiles.NumberTiles;
using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 牌の集合を表現するクラス
/// </summary>
[CollectionBuilder(typeof(TileListBuilder), "Create")]
public record TileList : IEnumerable<Tile>, IComparable<TileList>
{
    /// <summary>
    /// 全ての牌が萬子かどうか
    /// </summary>
    public bool IsAllMan => tiles_.All(x => x.IsMan);
    /// <summary>
    /// 全ての牌が筒子かどうか
    /// </summary>
    public bool IsAllPin => tiles_.All(x => x.IsPin);
    /// <summary>
    /// 全ての牌が索子かどうか
    /// </summary>
    public bool IsAllSou => tiles_.All(x => x.IsSou);
    /// <summary>
    /// 全ての牌が数牌でかつ同じ種類(萬子/筒子/索子)かどうか
    /// </summary>
    public bool IsAllSameSuit => IsAllMan || IsAllPin || IsAllSou;

    /// <summary>
    /// 対子かどうか
    /// </summary>
    public bool IsToitsu => Count == 2 && this[0] == this[1];
    /// <summary>
    /// 順子かどうか
    /// </summary>
    public bool IsShuntsu
    {
        get
        {
            var numTiles = tiles_.OfType<NumberTile>().ToList();
            return
                IsAllSameSuit && numTiles.Count == 3 &&
                numTiles[0].Number + 1 == numTiles[1].Number &&
                numTiles[1].Number + 1 == numTiles[2].Number;
        }
    }
    /// <summary>
    /// 刻子かどうか
    /// </summary>
    public bool IsKoutsu => Count == 3 && this[0] == this[1] && this[1] == this[2];
    /// <summary>
    /// 槓子かどうか
    /// </summary>
    public bool IsKantsu => Count == 4 && this[0] == this[1] && this[1] == this[2] && this[2] == this[3];

    /// <summary>
    /// インデクサー 指定されたインデックスの牌を取得します
    /// </summary>
    /// <param name="index">取得する牌のインデックス</param>
    /// <returns>指定されたインデックスの牌</returns>
    public Tile this[int index] => tiles_[index];

    /// <summary>
    /// 牌リスト内の牌の数を取得します
    /// </summary>
    public int Count => tiles_.Count;

    private readonly ImmutableList<Tile> tiles_;

    /// <summary>
    /// 空の新しい牌リストを初期化します
    /// </summary>
    public TileList()
    {
        tiles_ = [];
    }

    /// <summary>
    /// 指定の牌のコレクションから新しい牌リストを初期化します
    /// </summary>
    /// <param name="tiles">初期化に使用する牌のコレクション</param>
    public TileList(IEnumerable<Tile> tiles)
    {
        tiles_ = [.. tiles];
    }

    /// <summary>
    /// 文字列から牌リストを初期化します
    /// </summary>
    /// <param name="man">萬子を表す文字列（例："123"）</param>
    /// <param name="pin">筒子を表す文字列（例："456"）</param>
    /// <param name="sou">索子を表す文字列（例："789"）</param>
    /// <param name="honor">字牌を表す文字列（例："tnsp"→"東南西北"）</param>
    public TileList(string man = "", string pin = "", string sou = "", string honor = "")
    {
        var tiles = new List<Tile>();
        // 萬子の変換
        foreach (var c in man)
        {
            if (ManTile.TryFromChar(c, out var manTile))
            {
                tiles.Add(manTile);
            }
        }
        // 筒子の変換
        foreach (var c in pin)
        {
            if (PinTile.TryFromChar(c, out var pinTile))
            {
                tiles.Add(pinTile);
            }
        }
        // 索子の変換
        foreach (var c in sou)
        {
            if (SouTile.TryFromChar(c, out var souTile))
            {
                tiles.Add(souTile);
            }
        }
        // 字牌の変換
        foreach (var c in honor)
        {
            if (HonorTile.TryFromChar(c, out var honorTile))
            {
                tiles.Add(honorTile);
            }
        }
        tiles_ = [.. tiles];
    }

    /// <summary>
    /// 指定の牌を追加した新しい牌リストを返します
    /// </summary>
    /// <param name="tile">追加する牌</param>
    /// <returns>新しい牌リスト</returns>
    public TileList Add(Tile tile)
    {
        return [.. tiles_.Add(tile)];
    }

    /// <summary>
    /// 牌リストの内容をソートした新しい牌リストを返します
    /// </summary>
    /// <returns>ソート済みの新しい牌リスト</returns>
    public TileList Sorted()
    {
        return [.. tiles_.OrderBy(x => x)];
    }

    /// <summary>
    /// 牌リストを別の牌リストと比較します
    /// </summary>
    /// <param name="other">比較対象の牌リスト</param>
    /// <returns>
    /// このリストが比較対象より小さい場合は負の値、等しい場合は0、大きい場合は正の値
    /// </returns>
    public int CompareTo(TileList? other)
    {
        if (other is null) { return 1; }
        var minCount = Math.Min(Count, other.Count);
        for (var i = 0; i < minCount; i++)
        {
            var comparison = this[i].CompareTo(other[i]);
            if (comparison != 0) { return comparison; }
        }
        return Count.CompareTo(other.Count);
    }

    /// <summary>
    /// 牌リスト内の牌を列挙するための列挙子を返します
    /// </summary>
    /// <returns>牌リスト内の牌を列挙するための列挙子</returns>
    public IEnumerator<Tile> GetEnumerator()
    {
        return tiles_.GetEnumerator();
    }

    /// <summary>
    /// 牌リスト内の牌を列挙するための列挙子を返します（非ジェネリック版）
    /// </summary>
    /// <returns>牌リスト内の牌を列挙するための列挙子</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// 小なり演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌リスト</param>
    /// <param name="right">右辺の牌リスト</param>
    /// <returns>左辺が右辺より小さい場合はtrue、そうでない場合はfalse</returns>
    public static bool operator <(TileList? left, TileList? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    /// <summary>
    /// 大なり演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌リスト</param>
    /// <param name="right">右辺の牌リスト</param>
    /// <returns>左辺が右辺より大きい場合はtrue、そうでない場合はfalse</returns>
    public static bool operator >(TileList? left, TileList? right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    /// <summary>
    /// 以下演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌リスト</param>
    /// <param name="right">右辺の牌リスト</param>
    /// <returns>左辺が右辺以下の場合はtrue、そうでない場合はfalse</returns>
    public static bool operator <=(TileList? left, TileList? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    /// <summary>
    /// 以上演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌リスト</param>
    /// <param name="right">右辺の牌リスト</param>
    /// <returns>左辺が右辺以上の場合はtrue、そうでない場合はfalse</returns>
    public static bool operator >=(TileList? left, TileList? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    public static class TileListBuilder
    {
        public static TileList Create(ReadOnlySpan<Tile> values)
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