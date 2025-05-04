using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Tiles;

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
        var tileList = new TileList(man: "123456789");

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
        var tileList = new TileList(pin: "444555666");

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
        var tileList = new TileList(sou: "22334455667788");

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
        var toitsu1 = new TileList(man: "11");
        var toitsu2 = new TileList(pin: "55");
        var toitsu3 = new TileList(honor: "tt"); // 東東

        var notToitsu1 = new TileList(man: "12");
        var notToitsu2 = new TileList(man: "1");
        var notToitsu3 = new TileList(man: "111");

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
        var shuntsu1 = new TileList(man: "123");
        var shuntsu2 = new TileList(pin: "345");
        var shuntsu3 = new TileList(sou: "789");

        var notShuntsu1 = new TileList(man: "135"); // 連続していない
        var notShuntsu2 = new TileList(man: "9", pin: "12"); // 異なる種類
        var notShuntsu3 = new TileList(man: "12"); // 2枚しかない
        var notShuntsu4 = new TileList(honor: "tns"); // 字牌

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
        var koutsu1 = new TileList(man: "111");
        var koutsu2 = new TileList(pin: "555");
        var koutsu3 = new TileList(honor: "ttt"); // 東東東

        var notKoutsu1 = new TileList(man: "123"); // 順子
        var notKoutsu2 = new TileList(man: "11"); // 2枚しかない
        var notKoutsu3 = new TileList(man: "1111"); // 4枚ある（槓子）

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
        var kantsu1 = new TileList(man: "1111");
        var kantsu2 = new TileList(pin: "5555");
        var kantsu3 = new TileList(honor: "tttt"); // 東東東東

        var notKantsu1 = new TileList(man: "1234"); // 連続牌
        var notKantsu2 = new TileList(man: "111"); // 3枚しかない（刻子）
        var notKantsu3 = new TileList(man: "11"); // 2枚しかない（対子）

        // Act & Assert
        Assert.True(kantsu1.IsKantsu);
        Assert.True(kantsu2.IsKantsu);
        Assert.True(kantsu3.IsKantsu);

        Assert.False(notKantsu1.IsKantsu);
        Assert.False(notKantsu2.IsKantsu);
        Assert.False(notKantsu3.IsKantsu);
    }

    [Fact]
    public void Sorted_ソートされた新しいリストが返される()
    {
        // Arrange
        TileList unsorted = [Tile.Sou9, Tile.Man1, Tile.Ton, Tile.Pin5];

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
        var list1 = new TileList(man: "123");
        var list2 = new TileList(pin: "123");
        var list3 = new TileList(man: "12");
        var list4 = new TileList(man: "123");

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
        var list1 = new TileList(man: "12");
        var list2 = new TileList(man: "13");

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
        var list1 = new TileList(man: "12");
        var list2 = new TileList(man: "13");
        var list3 = new TileList(man: "12");

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
        var list1 = new TileList(man: "12");
        var list2 = new TileList(man: "13");

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
        var list1 = new TileList(man: "12");
        var list2 = new TileList(man: "13");
        var list3 = new TileList(man: "12");

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
        var tileList = new TileList(man: "1", pin: "2", sou: "3", honor: "t"); // 東
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
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var tileList3 = new TileList(honor: "tnsp"); // 東南西北
        var tileList4 = new TileList(man: "1", pin: "2", sou: "3", honor: "t"); // 東

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

    [Fact]
    public void CountOf_存在する牌の数を数える_正確な個数を返す()
    {
        // Arrange
        var tileList = new TileList(man: "112233");

        // Act
        var countOfMan1 = tileList.CountOf(Tile.Man1);
        var countOfMan2 = tileList.CountOf(Tile.Man2);
        var countOfMan3 = tileList.CountOf(Tile.Man3);
        var countOfPin1 = tileList.CountOf(Tile.Pin1);

        // Assert
        Assert.Equal(2, countOfMan1);
        Assert.Equal(2, countOfMan2);
        Assert.Equal(2, countOfMan3);
        Assert.Equal(0, countOfPin1);
    }

    [Fact]
    public void CountOf_存在しない牌の数を数える_0を返す()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "456");

        // Act
        var countOfSou1 = tileList.CountOf(Tile.Sou1);
        var countOfTon = tileList.CountOf(Tile.Ton);

        // Assert
        Assert.Equal(0, countOfSou1);
        Assert.Equal(0, countOfTon);
    }

    [Fact]
    public void CountOf_空の牌リストで牌の数を数える_0を返す()
    {
        // Arrange
        var emptyTileList = new TileList();

        // Act
        var count = emptyTileList.CountOf(Tile.Man1);

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public void Remove_存在する牌を1つ削除_その牌が削除された新しい牌リストを返す()
    {
        // Arrange
        var tileList = new TileList(man: "123");

        // Act
        var result = tileList.Remove(Tile.Man1);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(Tile.Man2, result[0]);
        Assert.Equal(Tile.Man3, result[1]);
        Assert.Equal(0, result.CountOf(Tile.Man1));
    }

    [Fact]
    public void Remove_存在する牌を複数削除_指定した個数の牌が削除された新しい牌リストを返す()
    {
        // Arrange
        var tileList = new TileList(man: "111222");

        // Act
        var result = tileList.Remove(Tile.Man1, 2);

        // Assert
        Assert.Equal(4, result.Count);
        Assert.Equal(1, result.CountOf(Tile.Man1));
        Assert.Equal(3, result.CountOf(Tile.Man2));
    }

    [Fact]
    public void Remove_牌のコレクションを削除_全ての牌が削除された新しい牌リストを返す()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "456");
        var tilesToRemove = new List<Tile> { Tile.Man1, Tile.Pin4, Tile.Pin6 };

        // Act
        var result = tileList.Remove(tilesToRemove);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(0, result.CountOf(Tile.Man1));
        Assert.Equal(1, result.CountOf(Tile.Man2));
        Assert.Equal(1, result.CountOf(Tile.Man3));
        Assert.Equal(0, result.CountOf(Tile.Pin4));
        Assert.Equal(1, result.CountOf(Tile.Pin5));
        Assert.Equal(0, result.CountOf(Tile.Pin6));
    }

    [Fact]
    public void Remove_空のコレクションを削除_元の牌リストと同じ内容の新しい牌リストを返す()
    {
        // Arrange
        var tileList = new TileList(man: "123");
        var emptyCollection = new List<Tile>();

        // Act
        var result = tileList.Remove(emptyCollection);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result.CountOf(Tile.Man1));
        Assert.Equal(1, result.CountOf(Tile.Man2));
        Assert.Equal(1, result.CountOf(Tile.Man3));
    }

    [Fact]
    public void Remove_存在しない牌のコレクションを削除_ArgumentExceptionをスローする()
    {
        // Arrange
        var tileList = new TileList(man: "123");
        var nonExistingTiles = new List<Tile> { Tile.Pin1 };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => tileList.Remove(nonExistingTiles));
        Assert.Equal("tile", exception.ParamName);
        Assert.Contains("指定牌がありません", exception.Message);
    }

    [Fact]
    public void Remove_存在する数より多くの牌を削除_ArgumentExceptionをスローする()
    {
        // Arrange
        var tileList = new TileList(man: "112");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => tileList.Remove(Tile.Man1, 3));
        Assert.Equal("tile", exception.ParamName);
        Assert.Contains("指定牌がありません", exception.Message);
    }

    [Fact]
    public void IsAllNumber_全て数牌の場合_trueを返す()
    {
        // Arrange
        var allNumber = new TileList(man: "123", pin: "45", sou: "789");
        // Act & Assert
        Assert.True(allNumber.IsAllNumber);
    }

    [Fact]
    public void IsAllNumber_字牌を含む場合_falseを返す()
    {
        // Arrange
        var mixedWithHonor = new TileList(man: "123", honor: "t");
        // Act & Assert
        Assert.False(mixedWithHonor.IsAllNumber);
    }

    [Fact]
    public void IsAllNumber_字牌のみの場合_falseを返す()
    {
        // Arrange
        var onlyHonor = new TileList(honor: "tnsp");
        // Act & Assert
        Assert.False(onlyHonor.IsAllNumber);
    }

    [Fact]
    public void IsAllHonor_全て字牌の場合_trueを返す()
    {
        // Arrange
        var allHonor = new TileList(honor: "tnsphrc"); // 東南西北白發中
        // Act & Assert
        Assert.True(allHonor.IsAllHonor);
    }

    [Fact]
    public void IsAllHonor_数牌を含む場合_falseを返す()
    {
        // Arrange
        var mixedWithNumber = new TileList(man: "1", honor: "tnsp");
        // Act & Assert
        Assert.False(mixedWithNumber.IsAllHonor);
    }

    [Fact]
    public void IsAllHonor_数牌のみの場合_falseを返す()
    {
        // Arrange
        var onlyNumber = new TileList(man: "123", pin: "45", sou: "789");
        // Act & Assert
        Assert.False(onlyNumber.IsAllHonor);
    }

    [Fact]
    public void IsAllWind_全て風牌の場合_trueを返す()
    {
        // Arrange
        var allWind = new TileList(honor: "tnsp"); // 東南西北
        // Act & Assert
        Assert.True(allWind.IsAllWind);
    }

    [Fact]
    public void IsAllWind_三元牌を含む場合_falseを返す()
    {
        // Arrange
        var mixedWithDragon = new TileList(honor: "tnsh"); // 東南西白
        // Act & Assert
        Assert.False(mixedWithDragon.IsAllWind);
    }

    [Fact]
    public void IsAllWind_数牌を含む場合_falseを返す()
    {
        // Arrange
        var mixedWithNumber = new TileList(honor: "tn", man: "1"); // 東南一
        // Act & Assert
        Assert.False(mixedWithNumber.IsAllWind);
    }

    [Fact]
    public void IsAllWind_数牌のみの場合_falseを返す()
    {
        // Arrange
        var onlyNumber = new TileList(man: "123");
        // Act & Assert
        Assert.False(onlyNumber.IsAllWind);
    }

    [Fact]
    public void IsAllDragon_全て三元牌の場合_trueを返す()
    {
        // Arrange
        var allDragon = new TileList(honor: "hrc"); // 白發中
        // Act & Assert
        Assert.True(allDragon.IsAllDragon);
    }

    [Fact]
    public void IsAllDragon_風牌を含む場合_falseを返す()
    {
        // Arrange
        var mixedWithWind = new TileList(honor: "thr"); // 東白發
        // Act & Assert
        Assert.False(mixedWithWind.IsAllDragon);
    }

    [Fact]
    public void IsAllDragon_数牌を含む場合_falseを返す()
    {
        // Arrange
        var mixedWithNumber = new TileList(honor: "hr", man: "1"); // 白發一
        // Act & Assert
        Assert.False(mixedWithNumber.IsAllDragon);
    }

    [Fact]
    public void IsAllDragon_数牌のみの場合_falseを返す()
    {
        // Arrange
        var onlyNumber = new TileList(man: "123");
        // Act & Assert
        Assert.False(onlyNumber.IsAllDragon);
    }

    [Fact]
    public void コンストラクタ_不正な萬子の文字_ArgumentExceptionをスローする()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new TileList(man: "X"));
        Assert.Equal("man", exception.ParamName);
        Assert.Contains("入力された萬子の文字が正しくありません", exception.Message);
    }

    [Fact]
    public void コンストラクタ_不正な筒子の文字_ArgumentExceptionをスローする()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new TileList(pin: "Y"));
        Assert.Equal("pin", exception.ParamName);
        Assert.Contains("入力された筒子の文字が正しくありません", exception.Message);
    }

    [Fact]
    public void コンストラクタ_不正な索子の文字_ArgumentExceptionをスローする()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new TileList(sou: "Z"));
        Assert.Equal("sou", exception.ParamName);
        Assert.Contains("入力された索子の文字が正しくありません", exception.Message);
    }

    [Fact]
    public void コンストラクタ_不正な字牌の文字_ArgumentExceptionをスローする()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new TileList(honor: "X"));
        Assert.Equal("honor", exception.ParamName);
        Assert.Contains("入力された字牌の文字が正しくありません", exception.Message);
    }
}
