using Mahjong2.Lib.Tiles.HonotTiles;
using Mahjong2.Lib.Tiles.NumberTiles;
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
    public static ImmutableList<NumberTile> Chuchans { get; } = [.. Numbers.Where(t => t.IsChuchan)];
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
    public bool IsChuchan => this is NumberTile numberTile && numberTile.Number is >= 2 and <= 8;
    /// <summary>
    /// 么九牌かどうか
    /// </summary>
    public bool IsYaochu => !IsChuchan;
    /// <summary>
    /// 老頭牌かどうか
    /// </summary>
    public bool IsRoutou => this is NumberTile numberTile && numberTile.Number is 1 or 9;

    /// <summary>
    /// ドラ表示牌から実際のドラを取得する
    /// </summary>
    /// <param name="doraIndicator">ドラ表示牌</param>
    /// <returns>実際のドラ</returns>
    public static Tile GetActualDora(Tile doraIndicator)
    {
        return doraIndicator switch
        {
            NumberTiles.Man1 => Man2,
            NumberTiles.Man2 => Man3,
            NumberTiles.Man3 => Man4,
            NumberTiles.Man4 => Man5,
            NumberTiles.Man5 => Man6,
            NumberTiles.Man6 => Man7,
            NumberTiles.Man7 => Man8,
            NumberTiles.Man8 => Man9,
            NumberTiles.Man9 => Man1,
            NumberTiles.Pin1 => Pin2,
            NumberTiles.Pin2 => Pin3,
            NumberTiles.Pin3 => Pin4,
            NumberTiles.Pin4 => Pin5,
            NumberTiles.Pin5 => Pin6,
            NumberTiles.Pin6 => Pin7,
            NumberTiles.Pin7 => Pin8,
            NumberTiles.Pin8 => Pin9,
            NumberTiles.Pin9 => Pin1,
            NumberTiles.Sou1 => Sou2,
            NumberTiles.Sou2 => Sou3,
            NumberTiles.Sou3 => Sou4,
            NumberTiles.Sou4 => Sou5,
            NumberTiles.Sou5 => Sou6,
            NumberTiles.Sou6 => Sou7,
            NumberTiles.Sou7 => Sou8,
            NumberTiles.Sou8 => Sou9,
            NumberTiles.Sou9 => Sou1,
            HonotTiles.Ton => Nan,
            HonotTiles.Nan => Sha,
            HonotTiles.Sha => Pei,
            HonotTiles.Pei => Ton,
            HonotTiles.Haku => Hatsu,
            HonotTiles.Hatsu => Chun,
            HonotTiles.Chun => Haku,
            _ => throw new ArgumentException("不明なドラ表示牌です", nameof(doraIndicator)),
        };
    }

    /// <summary>
    /// 牌を比較します
    /// </summary>
    /// <param name="other">比較対象の牌</param>
    /// <returns>この牌が<paramref name="other"/>より小さい場合は負の値、等しい場合は0、大きい場合は正の値</returns>
    /// <exception cref="InvalidOperationException">不明な牌の比較が行われた場合</exception>
    /// <exception cref="ArgumentException">不明な牌が指定された場合</exception>
    public int CompareTo(Tile? other)
    {
        if (other is null) { return 1; }

        // 牌の種類での比較を最初に行う
        var typeComparison = GetTileTypeValue(this).CompareTo(GetTileTypeValue(other));
        if (typeComparison != 0) { return typeComparison; }
        if (this is NumberTile thisNumberTile && other is NumberTile otherNumberTile) { return thisNumberTile.CompareTo(otherNumberTile); }
        if (this is HonorTile thisHonorTile && other is HonorTile otherHonorTile) { return thisHonorTile.CompareTo(otherHonorTile); }
        throw new InvalidOperationException($"不明な牌の比較です: {this} vs {other}");

        static int GetTileTypeValue(Tile tile)
        {
            return tile switch
            {
                NumberTile => 0,
                HonorTile => 1,
                _ => throw new ArgumentException("不明な牌です", nameof(tile)),
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
}
