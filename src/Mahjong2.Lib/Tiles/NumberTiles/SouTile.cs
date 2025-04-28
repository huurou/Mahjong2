using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.NumberTiles;

/// <summary>
/// 索子
/// </summary>
public abstract record SouTile : NumberTile
{
    /// <summary>
    /// 数字から対応する索子を取得します
    /// </summary>
    /// <param name="number">索子の数（1～9）</param>
    /// <param name="souTile">見つかった索子。範囲外の場合はnull</param>
    /// <returns>指定された数の索子が存在する場合はtrue、存在しない場合はfalse</returns>
    public static bool TryFromNumber(int number, [NotNullWhen(true)] out SouTile? souTile)
    {
        souTile = number switch
        {
            1 => Sou1,
            2 => Sou2,
            3 => Sou3,
            4 => Sou4,
            5 => Sou5,
            6 => Sou6,
            7 => Sou7,
            8 => Sou8,
            9 => Sou9,
            _ => null,
        };
        return souTile is not null;
    }

    /// <summary>
    /// 文字から索子に変換を試みます
    /// </summary>
    /// <param name="c">変換する文字</param>
    /// <param name="souTile">変換された索子。変換に失敗した場合はnull</param>
    /// <returns>変換に成功した場合はtrue、失敗した場合はfalse</returns>
    public static bool TryFromChar(char c, [NotNullWhen(true)] out SouTile? souTile)
    {
        souTile = null;
        return int.TryParse(c.ToString(), out var num) && TryFromNumber(num, out souTile);
    }

    /// <summary>
    /// 現在の索子から指定された距離だけ離れた索子を取得します
    /// </summary>
    /// <param name="distance">移動する距離（正の値は大きい数字の牌へ、負の値は小さい数字の牌へ）</param>
    /// <param name="tile">見つかった牌。見つからなかった場合はnull</param>
    /// <returns>指定された距離の牌が存在する場合はtrue、存在しない場合（範囲外の場合）はfalse</returns>
    public override bool TryGetAtDistance(int distance, [NotNullWhen(true)] out NumberTile? tile)
    {
        var result = TryFromNumber(Number + distance, out var souTile);
        tile = souTile;
        return result;
    }

    /// <summary>
    /// 牌の表示名を取得する
    /// </summary>
    /// <returns>牌の表示名</returns>
    public sealed override string ToString()
    {
        return Number.ToString();
    }
}

/// <summary>
/// 一索
/// </summary>
public record Sou1() : SouTile
{
    public override int Number => 1;
}
/// <summary>
/// 二索
/// </summary>
public record Sou2() : SouTile
{
    public override int Number => 2;
}
/// <summary>
/// 三索
/// </summary>
public record Sou3() : SouTile
{
    public override int Number => 3;
}
/// <summary>
/// 四索
/// </summary>
public record Sou4() : SouTile
{
    public override int Number => 4;
}
/// <summary>
/// 五索
/// </summary>
public record Sou5() : SouTile
{
    public override int Number => 5;
}
/// <summary>
/// 六索
/// </summary>
public record Sou6() : SouTile
{
    public override int Number => 6;
}
/// <summary>
/// 七索
/// </summary>
public record Sou7() : SouTile
{
    public override int Number => 7;
}
/// <summary>
/// 八索
/// </summary>
public record Sou8() : SouTile
{
    public override int Number => 8;
}
/// <summary>
/// 九索
/// </summary>
public record Sou9() : SouTile
{
    public override int Number => 9;
}
