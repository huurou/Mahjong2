using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.NumberTiles;

/// <summary>
/// 数牌
/// </summary>
/// <param name="Number">絵柄の数字</param>
public abstract record NumberTile : Tile, IComparable<NumberTile>
{
    public abstract int Number { get; }

    /// <summary>
    /// 現在の牌から指定された距離だけ離れた数牌を取得します
    /// </summary>
    /// <param name="distance">移動する距離（正の値は大きい数字の牌へ、負の値は小さい数字の牌へ）</param>
    /// <param name="tile">見つかった牌。見つからなかった場合はnull</param>
    /// <returns>指定された距離の牌が存在する場合はtrue、存在しない場合（範囲外の場合）はfalse</returns>
    public abstract bool TryGetAtDistance(int distance, [NotNullWhen(true)] out NumberTile? tile);

    /// <summary>
    /// 数牌を比較します
    /// </summary>
    /// <param name="other">比較対象の数牌</param>
    /// <returns>この数牌が<paramref name="other"/>より小さい場合は負の値、等しい場合は0、大きい場合は正の値</returns>
    /// <exception cref="ArgumentException">不明な数牌が指定された場合</exception>
    public int CompareTo(NumberTile? other)
    {
        if (other is null) { return 1; }

        // 牌の種類での比較を最初に行う
        var typeComparison = GetNumberTileTypeValue(this).CompareTo(GetNumberTileTypeValue(other));
        if (typeComparison != 0) { return typeComparison; }
        return Number.CompareTo(other.Number);

        static int GetNumberTileTypeValue(NumberTile numberTile)
        {
            return numberTile switch
            {
                ManTile => 0,
                PinTile => 1,
                SouTile => 2,
                _ => throw new ArgumentException("不明な数牌です", nameof(numberTile)),
            };
        }
    }
}
