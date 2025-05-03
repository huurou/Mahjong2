using Mahjong2.Lib.Fus;
using Mahjong2.Lib.HandCalculating.Games;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 平和
/// </summary>
public record Pinfu : Yaku
{
    public override string Name => "平和";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(FuList fuList, WinSituation winSituation, GameRules gameRules)
    {
        if (winSituation.IsTsumo)
        {
            // ピンヅモありならツモでもツモ符はつかない
            // ピンヅモなしなら平和不成立
            return gameRules.PinzumoEnabled && fuList.Contains(Fu.Futei) && fuList.Count == 1;
        }
        else
        {
            // ロンなら副底と面前符だけ
            return fuList.Contains(Fu.Futei) && fuList.Contains(Fu.MenzenFu) && fuList.Count == 2;
        }
    }
}