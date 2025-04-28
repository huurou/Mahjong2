using System.Collections.Immutable;

namespace Mahjong2.Lib.Tiles;

/// <summary>
/// 牌を表現するクラス
/// </summary>
public abstract record Tile : IComparable<Tile>
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
    public bool IsChucahn => this is NumberTile numberTile && numberTile.Number is >= 2 and <= 8;
    /// <summary>
    /// 么九牌かどうか
    /// </summary>
    public bool IsYaochu => !IsChucahn;
    /// <summary>
    /// 老頭牌かどうか
    /// </summary>
    public bool IsRoutou => this is NumberTile numberTile && numberTile.Number is 1 or 9;

    public int CompareTo(Tile? other)
    {
        if (other is null) { return 1; }

        // 牌の種類での比較を最初に行う
        var typeComparison = GetTileTypeValue(this).CompareTo(GetTileTypeValue(other));
        if (typeComparison != 0) { return typeComparison; }

        // 同じ種類の牌の場合の比較
        if (this is NumberTile thisNumberTile && other is NumberTile otherNumberTile)
        {
            return thisNumberTile.Number.CompareTo(otherNumberTile.Number);
        }
        if (this is WindTile thisWindTile && other is WindTile otherWindTile)
        {
            return GetWindNumber(thisWindTile).CompareTo(GetWindNumber(otherWindTile));
        }
        if (this is DragonTile thisDragonTile && other is DragonTile otherDragonTile)
        {
            return GetDragonValue(thisDragonTile).CompareTo(GetDragonValue(otherDragonTile));
        }
        return 0;

        static int GetTileTypeValue(Tile tile)
        {
            return tile switch
            {
                ManTile => 0,
                PinTile => 1,
                SouTile => 2,
                WindTile => 3,
                DragonTile => 4,
                _ => throw new ArgumentException("不明な牌種類です", nameof(tile)),
            };
        }
        static int GetWindNumber(WindTile windTile)
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
        static int GetDragonValue(DragonTile dragonTile)
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

    /// <summary>
    /// 小なり演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌</param>
    /// <param name="right">右辺の牌</param>
    /// <returns>左辺が右辺より小さい場合はtrue、そうでない場合はfalse</returns>
    public static bool operator <(Tile? left, Tile? right)
    {
        return left is not null ? left.CompareTo(right) < 0 : right is not null;
    }
    /// <summary>
    /// 大なり演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌</param>
    /// <param name="right">右辺の牌</param>
    /// <returns>左辺が右辺より大きい場合はtrue、そうでない場合はfalse</returns>
    public static bool operator >(Tile? left, Tile? right)
    {
        return right is not null ? right.CompareTo(left) < 0 : left is not null;
    }
    /// <summary>
    /// 以下演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌</param>
    /// <param name="right">右辺の牌</param>
    /// <returns>左辺が右辺以下の場合はtrue、そうでない場合はfalse</returns>
    public static bool operator <=(Tile? left, Tile? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }
    /// <summary>
    /// 以上演算子の実装
    /// </summary>
    /// <param name="left">左辺の牌</param>
    /// <param name="right">右辺の牌</param>
    /// <returns>左辺が右辺以上の場合はtrue、そうでない場合はfalse</returns>
    public static bool operator >=(Tile? left, Tile? right)
    {
        return right is null || right.CompareTo(left) <= 0;
    }

    /// <summary>
    /// 牌の表示名を取得する
    /// </summary>
    /// <returns>牌の表示名</returns>
    public override sealed string ToString()
    {
        return this switch
        {
            ManTile manTile => manTile.Number switch
            {
                1 => "一",
                2 => "二",
                3 => "三",
                4 => "四",
                5 => "五",
                6 => "六",
                7 => "七",
                8 => "八",
                9 => "九",
                _ => throw new InvalidOperationException($"無効な萬子の数字: {manTile.Number}")
            },
            PinTile pinTile => $"({pinTile.Number})",
            SouTile souTile => souTile.Number.ToString(),
            Tiles.Ton => "東",
            Tiles.Nan => "南",
            Tiles.Sha => "西",
            Tiles.Pei => "北",
            Tiles.Haku => "白",
            Tiles.Hatsu => "發",
            Tiles.Chun => "中",
            _ => throw new InvalidOperationException($"不明な牌です: {GetType().Name}")
        };
    }
}

/// <summary>
/// 数牌
/// </summary>
/// <param name="Number">絵柄の数字</param>
public abstract record NumberTile(int Number) : Tile;
/// <summary>
/// 萬子
/// </summary>
public abstract record ManTile(int Number) : NumberTile(Number);
/// <summary>
/// 筒子
/// </summary>
public abstract record PinTile(int Number) : NumberTile(Number);
/// <summary>
/// 索子
/// </summary>
public abstract record SouTile(int Number) : NumberTile(Number);
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
public record Man1() : ManTile(1);
/// <summary>
/// 二萬
/// </summary>
public record Man2() : ManTile(2);
/// <summary>
/// 三萬
/// </summary>
public record Man3() : ManTile(3);
/// <summary>
/// 四萬
/// </summary>
public record Man4() : ManTile(4);
/// <summary>
/// 五萬
/// </summary>
public record Man5() : ManTile(5);
/// <summary>
/// 六萬
/// </summary>
public record Man6() : ManTile(6);
/// <summary>
/// 七萬
/// </summary>
public record Man7() : ManTile(7);
/// <summary>
/// 八萬
/// </summary>
public record Man8() : ManTile(8);
/// <summary>
/// 九萬
/// </summary>
public record Man9() : ManTile(9);

/// <summary>
/// 一筒
/// </summary>
public record Pin1() : PinTile(1);
/// <summary>
/// 二筒
/// </summary>
public record Pin2() : PinTile(2);
/// <summary>
/// 三筒
/// </summary>
public record Pin3() : PinTile(3);
/// <summary>
/// 四筒
/// </summary>
public record Pin4() : PinTile(4);
/// <summary>
/// 五筒
/// </summary>
public record Pin5() : PinTile(5);
/// <summary>
/// 六筒
/// </summary>
public record Pin6() : PinTile(6);
/// <summary>
/// 七筒
/// </summary>
public record Pin7() : PinTile(7);
/// <summary>
/// 八筒
/// </summary>
public record Pin8() : PinTile(8);
/// <summary>
/// 九筒
/// </summary>
public record Pin9() : PinTile(9);

/// <summary>
/// 一索
/// </summary>
public record Sou1() : SouTile(1);
/// <summary>
/// 二索
/// </summary>
public record Sou2() : SouTile(2);
/// <summary>
/// 三索
/// </summary>
public record Sou3() : SouTile(3);
/// <summary>
/// 四索
/// </summary>
public record Sou4() : SouTile(4);
/// <summary>
/// 五索
/// </summary>
public record Sou5() : SouTile(5);
/// <summary>
/// 六索
/// </summary>
public record Sou6() : SouTile(6);
/// <summary>
/// 七索
/// </summary>
public record Sou7() : SouTile(7);
/// <summary>
/// 八索
/// </summary>
public record Sou8() : SouTile(8);
/// <summary>
/// 九索
/// </summary>
public record Sou9() : SouTile(9);

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
