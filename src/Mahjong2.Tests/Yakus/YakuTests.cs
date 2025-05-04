using Mahjong2.Lib.Internals.Yakus;

namespace Mahjong2.Tests.Yakus;

public class YakuTests
{
    [Fact]
    public void CompareTo_Nullと比較_1を返す()
    {
        // Arrange
        Yaku yaku = Yaku.Riichi;
        Yaku? other = null;

        // Act
        var result = yaku.CompareTo(other);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CompareTo_自分自身と比較_0を返す()
    {
        // Arrange
        Yaku yaku = Yaku.Riichi;
        Yaku other = Yaku.Riichi;

        // Act
        var result = yaku.CompareTo(other);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CompareTo_番号が小さい役と比較_正の値を返す()
    {
        // Arrange
        // RiichiとTanyaoを使用し、Numberプロパティの値を確認
        Yaku smallerYaku = Yaku.Riichi;
        Yaku largerYaku = Yaku.Tanyao;

        // 前提条件の検証（Numberが実際に異なることを確認）
        Assert.True(GetNumberProperty(smallerYaku) < GetNumberProperty(largerYaku));

        // Act
        var result = largerYaku.CompareTo(smallerYaku);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void CompareTo_番号が大きい役と比較_負の値を返す()
    {
        // Arrange
        // RiichiとTanyaoを使用
        Yaku smallerYaku = Yaku.Riichi;
        Yaku largerYaku = Yaku.Tanyao;

        // 前提条件の検証
        Assert.True(GetNumberProperty(smallerYaku) < GetNumberProperty(largerYaku));

        // Act
        var result = smallerYaku.CompareTo(largerYaku);

        // Assert
        Assert.True(result < 0);
    }

    // テスト用にNumberプロパティの値を取得するヘルパーメソッド
    private static int GetNumberProperty(Yaku yaku)
    {
        var property = typeof(Yaku).GetProperty("Number") ?? throw new InvalidOperationException("Numberプロパティが見つかりません");
        return (int)property.GetValue(yaku)!;
    }
}