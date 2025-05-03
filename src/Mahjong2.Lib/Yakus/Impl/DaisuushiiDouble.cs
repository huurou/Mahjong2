using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 大四喜ダブル
/// </summary>
public record DaisuushiiDouble : Yaku
{
    public override string Name => "大四喜";
    public override int HanOpen => 26;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, FuuroList fuuroList, GameRules gameRules)
    {
        return gameRules.DoubleYakumanEnabled && Daisuushii.Valid(hand, fuuroList);
    }
}