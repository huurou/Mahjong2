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
public record TileList() : IEnumerable<Tile>, IComparable<TileList>, IEquatable<TileList>
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
    /// 全ての牌が数牌かどうか
    /// </summary>
    public bool IsAllNumber => tiles_.All(x => x.IsNumber);
    /// <summary>
    /// 全ての牌が字牌かどうか
    /// </summary>
    public bool IsAllHonor => tiles_.All(x => x.IsHonor);
    /// <summary>
    /// 全ての牌が風牌かどうか
    /// </summary>
    public bool IsAllWind => tiles_.All(x => x.IsWind);
    /// <summary>
    /// 全ての牌が三元牌かどうか
    /// </summary>
    public bool IsAllDragon => tiles_.All(x => x.IsDragon);

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

    private readonly ImmutableList<Tile> tiles_ = [];

    /// <summary>
    /// 指定の牌のコレクションから新しい牌リストを初期化します
    /// </summary>
    /// <param name="tiles">初期化に使用する牌のコレクション</param>
    public TileList(IEnumerable<Tile> tiles) : this()
    {
        tiles_ = [.. tiles];
    }

    /// <summary>
    /// 文字列から牌リストを初期化します
    /// </summary>
    /// <param name="man">萬子の数字を並べた文字列</param>
    /// <param name="pin">筒子の数字を並べた文字列</param>
    /// <param name="sou">索子の数字を並べた文字列</param>
    /// <param name="honor">字牌を表す文字列 "tnsphrc" or "東南西北白發中"</param>
    public TileList(string man = "", string pin = "", string sou = "", string honor = "") : this()
    {
        var tiles = new List<Tile>();
        // 萬子の変換
        foreach (var c in man)
        {
            if (ManTile.TryFromChar(c, out var manTile))
            {
                tiles.Add(manTile);
            }
            else { throw new ArgumentException($"入力された萬子の文字が正しくありません。 c:{c}", nameof(man)); }
        }
        // 筒子の変換
        foreach (var c in pin)
        {
            if (PinTile.TryFromChar(c, out var pinTile))
            {
                tiles.Add(pinTile);
            }
            else { throw new ArgumentException($"入力された筒子の文字が正しくありません。 c:{c}", nameof(pin)); }
        }
        // 索子の変換
        foreach (var c in sou)
        {
            if (SouTile.TryFromChar(c, out var souTile))
            {
                tiles.Add(souTile);
            }
            else { throw new ArgumentException($"入力された索子の文字が正しくありません。 c:{c}", nameof(sou)); }
        }
        // 字牌の変換
        foreach (var c in honor)
        {
            if (HonorTile.TryFromChar(c, out var honorTile))
            {
                tiles.Add(honorTile);
            }
            else { throw new ArgumentException($"入力された字牌の文字が正しくありません。 c:{c}", nameof(honor)); }
        }
        tiles_ = [.. tiles];
    }

    /// <summary>
    /// 牌リストの内容をソートした新しい牌リストを返します
    /// </summary>
    /// <remarks>
    /// ソートの順序：萬子→筒子→索子→風牌（東南西北）→三元牌（白發中）の順
    /// 同じ種類の牌は数字順（1,2,3...）、字牌は定義された順序に従います
    /// </remarks>
    /// <returns>ソート済みの新しい牌リスト</returns>
    public TileList Sorted()
    {
        return [.. tiles_.OrderBy(x => x)];
    }

    /// <summary>
    /// 指定された牌がこのリスト内に何個存在するかを数えます
    /// </summary>
    /// <param name="tile">数える対象の牌</param>
    /// <returns>指定された牌の数</returns>
    public int CountOf(Tile tile)
    {
        return tiles_.Count(x => x == tile);
    }

    /// <summary>
    /// 指定された牌をリストから指定された個数だけ削除した新しい牌リストを返します
    /// </summary>
    /// <param name="tile">削除する牌</param>
    /// <param name="count">削除する個数（デフォルトは1）</param>
    /// <returns>牌を削除した新しい牌リスト</returns>
    /// <exception cref="ArgumentException">指定された牌が存在しないか、指定された個数だけ存在しない場合</exception>
    public TileList Remove(Tile tile, int count = 1)
    {
        var tiles = tiles_;
        for (var i = 0; i < count; i++)
        {
            if (!tiles.Contains(tile)) { throw new ArgumentException($"指定牌がありません。 tile:{tile} count:{count}", nameof(tile)); }
            tiles = tiles.Remove(tile);
        }
        return [.. tiles];
    }

    /// <summary>
    /// 指定された牌のコレクションをリストから削除した新しい牌リストを返します
    /// </summary>
    /// <param name="tiles">削除する牌のコレクション</param>
    /// <returns>牌を削除した新しい牌リスト</returns>
    /// <exception cref="ArgumentException">指定された牌が存在しない場合</exception>
    public TileList Remove(IEnumerable<Tile> tiles)
    {
        var tileList = this;
        foreach (var tile in tiles)
        {
            tileList = tileList.Remove(tile);
        }
        return tileList;
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

    /// <summary>
    /// 指定されたTileListオブジェクトと現在のTileListオブジェクトが等しいかどうかを判断します
    /// </summary>
    /// <param name="other">このオブジェクトと比較する牌リスト</param>
    /// <returns>指定されたオブジェクトと現在のオブジェクトが等しい場合はtrue、それ以外の場合はfalse</returns>
    public virtual bool Equals(TileList? other)
    {
        if (other is null) { return false; }
        if (ReferenceEquals(this, other)) { return true; }

        return tiles_.SequenceEqual(other.tiles_);
    }

    /// <summary>
    /// オブジェクトのハッシュコードを計算します
    /// </summary>
    /// <returns>このオブジェクトのハッシュコード</returns>
    public override int GetHashCode()
    {
        return tiles_.Aggregate(0, (hash, tile) => hash * 31 + tile.GetHashCode());
    }

    /// <summary>
    /// 牌リストの文字列表現を取得します
    /// </summary>
    /// <returns>牌リストに含まれる全ての牌を連結した文字列</returns>
    public sealed override string ToString()
    {
        return string.Join("", this);
    }

    public static class TileListBuilder
    {
        /// <summary>
        /// 指定された牌の配列から新しいTileListを作成します
        /// </summary>
        /// <param name="values">TileListに含める牌の配列</param>
        /// <returns>指定された牌を含む新しいTileList</returns>
        public static TileList Create(ReadOnlySpan<Tile> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}