using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Tiles;

public class HandTests
{
    [Fact]
    public void コンストラクタ_空のコンストラクタ_空の手牌が作成される()
    {
        // Arrange & Act
        var hand = new Hand();

        // Assert
        Assert.Empty(hand);
        Assert.Equal(0, hand.Count);
    }

    [Fact]
    public void コンストラクタ_牌リストコレクションから_正しく手牌が作成される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        // Act
        var hand = new Hand([tileList1, tileList2]);

        // Assert
        Assert.Equal(2, hand.Count);
        Assert.Equal(tileList1, hand[0]);
        Assert.Equal(tileList2, hand[1]);
    }

    [Fact]
    public void CombineFuuro_副露と結合_正しく結合された牌リストリストが返される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var hand = new Hand([tileList1, tileList2]);

        var fuuroTileList1 = new TileList(sou: "789");
        var fuuroTileList2 = new TileList(honor: "ttt");
        var chi = new Chi(fuuroTileList1);
        var pon = new Pon(fuuroTileList2);
        var fuuroList = new FuuroList([chi, pon]);

        // Act
        var actual = hand.CombineFuuro(fuuroList);

        // Assert
        Assert.Equal(4, actual.Count);
        Assert.Equal(tileList1, actual[0]);
        Assert.Equal(tileList2, actual[1]);
        Assert.Equal(fuuroTileList1, actual[2]);
        Assert.Equal(fuuroTileList2, actual[3]);
    }

    [Fact]
    public void CombineFuuro_空の副露と結合_元の手牌と同じ内容の牌リストリストが返される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var hand = new Hand([tileList1, tileList2]);

        var emptyFuuroList = new FuuroList();

        // Act
        var actual = hand.CombineFuuro(emptyFuuroList);

        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal(tileList1, actual[0]);
        Assert.Equal(tileList2, actual[1]);
    }

    [Fact]
    public void HandBuilder_Create_配列からの作成_正しく手牌が作成される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");

        // Act
        var hand = Hand.HandBuilder.Create([tileList1, tileList2]);

        // Assert
        Assert.Equal(2, hand.Count);
        Assert.Equal(tileList1, hand[0]);
        Assert.Equal(tileList2, hand[1]);
    }

    [Fact]
    public void GetWinGroups_和了牌を含むグループが複数_重複なく返す()
    {
        // Arrange
        var winTile = Tile.Man1;
        var tileList1 = new TileList(man: "11"); // Man1を2枚含む
        var tileList2 = new TileList(man: "123"); // Man1を1枚含む
        var tileList3 = new TileList(pin: "456"); // Man1を含まない
        var hand = new Hand([tileList1, tileList2, tileList3]);

        // Act
        var actual = hand.GetWinGroups(winTile);

        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Contains(tileList1, actual);
        Assert.Contains(tileList2, actual);
        Assert.DoesNotContain(tileList3, actual);
    }

    [Fact]
    public void GetWinGroups_和了牌を含むグループが1つだけ_そのグループのみ返す()
    {
        // Arrange
        var winTile = Tile.Pin4;
        var tileList1 = new TileList(pin: "444"); // Pin4を含む
        var tileList2 = new TileList(man: "123"); // Pin4を含まない
        var hand = new Hand([tileList1, tileList2]);

        // Act
        var actual = hand.GetWinGroups(winTile);

        // Assert
        Assert.Single(actual);
        Assert.Equal(tileList1, actual[0]);
    }

    [Fact]
    public void GetWinGroups_和了牌を含むグループがない_空リストを返す()
    {
        // Arrange
        var winTile = Tile.Sou9;
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var hand = new Hand([tileList1, tileList2]);

        // Act
        var actual = hand.GetWinGroups(winTile);

        // Assert
        Assert.Empty(actual);
    }
}