using Mahjong2.Lib.Tiles;

namespace Mahjong2.Tests.Tiles;

/// <summary>
/// TileListクラスのテスト
/// </summary>
public class TileListTests
{
    [Fact]
    public void コンストラクタ_空のコンストラクタ_空の牌リストが作成される()
    {
        // Arrange & Act
        var tileList = new TileList();

        // Assert
        Assert.Empty(tileList);
        Assert.Equal(0, tileList.Count);
    }

    [Fact]
    public void コンストラクタ_牌コレクションから_正しく牌リストが作成される()
    {
        // Arrange
        List<Tile> tiles = [Tile.Man1, Tile.Pin2, Tile.Sou3];

        // Act
        var tileList = new TileList(tiles);

        // Assert
        Assert.Equal(3, tileList.Count);
        Assert.Equal(Tile.Man1, tileList[0]);
        Assert.Equal(Tile.Pin2, tileList[1]);
        Assert.Equal(Tile.Sou3, tileList[2]);
    }

    [Fact]
    public void コンストラクタ_文字列から_正しく牌リストが作成される()
    {
        // Arrange & Act
        var tileList = new TileList(man: "123", pin: "456", sou: "789", honor: "tnsp");

        // Assert
        Assert.Equal(13, tileList.Count);

        // 萬子の確認
        Assert.Equal(Tile.Man1, tileList[0]);
        Assert.Equal(Tile.Man2, tileList[1]);
        Assert.Equal(Tile.Man3, tileList[2]);

        // 筒子の確認
        Assert.Equal(Tile.Pin4, tileList[3]);
        Assert.Equal(Tile.Pin5, tileList[4]);
        Assert.Equal(Tile.Pin6, tileList[5]);

        // 索子の確認
        Assert.Equal(Tile.Sou7, tileList[6]);
        Assert.Equal(Tile.Sou8, tileList[7]);
        Assert.Equal(Tile.Sou9, tileList[8]);

        // 字牌の確認
        Assert.Equal(Tile.Ton, tileList[9]);
        Assert.Equal(Tile.Nan, tileList[10]);
        Assert.Equal(Tile.Sha, tileList[11]);
        Assert.Equal(Tile.Pei, tileList[12]);
    }

    [Fact]
    public void IsAllMan_全て萬子の場合_trueを返す()
    {
        // Arrange
        var tileList = new TileList(man: "123");

        // Act & Assert
        Assert.True(tileList.IsAllMan);
        Assert.False(tileList.IsAllPin);
        Assert.False(tileList.IsAllSou);
        Assert.True(tileList.IsAllSameSuit);
    }

    [Fact]
    public void IsAllPin_全て筒子の場合_trueを返す()
    {
        // Arrange
        var tileList = new TileList(pin: "456");

        // Act & Assert
        Assert.False(tileList.IsAllMan);
        Assert.True(tileList.IsAllPin);
        Assert.False(tileList.IsAllSou);
        Assert.True(tileList.IsAllSameSuit);
    }

    [Fact]
    public void IsAllSou_全て索子の場合_trueを返す()
    {
        // Arrange
        var tileList = new TileList(sou: "789");

        // Act & Assert
        Assert.False(tileList.IsAllMan);
        Assert.False(tileList.IsAllPin);
        Assert.True(tileList.IsAllSou);
        Assert.True(tileList.IsAllSameSuit);
    }

    [Fact]
    public void IsAllSameSuit_異なる種類の牌が混在している場合_falseを返す()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "456");

        // Act & Assert
        Assert.False(tileList.IsAllMan);
        Assert.False(tileList.IsAllPin);
        Assert.False(tileList.IsAllSou);
        Assert.False(tileList.IsAllSameSuit);
    }

    [Fact]
    public void IsToitsu_対子の場合_trueを返す()
    {
        // Arrange
        TileList toitsu1 = [Tile.Man1, Tile.Man1];
        TileList toitsu2 = [Tile.Pin5, Tile.Pin5];
        TileList toitsu3 = [Tile.Ton, Tile.Ton];

        TileList notToitsu1 = [Tile.Man1, Tile.Man2];
        TileList notToitsu2 = [Tile.Man1];
        TileList notToitsu3 = [Tile.Man1, Tile.Man1, Tile.Man1];

        // Act & Assert
        Assert.True(toitsu1.IsToitsu);
        Assert.True(toitsu2.IsToitsu);
        Assert.True(toitsu3.IsToitsu);

        Assert.False(notToitsu1.IsToitsu);
        Assert.False(notToitsu2.IsToitsu);
        Assert.False(notToitsu3.IsToitsu);
    }

    [Fact]
    public void IsShuntsu_順子の場合_trueを返す()
    {
        // Arrange
        TileList shuntsu1 = [Tile.Man1, Tile.Man2, Tile.Man3];
        TileList shuntsu2 = [Tile.Pin3, Tile.Pin4, Tile.Pin5];
        TileList shuntsu3 = [Tile.Sou7, Tile.Sou8, Tile.Sou9];

        TileList notShuntsu1 = [Tile.Man1, Tile.Man3, Tile.Man5]; // 連続していない
        TileList notShuntsu2 = [Tile.Man9, Tile.Pin1, Tile.Pin2]; // 異なる種類
        TileList notShuntsu3 = [Tile.Man1, Tile.Man2]; // 2枚しかない
        TileList notShuntsu4 = [Tile.Ton, Tile.Nan, Tile.Sha]; // 字牌

        // Act & Assert
        Assert.True(shuntsu1.IsShuntsu);
        Assert.True(shuntsu2.IsShuntsu);
        Assert.True(shuntsu3.IsShuntsu);

        Assert.False(notShuntsu1.IsShuntsu);
        Assert.False(notShuntsu2.IsShuntsu);
        Assert.False(notShuntsu3.IsShuntsu);
        Assert.False(notShuntsu4.IsShuntsu);
    }

    [Fact]
    public void IsKoutsu_刻子の場合_trueを返す()
    {
        // Arrange
        TileList koutsu1 = [Tile.Man1, Tile.Man1, Tile.Man1];
        TileList koutsu2 = [Tile.Pin5, Tile.Pin5, Tile.Pin5];
        TileList koutsu3 = [Tile.Ton, Tile.Ton, Tile.Ton];

        TileList notKoutsu1 = [Tile.Man1, Tile.Man2, Tile.Man3]; // 順子
        TileList notKoutsu2 = [Tile.Man1, Tile.Man1]; // 2枚しかない
        TileList notKoutsu3 = [Tile.Man1, Tile.Man1, Tile.Man1, Tile.Man1]; // 4枚ある（槓子）

        // Act & Assert
        Assert.True(koutsu1.IsKoutsu);
        Assert.True(koutsu2.IsKoutsu);
        Assert.True(koutsu3.IsKoutsu);

        Assert.False(notKoutsu1.IsKoutsu);
        Assert.False(notKoutsu2.IsKoutsu);
        Assert.False(notKoutsu3.IsKoutsu);
    }

    [Fact]
    public void IsKantsu_槓子の場合_trueを返す()
    {
        // Arrange
        TileList kantsu1 = [Tile.Man1, Tile.Man1, Tile.Man1, Tile.Man1];
        TileList kantsu2 = [Tile.Pin5, Tile.Pin5, Tile.Pin5, Tile.Pin5];
        TileList kantsu3 = [Tile.Ton, Tile.Ton, Tile.Ton, Tile.Ton];

        TileList notKantsu1 = [Tile.Man1, Tile.Man2, Tile.Man3, Tile.Man4]; // 連続牌
        TileList notKantsu2 = [Tile.Man1, Tile.Man1, Tile.Man1]; // 3枚しかない（刻子）
        TileList notKantsu3 = [Tile.Man1, Tile.Man1]; // 2枚しかない（対子）

        // Act & Assert
        Assert.True(kantsu1.IsKantsu);
        Assert.True(kantsu2.IsKantsu);
        Assert.True(kantsu3.IsKantsu);

        Assert.False(notKantsu1.IsKantsu);
        Assert.False(notKantsu2.IsKantsu);
        Assert.False(notKantsu3.IsKantsu);
    }

    [Fact]
    public void Add_牌を追加_新しいリストが返される()
    {
        // Arrange
        TileList tileList = [Tile.Man1, Tile.Man2];

        // Act
        var newTileList = tileList.Add(Tile.Man3);

        // Assert
        Assert.Equal(2, tileList.Count); // 元のリストは変化しない
        Assert.Equal(3, newTileList.Count); // 新しいリストが返される
        Assert.Equal(Tile.Man3, newTileList[2]); // 追加された牌が末尾にある
    }

    [Fact]
    public void Sorted_ソートされた新しいリストが返される()
    {
        // Arrange
        TileList unsorted = [Tile.Pin5, Tile.Man1, Tile.Sou9, Tile.Ton];

        // Act
        var sorted = unsorted.Sorted();

        // Assert
        Assert.Equal(4, sorted.Count);
        Assert.Equal(Tile.Man1, sorted[0]); // 萬子が最初
        Assert.Equal(Tile.Pin5, sorted[1]); // 次に筒子
        Assert.Equal(Tile.Sou9, sorted[2]); // 次に索子
        Assert.Equal(Tile.Ton, sorted[3]); // 最後に字牌
    }

    [Fact]
    public void CompareTo_牌リストの比較_正しく比較できる()
    {
        // Arrange
        TileList list1 = [Tile.Man1, Tile.Man2, Tile.Man3];
        TileList list2 = [Tile.Pin1, Tile.Pin2, Tile.Pin3];
        TileList list3 = [Tile.Man1, Tile.Man2];
        TileList list4 = [Tile.Man1, Tile.Man2, Tile.Man3];

        // Act & Assert
        Assert.True(list1.CompareTo(list2) < 0); // 萬子 < 筒子
        Assert.True(list2.CompareTo(list1) > 0); // 筒子 > 萬子
        Assert.True(list3.CompareTo(list1) < 0); // 要素数が少ない方が小さい
        Assert.Equal(0, list1.CompareTo(list4)); // 内容が同じなら0
        Assert.True(list1.CompareTo(null) > 0); // nullとの比較は常に正
    }

    [Fact]
    public void 演算子小なり_左辺が右辺より小さい場合_trueを返す()
    {
        // Arrange
        TileList list1 = [Tile.Man1, Tile.Man2];
        TileList list2 = [Tile.Man1, Tile.Man3];

        // Act & Assert
        Assert.True(list1 < list2);
        Assert.False(list2 < list1);
        Assert.True(null < list1);
        Assert.False(list1 < null);
    }

    [Fact]
    public void 演算子以下_左辺が右辺以下の場合_trueを返す()
    {
        // Arrange
        TileList list1 = [Tile.Man1, Tile.Man2];
        TileList list2 = [Tile.Man1, Tile.Man3];
        TileList list3 = [Tile.Man1, Tile.Man2];

        // Act & Assert
        Assert.True(list1 <= list2);
        Assert.False(list2 <= list1);
        Assert.True(list1 <= list3);
        Assert.True(null <= list1);
        Assert.False(list1 <= null);
    }

    [Fact]
    public void 演算子大なり_左辺が右辺より大きい場合_trueを返す()
    {
        // Arrange
        TileList list1 = [Tile.Man1, Tile.Man2];
        TileList list2 = [Tile.Man1, Tile.Man3];

        // Act & Assert
        Assert.False(list1 > list2);
        Assert.True(list2 > list1);
        Assert.False(null > list1);
        Assert.True(list1 > null);
    }

    [Fact]
    public void 演算子以上_左辺が右辺以上の場合_trueを返す()
    {
        // Arrange
        TileList list1 = [Tile.Man1, Tile.Man2];
        TileList list2 = [Tile.Man1, Tile.Man3];
        TileList list3 = [Tile.Man1, Tile.Man2];

        // Act & Assert
        Assert.False(list1 >= list2);
        Assert.True(list2 >= list1);
        Assert.True(list1 >= list3);
        Assert.False(null >= list1);
        Assert.True(list1 >= null);
    }

    [Fact]
    public void GetEnumerator_非ジェネリック版_ジェネリック版と同じ結果を返す()
    {
        // Arrange
        TileList tileList = [Tile.Man1, Tile.Pin2, Tile.Sou3, Tile.Ton];
        var expected = new List<Tile>();
        foreach (var tile in tileList)
        {
            expected.Add(tile);
        }

        // Act
        var actual = new List<Tile>();
        System.Collections.IEnumerable nonGenericList = tileList;
        foreach (Tile tile in nonGenericList)
        {
            actual.Add(tile);
        }

        // Assert
        Assert.Equal(expected.Count, actual.Count);
        for (var i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void ToString_牌リストの文字列表現_正しく変換される()
    {
        // Arrange
        TileList tileList1 = [Tile.Man1, Tile.Man2, Tile.Man3];
        TileList tileList2 = [Tile.Pin4, Tile.Pin5, Tile.Pin6];
        TileList tileList3 = [Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei];
        TileList tileList4 = [Tile.Man1, Tile.Pin2, Tile.Sou3, Tile.Ton];

        // Act
        var actual1 = tileList1.ToString();
        var actual2 = tileList2.ToString();
        var actual3 = tileList3.ToString();
        var actual4 = tileList4.ToString();

        // Assert
        Assert.Equal("一二三", actual1);
        Assert.Equal("(4)(5)(6)", actual2);
        Assert.Equal("東南西北", actual3);
        Assert.Equal("一(2)3東", actual4);
    }
}
