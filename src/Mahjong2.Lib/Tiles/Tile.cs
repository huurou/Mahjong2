using System.Collections.Immutable;

namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 牌を表現するクラス
/// </summary>
public abstract record Tile
{
    #region シングルトンプロパティ

    /// <summary>
    /// 一萬
    /// </summary>
    public static Man1 Man1 { get; } = new();
    /// <summary>
    /// 二萬
    /// </summary>
    public static Man2 Man2 { get; } = new();
    /// <summary>
    /// 三萬
    /// </summary>
    public static Man3 Man3 { get; } = new();
    /// <summary>
    /// 四萬
    /// </summary>
    public static Man4 Man4 { get; } = new();
    /// <summary>
    /// 五萬
    /// </summary>
    public static Man5 Man5 { get; } = new();
    /// <summary>
    /// 六萬
    /// </summary>
    public static Man6 Man6 { get; } = new();
    /// <summary>
    /// 七萬
    /// </summary>
    public static Man7 Man7 { get; } = new();
    /// <summary>
    /// 八萬
    /// </summary>
    public static Man8 Man8 { get; } = new();
    /// <summary>
    /// 九萬
    /// </summary>
    public static Man9 Man9 { get; } = new();

    /// <summary>
    /// 一筒
    /// </summary>
    public static Pin1 Pin1 { get; } = new();
    /// <summary>
    /// 二筒
    /// </summary>
    public static Pin2 Pin2 { get; } = new();
    /// <summary>
    /// 三筒
    /// </summary>
    public static Pin3 Pin3 { get; } = new();
    /// <summary>
    /// 四筒
    /// </summary>
    public static Pin4 Pin4 { get; } = new();
    /// <summary>
    /// 五筒
    /// </summary>
    public static Pin5 Pin5 { get; } = new();
    /// <summary>
    /// 六筒
    /// </summary>
    public static Pin6 Pin6 { get; } = new();
    /// <summary>
    /// 七筒
    /// </summary>
    public static Pin7 Pin7 { get; } = new();
    /// <summary>
    /// 八筒
    /// </summary>
    public static Pin8 Pin8 { get; } = new();
    /// <summary>
    /// 九筒
    /// </summary>
    public static Pin9 Pin9 { get; } = new();

    /// <summary>
    /// 一索
    /// </summary>
    public static Sou1 Sou1 { get; } = new();
    /// <summary>
    /// 二索
    /// </summary>
    public static Sou2 Sou2 { get; } = new();
    /// <summary>
    /// 三索
    /// </summary>
    public static Sou3 Sou3 { get; } = new();
    /// <summary>
    /// 四索
    /// </summary>
    public static Sou4 Sou4 { get; } = new();
    /// <summary>
    /// 五索
    /// </summary>
    public static Sou5 Sou5 { get; } = new();
    /// <summary>
    /// 六索
    /// </summary>
    public static Sou6 Sou6 { get; } = new();
    /// <summary>
    /// 七索
    /// </summary>
    public static Sou7 Sou7 { get; } = new();
    /// <summary>
    /// 八索
    /// </summary>
    public static Sou8 Sou8 { get; } = new();
    /// <summary>
    /// 九索
    /// </summary>
    public static Sou9 Sou9 { get; } = new();

    /// <summary>
    /// 東
    /// </summary>
    public static Ton Ton { get; } = new();
    /// <summary>
    /// 南
    /// </summary>
    public static Nan Nan { get; } = new();
    /// <summary>
    /// 西
    /// </summary>
    public static Sha Sha { get; } = new();
    /// <summary>
    /// 北
    /// </summary>
    public static Pei Pei { get; } = new();

    /// <summary>
    /// 白
    /// </summary>
    public static Haku Haku { get; } = new();
    /// <summary>
    /// 發
    /// </summary>
    public static Hatsu Hatsu { get; } = new();
    /// <summary>
    /// 中
    /// </summary>
    public static Chun Chun { get; } = new();

    #endregion シングルトンプロパティ

    /// <summary>
    /// 全種類の牌のリスト
    /// </summary>
    public static ImmutableList<Tile> All { get; } = [
        Man1, Man2, Man3, Man4, Man5, Man6, Man7, Man8, Man9,
        Pin1, Pin2, Pin3, Pin4, Pin5, Pin6, Pin7, Pin8, Pin9,
        Sou1, Sou2, Sou3, Sou4, Sou5, Sou6, Sou7, Sou8, Sou9,
        Ton, Nan, Sha, Pei, Haku, Hatsu, Chun,
    ];
    /// <summary>
    /// 数牌のリスト
    /// </summary>
    public static ImmutableList<NumberTile> Numbers { get; } = [.. All.OfType<NumberTile>()];
    /// <summary>
    /// 萬子のリスト
    /// </summary>
    public static ImmutableList<ManTile> Mans { get; } = [.. All.OfType<ManTile>()];
    /// <summary>
    /// 筒子のリスト
    /// </summary>
    public static ImmutableList<PinTile> Pins { get; } = [.. All.OfType<PinTile>()];
    /// <summary>
    /// 索子のリスト
    /// </summary>
    public static ImmutableList<SouTile> Sous { get; } = [.. All.OfType<SouTile>()];
    /// <summary>
    /// 字牌のリスト
    /// </summary>
    public static ImmutableList<HonorTile> Honors { get; } = [.. All.OfType<HonorTile>()];
    /// <summary>
    /// 風牌のリスト
    /// </summary>
    public static ImmutableList<WindTile> Winds { get; } = [.. All.OfType<WindTile>()];
    /// <summary>
    /// 三元牌のリスト
    /// </summary>
    public static ImmutableList<DragonTile> Dragons { get; } = [.. All.OfType<DragonTile>()];
    /// <summary>
    /// 中張牌のリスト
    /// </summary>
    public static ImmutableList<NumberTile> Chuchans { get; } = [.. Numbers.Where(t => t.IsChucahn)];
    /// <summary>
    /// 么九牌のリスト
    /// </summary>
    public static ImmutableList<Tile> Yaochus { get; } = [.. All.Where(t => t.IsYaochu)];
    /// <summary>
    /// 老頭牌のリスト
    /// </summary>
    public static ImmutableList<NumberTile> Routous { get; } = [.. Numbers.Where(t => t.IsRoutou)];

    /// <summary>
    /// 数牌かどうか
    /// </summary>
    public bool IsNumber => this is NumberTile;
    /// <summary>
    /// 萬子かどうか
    /// </summary>
    public bool IsMan => this is ManTile;
    /// <summary>
    /// 筒子かどうか
    /// </summary>
    public bool IsPin => this is PinTile;
    /// <summary>
    /// 索子かどうか
    /// </summary>
    public bool IsSou => this is SouTile;
    /// <summary>
    /// 字牌かどうか
    /// </summary>
    public bool IsHonor => this is HonorTile;
    /// <summary>
    /// 風牌かどうか
    /// </summary>
    public bool IsWind => this is WindTile;
    /// <summary>
    /// 三元牌かどうか
    /// </summary>
    public bool IsDragon => this is DragonTile;
    /// <summary>
    /// 中張牌かどうか
    /// </summary>
    public bool IsChucahn => Number is >= 2 and <= 8;
    /// <summary>
    /// 么九牌かどうか
    /// </summary>
    public bool IsYaochu => !IsChucahn;
    /// <summary>
    /// 老頭牌かどうか
    /// </summary>
    public bool IsRoutou => Number is 1 or 9;

    /// <summary>
    /// 絵柄の数字 字牌はすべて0
    /// </summary>
    public abstract int Number { get; }
}

/// <summary>
/// 数牌
/// </summary>
public abstract record NumberTile : Tile;
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
/// 字牌
/// </summary>
public abstract record HonorTile : Tile;
/// <summary>
/// 風牌
/// </summary>
public abstract record WindTile : HonorTile;
/// <summary>
/// 三元牌
/// </summary>
public abstract record DragonTile : HonorTile;

/// <summary>
/// 一萬
/// </summary>
public record Man1 : ManTile
{
    public override int Number { get; } = 1;

    public override string ToString()
    {
        return "一";
    }
}

/// <summary>
/// 二萬
/// </summary>
public record Man2 : ManTile
{
    public override int Number { get; } = 2;

    public override string ToString()
    {
        return "二";
    }
}

/// <summary>
/// 三萬
/// </summary>
public record Man3 : ManTile
{
    public override int Number { get; } = 3;

    public override string ToString()
    {
        return "三";
    }
}
/// <summary>
/// 四萬
/// </summary>
public record Man4 : ManTile
{
    public override int Number { get; } = 4;

    public override string ToString()
    {
        return "四";
    }
}
/// <summary>
/// 五萬
/// </summary>
public record Man5 : ManTile
{
    public override int Number { get; } = 5;

    public override string ToString()
    {
        return "五";
    }
}
/// <summary>
/// 六萬
/// </summary>
public record Man6 : ManTile
{
    public override int Number { get; } = 6;

    public override string ToString()
    {
        return "六";
    }
}
/// <summary>
/// 七萬
/// </summary>
public record Man7 : ManTile
{
    public override int Number { get; } = 7;

    public override string ToString()
    {
        return "七";
    }
}
/// <summary>
/// 八萬
/// </summary>
public record Man8 : ManTile
{
    public override int Number { get; } = 8;

    public override string ToString()
    {
        return "八";
    }
}
/// <summary>
/// 九萬
/// </summary>
public record Man9 : ManTile
{
    public override int Number { get; } = 9;

    public override string ToString()
    {
        return "九";
    }
}

/// <summary>
/// 一筒
/// </summary>
public record Pin1 : PinTile
{
    public override int Number { get; } = 1;

    public override string ToString()
    {
        return "(1)";
    }
}
/// <summary>
/// 二筒
/// </summary>
public record Pin2 : PinTile
{
    public override int Number { get; } = 2;

    public override string ToString()
    {
        return "(2)";
    }
}
/// <summary>
/// 三筒
/// </summary>
public record Pin3 : PinTile
{
    public override int Number { get; } = 3;

    public override string ToString()
    {
        return "(3)";
    }
}
/// <summary>
/// 四筒
/// </summary>
public record Pin4 : PinTile
{
    public override int Number { get; } = 4;

    public override string ToString()
    {
        return "(4)";
    }
}
/// <summary>
/// 五筒
/// </summary>
public record Pin5 : PinTile
{
    public override int Number { get; } = 5;

    public override string ToString()
    {
        return "(5)";
    }
}
/// <summary>
/// 六筒
/// </summary>
public record Pin6 : PinTile
{
    public override int Number { get; } = 6;

    public override string ToString()
    {
        return "(6)";
    }
}
/// <summary>
/// 七筒
/// </summary>
public record Pin7 : PinTile
{
    public override int Number { get; } = 7;

    public override string ToString()
    {
        return "(7)";
    }
}
/// <summary>
/// 八筒
/// </summary>
public record Pin8 : PinTile
{
    public override int Number { get; } = 8;

    public override string ToString()
    {
        return "(8)";
    }
}
/// <summary>
/// 九筒
/// </summary>
public record Pin9 : PinTile
{
    public override int Number { get; } = 9;

    public override string ToString()
    {
        return "(9)";
    }
}

/// <summary>
/// 一索
/// </summary>
public record Sou1 : SouTile
{
    public override int Number { get; } = 1;

    public override string ToString()
    {
        return "1";
    }
}
/// <summary>
/// 二索
/// </summary>
public record Sou2 : SouTile
{
    public override int Number { get; } = 2;

    public override string ToString()
    {
        return "2";
    }
}
/// <summary>
/// 三索
/// </summary>
public record Sou3 : SouTile
{
    public override int Number { get; } = 3;

    public override string ToString()
    {
        return "3";
    }
}
/// <summary>
/// 四索
/// </summary>
public record Sou4 : SouTile
{
    public override int Number { get; } = 4;

    public override string ToString()
    {
        return "4";
    }
}
/// <summary>
/// 五索
/// </summary>
public record Sou5 : SouTile
{
    public override int Number { get; } = 5;

    public override string ToString()
    {
        return "5";
    }
}
/// <summary>
/// 六索
/// </summary>
public record Sou6 : SouTile
{
    public override int Number { get; } = 6;

    public override string ToString()
    {
        return "6";
    }
}
/// <summary>
/// 七索
/// </summary>
public record Sou7 : SouTile
{
    public override int Number { get; } = 7;

    public override string ToString()
    {
        return "7";
    }
}
/// <summary>
/// 八索
/// </summary>
public record Sou8 : SouTile
{
    public override int Number { get; } = 8;

    public override string ToString()
    {
        return "8";
    }
}
/// <summary>
/// 九索
/// </summary>
public record Sou9 : SouTile
{
    public override int Number { get; } = 9;

    public override string ToString()
    {
        return "9";
    }
}

/// <summary>
/// 東
/// </summary>
public record Ton : WindTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "東";
    }
}

/// <summary>
/// 南
/// </summary>
public record Nan : WindTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "南";
    }
}

/// <summary>
/// 西
/// </summary>
public record Sha : WindTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "西";
    }
}
/// <summary>
/// 北
/// </summary>
public record Pei : WindTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "北";
    }
}

/// <summary>
/// 白
/// </summary>
public record Haku : DragonTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "白";
    }
}
/// <summary>
/// 發
/// </summary>
public record Hatsu : DragonTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "發";
    }
}
/// <summary>
/// 中
/// </summary>
public record Chun : DragonTile
{
    public override int Number { get; } = 0;

    public override string ToString()
    {
        return "中";
    }
}
