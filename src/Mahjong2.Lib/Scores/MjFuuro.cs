using Mahjong2.Lib.Internals.Fuuros;

namespace Mahjong2.Lib.Scores;

public record MjFuuro(MjFuuroType Type, List<MjTileType> Tiles);

public enum MjFuuroType
{
    Pon,
    Chi,
    Ankan,
    Minkan,
}

internal static class MjFuuroExtentions
{
    public static Fuuro ToFuuro(this MjFuuro mjFuuro)
    {
        var tileList = mjFuuro.Tiles.ToTileList();
        return mjFuuro.Type switch
        {
            MjFuuroType.Pon => new Pon(tileList),
            MjFuuroType.Chi => new Chi(tileList),
            MjFuuroType.Ankan => new Ankan(tileList),
            MjFuuroType.Minkan => new Minkan(tileList),
            _ => throw new NotImplementedException(),
        };
    }

    public static FuuroList ToFuuroList(this IEnumerable<MjFuuro> mjFuuros)
    {
        return [.. mjFuuros.Select(x => x.ToFuuro())];
    }
}
