using Mahjong2.Lib.Fus;
using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Games;
using Mahjong2.Lib.HandCalculating.HandDeviding;
using Mahjong2.Lib.Shantens;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;
using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.HandCalculating;

/// <summary>
/// 麻雀の手牌から役と点数の計算を行います
/// </summary>
internal static class HandCalculator
{
    /// <summary>
    /// 手牌・状況・ルールをもとに和了結果を計算します。
    /// </summary>
    /// <param name="tileList">手牌の牌リスト</param>
    /// <param name="winTile">和了牌（天和時,流し満貫時はnull）</param>
    /// <param name="fuuroList">副露リスト</param>
    /// <param name="doraIndicators">ドラ表示牌リスト</param>
    /// <param name="uradoraIndicators">裏ドラ表示牌リスト</param>
    /// <param name="winSituation">和了状況</param>
    /// <param name="gameRules">ルール設定</param>
    /// <returns>和了結果</returns>
    public static HandResult Calc(
        TileList tileList,
        Tile? winTile,
        FuuroList? fuuroList = null,
        TileList? doraIndicators = null,
        TileList? uradoraIndicators = null,
        WinSituation? winSituation = null,
        GameRules? gameRules = null
    )
    {
        fuuroList ??= [];
        doraIndicators ??= [];
        uradoraIndicators ??= [];
        winSituation ??= new();
        gameRules ??= new();
        HandResult? handResult;

        // 流し満貫は手牌の形に関係ないのでここで返す
        if (EvalNagashimangan(winSituation, winTile, out handResult)) { return handResult; }
        // エラーをチェックする
        if (HasError(tileList, winTile, fuuroList, winSituation, out handResult)) { return handResult; }
        // 国士無双はHandDeviderによって適切に分解されないのでここで先に処理する 重複するのは天和 地和 人和(役満)だけ
        if (EvalKokushimusou(tileList, winTile, winSituation, gameRules, out handResult)) { return handResult; }

        var hands = HandDevider.Devide(tileList);
        List<HandResult> handResults = [];
        foreach (var hand in hands)
        {
            // 天和は和了牌がnullになるので、特別に判定する
            if (winTile is null)
            {
                // HasErrorでチェックされてるはず
                if (!winSituation.IsTenhou) { throw new InvalidOperationException("和了牌がnullになれるのは天和の場合だけです。"); }
                var yakuList = EvalTenhou(hand, winSituation, gameRules);
                handResults.Add(HandResult.Create(yakuList, fuuroList: fuuroList, winSituation: winSituation, gameRules: gameRules));
                continue;
            }
            var winGroups = hand.GetWinGroups(winTile);
            foreach (var winGroup in winGroups)
            {
                var fuList = FuCalculator.Calc(hand, winTile, winGroup, fuuroList, winSituation, gameRules);
                var yakuList = EvalYaku(hand, winTile, winGroup, fuuroList, fuList, winSituation, gameRules);
                if (yakuList.Any(x => x.IsYakuman))
                {
                    // 役満が含まれていた場合は役満だけにする
                    yakuList = [.. yakuList.Where(x => x.IsYakuman)];
                }
                else if (yakuList.Count != 0)
                {
                    yakuList = yakuList.AddRange(EvalDora(hand, doraIndicators, uradoraIndicators, winSituation));
                }
                if (yakuList.Count != 0)
                {
                    handResults.Add(HandResult.Create(yakuList, fuList, fuuroList, winSituation, gameRules));
                }
                else
                {
                    handResults.Add(HandResult.Error("役がありません。"));
                }
            }
        }
        // 高点法に基づき最も高い点数が最初になるように並び替える
        handResults.Sort((x, y) => x.Han < y.Han ? 1 : x.Han > y.Han ? -1 : x.Fu < y.Fu ? 1 : x.Fu > y.Fu ? -1 : 0);
        return handResults[0];
    }

    /// <summary>
    /// エラー判定。エラーがあればHandResultを返す。
    /// </summary>
    private static bool HasError(TileList tileList, Tile? winTile, FuuroList fuuroList, WinSituation winSituation, [NotNullWhen(true)] out HandResult? handResult)
    {
        handResult = null;
        if (ShantenCalculator.Calc(tileList) != ShantenCalculator.AGARI_SHANTEN)
        {
            handResult = HandResult.Error("手牌がアガリ形ではありません。");
            return true;
        }
        if (!winSituation.IsTenhou && winTile is not null && !tileList.Contains(winTile))
        {
            handResult = HandResult.Error("手牌にアガリ牌がありません。");
            return true;
        }
        if (winSituation.IsIppatsu && fuuroList.HasOpen)
        {
            handResult = HandResult.Error("一発と非面前は両立できません。");
            return true;
        }
        if (winSituation.IsRiichi && fuuroList.HasOpen)
        {
            handResult = HandResult.Error("立直と非面前は両立できません。");
            return true;
        }
        if (winSituation.IsDoubleRiichi && fuuroList.HasOpen)
        {
            handResult = HandResult.Error("ダブル立直と非面前は両立できません。");
            return true;
        }
        if (winSituation.IsIppatsu && !winSituation.IsRiichi && !winSituation.IsDoubleRiichi)
        {
            handResult = HandResult.Error("一発は立直orダブル立直時にしか成立しません。");
            return true;
        }
        if (winSituation.IsChankan && winSituation.IsTsumo)
        {
            handResult = HandResult.Error("槍槓とツモアガリは両立できません。");
            return true;
        }
        if (winSituation.IsRinshan && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("嶺上開花とロンアガリは両立できません。");
            return true;
        }
        if (winSituation.IsHaitei && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("海底撈月とロンアガリは両立できません。");
            return true;
        }
        if (winSituation.IsHoutei && winSituation.IsTsumo)
        {
            handResult = HandResult.Error("河底撈魚とツモアガリは両立できません。");
            return true;
        }
        if (winSituation.IsHaitei && winSituation.IsRinshan)
        {
            handResult = HandResult.Error("海底撈月と嶺上開花は両立できません。");
            return true;
        }
        if (winSituation.IsHoutei && winSituation.IsChankan)
        {
            handResult = HandResult.Error("河底撈魚と槍槓は両立できません。");
            return true;
        }
        if (winSituation.IsTenhou && !winSituation.IsDealer)
        {
            handResult = HandResult.Error("天和はプレイヤーが親の時のみ有効です。");
            return true;
        }
        if (winSituation.IsTenhou && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("天和とロンアガリは両立できません。");
            return true;
        }
        if (winSituation.IsTenhou && fuuroList.Count != 0)
        {
            handResult = HandResult.Error("副露を伴う天和は無効です。");
            return true;
        }
        if (winSituation.IsChiihou && winSituation.IsDealer)
        {
            handResult = HandResult.Error("地和はプレイヤーが子の時のみ有効です。");
            return true;
        }
        if (winSituation.IsChiihou && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("地和とロンアガリは両立できません。");
            return true;
        }
        if (winSituation.IsChiihou && fuuroList.Count != 0)
        {
            handResult = HandResult.Error("副露を伴う地和は無効です。");
            return true;
        }
        if (winSituation.IsRenhou && winSituation.IsDealer)
        {
            handResult = HandResult.Error("人和はプレイヤーが子の時のみ有効です。");
            return true;
        }
        if (winSituation.IsRenhou && winSituation.IsTsumo)
        {
            handResult = HandResult.Error("人和とロンアガリは両立できません。");
            return true;
        }
        if (winSituation.IsRenhou && fuuroList.Count != 0)
        {
            handResult = HandResult.Error("副露を伴う人和は無効です。");
            return true;
        }
        if (winSituation.IsTenhou && winTile is not null)
        {
            handResult = HandResult.Error("天和の時は和了牌にnullを指定してください。");
            return true;
        }
        return false;
    }

    /// <summary>
    /// 流し満貫の判定
    /// </summary>
    private static bool EvalNagashimangan(WinSituation winSituation, Tile? winTile, [NotNullWhen(true)] out HandResult? handResult)
    {
        handResult = null;
        if (winSituation.IsNagashimangan && winTile is not null)
        {
            handResult = HandResult.Error("流し満貫の時は和了牌にnullを指定してください。");
            return true;
        }
        if (Nagashimangan.Valid(winSituation))
        {
            handResult = HandResult.Create([Yaku.Nagashimangan], winSituation: winSituation);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 国士無双の判定 国士無双は適切なHandに分解されないので先に処理する
    /// </summary>
    private static bool EvalKokushimusou(TileList tileList, Tile? winTile, WinSituation winSituation, GameRules gameRules, [NotNullWhen(true)] out HandResult? handResult)
    {
        handResult = null;
        YakuList yakuList = [];
        if (Kokushimusou.Valid(tileList))
        {
            if (winTile is not null && Kokushimusou13menmachi.Valid(tileList, winTile))
            {
                yakuList = yakuList.Add(Yaku.Kokushimusou13menmachi);
            }
            else
            {
                yakuList = yakuList.Add(Yaku.Kokushimusou);
            }
            if (Tenhou.Valid(winSituation))
            {
                yakuList = yakuList.Add(Yaku.Tenhou);
            }
            if (Chiihou.Valid(winSituation))
            {
                yakuList = yakuList.Add(Yaku.Chiihou);
            }
            if (RenhouYakuman.Valid(winSituation, gameRules))
            {
                yakuList = yakuList.Add(Yaku.RenhouYakuman);
            }
            handResult = HandResult.Create(yakuList, winSituation: winSituation, gameRules: gameRules);
        }
        return handResult is not null;
    }

    /// <summary>
    /// 天和判定を行う 国士無双は除く
    /// </summary>
    private static YakuList EvalTenhou(Hand hand, WinSituation winSituation, GameRules gameRules)
    {
        YakuList yakuList = [];
        if (Tenhou.Valid(winSituation))
        {
            yakuList = yakuList.Add(Yaku.Tenhou);
        }
        if (Chuurenpoutou.Valid(hand))
        {
            yakuList = yakuList.Add(Yaku.Chuurenpoutou);
        }
        // ツモ牌がないので特別に四暗刻の判定を行う
        if (hand.Count(x => x.IsKoutsu) == 4)
        {
            yakuList = yakuList.Add(Yaku.Suuankou);
        }
        if (Daisangen.Valid(hand, []))
        {
            yakuList = yakuList.Add(Yaku.Daisangen);
        }
        if (Shousuushii.Valid(hand, []))
        {
            yakuList = yakuList.Add(Yaku.Shousuushii);
        }
        if (Daisuushii.Valid(hand, []))
        {
            if (gameRules.DoubleYakumanEnabled)
            {
                yakuList = yakuList.Add(Yaku.DaisuushiiDouble);
            }
            else
            {
                yakuList = yakuList.Add(Yaku.Daisuushii);
            }
        }
        if (Ryuuiisou.Valid(hand, []))
        {
            yakuList = yakuList.Add(Yaku.Ryuuiisou);
        }
        if (Tsuuiisou.Valid(hand, []))
        {
            yakuList = yakuList.Add(Yaku.Tsuuiisou);
        }
        if (Chinroutou.Valid(hand, []))
        {
            yakuList = yakuList.Add(Yaku.Chinroutou);
        }
        if (Daisharin.Valid(hand, gameRules))
        {
            yakuList = yakuList.Add(Yaku.Daisharin);
        }
        return yakuList;
    }

    /// <summary>
    /// 役の判定を行う
    /// </summary>
    private static YakuList EvalYaku(Hand hand, Tile winTile, TileList winGroup, FuuroList fuuroList, FuList fuList, WinSituation winSituation, GameRules gameRules)
    {
        YakuList yakuList = [];
        yakuList = yakuList.AddRange(EvalFormless(hand, fuuroList, winSituation, gameRules));
        if (hand.Count == 7)
        {
            yakuList = yakuList.AddRange(EvalChiitoitsu(hand, gameRules));
        }
        if (hand.CombineFuuro(fuuroList).Any(x => x.IsShuntsu))
        {
            yakuList = yakuList.AddRange(EvalShuntsu(hand, fuuroList, fuList, winSituation, gameRules));
        }
        if (hand.CombineFuuro(fuuroList).Any(x => x.IsKoutsu || x.IsKantsu))
        {
            yakuList = yakuList.AddRange(EvalKoutsu(hand, winTile, winGroup, fuuroList, winSituation, gameRules));
        }
        return yakuList;
    }

    /// <summary>
    /// 形が関係ない役の判定を行う
    /// </summary>
    private static YakuList EvalFormless(Hand hand, FuuroList fuuroList, WinSituation winSituation, GameRules gameRules)
    {
        YakuList yakuList = [];
        if (Tsumo.Valid(fuuroList, winSituation))
        {
            yakuList = yakuList.Add(Yaku.Tsumo);
        }
        if (Riichi.Valid(winSituation, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Riichi);
        }
        if (DoubleRiichi.Valid(winSituation, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.DoubleRiichi);
        }
        if (Tanyao.Valid(hand, fuuroList, gameRules))
        {
            yakuList = yakuList.Add(Yaku.Tanyao);
        }
        if (Ippatsu.Valid(winSituation, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Ippatsu);
        }
        if (Chankan.Valid(winSituation))
        {
            yakuList = yakuList.Add(Yaku.Chankan);
        }
        if (Rinshan.Valid(winSituation))
        {
            yakuList = yakuList.Add(Yaku.Rinshan);
        }
        if (Haitei.Valid(winSituation))
        {
            yakuList = yakuList.Add(Yaku.Haitei);
        }
        if (Houtei.Valid(winSituation))
        {
            yakuList = yakuList.Add(Yaku.Houtei);
        }
        if (Renhou.Valid(winSituation, gameRules))
        {
            yakuList = yakuList.Add(Yaku.Renhou);
        }
        if (Honitsu.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Honitsu);
        }
        if (Chinitsu.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Chinitsu);
        }
        if (Tsuuiisou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Tsuuiisou);
        }
        if (Honroutou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Honroutou);
        }
        if (Ryuuiisou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Ryuuiisou);
        }
        if (Chiihou.Valid(winSituation))
        {
            yakuList = yakuList.Add(Yaku.Chiihou);
        }
        if (RenhouYakuman.Valid(winSituation, gameRules))
        {
            yakuList = yakuList.Add(Yaku.RenhouYakuman);
        }
        return yakuList;
    }

    /// <summary>
    /// 七対子形の役の判定を行う
    /// </summary>
    private static YakuList EvalChiitoitsu(Hand hand, GameRules gameRules)
    {
        YakuList yakuList = [];
        if (Chiitoitsu.Valid(hand))
        {
            yakuList = yakuList.Add(Yaku.Chiitoitsu);
        }
        if (Daisharin.Valid(hand, gameRules))
        {
            yakuList = yakuList.Add(Yaku.Daisharin);
        }
        return yakuList;
    }

    /// <summary>
    /// 順子が必要な役の判定を行う
    /// </summary>
    private static YakuList EvalShuntsu(Hand hand, FuuroList fuuroList, FuList fuList, WinSituation winSituation, GameRules gameRules)
    {
        YakuList yakuList = [];
        if (Pinfu.Valid(fuList, winSituation, gameRules))
        {
            yakuList = yakuList.Add(Yaku.Pinfu);
        }
        if (Chanta.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Chanta);
        }
        if (Junchan.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Junchan);
        }
        if (Ittsuu.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Ittsuu);
        }
        // 一盃口と二盃口は両立しない
        if (Ryanpeikou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Ryanpeikou);
        }
        else if (Iipeikou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Iipeikou);
        }
        if (Sanshoku.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Sanshoku);
        }
        return yakuList;
    }

    /// <summary>
    /// 刻子が必要な役の判定を行う
    /// </summary>
    private static YakuList EvalKoutsu(Hand hand, Tile winTile, TileList winGroup, FuuroList fuuroList, WinSituation winSituation, GameRules gameRules)
    {
        YakuList yakuList = [];
        if (Toitoihou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Toitoihou);
        }
        if (Sanankou.Valid(hand, winGroup, fuuroList, winSituation))
        {
            yakuList = yakuList.Add(Yaku.Sanankou);
        }
        if (Sanshokudoukou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Sanshokudoukou);
        }
        if (Shousangen.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Shousangen);
        }
        if (Haku.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Haku);
        }
        if (Hatsu.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Hatsu);
        }
        if (Chun.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Chun);
        }
        if (PlayerWind.Valid(hand, fuuroList, winSituation))
        {
            yakuList = yakuList.Add(Yaku.PlayerWind);
        }
        if (RoundWind.Valid(hand, fuuroList, winSituation))
        {
            yakuList = yakuList.Add(Yaku.RoundWind);
        }
        if (Daisangen.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Daisangen);
        }
        if (Shousuushii.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Shousuushii);
        }
        if (Daisuushii.Valid(hand, fuuroList))
        {
            if (gameRules.DoubleYakumanEnabled)
            {
                yakuList = yakuList.Add(Yaku.DaisuushiiDouble);
            }
            else
            {
                yakuList = yakuList.Add(Yaku.Daisuushii);
            }
        }
        if (Chuurenpoutou.Valid(hand))
        {
            if (JunseiChuurenpoutou.Valid(hand, winTile, gameRules))
            {
                yakuList = yakuList.Add(Yaku.JunseiChuurenpoutou);
            }
            else
            {
                yakuList = yakuList.Add(Yaku.Chuurenpoutou);
            }
        }
        if (Suuankou.Valid(hand, winGroup, fuuroList, winSituation))
        {
            if (SuuankouTanki.Valid(hand, winGroup, winTile, fuuroList, winSituation, gameRules))
            {
                yakuList = yakuList.Add(Yaku.SuuankouTanki);
            }
            else
            {
                yakuList = yakuList.Add(Yaku.Suuankou);
            }
        }
        if (Chinroutou.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Chinroutou);
        }
        if (Sankantsu.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Sankantsu);
        }
        if (Suukantsu.Valid(hand, fuuroList))
        {
            yakuList = yakuList.Add(Yaku.Suukantsu);
        }
        return yakuList;
    }

    /// <summary>
    /// ドラの判定を行う
    /// </summary>
    private static YakuList EvalDora(Hand hand, TileList doraIndicators, TileList uradoraIndicators, WinSituation winSituation)
    {
        YakuList yakuList = [];
        var tiles = hand.SelectMany(x => x);
        yakuList = yakuList.AddRange(Enumerable.Repeat(Yaku.Dora, doraIndicators.Select(Tile.GetActualDora).Sum(x => tiles.Count(y => x == y))));
        yakuList = yakuList.AddRange(Enumerable.Repeat(Yaku.Uradora, uradoraIndicators.Select(Tile.GetActualDora).Sum(x => tiles.Count(y => x == y))));
        yakuList = yakuList.AddRange(Enumerable.Repeat(Yaku.Akadora, winSituation.AkadoraCount));
        return yakuList;
    }
}
