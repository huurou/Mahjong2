using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.HonotTiles;

/// <summary>
/// 字牌
/// </summary>
internal abstract record HonorTile : Tile, IComparable<HonorTile>
{
    /// <summary>
    /// 文字から字牌に変換を試みます
    /// </summary>
    /// <param name="c">変換する文字</param>
    /// <param name="honorTile">変換された字牌。変換に失敗した場合はnull</param>
    /// <returns>変換に成功した場合はtrue、失敗した場合はfalse</returns>
    public static bool TryFromChar(char c, [NotNullWhen(true)] out HonorTile? honorTile)
    {
        honorTile = null;
        if (WindTile.TryFromChar(c, out var windTile))
        {
            honorTile = windTile;
            return true;
        }
        if (DragonTile.TryFromChar(c, out var dragonTile))
        {
            honorTile = dragonTile;
            return true;
        }
        return false;
    }

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
        var typeComparison = GetHonorTileNum(this).CompareTo(GetHonorTileNum(other));
        if (typeComparison != 0) { return typeComparison; }
        if (this is WindTile thisWindTile && other is WindTile otherWindTile) { return thisWindTile.CompareTo(otherWindTile); }
        if (this is DragonTile thisDragonTile && other is DragonTile otherDraginTile) { return thisDragonTile.CompareTo(otherDraginTile); }
        throw new InvalidOperationException($"不明な字牌の比較です。");

        static int GetHonorTileNum(HonorTile honorTile)
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
