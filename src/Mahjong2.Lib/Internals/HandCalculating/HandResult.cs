using Mahjong2.Lib.Internals.Fus;
using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.HandCalculating.Scores;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.HandCalculating;

/// <summary>
/// 手牌の計算結果を表現するクラス
/// </summary>
/// <param name="Fu">符</param>
/// <param name="Han">翻</param>
/// <param name="Score">点数</param>
/// <param name="YakuList">役のリスト</param>
/// <param name="FuList">符のリスト</param>
/// <param name="ErrorMessage">エラーメッセージ</param>
internal record HandResult(int Fu, int Han, Score Score, YakuList YakuList, FuList FuList, string? ErrorMessage)
{
    public static HandResult Create(YakuList yakuList, FuList? fuList = null, FuuroList? fuuroList = null, WinSituation? winSituation = null, GameRules? gameRules = null)
    {
        fuList ??= [];
        fuuroList ??= [];
        winSituation ??= new();
        gameRules ??= new();

        var fu = fuList.Total;
        var han = fuuroList.HasOpen ? yakuList.Sum(x => x.HanOpen) : yakuList.Sum(x => x.HanClosed);
        var score = ScoreCalculator.Calc(fu, han, winSituation, gameRules);
        return new(fu, han, score, yakuList, fuList, null);
    }

    public static HandResult Error(string message)
    {
        return new(0, 0, new(0), [], [], message);
    }
}
