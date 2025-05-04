namespace Mahjong2.Lib.Fus;

/// <summary>
/// 符を表現するクラス
/// </summary>
internal abstract record Fu
{
    #region シングルトンプロパティ

    /// <summary>
    /// 副底
    /// </summary>
    public static Futei Futei { get; } = new();
    /// <summary>
    /// 門前加符
    /// </summary>
    public static MenzenFu MenzenFu { get; } = new();
    /// <summary>
    /// 七対子
    /// </summary>
    public static ChiitoitsuFu ChiitoitsuFu { get; } = new();
    /// <summary>
    /// 副底(食い平和)
    /// </summary>
    public static FuteiOpenPinfu FuteiOpenPinfu { get; } = new();
    /// <summary>
    /// ツモ符
    /// </summary>
    public static TsumoFu TsumoFu { get; } = new();
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

    #endregion シングルトンプロパティ

    /// <summary>
    /// 番号
    /// 並び替え用
    /// </summary>
    public abstract int Number { get; }
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
internal record Futei : Fu
{
    public override int Number => 1;
    public override string Name { get; } = "副底";
    public override int Value { get; } = 20;
}

/// <summary>
/// 門前加符
/// </summary>
internal record MenzenFu : Fu
{
    public override int Number => 2;
    public override string Name { get; } = "門前加符";
    public override int Value { get; } = 10;
}

/// <summary>
/// 七対子
/// </summary>
internal record ChiitoitsuFu : Fu
{
    public override int Number => 3;
    public override string Name { get; } = "七対子";
    public override int Value { get; } = 25;
}

/// <summary>
/// 副底(食い平和)
/// </summary>
internal record FuteiOpenPinfu : Fu
{
    public override int Number => 4;
    public override string Name { get; } = "副底(食い平和)";
    public override int Value { get; } = 30;
}

/// <summary>
/// ツモ符
/// </summary>
internal record TsumoFu : Fu
{
    public override int Number => 5;
    public override string Name { get; } = "ツモ符";
    public override int Value { get; } = 2;
}

/// <summary>
/// 待ち
/// </summary>
internal abstract record Wait : Fu;

/// <summary>
/// カンチャン待ち
/// </summary>
internal record WaitKanchan : Wait
{
    public override int Number => 6;
    public override string Name { get; } = "カンチャン待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// ペンチャン待ち
/// </summary>
internal record WaitPenchan : Wait
{
    public override int Number => 7;
    public override string Name { get; } = "ペンチャン待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// 単騎待ち
/// </summary>
internal record WaitTanki : Wait
{
    public override int Number => 8;
    public override string Name { get; } = "単騎待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// 雀頭
/// </summary>
internal abstract record Jantou : Fu;

/// <summary>
/// 自風の雀頭
/// </summary>
internal record JantouPlayerWind : Jantou
{
    public override int Number => 9;
    public override string Name { get; } = "自風の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 場風の雀頭
/// </summary>
internal record JantouRoundWind : Jantou
{
    public override int Number => 10;
    public override string Name { get; } = "場風の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 三元牌の雀頭
/// </summary>
internal record JantouDragon : Jantou
{
    public override int Number => 11;
    public override string Name { get; } = "三元牌の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 面子
/// </summary>
internal abstract record Mentsu : Fu;

/// <summary>
/// 刻子
/// </summary>
internal abstract record Koutsu : Mentsu;

/// <summary>
/// 明刻
/// </summary>
internal abstract record Minko : Koutsu;

/// <summary>
/// 中張牌の明刻
/// </summary>
internal record MinkoChuchan : Minko
{
    public override int Number => 12;
    public override string Name { get; } = "中張牌の明刻";
    public override int Value { get; } = 2;
}

/// <summary>
/// 么九牌の明刻
/// </summary>
internal record MinkoYaochu : Minko
{
    public override int Number => 13;
    public override string Name { get; } = "么九牌の明刻";
    public override int Value { get; } = 4;
}

/// <summary>
/// 暗刻
/// </summary>
internal abstract record Anko : Koutsu;

/// <summary>
/// 中張牌の暗刻
/// </summary>
internal record AnkoChuchan : Anko
{
    public override int Number => 14;
    public override string Name { get; } = "中張牌の暗刻";
    public override int Value { get; } = 4;
}

/// <summary>
/// 么九牌の暗刻
/// </summary>
internal record AnkoYaochu : Anko
{
    public override int Number => 15;
    public override string Name { get; } = "么九牌の暗刻";
    public override int Value { get; } = 8;
}

/// <summary>
/// 明槓
/// </summary>
internal abstract record Minkan : Koutsu;

/// <summary>
/// 中張牌の明槓
/// </summary>
internal record MinkanChuchan : Minkan
{
    public override int Number => 16;
    public override string Name { get; } = "中張牌の明槓";
    public override int Value { get; } = 8;
}

/// <summary>
/// 么九牌の明槓
/// </summary>
internal record MinkanYaochu : Minkan
{
    public override int Number => 17;
    public override string Name { get; } = "么九牌の明槓";
    public override int Value { get; } = 16;
}

/// <summary>
/// 暗槓
/// </summary>
internal abstract record Ankan : Koutsu;

/// <summary>
/// 中張牌の暗槓
/// </summary>
internal record AnkanChuchan : Ankan
{
    public override int Number => 18;
    public override string Name { get; } = "中張牌の暗槓";
    public override int Value { get; } = 16;
}

/// <summary>
/// 么九牌の暗槓
/// </summary>
internal record AnkanYaochu : Ankan
{
    public override int Number => 19;
    public override string Name { get; } = "么九牌の暗槓";
    public override int Value { get; } = 32;
}
