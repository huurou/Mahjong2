namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 数牌
/// </summary>
/// <param name="Number">絵柄の数字</param>
public abstract record NumberTile : Tile, IComparable<NumberTile>
{
    public abstract int Number { get; }

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

/// <summary>
/// 萬子
/// </summary>
public abstract record ManTile : NumberTile;
/// <summary>
/// 筒子
/// </summary>
public abstract record PinTile : NumberTile;
/// <summary>
/// 索子
/// </summary>
public abstract record SouTile : NumberTile;

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
