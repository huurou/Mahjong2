using Mahjong2.Lib.Tiles;
using System.Collections;

namespace Mahjong2.Tests.Tiles;

public class TileListListTests
{
    [Fact]
    public void コンストラクタ_空のコンストラクタ_空のコレクションが作成される()
    {
        // Arrange & Act
        var tileListList = new TileListList();

        // Assert
        Assert.Empty(tileListList);
        Assert.Equal(0, tileListList.Count);
    }

    [Fact]
    public void コンストラクタ_牌リストコレクションから_正しく牌リストリストが作成される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileList3 = new TileList(sou: "789");
        var tileLists = new List<TileList> { tileList1, tileList2, tileList3 };

        // Act
        var tileListList = new TileListList(tileLists);

        // Assert
        Assert.Equal(3, tileListList.Count);
        Assert.Equal(tileList1, tileListList[0]);
        Assert.Equal(tileList2, tileListList[1]);
        Assert.Equal(tileList3, tileListList[2]);
    }

    [Fact]
    public void インデクサー_正しいインデックスを指定_対応する牌リストを返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileLists = new List<TileList> { tileList1, tileList2 };
        var tileListList = new TileListList(tileLists);

        // Act
        var result1 = tileListList[0];
        var result2 = tileListList[1];

        // Assert
        Assert.Equal(tileList1, result1);
        Assert.Equal(tileList2, result2);
    }

    [Fact]
    public void IncludesKoutsu_刻子が含まれている場合_trueを返す()
    {
        // Arrange
        var koutsu = new TileList(man: "111"); // 刻子
        var shuntsu = new TileList(pin: "123"); // 順子
        var tileLists = new List<TileList> { koutsu, shuntsu };
        var tileListList = new TileListList(tileLists);

        // Act
        var result = tileListList.IncludesKoutsu(Tile.Man1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IncludesKoutsu_槓子が含まれている場合_trueを返す()
    {
        // Arrange
        var kantsu = new TileList(pin: "5555"); // 槓子
        var shuntsu = new TileList(man: "123"); // 順子
        var tileLists = new List<TileList> { kantsu, shuntsu };
        var tileListList = new TileListList(tileLists);

        // Act
        var result = tileListList.IncludesKoutsu(Tile.Pin5);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IncludesKoutsu_刻子も槓子も含まれていない場合_falseを返す()
    {
        // Arrange
        var shuntsu1 = new TileList(man: "123"); // 順子
        var shuntsu2 = new TileList(pin: "456"); // 順子
        var tileLists = new List<TileList> { shuntsu1, shuntsu2 };
        var tileListList = new TileListList(tileLists);

        // Act
        var result1 = tileListList.IncludesKoutsu(Tile.Man1);
        var result2 = tileListList.IncludesKoutsu(Tile.Pin4);

        // Assert
        Assert.False(result1);
        Assert.False(result2);
    }

    [Fact]
    public void IncludesKoutsu_空のコレクションの場合_falseを返す()
    {
        // Arrange
        var tileListList = new TileListList();

        // Act
        var result = tileListList.IncludesKoutsu(Tile.Man1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ToString_複数の牌リストがある場合_正しく文字列表現を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileLists = new List<TileList> { tileList1, tileList2 };
        var tileListList = new TileListList(tileLists);

        // Act
        var result = tileListList.ToString();

        // Assert
        Assert.Equal("[一二三][(4)(5)(6)]", result);
    }

    [Fact]
    public void ToString_空のコレクションの場合_空文字列を返す()
    {
        // Arrange
        var tileListList = new TileListList();

        // Act
        var result = tileListList.ToString();

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void GetEnumerator_正しく列挙できる()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileLists = new List<TileList> { tileList1, tileList2 };
        var tileListList = new TileListList(tileLists);
        var expected = new List<TileList> { tileList1, tileList2 };

        // Act
        var actual = new List<TileList>();
        foreach (var tileList in tileListList)
        {
            actual.Add(tileList);
        }

        // Assert
        Assert.Equal(expected.Count, actual.Count);
        for (var i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void GetEnumerator_非ジェネリック版_ジェネリック版と同じ結果を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileLists = new List<TileList> { tileList1, tileList2 };
        var tileListList = new TileListList(tileLists);
        var expected = new List<TileList>();
        foreach (var tileList in tileListList)
        {
            expected.Add(tileList);
        }

        // Act
        var actual = new List<TileList>();
        IEnumerable nonGenericList = tileListList;
        foreach (TileList tileList in nonGenericList)
        {
            actual.Add(tileList);
        }

        // Assert
        Assert.Equal(expected.Count, actual.Count);
        for (var i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void Equals_同じ内容のインスタンス_trueを返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList1, tileList2]);

        // Act & Assert
        Assert.True(tileListList1.Equals(tileListList2));
        Assert.True(tileListList2.Equals(tileListList1));
    }

    [Fact]
    public void Equals_順序が異なる同じ内容のインスタンス_trueを返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList2, tileList1]);

        // Act & Assert
        Assert.True(tileListList1.Equals(tileListList2));
        Assert.True(tileListList2.Equals(tileListList1));
    }

    [Fact]
    public void Equals_異なる内容のインスタンス_falseを返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileList3 = new TileList(sou: "789");

        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList1, tileList3]);

        // Act & Assert
        Assert.False(tileListList1.Equals(tileListList2));
        Assert.False(tileListList2.Equals(tileListList1));
    }

    [Fact]
    public void Equals_nullとの比較_falseを返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        var tileListList = new TileListList([tileList1, tileList2]);
        TileListList? nullTileListList = null;

        // Act & Assert
        Assert.False(tileListList.Equals(nullTileListList));
    }

    [Fact]
    public void GetHashCode_同じ内容のインスタンス_同じハッシュコードを返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList1, tileList2]);

        // Act
        var hashCode1 = tileListList1.GetHashCode();
        var hashCode2 = tileListList2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void TileListListBuilder_Create_正しく牌リストリストが作成される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        // Act
        TileListList tileListList = [tileList1, tileList2];

        // Assert
        Assert.Equal(2, tileListList.Count);
        Assert.Equal(tileList1, tileListList[0]);
        Assert.Equal(tileList2, tileListList[1]);
    }

    [Fact]
    public void CompareTo_引数がnullの場合_正の数を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileListList = new TileListList([tileList1, tileList2]);
        TileListList? other = null;

        // Act
        var result = tileListList.CompareTo(other);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void CompareTo_自分の方が要素数が少ない場合_負の数を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileListList1 = new TileListList([tileList1]);
        var tileList2 = new TileList(pin: "456");
        var tileListList2 = new TileListList([tileList1, tileList2]);

        // Act
        var result = tileListList1.CompareTo(tileListList2);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void CompareTo_自分の方が要素数が多い場合_正の数を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList1]);

        // Act
        var result = tileListList1.CompareTo(tileListList2);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void CompareTo_要素数が同じで自分の方が小さい場合_負の数を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList2, tileList2]);

        // Act
        var result = tileListList1.CompareTo(tileListList2);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void CompareTo_要素数が同じで自分の方が大きい場合_正の数を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileListList1 = new TileListList([tileList2, tileList2]);
        var tileListList2 = new TileListList([tileList1, tileList2]);

        // Act
        var result = tileListList1.CompareTo(tileListList2);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void CompareTo_全ての要素が等しい場合_0を返す()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileListList1 = new TileListList([tileList1, tileList2]);
        var tileListList2 = new TileListList([tileList1, tileList2]);

        // Act
        var result = tileListList1.CompareTo(tileListList2);

        // Assert
        Assert.Equal(0, result);
    }
}