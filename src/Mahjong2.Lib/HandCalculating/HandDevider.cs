using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.HandCalculating;

public partial record HandDevider
{
    public static Hand Devide(TileList tileList)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 雀頭候補となる牌のリストを取得する
    /// </summary>
    /// <param name="tileList">牌の集合</param>
    /// <returns></returns>
    private static IEnumerable<Tile> FindToitsuTiles(TileList tileList)
    {
        // 字牌の同種3or4枚は対子になり得ない
        return tileList.Distinct().Where(x => x.IsHonor && tileList.CountOf(x) == 2 || !x.IsHonor && tileList.CountOf(x) >= 2);
    }

    private static List<TileListList> FindValidCombinations(TileList tileList, Type tileType, bool handNotCompleted = false)
    {
        var specifiedTypeTileList = new TileList(tileList.Where(x => x.GetType() == tileType));
        // nP3全順列を列挙する
        // [1,2,3,4,4]=>[[1,2,3],[1,2,4],[1,3,2],[1,3,4],[1,4,2],[1,4,3],[1,4,4],...]
        var perms = Combinatorics.PermutationsUnique(specifiedTypeTileList, 3);
        throw new NotImplementedException();
    }
}
