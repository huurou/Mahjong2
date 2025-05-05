using Mahjong2.Lib.Scoring.Tiles;
using System.Collections;
using Mahjong2.Lib.Scoring.Shantens;

namespace Mahjong2.Tests.Scoring.Shantens;

public class IsolationSetTests
{
    [Fact]
    public void 空のコンストラクタ_初期化した場合_空のセットが作成される()
    {
        // Arrange & Act
        var isolationSet = new IsolationSet();

        // Assert
        Assert.Empty(isolationSet);
        Assert.Equal(0, isolationSet.Count);
    }

    [Fact]
    public void コレクションコンストラクタ_タイルのコレクションで初期化した場合_指定したタイルを含むセットが作成される()
    {
        // Arrange
        var tileList = new TileList(man: "1123");

        // Act
        var isolationSet = new IsolationSet(tileList);

        // Assert
        Assert.Equal(3, isolationSet.Count);
        Assert.Contains(Tile.Man1, isolationSet);
        Assert.Contains(Tile.Man2, isolationSet);
        Assert.Contains(Tile.Man3, isolationSet);
    }

    [Fact]
    public void Count_重複するタイルを含むコレクションで初期化した場合_重複が除去されて正しい数が返される()
    {
        // Arrange
        var tileList = new TileList(man: "1123");

        // Act
        var isolationSet = new IsolationSet(tileList);

        // Assert
        Assert.Equal(3, isolationSet.Count); // 重複したMan1は1回だけカウントされる
    }

    [Fact]
    public void GetEnumerator_列挙した場合_すべての要素を順に取得できる()
    {
        // Arrange
        var tiles = new List<Tile> { Tile.Man1, Tile.Man2, Tile.Pin3 };
        var isolationSet = new IsolationSet(tiles);

        // Act
        var enumeratedTiles = isolationSet.ToList();

        // Assert
        Assert.Equal(3, enumeratedTiles.Count);
        Assert.Contains(Tile.Man1, enumeratedTiles);
        Assert.Contains(Tile.Man2, enumeratedTiles);
        Assert.Contains(Tile.Pin3, enumeratedTiles);
    }

    [Fact]
    public void 非ジェネリック版GetEnumerator_IEnumerableとしてキャストして列挙した場合_すべての要素を順に取得できる()
    {
        // Arrange
        var tiles = new List<Tile> { Tile.Man1, Tile.Man2, Tile.Pin3 };
        var isolationSet = new IsolationSet(tiles);
        var enumerableSet = (IEnumerable)isolationSet;

        // Act
        var enumeratedTiles = new List<Tile>();
        foreach (Tile tile in enumerableSet)
        {
            enumeratedTiles.Add(tile);
        }

        // Assert
        Assert.Equal(3, enumeratedTiles.Count);
        Assert.Contains(Tile.Man1, enumeratedTiles);
        Assert.Contains(Tile.Man2, enumeratedTiles);
        Assert.Contains(Tile.Pin3, enumeratedTiles);
    }

    [Fact]
    public void IsolationSetBuilder_CreateメソッドでSpanから作成した場合_正しいセットが作成される()
    {
        // Arrange
        var tiles = new Tile[] { Tile.Man1, Tile.Man2, Tile.Pin3 };

        // Act
        IsolationSet isolationSet = [.. tiles];

        // Assert
        Assert.Equal(3, isolationSet.Count);
        Assert.Contains(Tile.Man1, isolationSet);
        Assert.Contains(Tile.Man2, isolationSet);
        Assert.Contains(Tile.Pin3, isolationSet);
    }
}