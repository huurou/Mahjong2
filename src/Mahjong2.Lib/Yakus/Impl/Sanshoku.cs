using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;

namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 三色同順
/// </summary>
public record Sanshoku : Yaku
{
    public override string Name => "三色同順";
    public override int HanOpen => 1;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var shuntsus = hand.CombineFuuro(fuuroList).Where(x => x.IsShuntsu);
        if (shuntsus.Count() < 3) { return false; }
        var mans = shuntsus.Where(x => x[0].IsMan);
        var pins = shuntsus.Where(x => x[0].IsPin);
        var sous = shuntsus.Where(x => x[0].IsSou);
        foreach (var man in mans)
        {
            foreach (var pin in pins)
            {
                foreach (var sou in sous)
                {
                    var manNums = man.OfType<NumberTile>().Select(x => x.Number);
                    var pinNums = pin.OfType<NumberTile>().Select(x => x.Number);
                    var souNums = sou.OfType<NumberTile>().Select(x => x.Number);
                    if (manNums.SequenceEqual(pinNums) && pinNums.SequenceEqual(souNums)) { return true; }
                }
            }
        }
        return false;
    }
}