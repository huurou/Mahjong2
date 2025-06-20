using System.Collections.Immutable;

namespace Mahjong2.Lib;

internal record Tile(int Id, bool Hidden = false);

internal record Wall : IEquatable<Wall>
{
    private readonly ImmutableList<Tile> tiles_;

    public Wall(IEnumerable<Tile> tiles)
    {
        tiles_ = [.. tiles];
    }

    public virtual bool Equals(Wall? other)
    {
        return other is Wall wall && tiles_.SequenceEqual(wall.tiles_);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(tiles_);
    }
}

internal record River
{
    private readonly ImmutableList<Tile> tiles_;

    public River(IEnumerable<Tile> tiles)
    {
        tiles_ = [.. tiles];
    }
}

internal record PureHand
{
    private readonly ImmutableList<Tile> tiles_;

    public PureHand(IEnumerable<Tile> tiles)
    {
        tiles_ = [.. tiles];
    }
}

/// <summary>
/// 風
/// </summary>
internal record Wind(int Number)
{
    public static Wind East { get; } = new(0);
    public static Wind South { get; } = new(1);
    public static Wind West { get; } = new(2);
    public static Wind North { get; } = new(3);
}

/// <summary>
/// 配牌 ツモ 打牌 副露 槓 槓ツモ などのイベントにおいて誰が？にあたる部分を表現する
/// 内部的にはその局の各プレイヤーの風で表現する
/// </summary>
internal record Who(Wind Wind);

// ローカルではプレイヤーのメソッドを直接呼び出す
// リモートではプレイヤーにイベントを通知する
internal interface IGameEventNotifier
{
    /// <summary>
    /// ツモを通知する
    /// </summary>
    /// <param name="who">誰がツモったか</param>
    /// <param name="tile">何をツモったか</param>
    void NotifyTsumo(Who who, Tile tile);
}

internal record GameEventNotifierLocal : IGameEventNotifier
{
    public void NotifyTsumo(Who who, Tile tile)
    {
        throw new NotImplementedException();
    }
}

internal interface IPlayer
{
    void OnTsumoNotified(Who who, Tile tile, bool hidden);
}