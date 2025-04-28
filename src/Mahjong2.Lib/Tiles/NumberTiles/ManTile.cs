using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.Tiles.NumberTiles;

/// <summary>
/// 萬子
/// </summary>
public abstract record ManTile : NumberTile
{
    /// <summary>
    /// 数字から対応する萬子を取得します
    /// </summary>
    /// <param name="number">萬子の数字（1～9）</param>
    /// <param name="manTile">見つかった萬子。範囲外の場合はnull</param>
    /// <returns>指定された数の萬子が存在する場合はtrue、存在しない場合はfalse</returns>
    public static bool TryFromNumber(int number, [NotNullWhen(true)] out ManTile? manTile)
    {
        manTile = number switch
        {
            1 => Man1,
            2 => Man2,
            3 => Man3,
            4 => Man4,
            5 => Man5,
            6 => Man6,
            7 => Man7,
            8 => Man8,
            9 => Man9,
            _ => null,
        };
        return manTile is not null;
    }

    /// <summary>
    /// 文字から萬子に変換を試みます
    /// </summary>
    /// <param name="c">変換する文字</param>
    /// <param name="manTile">変換された萬子。変換に失敗した場合はnull</param>
    /// <returns>変換に成功した場合はtrue、失敗した場合はfalse</returns>
    public static bool TryFromChar(char c, [NotNullWhen(true)] out ManTile? manTile)
    {
        manTile = null;
        return int.TryParse(c.ToString(), out var num) && TryFromNumber(num, out manTile);
    }

    /// <summary>
    /// 現在の萬子から指定された距離だけ離れた萬子を取得します
    /// </summary>
    /// <param name="distance">移動する距離（正の値は大きい数字の牌へ、負の値は小さい数字の牌へ）</param>
    /// <param name="tile">見つかった牌。見つからなかった場合はnull</param>
    /// <returns>指定された距離の牌が存在する場合はtrue、存在しない場合（範囲外の場合）はfalse</returns>
    public override bool TryGetAtDistance(int distance, [NotNullWhen(true)] out NumberTile? tile)
    {
        var result = TryFromNumber(Number + distance, out var manTile);
        tile = manTile;
        return result;
    }

    /// <summary>
    /// 牌の表示名を取得する
    /// </summary>
    /// <returns>牌の表示名</returns>
    public sealed override string ToString()
    {
        return this switch
        {
            NumberTiles.Man1 => "一",
            NumberTiles.Man2 => "二",
            NumberTiles.Man3 => "三",
            NumberTiles.Man4 => "四",
            NumberTiles.Man5 => "五",
            NumberTiles.Man6 => "六",
            NumberTiles.Man7 => "七",
            NumberTiles.Man8 => "八",
            NumberTiles.Man9 => "九",
            _ => throw new InvalidOperationException($"無効な萬子の数字: {this}")
        };
    }
}

/// <summary>
/// 一萬
/// </summary>
public record Man1() : ManTile
{
    public override int Number => 1;
}
/// <summary>
/// 二萬
/// </summary>
public record Man2() : ManTile
{
    public override int Number => 2;
}
/// <summary>
/// 三萬
/// </summary>
public record Man3() : ManTile
{
    public override int Number => 3;
}
/// <summary>
/// 四萬
/// </summary>
public record Man4() : ManTile
{
    public override int Number => 4;
}
/// <summary>
/// 五萬
/// </summary>
public record Man5() : ManTile
{
    public override int Number => 5;
}
/// <summary>
/// 六萬
/// </summary>
public record Man6() : ManTile
{
    public override int Number => 6;
}
/// <summary>
/// 七萬
/// </summary>
public record Man7() : ManTile
{
    public override int Number => 7;
}
/// <summary>
/// 八萬
/// </summary>
public record Man8() : ManTile
{
    public override int Number => 8;
}
/// <summary>
/// 九萬
/// </summary>
public record Man9() : ManTile
{
    public override int Number => 9;
}
