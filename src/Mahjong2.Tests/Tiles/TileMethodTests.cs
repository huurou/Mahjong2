using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Tiles;

/// <summary>
/// Tileクラスのメソッドと演算子に関するテスト
/// </summary>
public class TileMethodTests
{
    [Fact]
    public void ToString_文字列表現の確認_正しい文字列が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal("一", Tile.Man1.ToString());
        Assert.Equal("二", Tile.Man2.ToString());
        Assert.Equal("三", Tile.Man3.ToString());
        Assert.Equal("四", Tile.Man4.ToString());
        Assert.Equal("五", Tile.Man5.ToString());
        Assert.Equal("六", Tile.Man6.ToString());
        Assert.Equal("七", Tile.Man7.ToString());
        Assert.Equal("八", Tile.Man8.ToString());
        Assert.Equal("九", Tile.Man9.ToString());
        Assert.Equal("(1)", Tile.Pin1.ToString());
        Assert.Equal("(2)", Tile.Pin2.ToString());
        Assert.Equal("(3)", Tile.Pin3.ToString());
        Assert.Equal("(4)", Tile.Pin4.ToString());
        Assert.Equal("(5)", Tile.Pin5.ToString());
        Assert.Equal("(6)", Tile.Pin6.ToString());
        Assert.Equal("(7)", Tile.Pin7.ToString());
        Assert.Equal("(8)", Tile.Pin8.ToString());
        Assert.Equal("(9)", Tile.Pin9.ToString());
        Assert.Equal("1", Tile.Sou1.ToString());
        Assert.Equal("2", Tile.Sou2.ToString());
        Assert.Equal("3", Tile.Sou3.ToString());
        Assert.Equal("4", Tile.Sou4.ToString());
        Assert.Equal("5", Tile.Sou5.ToString());
        Assert.Equal("6", Tile.Sou6.ToString());
        Assert.Equal("7", Tile.Sou7.ToString());
        Assert.Equal("8", Tile.Sou8.ToString());
        Assert.Equal("9", Tile.Sou9.ToString());
        Assert.Equal("東", Tile.Ton.ToString());
        Assert.Equal("南", Tile.Nan.ToString());
        Assert.Equal("西", Tile.Sha.ToString());
        Assert.Equal("北", Tile.Pei.ToString());
        Assert.Equal("白", Tile.Haku.ToString());
        Assert.Equal("發", Tile.Hatsu.ToString());
        Assert.Equal("中", Tile.Chun.ToString());
    }

    [Fact]
    public void CompareTo_牌の種類での比較_正しい順序で比較できる()
    {
        // Arrange & Act & Assert
        // 萬子 < 筒子 < 索子 < 風牌 < 三元牌
        Assert.True(Tile.Man1.CompareTo(Tile.Pin1) < 0); // 萬子 < 筒子
        Assert.True(Tile.Pin1.CompareTo(Tile.Sou1) < 0);  // 筒子 < 索子
        Assert.True(Tile.Sou1.CompareTo(Tile.Ton) < 0);   // 索子 < 風牌
        Assert.True(Tile.Ton.CompareTo(Tile.Haku) < 0);   // 風牌 < 三元牌

        // 逆の比較も確認
        Assert.True(Tile.Pin1.CompareTo(Tile.Man1) > 0);
        Assert.True(Tile.Sou1.CompareTo(Tile.Pin1) > 0);
        Assert.True(Tile.Ton.CompareTo(Tile.Sou1) > 0);
        Assert.True(Tile.Haku.CompareTo(Tile.Ton) > 0);
    }

    [Fact]
    public void CompareTo_同じ種類の牌での比較_数字順で比較できる()
    {
        // Arrange & Act & Assert
        // 萬子での比較（数字の昇順）
        Assert.True(Tile.Man1.CompareTo(Tile.Man2) < 0);
        Assert.True(Tile.Man5.CompareTo(Tile.Man9) < 0);

        // 筒子での比較
        Assert.True(Tile.Pin3.CompareTo(Tile.Pin7) < 0);
        Assert.True(Tile.Pin9.CompareTo(Tile.Pin5) > 0);

        // 索子での比較
        Assert.True(Tile.Sou1.CompareTo(Tile.Sou4) < 0);
        Assert.True(Tile.Sou8.CompareTo(Tile.Sou2) > 0);

        // 同じ牌どうしの比較は0
        Assert.Equal(0, Tile.Man5.CompareTo(Tile.Man5));
        Assert.Equal(0, Tile.Pin7.CompareTo(Tile.Pin7));
        Assert.Equal(0, Tile.Sou3.CompareTo(Tile.Sou3));
    }

    [Fact]
    public void CompareTo_風牌どうしの比較_東南西北の順で比較できる()
    {
        // Arrange & Act & Assert
        // 風牌の順序: 東 < 南 < 西 < 北
        Assert.True(Tile.Ton.CompareTo(Tile.Nan) < 0); // 東 < 南
        Assert.True(Tile.Nan.CompareTo(Tile.Sha) < 0); // 南 < 西
        Assert.True(Tile.Sha.CompareTo(Tile.Pei) < 0); // 西 < 北

        // 逆の比較も確認
        Assert.True(Tile.Nan.CompareTo(Tile.Ton) > 0);
        Assert.True(Tile.Sha.CompareTo(Tile.Nan) > 0);
        Assert.True(Tile.Pei.CompareTo(Tile.Sha) > 0);

        // 同じ牌どうしの比較は0
        Assert.Equal(0, Tile.Ton.CompareTo(Tile.Ton));
        Assert.Equal(0, Tile.Nan.CompareTo(Tile.Nan));
        Assert.Equal(0, Tile.Sha.CompareTo(Tile.Sha));
        Assert.Equal(0, Tile.Pei.CompareTo(Tile.Pei));
    }

    [Fact]
    public void CompareTo_三元牌どうしの比較_白發中の順で比較できる()
    {
        // Arrange & Act & Assert
        // 三元牌の順序: 白 < 發 < 中
        Assert.True(Tile.Haku.CompareTo(Tile.Hatsu) < 0);  // 白 < 發
        Assert.True(Tile.Hatsu.CompareTo(Tile.Chun) < 0);  // 發 < 中

        // 逆の比較も確認
        Assert.True(Tile.Hatsu.CompareTo(Tile.Haku) > 0);
        Assert.True(Tile.Chun.CompareTo(Tile.Hatsu) > 0);

        // 同じ牌どうしの比較は0
        Assert.Equal(0, Tile.Haku.CompareTo(Tile.Haku));
        Assert.Equal(0, Tile.Hatsu.CompareTo(Tile.Hatsu));
        Assert.Equal(0, Tile.Chun.CompareTo(Tile.Chun));
    }

    /// <summary>
    /// CompareTo()メソッドがnullと比較した場合に正しく動作することを確認
    /// </summary>
    [Fact]
    public void CompareTo_null値との比較_正の値を返す()
    {
        // Arrange & Act & Assert
        // null値との比較は常に1(正の値)を返す
        Assert.True(Tile.Man1.CompareTo(null) > 0);
        Assert.True(Tile.Pin5.CompareTo(null) > 0);
        Assert.True(Tile.Sou9.CompareTo(null) > 0);
        Assert.True(Tile.Ton.CompareTo(null) > 0);
        Assert.True(Tile.Haku.CompareTo(null) > 0);
    }

    /// <summary>
    /// 比較演算子が正しく動作することを確認
    /// </summary>
    [Fact]
    public void 比較演算子_各種比較演算子_正しく比較できる()
    {
        // Arrange & Act & Assert
        // < 演算子のテスト
        Assert.True(Tile.Man1 < Tile.Pin1); // 萬子 < 筒子
        Assert.True(Tile.Man1 < Tile.Man2); // 同じ種類では数字順
        Assert.True(Tile.Ton < Tile.Nan);   // 字牌も順序通り
        Assert.False(Tile.Pin1 < Tile.Man1);
        Assert.False(Tile.Man2 < Tile.Man2); // 等しい場合はfalse

        // > 演算子のテスト
        Assert.True(Tile.Pin1 > Tile.Man1);
        Assert.True(Tile.Man5 > Tile.Man3);
        Assert.True(Tile.Hatsu > Tile.Haku);
        Assert.False(Tile.Man1 > Tile.Pin1);
        Assert.False(Tile.Man2 > Tile.Man2); // 等しい場合はfalse

        // <= 演算子のテスト
        Assert.True(Tile.Man1 <= Tile.Pin1);
        Assert.True(Tile.Man1 <= Tile.Man2);
        Assert.True(Tile.Man2 <= Tile.Man2); // 等しい場合はtrue
        Assert.False(Tile.Pin1 <= Tile.Man1);

        // >= 演算子のテスト
        Assert.True(Tile.Pin1 >= Tile.Man1);
        Assert.True(Tile.Man5 >= Tile.Man3);
        Assert.True(Tile.Man2 >= Tile.Man2); // 等しい場合はtrue
        Assert.False(Tile.Man1 >= Tile.Pin1);
    }

    /// <summary>
    /// null値との比較演算子が正しく動作することを確認
    /// </summary>
    [Fact]
    public void 比較演算子_null値との比較_正しく比較できる()
    {
        // Arrange & Act & Assert
        // null との比較
        Assert.True(Tile.Man1 > null);      // 任意の牌 > null
        Assert.True(Tile.Pin9 > null);
        Assert.True(Tile.Chun > null);

        Assert.False(Tile.Man1 < null);     // null < 任意の牌
        Assert.False(Tile.Pin9 < null);
        Assert.False(Tile.Chun < null);

        Assert.True(Tile.Man1 >= null);     // 任意の牌 >= null
        Assert.True(null <= Tile.Man1);     // null <= 任意の牌

        Assert.False(Tile.Man1 <= null);    // 任意の牌 <= null
        Assert.False(null >= Tile.Man1);    // null >= 任意の牌
    }

    /// <summary>
    /// ソートが正しく動作することを確認
    /// </summary>
    [Fact]
    public void 比較演算子_ソートでの利用_順序通りにソートできる()
    {
        // Arrange
        var unsortedTiles = new List<Tile>
        {
            Tile.Chun, Tile.Ton, Tile.Man5, Tile.Sou1, Tile.Pin9,
            Tile.Haku, Tile.Pei, Tile.Man1, Tile.Pin1, Tile.Sou9,
            Tile.Sha, Tile.Man9, Tile.Hatsu, Tile.Nan, Tile.Pin3
        };

        var expectedOrder = new List<Tile>
        {
            // 萬子
            Tile.Man1, Tile.Man5, Tile.Man9,
            // 筒子
            Tile.Pin1, Tile.Pin3, Tile.Pin9,
            // 索子
            Tile.Sou1, Tile.Sou9,
            // 風牌
            Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei,
            // 三元牌
            Tile.Haku, Tile.Hatsu, Tile.Chun
        };

        // Act
        var sortedTiles = unsortedTiles.OrderBy(t => t).ToList();

        // Assert
        Assert.Equal(expectedOrder, sortedTiles);
    }

    [Theory]
    [InlineData("Man1", "Man2")]
    [InlineData("Man2", "Man3")]
    [InlineData("Man3", "Man4")]
    [InlineData("Man4", "Man5")]
    [InlineData("Man5", "Man6")]
    [InlineData("Man6", "Man7")]
    [InlineData("Man7", "Man8")]
    [InlineData("Man8", "Man9")]
    [InlineData("Man9", "Man1")]
    [InlineData("Pin1", "Pin2")]
    [InlineData("Pin2", "Pin3")]
    [InlineData("Pin3", "Pin4")]
    [InlineData("Pin4", "Pin5")]
    [InlineData("Pin5", "Pin6")]
    [InlineData("Pin6", "Pin7")]
    [InlineData("Pin7", "Pin8")]
    [InlineData("Pin8", "Pin9")]
    [InlineData("Pin9", "Pin1")]
    [InlineData("Sou1", "Sou2")]
    [InlineData("Sou2", "Sou3")]
    [InlineData("Sou3", "Sou4")]
    [InlineData("Sou4", "Sou5")]
    [InlineData("Sou5", "Sou6")]
    [InlineData("Sou6", "Sou7")]
    [InlineData("Sou7", "Sou8")]
    [InlineData("Sou8", "Sou9")]
    [InlineData("Sou9", "Sou1")]
    [InlineData("Ton", "Nan")]
    [InlineData("Nan", "Sha")]
    [InlineData("Sha", "Pei")]
    [InlineData("Pei", "Ton")]
    [InlineData("Haku", "Hatsu")]
    [InlineData("Hatsu", "Chun")]
    [InlineData("Chun", "Haku")]
    public void GetActualDora_正しいドラが返る(string indicatorName, string expectedName)
    {
        // Arrange
        var indicator = typeof(Tile).GetProperty(indicatorName)!.GetValue(null) as Tile;
        var expected = typeof(Tile).GetProperty(expectedName)!.GetValue(null) as Tile;

        // Act
        var actual = Tile.GetActualDora(indicator!);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetActualDora_不正な牌を渡した場合_例外が発生する()
    {
        // Arrange
        var dummy = new DummyTile();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Tile.GetActualDora(dummy));
    }

    private record DummyTile : Tile { }
}
