namespace Mahjong2.Lib.Fus;

/// <summary>
/// 符を表現するクラス
/// </summary>
public abstract record Fu
{
    #region シングルトンプロパティ

    /// <summary>
    /// 副底
    /// </summary>
    public static Futei Futei { get; } = new();
    /// <summary>
    /// 順子
    /// </summary>
    public static Shuntsu Shuntsu { get; } = new();
    /// <summary>
    /// 中張牌の明刻
    /// </summary>
    public static MinkoChuchan MinkoChuchan { get; } = new();
    /// <summary>
    /// 么九牌の明刻
    /// </summary>
    public static MinkoYaochu MinkoYaochu { get; } = new();
    /// <summary>
    /// 中張牌の暗刻
    /// </summary>
    public static AnkoChuchan AnkoChuchan { get; } = new();
    /// <summary>
    /// 么九牌の暗刻
    /// </summary>
    public static AnkoYaochu AnkoYaochu { get; } = new();
    /// <summary>
    /// 中張牌の明槓
    /// </summary>
    public static MinkanChuchan MinkanChuchan { get; } = new();
    /// <summary>
    /// 么九牌の明槓
    /// </summary>
    public static MinkanYaochu MinkanYaochu { get; } = new();
    /// <summary>
    /// 中張牌の暗槓
    /// </summary>
    public static AnkanChuchan AnkanChuchan { get; } = new();
    /// <summary>
    /// 么九牌の暗槓
    /// </summary>
    public static AnkanYaochu AnkanYaochu { get; } = new();
    /// <summary>
    /// 数牌の雀頭
    /// </summary>
    public static JantoNumber JantoNumber { get; } = new();
    /// <summary>
    /// 客風の雀頭
    /// </summary>
    public static JantoOtherWind JantoOtherWind { get; } = new();
    /// <summary>
    /// 自風の雀頭
    /// </summary>
    public static JantouPlayerWind JantouPlayerWind { get; } = new();
    /// <summary>
    /// 場風の雀頭
    /// </summary>
    public static JantouRoundWind JantouRoundWind { get; } = new();
    /// <summary>
    /// 三元牌の雀頭
    /// </summary>
    public static JantouDragon JantouDragon { get; } = new();
    /// <summary>
    /// 両面待ち
    /// </summary>
    public static WaitRyanmen WaitRyanmen { get; } = new();
    /// <summary>
    /// シャンポン待ち
    /// </summary>
    public static WaitShanpon WaitShanpon { get; } = new();
    /// <summary>
    /// カンチャン待ち
    /// </summary>
    public static WaitKanchan WaitKanchan { get; } = new();
    /// <summary>
    /// ペンチャン待ち
    /// </summary>
    public static WaitPenchan WaitPenchan { get; } = new();
    /// <summary>
    /// 単騎待ち
    /// </summary>
    public static WaitTanki WaitTanki { get; } = new();
    /// <summary>
    /// 門前加符
    /// </summary>
    public static MenzenFu MenzenFu { get; } = new();
    /// <summary>
    /// ツモ符
    /// </summary>
    public static TsumoFu TsumoFu { get; } = new();

    #endregion シングルトンプロパティ

    /// <summary>
    /// 名前
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 値
    /// </summary>
    public abstract int Value { get; }

    /// <summary>
    /// 符のテキスト表現を取得する
    /// </summary>
    /// <returns>「名前:値符」の形式の文字列</returns>
    public sealed override string ToString()
    {
        return $"{Name}:{Value}符";
    }
}

/// <summary>
/// 副底
/// </summary>
public record Futei : Fu
{
    public override string Name { get; } = "副底";
    public override int Value { get; } = 20;
}

/// <summary>
/// 面子
/// </summary>
public abstract record Mentsu : Fu;

/// <summary>
/// 順子
/// </summary>
public record Shuntsu : Mentsu
{
    public override string Name { get; } = "順子";
    public override int Value { get; } = 0;
}

/// <summary>
/// 刻子
/// </summary>
public abstract record Koutsu : Mentsu;

/// <summary>
/// 明刻
/// </summary>
public abstract record Minko : Koutsu;

/// <summary>
/// 中張牌の明刻
/// </summary>
public record MinkoChuchan : Minko
{
    public override string Name { get; } = "中張牌の明刻";
    public override int Value { get; } = 2;
}

/// <summary>
/// 么九牌の明刻
/// </summary>
public record MinkoYaochu : Minko
{
    public override string Name { get; } = "么九牌の明刻";
    public override int Value { get; } = 4;
}

/// <summary>
/// 暗刻
/// </summary>
public abstract record Anko : Koutsu;

/// <summary>
/// 中張牌の暗刻
/// </summary>
public record AnkoChuchan : Anko
{
    public override string Name { get; } = "中張牌の暗刻";
    public override int Value { get; } = 4;
}

/// <summary>
/// 么九牌の暗刻
/// </summary>
public record AnkoYaochu : Anko
{
    public override string Name { get; } = "么九牌の暗刻";
    public override int Value { get; } = 8;
}

/// <summary>
/// 明槓
/// </summary>
public abstract record Minkan : Koutsu;

/// <summary>
/// 中張牌の明槓
/// </summary>
public record MinkanChuchan : Minkan
{
    public override string Name { get; } = "中張牌の明槓";
    public override int Value { get; } = 8;
}

/// <summary>
/// 么九牌の明槓
/// </summary>
public record MinkanYaochu : Minkan
{
    public override string Name { get; } = "么九牌の明槓";
    public override int Value { get; } = 16;
}

/// <summary>
/// 暗槓
/// </summary>
public abstract record Ankan : Koutsu;

/// <summary>
/// 中張牌の暗槓
/// </summary>
public record AnkanChuchan : Ankan
{
    public override string Name { get; } = "中張牌の暗槓";
    public override int Value { get; } = 16;
}

/// <summary>
/// 么九牌の暗槓
/// </summary>
public record AnkanYaochu : Ankan
{
    public override string Name { get; } = "么九牌の暗槓";
    public override int Value { get; } = 32;
}

/// <summary>
/// 雀頭
/// </summary>
public abstract record Jantou : Fu;

/// <summary>
/// 数牌の雀頭
/// </summary>
public record JantoNumber : Jantou
{
    public override string Name { get; } = "数牌の雀頭";
    public override int Value { get; } = 0;
}

/// <summary>
/// 客風の雀頭
/// </summary>
public record JantoOtherWind : Jantou
{
    public override string Name { get; } = "客風の雀頭";
    public override int Value { get; } = 0;
}

/// <summary>
/// 自風の雀頭
/// </summary>
public record JantouPlayerWind : Jantou
{
    public override string Name { get; } = "自風の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 場風の雀頭
/// </summary>
public record JantouRoundWind : Jantou
{
    public override string Name { get; } = "場風の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 三元牌の雀頭
/// </summary>
public record JantouDragon : Jantou
{
    public override string Name { get; } = "三元牌の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 待ち
/// </summary>
public abstract record Wait : Fu;

/// <summary>
/// 両面待ち
/// </summary>
public record WaitRyanmen : Wait
{
    public override string Name { get; } = "両面待ち";
    public override int Value { get; } = 0;
}

/// <summary>
/// シャンポン待ち
/// </summary>
public record WaitShanpon : Wait
{
    public override string Name { get; } = "シャンポン待ち";
    public override int Value { get; } = 0;
}

/// <summary>
/// カンチャン待ち
/// </summary>
public record WaitKanchan : Wait
{
    public override string Name { get; } = "カンチャン待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// ペンチャン待ち
/// </summary>
public record WaitPenchan : Wait
{
    public override string Name { get; } = "ペンチャン待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// 単騎待ち
/// </summary>
public record WaitTanki : Wait
{
    public override string Name { get; } = "単騎待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// 門前加符
/// </summary>
public record MenzenFu : Fu
{
    public override string Name { get; } = "門前加符";
    public override int Value { get; } = 10;
}

/// <summary>
/// ツモ符
/// </summary>
public record TsumoFu : Fu
{
    public override string Name { get; } = "ツモ符";
    public override int Value { get; } = 2;
}
