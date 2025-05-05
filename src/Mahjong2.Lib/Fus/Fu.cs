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
    public static FuteiFu FuteiFu { get; } = new();
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
    public static FuteiOpenPinfuFu FuteiOpenPinfuFu { get; } = new();
    /// <summary>
    /// ツモ符
    /// </summary>
    public static TsumoFu TsumoFu { get; } = new();
    /// <summary>
    /// カンチャン待ち
    /// </summary>
    public static WaitKanchanFu WaitKanchanFu { get; } = new();
    /// <summary>
    /// ペンチャン待ち
    /// </summary>
    public static WaitPenchanFu WaitPenchanFu { get; } = new();
    /// <summary>
    /// 単騎待ち
    /// </summary>
    public static WaitTankiFu WaitTankiFu { get; } = new();
    /// <summary>
    /// 自風の雀頭
    /// </summary>
    public static JantouPlayerWindFu JantouPlayerWindFu { get; } = new();
    /// <summary>
    /// 場風の雀頭
    /// </summary>
    public static JantouRoundWindFu JantouRoundWindFu { get; } = new();
    /// <summary>
    /// 三元牌の雀頭
    /// </summary>
    public static JantouDragonFu JantouDragonFu { get; } = new();
    /// <summary>
    /// 中張牌の明刻
    /// </summary>
    public static MinkoChuchanFu MinkoChuchanFu { get; } = new();
    /// <summary>
    /// 么九牌の明刻
    /// </summary>
    public static MinkoYaochuFu MinkoYaochuFu { get; } = new();
    /// <summary>
    /// 中張牌の暗刻
    /// </summary>
    public static AnkoChuchanFu AnkoChuchanFu { get; } = new();
    /// <summary>
    /// 么九牌の暗刻
    /// </summary>
    public static AnkoYaochuFu AnkoYaochuFu { get; } = new();
    /// <summary>
    /// 中張牌の明槓
    /// </summary>
    public static MinkanChuchanFu MinkanChuchanFu { get; } = new();
    /// <summary>
    /// 么九牌の明槓
    /// </summary>
    public static MinkanYaochuFu MinkanYaochuFu { get; } = new();
    /// <summary>
    /// 中張牌の暗槓
    /// </summary>
    public static AnkanChuchanFu AnkanChuchanFu { get; } = new();
    /// <summary>
    /// 么九牌の暗槓
    /// </summary>
    public static AnkanYaochuFu AnkanYaochuFu { get; } = new();

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
internal record FuteiFu : Fu
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
internal record FuteiOpenPinfuFu : Fu
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
internal abstract record WaitFu : Fu;

/// <summary>
/// カンチャン待ち
/// </summary>
internal record WaitKanchanFu : WaitFu
{
    public override int Number => 6;
    public override string Name { get; } = "カンチャン待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// ペンチャン待ち
/// </summary>
internal record WaitPenchanFu : WaitFu
{
    public override int Number => 7;
    public override string Name { get; } = "ペンチャン待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// 単騎待ち
/// </summary>
internal record WaitTankiFu : WaitFu
{
    public override int Number => 8;
    public override string Name { get; } = "単騎待ち";
    public override int Value { get; } = 2;
}

/// <summary>
/// 雀頭
/// </summary>
internal abstract record JantouFu : Fu;

/// <summary>
/// 自風の雀頭
/// </summary>
internal record JantouPlayerWindFu : JantouFu
{
    public override int Number => 9;
    public override string Name { get; } = "自風の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 場風の雀頭
/// </summary>
internal record JantouRoundWindFu : JantouFu
{
    public override int Number => 10;
    public override string Name { get; } = "場風の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 三元牌の雀頭
/// </summary>
internal record JantouDragonFu : JantouFu
{
    public override int Number => 11;
    public override string Name { get; } = "三元牌の雀頭";
    public override int Value { get; } = 2;
}

/// <summary>
/// 面子
/// </summary>
internal abstract record MentsuFu : Fu;

/// <summary>
/// 刻子
/// </summary>
internal abstract record KoutsuFu : MentsuFu;

/// <summary>
/// 明刻
/// </summary>
internal abstract record MinkoFu : KoutsuFu;

/// <summary>
/// 中張牌の明刻
/// </summary>
internal record MinkoChuchanFu : MinkoFu
{
    public override int Number => 12;
    public override string Name { get; } = "中張牌の明刻";
    public override int Value { get; } = 2;
}

/// <summary>
/// 么九牌の明刻
/// </summary>
internal record MinkoYaochuFu : MinkoFu
{
    public override int Number => 13;
    public override string Name { get; } = "么九牌の明刻";
    public override int Value { get; } = 4;
}

/// <summary>
/// 暗刻
/// </summary>
internal abstract record AnkoFu : KoutsuFu;

/// <summary>
/// 中張牌の暗刻
/// </summary>
internal record AnkoChuchanFu : AnkoFu
{
    public override int Number => 14;
    public override string Name { get; } = "中張牌の暗刻";
    public override int Value { get; } = 4;
}

/// <summary>
/// 么九牌の暗刻
/// </summary>
internal record AnkoYaochuFu : AnkoFu
{
    public override int Number => 15;
    public override string Name { get; } = "么九牌の暗刻";
    public override int Value { get; } = 8;
}

/// <summary>
/// 明槓
/// </summary>
internal abstract record MinkanFu : KoutsuFu;

/// <summary>
/// 中張牌の明槓
/// </summary>
internal record MinkanChuchanFu : MinkanFu
{
    public override int Number => 16;
    public override string Name { get; } = "中張牌の明槓";
    public override int Value { get; } = 8;
}

/// <summary>
/// 么九牌の明槓
/// </summary>
internal record MinkanYaochuFu : MinkanFu
{
    public override int Number => 17;
    public override string Name { get; } = "么九牌の明槓";
    public override int Value { get; } = 16;
}

/// <summary>
/// 暗槓
/// </summary>
internal abstract record AnkanFu : KoutsuFu;

/// <summary>
/// 中張牌の暗槓
/// </summary>
internal record AnkanChuchanFu : AnkanFu
{
    public override int Number => 18;
    public override string Name { get; } = "中張牌の暗槓";
    public override int Value { get; } = 16;
}

/// <summary>
/// 么九牌の暗槓
/// </summary>
internal record AnkanYaochuFu : AnkanFu
{
    public override int Number => 19;
    public override string Name { get; } = "么九牌の暗槓";
    public override int Value { get; } = 32;
}
