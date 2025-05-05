using Mahjong2.Lib.Internals.Yakus;
using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Lib;

/// <summary>
/// 麻雀の役を表す列挙型です。
/// </summary>
public enum MjYaku
{
    /// <summary>立直</summary>
    Riichi,
    /// <summary>ダブル立直</summary>
    DoubleRiichi,
    /// <summary>自摸和了</summary>
    Tsumo,
    /// <summary>一発</summary>
    Ippatsu,
    /// <summary>槍槓</summary>
    Chankan,
    /// <summary>嶺上開花</summary>
    Rinshan,
    /// <summary>海底摸月</summary>
    Haitei,
    /// <summary>河底撈魚</summary>
    Houtei,
    /// <summary>流し満貫</summary>
    Nagashimangan,
    /// <summary>人和</summary>
    Renhou,
    /// <summary>平和</summary>
    Pinfu,
    /// <summary>断幺九</summary>
    Tanyao,
    /// <summary>一盃口</summary>
    Iipeikou,
    /// <summary>役牌（白）</summary>
    Haku,
    /// <summary>役牌（發）</summary>
    Hatsu,
    /// <summary>役牌（中）</summary>
    Chun,
    /// <summary>役牌（自風牌）</summary>
    PlayerWind,
    /// <summary>役牌（場風牌）</summary>
    RoundWind,
    /// <summary>三色同順</summary>
    Sanshoku,
    /// <summary>一気通貫</summary>
    Ittsuu,
    /// <summary>混全帯幺九</summary>
    Chanta,
    /// <summary>混老頭</summary>
    Honroutou,
    /// <summary>対々和</summary>
    Toitoihou,
    /// <summary>三暗刻</summary>
    Sanankou,
    /// <summary>三槓子</summary>
    Sankantsu,
    /// <summary>三色同刻</summary>
    Sanshokudoukou,
    /// <summary>七対子</summary>
    Chiitoitsu,
    /// <summary>小三元</summary>
    Shousangen,
    /// <summary>混一色</summary>
    Honitsu,
    /// <summary>純全帯幺九</summary>
    Junchan,
    /// <summary>二盃口</summary>
    Ryanpeikou,
    /// <summary>清一色</summary>
    Chinitsu,
    /// <summary>国士無双</summary>
    Kokushimusou,
    /// <summary>九蓮宝燈</summary>
    Chuurenpoutou,
    /// <summary>四暗刻</summary>
    Suuankou,
    /// <summary>大三元</summary>
    Daisangen,
    /// <summary>小四喜</summary>
    Shousuushii,
    /// <summary>大四喜</summary>
    Daisuushii,
    /// <summary>緑一色</summary>
    Ryuuiisou,
    /// <summary>四槓子</summary>
    Suukantsu,
    /// <summary>字一色</summary>
    Tsuuiisou,
    /// <summary>清老頭</summary>
    Chinroutou,
    /// <summary>大車輪</summary>
    Daisharin,
    /// <summary>大四喜ダブル役満</summary>
    DaisuushiiDouble,
    /// <summary>国士無双十三面待ち</summary>
    Kokushimusou13menmachi,
    /// <summary>四暗刻単騎待ち</summary>
    SuuankouTanki,
    /// <summary>純正九蓮宝燈</summary>
    JunseiChuurenpoutou,
    /// <summary>天和</summary>
    Tenhou,
    /// <summary>地和</summary>
    Chiihou,
    /// <summary>人和役満</summary>
    RenhouYakuman,
    /// <summary>ドラ</summary>
    Dora,
    /// <summary>裏ドラ</summary>
    Uradora,
    /// <summary>赤ドラ</summary>
    Akadora,
}

/// <summary>
/// 麻雀の役とその翻数を表すレコードです。
/// </summary>
/// <param name="Yaku">役の種類</param>
/// <param name="Han">翻数</param>
public record MjYakuResult(MjYaku Yaku, int Han);

/// <summary>
/// 内部実装の役を公開用の役に変換するための拡張メソッドを提供します。
/// </summary>
internal static class YakuExtensions
{
    /// <summary>
    /// 内部実装の <see cref="Yaku"/> を <see cref="MjYaku"/> に変換します。
    /// </summary>
    /// <param name="yaku">変換する役</param>
    /// <returns>変換された <see cref="MjYaku"/></returns>
    /// <exception cref="NotImplementedException">未実装の役が指定された場合にスローされます</exception>
    public static MjYaku ToMjYaku(this Yaku yaku)
    {
        return yaku switch
        {
            Riichi => MjYaku.Riichi,
            DoubleRiichi => MjYaku.DoubleRiichi,
            Tsumo => MjYaku.Tsumo,
            Ippatsu => MjYaku.Ippatsu,
            Chankan => MjYaku.Chankan,
            Rinshan => MjYaku.Rinshan,
            Haitei => MjYaku.Haitei,
            Houtei => MjYaku.Houtei,
            Nagashimangan => MjYaku.Nagashimangan,
            Renhou => MjYaku.Renhou,
            Pinfu => MjYaku.Pinfu,
            Tanyao => MjYaku.Tanyao,
            Iipeikou => MjYaku.Iipeikou,
            Haku => MjYaku.Haku,
            Hatsu => MjYaku.Hatsu,
            Chun => MjYaku.Chun,
            PlayerWind => MjYaku.PlayerWind,
            RoundWind => MjYaku.RoundWind,
            Sanshoku => MjYaku.Sanshoku,
            Ittsuu => MjYaku.Ittsuu,
            Chanta => MjYaku.Chanta,
            Honroutou => MjYaku.Honroutou,
            Toitoihou => MjYaku.Toitoihou,
            Sanankou => MjYaku.Sanankou,
            Sankantsu => MjYaku.Sankantsu,
            Sanshokudoukou => MjYaku.Sanshokudoukou,
            Chiitoitsu => MjYaku.Chiitoitsu,
            Shousangen => MjYaku.Shousangen,
            Honitsu => MjYaku.Honitsu,
            Junchan => MjYaku.Junchan,
            Ryanpeikou => MjYaku.Ryanpeikou,
            Chinitsu => MjYaku.Chinitsu,
            Kokushimusou => MjYaku.Kokushimusou,
            Chuurenpoutou => MjYaku.Chuurenpoutou,
            Suuankou => MjYaku.Suuankou,
            Daisangen => MjYaku.Daisangen,
            Shousuushii => MjYaku.Shousuushii,
            Daisuushii => MjYaku.Daisuushii,
            Ryuuiisou => MjYaku.Ryuuiisou,
            Suukantsu => MjYaku.Suukantsu,
            Tsuuiisou => MjYaku.Tsuuiisou,
            Chinroutou => MjYaku.Chinroutou,
            Daisharin => MjYaku.Daisharin,
            DaisuushiiDouble => MjYaku.DaisuushiiDouble,
            Kokushimusou13menmachi => MjYaku.Kokushimusou13menmachi,
            SuuankouTanki => MjYaku.SuuankouTanki,
            JunseiChuurenpoutou => MjYaku.JunseiChuurenpoutou,
            Tenhou => MjYaku.Tenhou,
            Chiihou => MjYaku.Chiihou,
            RenhouYakuman => MjYaku.RenhouYakuman,
            Dora => MjYaku.Dora,
            Uradora => MjYaku.Uradora,
            Akadora => MjYaku.Akadora,
            _ => throw new InvalidOperationException("不明な役です。")
        };
    }
}