using Mahjong2.Lib.Tiles;

namespace Mahjong2.Lib.Fuuros;

/// <summary>
/// 副露を表現するクラス
/// </summary>
/// <param name="TileList">副露を構成する牌のリスト</param>
public abstract record Fuuro(TileList TileList)
{
    /// <summary>
    /// チーかどうか
    /// </summary>
    public abstract bool IsChi { get; }
    /// <summary>
    /// ポンかどうか
    /// </summary>
    public abstract bool IsPon { get; }
    /// <summary>
    /// 槓かどうか
    /// </summary>
    public abstract bool IsKan { get; }
    /// <summary>
    /// 暗槓かどうか
    /// </summary>
    public abstract bool IsAnkan { get; }
    /// <summary>
    /// 明槓かどうか
    /// </summary>
    public abstract bool IsMinkan { get; }
    /// <summary>
    /// 大明槓かどうか
    /// </summary>
    public abstract bool IsDaiminkan { get; }
    /// <summary>
    /// 小明槓かどうか
    /// </summary>
    public abstract bool IsShouminkan { get; }
    /// <summary>
    /// 抜きかどうか
    /// </summary>
    public abstract bool IsNuki { get; }
    /// <summary>
    /// 門前でないかどうか
    /// </summary>
    public abstract bool IsOpen { get; }
}

/// <summary>
/// チー
/// </summary>
/// <param name="TileList"></param>
public record Chi : Fuuro
{
    public Chi(TileList tileList) : base(tileList)
    {
        if (!tileList.IsShuntsu) { throw new ArgumentException("チーの構成牌は順子でなければなりません。", nameof(tileList)); }
    }

    public override bool IsChi => true;
    public override bool IsPon => false;
    public override bool IsKan => false;
    public override bool IsAnkan => false;
    public override bool IsMinkan => false;
    public override bool IsDaiminkan => false;
    public override bool IsShouminkan => false;
    public override bool IsNuki => false;
    public override bool IsOpen => true;

    public sealed override string ToString()
    {
        return $"チー {TileList}";
    }
}

/// <summary>
/// ポン
/// </summary>
/// <param name="TileList"></param>
public record Pon : Fuuro
{
    public Pon(TileList tileList) : base(tileList)
    {
        if (!tileList.IsKoutsu) { throw new ArgumentException("ポンの構成牌は刻子でなければなりません。", nameof(tileList)); }
    }

    public override bool IsChi => false;
    public override bool IsPon => true;
    public override bool IsKan => false;
    public override bool IsAnkan => false;
    public override bool IsMinkan => false;
    public override bool IsDaiminkan => false;
    public override bool IsShouminkan => false;
    public override bool IsNuki => false;
    public override bool IsOpen => true;

    public sealed override string ToString()
    {
        return $"ポン {TileList}";
    }
}

/// <summary>
/// 槓
/// </summary>
/// <param name="TileList"></param>
public abstract record Kan : Fuuro
{
    public Kan(TileList tileList) : base(tileList)
    {
        if (!tileList.IsKantsu) { throw new ArgumentException("槓の構成牌は槓子でなければなりません。", nameof(tileList)); }
    }
    public override bool IsChi => false;
    public override bool IsPon => false;
    public override bool IsKan => true;
    public override bool IsNuki => false;
}

/// <summary>
/// 暗槓
/// </summary>
/// <param name="TileList"></param>
public record Ankan(TileList TileList) : Kan(TileList)
{
    public override bool IsAnkan => true;
    public override bool IsMinkan => false;
    public override bool IsDaiminkan => false;
    public override bool IsShouminkan => false;
    public override bool IsOpen => false;

    public sealed override string ToString()
    {
        return $"暗槓 {TileList}";
    }
}

/// <summary>
/// 明槓
/// </summary>
/// <param name="TileList"></param>
public abstract record Minkan(TileList TileList) : Kan(TileList)
{
    public override bool IsAnkan => false;
    public override bool IsMinkan => true;
    public override bool IsOpen => true;
}

/// <summary>
/// 大明槓
/// </summary>
/// <param name="TileList"></param>
public record Daiminkan(TileList TileList) : Minkan(TileList)
{
    public override bool IsDaiminkan => true;
    public override bool IsShouminkan => false;

    public sealed override string ToString()
    {
        return $"大明槓 {TileList}";
    }
}

/// <summary>
/// 小明槓
/// </summary>
/// <param name="TileList"></param>
public record Shouminkan(TileList TileList) : Minkan(TileList)
{
    public override bool IsDaiminkan => false;
    public override bool IsShouminkan => true;

    public sealed override string ToString()
    {
        return $"小明槓 {TileList}";
    }
}

/// <summary>
/// 抜き
/// </summary>
/// <param name="TileList"></param>
public record Nuki(TileList TileList) : Fuuro(TileList)
{
    public override bool IsChi => false;
    public override bool IsPon => false;
    public override bool IsKan => false;
    public override bool IsAnkan => false;
    public override bool IsMinkan => false;
    public override bool IsDaiminkan => false;
    public override bool IsShouminkan => false;
    public override bool IsNuki => true;
    public override bool IsOpen => false;

    public sealed override string ToString()
    {
        return $"抜き {TileList}";
    }
}