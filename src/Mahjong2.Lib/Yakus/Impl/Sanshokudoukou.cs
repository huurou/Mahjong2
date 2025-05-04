using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 三色同刻
/// </summary>
internal record Sanshokudoukou : Yaku
{
    public override int Number => 26;
    public override string Name => "三色同刻";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var koutsus = hand.CombineFuuro(fuuroList)
            .Where(x => (x.IsKoutsu || x.IsKantsu) && x.IsAllNumber)
            .Select(x => x.OfType<NumberTile>().Take(3).ToList());
        if (koutsus.Count() < 3) { return false; }
        var mans = koutsus.Where(x => x[0].IsMan);
        var pins = koutsus.Where(x => x[0].IsPin);
        var sous = koutsus.Where(x => x[0].IsSou);
        foreach (var man in mans)
        {
            foreach (var pin in pins)
            {
                foreach (var sou in sous)
                {
                    if (man[0].Number == pin[0].Number && pin[0].Number == sou[0].Number) { return true; }
                }
            }
        }
        return false;
    }
}