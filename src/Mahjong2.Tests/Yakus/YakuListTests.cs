using Mahjong2.Lib.Yakus;
using System.Collections;

namespace Mahjong2.Tests.Yakus;

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
}