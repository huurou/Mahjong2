using Mahjong2.Lib.Scoring.Yakus;
using System.Collections;

namespace Mahjong2.Tests.Scoring.Yakus;

public class YakuListTests
{
    [Fact]
    public void 空のYakuList作成_要素がない_成功する()
    {
        // Arrange & Act
        var yakuList = new YakuList();

        // Assert
        Assert.Empty(yakuList);
        Assert.Equal(0, yakuList.HanOpen);
        Assert.Equal(0, yakuList.HanClosed);
    }

    [Fact]
    public void コレクション指定コンストラクタ_役が追加される_成功する()
    {
        // Arrange
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };

        // Act
        var yakuList = new YakuList(yakus);

        // Assert
        Assert.Equal(2, yakuList.Count);
        Assert.Contains(Yaku.Tanyao, yakuList);
        Assert.Contains(Yaku.Pinfu, yakuList);
    }

    [Fact]
    public void HanOpen_役を追加_正しい翻数を返す()
    {
        // Arrange
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu, Yaku.Sanshoku };

        // Act
        var yakuList = new YakuList(yakus);

        // Assert
        // Tanyao: 1翻, Pinfu: 0翻(面前限定), Sanshoku: 1翻(副露時)
        Assert.Equal(2, yakuList.HanOpen);
    }

    [Fact]
    public void HanClosed_役を追加_正しい翻数を返す()
    {
        // Arrange
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu, Yaku.Sanshoku };

        // Act
        var yakuList = new YakuList(yakus);

        // Assert
        // Tanyao: 1翻, Pinfu: 1翻, Sanshoku: 2翻(面前時)
        Assert.Equal(4, yakuList.HanClosed);
    }

    [Fact]
    public void GetEnumerator_列挙可能_正しく列挙できる()
    {
        // Arrange
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList = new YakuList(yakus);

        // Act
        var enumerated = new List<Yaku>();
        foreach (var yaku in yakuList)
        {
            enumerated.Add(yaku);
        }

        // Assert
        Assert.Equal(2, enumerated.Count);
        Assert.Contains(Yaku.Tanyao, enumerated);
        Assert.Contains(Yaku.Pinfu, enumerated);
    }

    [Fact]
    public void ToString_空のリスト_空文字列を返す()
    {
        // Arrange
        var yakuList = new YakuList();

        // Act
        var result = yakuList.ToString();

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void ToString_複数の役_空白区切りの文字列を返す()
    {
        // Arrange
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList = new YakuList(yakus);

        // Act
        var result = yakuList.ToString();

        // Assert
        Assert.Equal($"{Yaku.Tanyao} {Yaku.Pinfu}", result);
    }

    [Fact]
    public void YakuListBuilder_Create_正しくYakuListを生成する()
    {
        // Arrange
        var yakus = new Yaku[] { Yaku.Tanyao, Yaku.Pinfu };

        // Act
        var yakuList = YakuList.YakuListBuilder.Create(yakus);

        // Assert
        Assert.Equal(2, yakuList.Count);
        Assert.Contains(Yaku.Tanyao, yakuList);
        Assert.Contains(Yaku.Pinfu, yakuList);
    }

    [Fact]
    public void IEnumerable実装_正しく列挙できる()
    {
        // Arrange
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList = new YakuList(yakus);
        var enumerable = (IEnumerable)yakuList;

        // Act
        var enumerated = new List<Yaku>();
        foreach (var yaku in enumerable)
        {
            enumerated.Add((Yaku)yaku);
        }

        // Assert
        Assert.Equal(2, enumerated.Count);
        Assert.Contains(Yaku.Tanyao, enumerated);
        Assert.Contains(Yaku.Pinfu, enumerated);
    }

    [Fact]
    public void Add_役を追加_新しいYakuListに役が含まれる()
    {
        // Arrange
        var yakuList = new YakuList();
        var yaku = Yaku.Tanyao;

        // Act
        var newList = yakuList.Add(yaku);

        // Assert
        Assert.Empty(yakuList); // 元のリストは不変
        Assert.Single(newList);
        Assert.Contains(yaku, newList);
    }

    [Fact]
    public void AddRange_複数役を追加_新しいYakuListに全て含まれる()
    {
        // Arrange
        var yakuList = new YakuList();
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu, Yaku.Sanshoku };

        // Act
        var newList = yakuList.AddRange(yakus);

        // Assert
        Assert.Empty(yakuList); // 元のリストは不変
        Assert.Equal(3, newList.Count);
        Assert.Contains(Yaku.Tanyao, newList);
        Assert.Contains(Yaku.Pinfu, newList);
        Assert.Contains(Yaku.Sanshoku, newList);
    }

    [Fact]
    public void AddRange_空の役リストに追加_新しい役リストに全ての役が含まれる()
    {
        // Arrange
        var emptyList = new YakuList();
        var yakus = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };

        // Act
        var result = emptyList.AddRange(yakus);

        // Assert
        Assert.Empty(emptyList); // 元のリストは不変
        Assert.Equal(2, result.Count);
        Assert.Contains(Yaku.Tanyao, result);
        Assert.Contains(Yaku.Pinfu, result);
    }

    [Fact]
    public void AddRange_中身がある役リストに追加_既存と新規の役がすべて含まれる()
    {
        // Arrange
        var initialYakus = new List<Yaku> { Yaku.Tanyao };
        var yakuList = new YakuList(initialYakus);
        var additionalYakus = new List<Yaku> { Yaku.Pinfu, Yaku.Sanshoku };

        // Act
        var result = yakuList.AddRange(additionalYakus);

        // Assert
        Assert.Single(yakuList); // 元のリストは不変
        Assert.Equal(3, result.Count);
        Assert.Contains(Yaku.Tanyao, result);
        Assert.Contains(Yaku.Pinfu, result);
        Assert.Contains(Yaku.Sanshoku, result);
    }

    [Fact]
    public void AddRange_重複する役を追加_全ての役が含まれる()
    {
        // Arrange
        var yakuList = new YakuList([Yaku.Tanyao]);

        // Act
        var result = yakuList.Add(Yaku.Tanyao);

        // Assert
        Assert.Single(yakuList); // 元のリストは不変
        Assert.Equal(2, result.Count); // 重複も許可される
        Assert.Equal(2, result.Count(y => y == Yaku.Tanyao));
    }

    [Fact]
    public void Equals_同じ役を含む_trueを返す()
    {
        // Arrange
        var yakus1 = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList1 = new YakuList(yakus1);
        var yakus2 = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList2 = new YakuList(yakus2);

        // Act & Assert
        Assert.True(yakuList1.Equals(yakuList2));
        Assert.True(yakuList2.Equals(yakuList1));
        Assert.Equal(yakuList1, yakuList2); // 演算子のテスト
    }

    [Fact]
    public void Equals_異なる役を含む_falseを返す()
    {
        // Arrange
        var yakuList1 = new YakuList([Yaku.Tanyao, Yaku.Pinfu]);
        var yakuList2 = new YakuList([Yaku.Tanyao, Yaku.Sanshoku]);

        // Act & Assert
        Assert.False(yakuList1.Equals(yakuList2));
        Assert.False(yakuList2.Equals(yakuList1));
        Assert.NotEqual(yakuList1, yakuList2); // 演算子のテスト
    }

    [Fact]
    public void Equals_順序が異なる_falseを返す()
    {
        // Arrange
        var yakuList1 = new YakuList([Yaku.Tanyao, Yaku.Pinfu]);
        var yakuList2 = new YakuList([Yaku.Pinfu, Yaku.Tanyao]);

        // Act & Assert
        Assert.False(yakuList1.Equals(yakuList2));
        Assert.False(yakuList2.Equals(yakuList1));
        Assert.NotEqual(yakuList1, yakuList2); // 演算子のテスト
    }

    [Fact]
    public void Equals_nullとの比較_falseを返す()
    {
        // Arrange
        var yakuList = new YakuList([Yaku.Tanyao]);
        YakuList? nullYakuList = null;

        // Act & Assert
        Assert.False(yakuList.Equals(nullYakuList));
    }

    [Fact]
    public void GetHashCode_同じ内容_同じハッシュコードを返す()
    {
        // Arrange
        var yakus1 = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList1 = new YakuList(yakus1);
        var yakus2 = new List<Yaku> { Yaku.Tanyao, Yaku.Pinfu };
        var yakuList2 = new YakuList(yakus2);

        // Act
        var hashCode1 = yakuList1.GetHashCode();
        var hashCode2 = yakuList2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void GetHashCode_異なる内容_異なるハッシュコードを返す()
    {
        // Arrange
        var yakuList1 = new YakuList([Yaku.Tanyao, Yaku.Pinfu]);
        var yakuList2 = new YakuList([Yaku.Tanyao, Yaku.Sanshoku]);

        // Act
        var hashCode1 = yakuList1.GetHashCode();
        var hashCode2 = yakuList2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
}