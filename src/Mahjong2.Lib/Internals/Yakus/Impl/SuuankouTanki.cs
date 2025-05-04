using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Lib.Internals.Yakus.Impl;

/// <summary>
/// 四暗刻単騎待ち
/// </summary>
internal record SuuankouTanki : Yaku
{
    public override int Number => 46;
    public override string Name => "四暗刻単騎";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, TileList winGroup, Tile winTile, FuuroList fuuroList, WinSituation winSituation, GameRules gameRules)
    {
        if (!gameRules.DoubleYakumanEnabled || !Suuankou.Valid(hand, winGroup, fuuroList, winSituation)) { return false; }
        var jantou = hand.Where(x => x.IsToitsu).First();
        return jantou[0] == winTile;
    }
}