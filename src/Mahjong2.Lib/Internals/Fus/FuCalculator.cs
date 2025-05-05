using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;
using Mahjong2.Lib.Internals.Tiles.HonotTiles;
using Mahjong2.Lib.Internals.Tiles.NumberTiles;

namespace Mahjong2.Lib.Internals.Fus;

internal static class FuCalculator
{
    public static FuList Calc(
        Hand hand,
        Tile winTile,
        TileList winGroup,
        FuuroList? fuuroList = null,
        WinSituation? winSituation = null,
        GameRules? gameRules = null
    )
    {
        fuuroList ??= [];
        winSituation ??= new();
        gameRules ??= new();

        if (hand.Count == 7) { return [Fu.ChiitoitsuFu]; }
        FuList fuList = [
            .. CalcJantou(hand, winSituation),
            .. CalcMentsu(hand, winGroup, fuuroList, winSituation),
            .. CalcWait(winTile, winGroup),
        ];
        fuList = ClacBase(fuList, hand, fuuroList, winSituation, gameRules);
        return [.. fuList.OrderBy(x => x.Number)];
    }

    private static FuList CalcJantou(Hand hand, WinSituation winSituation)
    {
        var toitsuTile = hand.First(x => x.IsToitsu)[0];
        if (toitsuTile.IsHonor)
        {
            return
                toitsuTile.IsDragon ? [Fu.JantouDragonFu]
                : toitsuTile == WindToTile(winSituation.PlayerWind) ? [Fu.JantouPlayerWindFu]
                : toitsuTile == WindToTile(winSituation.RoundWind) ? [Fu.JantouRoundWindFu]
                : [];
        }
        else { return []; }
    }

    private static FuList CalcMentsu(Hand hand, TileList winGroup, FuuroList fuuroList, WinSituation winSituation)
    {
        FuList fuList = [];
        // 手牌の明刻
        foreach (var minko in fuuroList.Where(x => x.IsPon).Select(x => x.TileList))
        {
            fuList = fuList.Add(minko[0].IsChuchan ? Fu.MinkoChuchanFu : Fu.MinkoYaochuFu);
        }
        // シャンポン待ちロン和了のとき明刻扱いになる
        if (!winSituation.IsTsumo && winGroup.IsKoutsu)
        {
            fuList = fuList.Add(winGroup[0].IsChuchan ? Fu.MinkoChuchanFu : Fu.MinkoYaochuFu);
        }
        // 手牌の暗刻
        foreach (var anko in hand.Where(x => x.IsKoutsu && x != winGroup))
        {
            fuList = fuList.Add(anko[0].IsChuchan ? Fu.AnkoChuchanFu : Fu.AnkoYaochuFu);
        }
        // シャンポン待ちツモ和了のとき暗刻扱いになる
        if (winSituation.IsTsumo && winGroup.IsKoutsu)
        {
            fuList = fuList.Add(winGroup[0].IsChuchan ? Fu.AnkoChuchanFu : Fu.AnkoYaochuFu);
        }
        // 明槓
        foreach (var minkan in fuuroList.Where(x => x.IsMinkan).Select(x => x.TileList))
        {
            fuList = fuList.Add(minkan[0].IsChuchan ? Fu.MinkanChuchanFu : Fu.MinkanYaochuFu);
        }
        // 暗槓
        foreach (var ankan in fuuroList.Where(x => x.IsAnkan).Select(x => x.TileList))
        {
            fuList = fuList.Add(ankan[0].IsChuchan ? Fu.AnkanChuchanFu : Fu.AnkanYaochuFu);
        }
        return fuList;
    }

    private static FuList CalcWait(Tile winTile, TileList winGroup)
    {
        FuList fuList = [];
        if (winTile is NumberTile numberWinTile)
        {
            // ペンチャン待ち
            if (numberWinTile.Number == 3 && winGroup.IndexOf(winTile) == 2 ||
                numberWinTile.Number == 7 && winGroup.IndexOf(winTile) == 0)
            {
                fuList = fuList.Add(Fu.WaitPenchanFu);
            }
            // カンチャン待ち
            if (winGroup.IndexOf(winTile) == 1)
            {
                fuList = fuList.Add(Fu.WaitKanchanFu);
            }
        }
        // 単騎待ち
        if (winGroup.IsToitsu)
        {
            fuList = fuList.Add(Fu.WaitTankiFu);
        }
        return fuList;
    }

    private static FuList ClacBase(FuList fuList, Hand hand, FuuroList fuuroList, WinSituation winSituation, GameRules gameRules)
    {
        if (winSituation.IsTsumo)
        {
            // ピンヅモありの場合、ツモでもツモ符を加えない
            if (gameRules.PinzumoEnabled && fuList.Count == 0 && !fuuroList.HasOpen) { }
            else
            {
                fuList = fuList.Add(Fu.TsumoFu);
            }
        }
        // 食い平和のロンアガリは副底を30符にする
        if (!winSituation.IsTsumo && fuuroList.HasOpen && fuList.Total == 0)
        {
            fuList = fuList.Add(Fu.FuteiOpenPinfuFu);
        }
        else
        {
            fuList = fuList.Add(Fu.FuteiFu);
            // 門前ロン
            if (!winSituation.IsTsumo && !fuuroList.HasOpen)
            {
                fuList = fuList.Add(Fu.MenzenFu);
            }
        }
        return fuList;
    }

    private static WindTile WindToTile(Wind wind)
    {
        return wind switch
        {
            Wind.East => Tile.Ton,
            Wind.South => Tile.Nan,
            Wind.West => Tile.Sha,
            Wind.North => Tile.Pei,
            _ => throw new ArgumentException("不明な風牌です。", nameof(wind)),
        };
    }
}
