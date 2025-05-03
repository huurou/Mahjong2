using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 断么九
/// </summary>
public record Tanyao : Yaku
{
    public override int Number => 12;
    public override string Name => "断么九";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, GameRules gameRules)
    {
        return hand.CombineFuuro(fuuroList).SelectMany(x => x).Distinct().All(x => x.IsChuchan) &&
            (!fuuroList.HasOpen || gameRules.KuitanEnabled);
    }
}