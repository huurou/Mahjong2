namespace Mahjong2.Lib.Yakus.Impl;

/// <summary>
/// 裏ドラ
/// </summary>
internal record Uradora : Yaku
{
    public override int Number => 52;
    public override string Name => "裏ドラ";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}