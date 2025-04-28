using System.Collections;
using System.Collections.Immutable;

namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 牌の集合を表現するクラス
/// </summary>
public record TileList : IEnumerable<Tile>
{
    /// <summary>
    /// 対子かどうか
    /// </summary>
    public bool IsToitsu => Count == 2 && this[0] == this[1];

    public Tile this[int index] => tiles_[index];

    public int Count => tiles_.Count;

    private readonly ImmutableList<Tile> tiles_;

    public TileList()
    {
        tiles_ = [];
    }

    /// <summary>
    /// 指定の牌のコレクションから新しい牌リストを初期化します
    /// </summary>
    /// <param name="tiles"></param>
    public TileList(IEnumerable<Tile> tiles)
    {
        tiles_ = [.. tiles];
    }

    public IEnumerator<Tile> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}