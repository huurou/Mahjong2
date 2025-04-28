using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.HonotTiles;

/// <summary>
/// 三元牌
/// </summary>
public abstract record DragonTile : HonorTile, IComparable<DragonTile>
{
    /// <summary>
    /// 文字から三元牌に変換を試みます
    /// </summary>
    /// <param name="c">変換する文字</param>
    /// <param name="dragonTile">変換された三元牌。変換に失敗した場合はnull</param>
    /// <returns>変換に成功した場合はtrue、失敗した場合はfalse</returns>
    public static bool TryFromChar(char c, [NotNullWhen(true)] out DragonTile? dragonTile)
    {
        dragonTile = c switch
        {
            'h' or '白' => Haku,
            'r' or '發' => Hatsu,
            'c' or '中' => Chun,
            _ => null,
        };
        return dragonTile is not null;
    }

    /// <summary>
    /// 三元牌を比較します
    /// </summary>
    /// <param name="other">比較対象の三元牌</param>
    /// <returns>この三元牌が<paramref name="other"/>より小さい場合は負の値、等しい場合は0、大きい場合は正の値</returns>
    /// <exception cref="ArgumentException">不明な三元牌が指定された場合</exception>
    public int CompareTo(DragonTile? other)
    {
        if (other is null) { return 1; }

        return GetDragonTileTypeValue(this).CompareTo(GetDragonTileTypeValue(other));

        static int GetDragonTileTypeValue(DragonTile dragonTile)
        {
            return dragonTile switch
            {
                HonotTiles.Haku => 0,
                HonotTiles.Hatsu => 1,
                HonotTiles.Chun => 2,
                _ => throw new ArgumentException("不明な三元牌です", nameof(dragonTile)),
            };
        }
    }

    /// <summary>
    /// 牌の表示名を取得する
    /// </summary>
    /// <returns>牌の表示名</returns>
    public sealed override string ToString()
    {
        return this switch
        {
            HonotTiles.Haku => "白",
            HonotTiles.Hatsu => "發",
            HonotTiles.Chun => "中",
            _ => throw new InvalidOperationException($"不明な字牌です:{this}"),
        };
    }
}

/// <summary>
/// 白
/// </summary>
public record Haku() : DragonTile;
/// <summary>
/// 發
/// </summary>
public record Hatsu() : DragonTile;
/// <summary>
/// 中
/// </summary>
public record Chun() : DragonTile;
