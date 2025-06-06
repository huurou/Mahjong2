namespace Mahjong2.Lib.Scoring.Yakus.Impl;

/// <summary>
/// ドラ
/// </summary>
internal record Dora : Yaku
{
    public override int Number => 51;
    public override string Name => "ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}