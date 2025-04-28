namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 字牌
/// </summary>
public abstract record HonorTile : Tile
{
    /// <summary>
    /// 字牌を比較します
    /// </summary>
    /// <param name="other">比較対象の字牌</param>
    /// <returns>この字牌が<paramref name="other"/>より小さい場合は負の値、等しい場合は0、大きい場合は正の値</returns>
    /// <exception cref="InvalidOperationException">不明な字牌の比較が行われた場合</exception>
    /// <exception cref="ArgumentException">不明な字牌が指定された場合</exception>
    public int CompareTo(HonorTile? other)
    {
        if (other is null) { return 1; }

        // 牌の種類での比較を最初に行う
        var typeComparison = GetHonorTileTypeValue(this).CompareTo(GetHonorTileTypeValue(other));
        if (typeComparison != 0) { return typeComparison; }
        if (this is WindTile thisWindTile && other is WindTile otherWindTile) { return thisWindTile.CompareTo(otherWindTile); }
        if (this is DragonTile thisDragonTile && other is DragonTile otherDraginTile) { return thisDragonTile.CompareTo(otherDraginTile); }
        throw new InvalidOperationException($"不明な字牌の比較です。 {this} vs {other}");

        static int GetHonorTileTypeValue(HonorTile honorTile)
        {
            return honorTile switch
            {
                WindTile => 0,
                DragonTile => 1,
                _ => throw new ArgumentException("不明な字牌です", nameof(honorTile)),
            };
        }
    }
}

/// <summary>
/// 風牌
/// </summary>
public abstract record WindTile : HonorTile
{
    /// <summary>
    /// 風牌を比較します
    /// </summary>
    /// <param name="other">比較対象の風牌</param>
    /// <returns>この風牌が<paramref name="other"/>より小さい場合は負の値、等しい場合は0、大きい場合は正の値</returns>
    /// <exception cref="ArgumentException">不明な風牌が指定された場合</exception>
    public int CompareTo(WindTile? other)
    {
        if (other is null) { return 1; }

        return GetWindTileTypeValue(this).CompareTo(GetWindTileTypeValue(other));

        static int GetWindTileTypeValue(WindTile windTile)
        {
            return windTile switch
            {
                Tiles.Ton => 0,
                Tiles.Nan => 1,
                Tiles.Sha => 2,
                Tiles.Pei => 3,
                _ => throw new ArgumentException("不明な風牌です", nameof(windTile)),
            };
        }
    }
}

/// <summary>
/// 三元牌
/// </summary>
public abstract record DragonTile : HonorTile
{
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
                Tiles.Haku => 0,
                Tiles.Hatsu => 1,
                Tiles.Chun => 2,
                _ => throw new ArgumentException("不明な三元牌です", nameof(dragonTile)),
            };
        }
    }
}

/// <summary>
/// 東
/// </summary>
public record Ton() : WindTile;
/// <summary>
/// 南
/// </summary>
public record Nan() : WindTile;
/// <summary>
/// 西
/// </summary>
public record Sha() : WindTile;
/// <summary>
/// 北
/// </summary>
public record Pei() : WindTile;

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
