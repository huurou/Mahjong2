using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 大車輪
/// </summary>
public record Daisharin : Yaku
{
    public override int Number => 43;
    public override string Name => "大車輪";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, GameRules gameRules)
    {
        return gameRules.DaisharinEnabled &&
            new TileListList(hand) == [new(pin: "22"), new(pin: "33"), new(pin: "44"), new(pin: "55"), new(pin: "66"), new(pin: "77"), new(pin: "88")];
    }
}