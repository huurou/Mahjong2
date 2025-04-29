using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.HonotTiles;

/// <summary>
/// 風牌
/// </summary>
public abstract record WindTile : HonorTile, IComparable<WindTile>
{
    /// <summary>
    /// 文字から風牌に変換を試みます
    /// </summary>
    /// <param name="c">変換する文字</param>
    /// <param name="windTile">変換された風牌。変換に失敗した場合はnull</param>
    /// <returns>変換に成功した場合はtrue、失敗した場合はfalse</returns>
    public static bool TryFromChar(char c, [NotNullWhen(true)] out WindTile? windTile)
    {
        windTile = c switch
        {
            't' or '東' => Ton,
            'n' or '南' => Nan,
            's' or '西' => Sha,
            'p' or '北' => Pei,
            _ => null,
        };
        return windTile is not null;
    }

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
                HonotTiles.Ton => 0,
                HonotTiles.Nan => 1,
                HonotTiles.Sha => 2,
                HonotTiles.Pei => 3,
                _ => throw new ArgumentException("不明な風牌です", nameof(windTile)),
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
            HonotTiles.Ton => "東",
            HonotTiles.Nan => "南",
            HonotTiles.Sha => "西",
            HonotTiles.Pei => "北",
            _ => throw new InvalidOperationException($"不明な風牌です。"),
        };
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
