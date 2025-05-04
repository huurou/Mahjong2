using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Lib.Yakus;

/// <summary>
/// 役を表現するクラス
/// </summary>
internal abstract record Yaku : IComparable<Yaku>
{
    #region シングルトンプロパティ

    // 状況による役
    public static Riichi Riichi { get; } = new();
    public static DoubleRiichi DoubleRiichi { get; } = new();
    public static Tsumo Tsumo { get; } = new();
    public static Ippatsu Ippatsu { get; } = new();
    public static Chankan Chankan { get; } = new();
    public static Rinshan Rinshan { get; } = new();
    public static Haitei Haitei { get; } = new();
    public static Houtei Houtei { get; } = new();
    public static Nagashimangan Nagashimangan { get; } = new();
    public static Renhou Renhou { get; } = new();

    // 1翻
    public static Pinfu Pinfu { get; } = new();
    public static Tanyao Tanyao { get; } = new();
    public static Iipeikou Iipeikou { get; } = new();
    public static Haku Haku { get; } = new();
    public static Hatsu Hatsu { get; } = new();
    public static Chun Chun { get; } = new();
    public static PlayerWind PlayerWind { get; } = new();
    public static RoundWind RoundWind { get; } = new();

    // 2翻
    public static Sanshoku Sanshoku { get; } = new();
    public static Ittsuu Ittsuu { get; } = new();
    public static Chanta Chanta { get; } = new();
    public static Honroutou Honroutou { get; } = new();
    public static Toitoihou Toitoihou { get; } = new();
    public static Sanankou Sanankou { get; } = new();
    public static Sankantsu Sankantsu { get; } = new();
    public static Sanshokudoukou Sanshokudoukou { get; } = new();
    public static Chiitoitsu Chiitoitsu { get; } = new();
    public static Shousangen Shousangen { get; } = new();

    // 3翻
    public static Honitsu Honitsu { get; } = new();
    public static Junchan Junchan { get; } = new();
    public static Ryanpeikou Ryanpeikou { get; } = new();

    // 6翻
    public static Chinitsu Chinitsu { get; } = new();

    // 役満
    public static Kokushimusou Kokushimusou { get; } = new();
    public static Chuurenpoutou Chuurenpoutou { get; } = new();
    public static Suuankou Suuankou { get; } = new();
    public static Daisangen Daisangen { get; } = new();
    public static Shousuushii Shousuushii { get; } = new();
    public static Daisuushii Daisuushii { get; } = new();
    public static Ryuuiisou Ryuuiisou { get; } = new();
    public static Suukantsu Suukantsu { get; } = new();
    public static Tsuuiisou Tsuuiisou { get; } = new();
    public static Chinroutou Chinroutou { get; } = new();
    public static Daisharin Daisharin { get; } = new();

    // ダブル役満
    public static DaisuushiiDouble DaisuushiiDouble { get; } = new();
    public static Kokushimusou13menmachi Kokushimusou13menmachi { get; } = new();
    public static SuuankouTanki SuuankouTanki { get; } = new();
    public static JunseiChuurenpoutou JunseiChuurenpoutou { get; } = new();

    // 状況による役満
    public static Tenhou Tenhou { get; } = new();
    public static Chiihou Chiihou { get; } = new();
    public static RenhouYakuman RenhouYakuman { get; } = new();

    // ドラ
    public static Dora Dora { get; } = new();
    public static Uradora Uradora { get; } = new();
    public static Akadora Akadora { get; } = new();

    #endregion シングルトンプロパティ

    /// <summary>
    /// 役の番号
    /// ソート用
    /// </summary>
    public abstract int Number { get; }
    /// <summary>
    /// 役の名前
    /// </summary>
    public abstract string Name { get; }
    /// <summary>
    /// 非門前時の翻数 非面前では成立しない場合は0
    /// </summary>
    public abstract int HanOpen { get; }
    /// <summary>
    /// 面前時の翻数
    /// </summary>
    public abstract int HanClosed { get; }
    /// <summary>
    /// 役満かどうか
    /// </summary>
    public abstract bool IsYakuman { get; }

    public int CompareTo(Yaku? other)
    {
        return other is null ? 1 : Number.CompareTo(other.Number);
    }

    public sealed override string ToString()
    {
        return Name;
    }
}
