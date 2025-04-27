namespace Mahjong2.Lib.Scores;

/// <summary>
/// 数え役満のルール
/// </summary>
public enum KazoeLimit
{
    /// <summary>
    /// 13翻以上は全て数え役満
    /// </summary>
    Limited = 0,
    /// <summary>
    /// 13翻以上は全て三倍満
    /// </summary>
    Sanbaiman = 1,
    /// <summary>
    /// 13翻以上は13翻ごとに数え役満が重なる
    /// </summary>
    Nolimit = 2
}
