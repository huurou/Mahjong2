using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.HandCalculating.HandDeviding;
using Mahjong2.Lib.Shantens;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;
using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Lib.HandCalculating;

public static class HandCalculator
{
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

        // 流し満貫は手牌の形に関係ないのでここで返す
        if (EvalNagashimangan(winSituation, out var handResult)) { return handResult; }
        // エラーをチェックする
        if (HasError(tileList, winTile, fuuroList, winSituation, out handResult)) { return handResult; }
        // 国士無双はHandDeviderによって適切に分解されないのでここで先に処理する 重複するのは天和 地和 人和(役満)だけ
        if (EvalKokushimusou(tileList, winSituation, gameRules, out handResult)) { return handResult; }

        var hands = HandDevider.Devide(tileList);
        List<HandResult> handResults = [];
        foreach (var hand in hands)
        {
            // 天和は和了牌がnullになるので、特別に判定する
            if (winTile is null)
            {
                // HasErrorでチェックされてるはず
                if (!winSituation.IsTenhou) { throw new InvalidOperationException("和了牌がnullになれるのは天和の場合だけです。"); }
                var yakuList = EvalForTenhou(hand, gameRules);
                handResults.Add(HandResult.Create(yakuList, fuuroList: fuuroList, winSituation: winSituation, gameRules: gameRules));
                continue;
            }
            var winGroups = hand.GetWinGroups(winTile);
            foreach (var winGroup in winGroups)
            {
                YakuList yakuList = [];
                //var fuList = FuCalculator
            }
        }

        return handResults[0];
    }

    private static bool HasError(TileList tileList, Tile? winTile, FuuroList fuuroList, WinSituation winSituation, [NotNullWhen(true)] out HandResult? handResult)
    {
        handResult = null;
        if (ShantenCalculator.Calc(tileList) != ShantenCalculator.AGARI_SHANTEN)
        {
            handResult = HandResult.Error("手牌がアガリ形ではありません。");
        }
        if (!winSituation.IsTenhou && winTile is not null && !tileList.Contains(winTile))
        {
            handResult = HandResult.Error("手牌にアガリ牌がありません。");
        }
        if (winSituation.IsRiichi && fuuroList.HasOpen)
        {
            handResult = HandResult.Error("リーチと非面前は両立できません。");
        }
        if (winSituation.IsDoubleRiichi && fuuroList.HasOpen)
        {
            handResult = HandResult.Error("ダブルリーチと非面前は両立できません。");
        }
        if (winSituation.IsIppatsu && fuuroList.HasOpen)
        {
            handResult = HandResult.Error("一発と非面前は両立できません。");
        }
        if (winSituation.IsIppatsu && !winSituation.IsRiichi && !winSituation.IsDoubleRiichi)
        {
            handResult = HandResult.Error("一発はリーチorダブルリーチ時にしか成立しません。");
        }
        if (winSituation.IsChankan && winSituation.IsTsumo)
        {
            handResult = HandResult.Error("槍槓とツモアガリは両立できません。");
        }
        if (winSituation.IsRinshan && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("嶺上開花とロンアガリは両立できません。");
        }
        if (winSituation.IsHaitei && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("海底撈月とロンアガリは両立できません。");
        }
        if (winSituation.IsHoutei && winSituation.IsTsumo)
        {
            handResult = HandResult.Error("河底撈魚とツモアガリは両立できません。");
        }
        if (winSituation.IsHaitei && winSituation.IsRinshan)
        {
            handResult = HandResult.Error("海底撈月と嶺上開花は両立できません。");
        }
        if (winSituation.IsHoutei && winSituation.IsChankan)
        {
            handResult = HandResult.Error("河底撈魚と槍槓は両立できません。");
        }
        if (winSituation.IsTenhou && !winSituation.IsDealer)
        {
            handResult = HandResult.Error("天和はプレイヤーが親の時のみ有効です。");
        }
        if (winSituation.IsTenhou && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("天和とロンアガリは両立できません。");
        }
        if (winSituation.IsTenhou && fuuroList.Any())
        {
            handResult = HandResult.Error("副露を伴う天和は無効です。");
        }
        if (winSituation.IsChiihou && winSituation.IsDealer)
        {
            handResult = HandResult.Error("地和はプレイヤーが子の時のみ有効です。");
        }
        if (winSituation.IsChiihou && !winSituation.IsTsumo)
        {
            handResult = HandResult.Error("地和とロンアガリは両立できません。");
        }
        if (winSituation.IsChiihou && fuuroList.Count != 0)
        {
            handResult = HandResult.Error("副露を伴う地和は無効です。");
        }
        if (winSituation.IsRenhou && winSituation.IsDealer)
        {
            handResult = HandResult.Error("人和はプレイヤーが子の時のみ有効です。");
        }
        if (winSituation.IsRenhou && winSituation.IsTsumo)
        {
            handResult = HandResult.Error("人和とロンアガリは両立できません。");
        }
        if (winSituation.IsRenhou && fuuroList.Count != 0)
        {
            handResult = HandResult.Error("副露を伴う人和は無効です。");
        }
        return handResult is not null;
    }

    private static bool EvalNagashimangan(WinSituation winSituation, [NotNullWhen(true)] out HandResult? handResult)
    {
        handResult = null;
        if (Nagashimangan.Valid(winSituation))
        {
            handResult = HandResult.Create([Yaku.Nagashimangan], winSituation: winSituation);
        }
        return handResult is not null;
    }

    // 国士無双は適切なHandに分解されないので先に処理する
    private static bool EvalKokushimusou(TileList tileList, WinSituation winSituation, GameRules gameRules, [NotNullWhen(true)] out HandResult? handResult)
    {
        handResult = null;
        YakuList yakuList = [];
        if (Kokushimusou.Valid(tileList))
        {
            if (Tenhou.Valid(winSituation))
            {
                yakuList = [.. yakuList, Yaku.Tenhou];
            }
            if (Chiihou.Valid(winSituation))
            {
                yakuList = [.. yakuList, Yaku.Chiihou];
            }
            if (RenhouYakuman.Valid(winSituation, gameRules))
            {
                yakuList = [.. yakuList, Yaku.RenhouYakuman];
            }
            handResult = HandResult.Create(yakuList, winSituation: winSituation, gameRules: gameRules);
        }
        return handResult is not null;
    }

    // 天和用の役満判定を行う 国士無双は適切なHandに分解されないので EvalKokushimusou で先に処理する
    private static YakuList EvalForTenhou(Hand hand, GameRules gameRules)
    {
        YakuList yakuList = [];
        if (Chuurenpoutou.Valid(hand))
        {
            yakuList = [.. yakuList, Yaku.Chuurenpoutou];
        }
        // ツモ牌がないので特別に四暗刻の判定を行う
        if (hand.Count(x => x.IsKoutsu) == 4)
        {
            yakuList = [.. yakuList, Yaku.Suuankou];
        }
        if (Daisangen.Valid(hand, []))
        {
            yakuList = [.. yakuList, Yaku.Daisangen];
        }
        if (Shousuushii.Valid(hand, []))
        {
            yakuList = [.. yakuList, Yaku.Shousuushii];
        }
        if (Daisuushii.Valid(hand, []))
        {
            if (gameRules.DoubleYakumanEnabled)
            {
                yakuList = [.. yakuList, Yaku.DaisuushiiDouble];
            }
            else
            {
                yakuList = [.. yakuList, Yaku.Daisuushii];
            }
        }
        if (Ryuuiisou.Valid(hand, []))
        {
            yakuList = [.. yakuList, Yaku.Ryuuiisou];
        }
        if (Suukantsu.Valid(hand, []))
        {
            yakuList = [.. yakuList, Yaku.Suukantsu];
        }
        if (Tsuuiisou.Valid(hand, []))
        {
            yakuList = [.. yakuList, Yaku.Tsuuiisou];
        }
        if (Chinroutou.Valid(hand, []))
        {
            yakuList = [.. yakuList, Yaku.Chinroutou];
        }
        if (Daisharin.Valid(hand, gameRules))
        {
            yakuList = [.. yakuList, Yaku.Daisharin];
        }
        return yakuList;
    }
}
