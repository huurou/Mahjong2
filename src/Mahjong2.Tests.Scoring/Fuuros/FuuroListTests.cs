using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Tiles;
using System.Collections;

namespace Mahjong2.Tests.Scoring.Fuuros;

public class FuuroListTests
{
    [Fact]
    public void 空のコンストラクタ_空のリストを作成できる()
    {
        // Arrange & Act
        var fuuroList = new FuuroList();

        // Assert
        Assert.Empty(fuuroList);
        Assert.False(fuuroList.HasOpen);
        Assert.Empty(fuuroList.TileLists);
    }

    [Fact]
    public void 副露のコレクションで初期化_正しくリストを作成できる()
    {
        // Arrange
        var chi = new Chi(new(man: "123"));
        var pon = new Pon(new(pin: "777"));

        // Act
        FuuroList fuuroList = [chi, pon];

        // Assert
        Assert.Equal(2, fuuroList.Count);
        Assert.Contains(chi, fuuroList);
        Assert.Contains(pon, fuuroList);
        Assert.True(fuuroList.HasOpen);
        Assert.Equal(2, fuuroList.TileLists.Count);
        Assert.Contains(chi.TileList, fuuroList.TileLists);
        Assert.Contains(pon.TileList, fuuroList.TileLists);
    }

    [Fact]
    public void ToString_正しい文字列表現を返す()
    {
        // Arrange
        var chi = new Chi(new(man: "123"));
        var pon = new Pon(new(pin: "777"));
        FuuroList fuuroList = [chi, pon];

        // Act
        var result = fuuroList.ToString();

        // Assert
        Assert.Equal($"{chi} {pon}", result);
    }

    [Fact]
    public void HasOpen_門前でない副露がある場合はTrue()
    {
        // Arrange
        var chi = new Chi(new(man: "123"));
        var fuuroList = new FuuroList([chi]);

        // Act & Assert
        Assert.True(fuuroList.HasOpen);
    }

    [Fact]
    public void HasOpen_門前の副露のみの場合はFalse()
    {
        // Arrange
        var ankan = new Ankan(new(man: "1111"));
        var nuki = new Nuki(new(honor: "p"));
        FuuroList fuuroList = [ankan, nuki];

        // Act & Assert
        Assert.False(fuuroList.HasOpen);
    }

    [Fact]
    public void TileLists_すべての副露の牌リストを取得できる()
    {
        // Arrange
        var chiTiles = new TileList(man: "123");
        var ponTiles = new TileList(pin: "777");
        var ankanTiles = new TileList(sou: "8888");

        var chi = new Chi(chiTiles);
        var pon = new Pon(ponTiles);
        var ankan = new Ankan(ankanTiles);

        FuuroList fuuroList = [chi, pon, ankan];

        // Act
        var tileLists = fuuroList.TileLists;

        // Assert
        Assert.Equal(3, tileLists.Count);
        Assert.Contains(chiTiles, tileLists);
        Assert.Contains(ponTiles, tileLists);
        Assert.Contains(ankanTiles, tileLists);
    }

    [Fact]
    public void CollectionInitializer_正しくリストを作成できる()
    {
        // Arrange
        var chi = new Chi(new(man: "123"));
        var pon = new Pon(new(pin: "777"));

        // Act
        FuuroList fuuroList = [chi, pon];

        // Assert
        Assert.Equal(2, fuuroList.Count);
        Assert.Contains(chi, fuuroList);
        Assert.Contains(pon, fuuroList);
    }

    [Fact]
    public void GetEnumerator明示的実装_正しく要素を列挙できる()
    {
        // Arrange
        var chi = new Chi(new(man: "123"));
        var pon = new Pon(new(pin: "777"));
        FuuroList fuuroList = [chi, pon];
        List<Fuuro> expectedFuuros = [chi, pon];

        // Act
        var actualFuuros = new List<Fuuro>();
        IEnumerable enumerable = fuuroList;
        foreach (Fuuro fuuro in enumerable)
        {
            actualFuuros.Add(fuuro);
        }

        // Assert
        Assert.Equal(expectedFuuros.Count, actualFuuros.Count);
        for (var i = 0; i < expectedFuuros.Count; i++)
        {
            Assert.Same(expectedFuuros[i], actualFuuros[i]);
        }
    }
}