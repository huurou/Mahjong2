using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Games;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// 大四喜ダブル
/// </summary>
internal record DaisuushiiDouble : Yaku
{
    public override int Number => 44;
    public override string Name => "大四喜";
    public override int HanOpen => 26;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, FuuroList fuuroList, GameRules gameRules)
    {
        return gameRules.DoubleYakumanEnabled && Daisuushii.Valid(hand, fuuroList);
    }
}