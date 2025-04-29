using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 役牌
/// </summary>
public record Yakuhai : Yaku
{
    public override string Name => "役牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, WinSituation winSituation)
    {
        var combined = hand.CombineFuuro(fuuroList);
        return PlayerWind.Valid(hand, fuuroList, winSituation) ||
            RoundWind.Valid(hand, fuuroList, winSituation) ||
            Haku.Valid(hand, fuuroList) ||
            Hatsu.Valid(hand, fuuroList) ||
            Chun.Valid(hand, fuuroList);
    }
}