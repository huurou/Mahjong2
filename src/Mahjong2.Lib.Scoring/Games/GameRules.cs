namespace Mahjong2.Lib.Scoring.Games;

/// <summary>
/// 点数に関わるルール
/// </summary>
internal record GameRules
{
    /// <summary>
    /// 喰いタンあり/なし
    /// </summary>
    public bool KuitanEnabled { get; init; } = true;

    /// <summary>
    /// ダブル役満あり/なし
    /// </summary>
    public bool DoubleYakumanEnabled { get; init; } = true;

    /// <summary>
    /// 数え役満
    /// </summary>
    public KazoeLimit KazoeLimit { get; init; } = KazoeLimit.Limited;

    /// <summary>
    /// 切り上げ満貫あり/なし
    /// </summary>
    public bool KiriageEnabled { get; init; } = false;

    /// <summary>
    /// ピンヅモあり/なし
    /// </summary>
    public bool PinzumoEnabled { get; init; } = true;

    /// <summary>
    /// 人和役満あり/なし
    /// </summary>
    public bool RenhouAsYakumanEnabled { get; init; } = false;

    /// <summary>
    /// 大車輪あり/なし
    /// </summary>
    public bool DaisharinEnabled { get; init; } = false;
}

/// <summary>
/// 数え役満のルール
/// </summary>
public enum KazoeLimit
{
    /// <summary>
    /// 13翻以上は全て数え役満
    /// </summary>
    Limited,
    /// <summary>
    /// 13翻以上は全て三倍満
    /// </summary>
    Sanbaiman,
    /// <summary>
    /// 13翻以上は13翻ごとに数え役満が重なる
    /// </summary>
    Nolimit,
}
