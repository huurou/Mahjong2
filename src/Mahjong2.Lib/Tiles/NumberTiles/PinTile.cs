using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.NumberTiles;

/// <summary>
/// 筒子
/// </summary>
public abstract record PinTile : NumberTile
{
    /// <summary>
    /// 数字から対応する筒子を取得します
    /// </summary>
    /// <param name="number">筒子の数（1～9）</param>
    /// <param name="pinTile">見つかった筒子。範囲外の場合はnull</param>
    /// <returns>指定された数の筒子が存在する場合はtrue、存在しない場合はfalse</returns>
    public static bool TryFromNumber(int number, [NotNullWhen(true)] out PinTile? pinTile)
    {
        pinTile = number switch
        {
            1 => Pin1,
            2 => Pin2,
            3 => Pin3,
            4 => Pin4,
            5 => Pin5,
            6 => Pin6,
            7 => Pin7,
            8 => Pin8,
            9 => Pin9,
            _ => null,
        };
        return pinTile is not null;
    }

    /// <summary>
    /// 文字から筒子に変換を試みます
    /// </summary>
    /// <param name="c">変換する文字</param>
    /// <param name="pinTile">変換された筒子。変換に失敗した場合はnull</param>
    /// <returns>変換に成功した場合はtrue、失敗した場合はfalse</returns>
    public static bool TryFromChar(char c, [NotNullWhen(true)] out PinTile? pinTile)
    {
        pinTile = null;
        return int.TryParse(c.ToString(), out var num) && TryFromNumber(num, out pinTile);
    }

    /// <summary>
    /// 現在の筒子から指定された距離だけ離れた筒子を取得します
    /// </summary>
    /// <param name="distance">移動する距離（正の値は大きい数字の牌へ、負の値は小さい数字の牌へ）</param>
    /// <param name="tile">見つかった牌。見つからなかった場合はnull</param>
    /// <returns>指定された距離の牌が存在する場合はtrue、存在しない場合（範囲外の場合）はfalse</returns>
    public override bool TryGetAtDistance(int distance, [NotNullWhen(true)] out NumberTile? tile)
    {
        var result = TryFromNumber(Number + distance, out var pinTile);
        tile = pinTile;
        return result;
    }

    /// <summary>
    /// 牌の表示名を取得する
    /// </summary>
    /// <returns>牌の表示名</returns>
    public sealed override string ToString()
    {
        return $"({Number})";
    }
}

/// <summary>
/// 一筒
/// </summary>
public record Pin1() : PinTile
{
    public override int Number => 1;
}
/// <summary>
/// 二筒
/// </summary>
public record Pin2() : PinTile
{
    public override int Number => 2;
}
/// <summary>
/// 三筒
/// </summary>
public record Pin3() : PinTile
{
    public override int Number => 3;
}
/// <summary>
/// 四筒
/// </summary>
public record Pin4() : PinTile
{
    public override int Number => 4;
}
/// <summary>
/// 五筒
/// </summary>
public record Pin5() : PinTile
{
    public override int Number => 5;
}
/// <summary>
/// 六筒
/// </summary>
public record Pin6() : PinTile
{
    public override int Number => 6;
}
/// <summary>
/// 七筒
/// </summary>
public record Pin7() : PinTile
{
    public override int Number => 7;
}
/// <summary>
/// 八筒
/// </summary>
public record Pin8() : PinTile
{
    public override int Number => 8;
}
/// <summary>
/// 九筒
/// </summary>
public record Pin9() : PinTile
{
    public override int Number => 9;
}
