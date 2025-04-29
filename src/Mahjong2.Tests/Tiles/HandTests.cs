using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Tests.Tiles;

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
    public void ConcatFuuro_副露と結合_正しく結合された牌リストリストが返される()
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
        var result = hand.ConcatFuuro(fuuroList);

        // Assert
        Assert.Equal(4, result.Count);
        Assert.Equal(tileList1, result[0]);
        Assert.Equal(tileList2, result[1]);
        Assert.Equal(fuuroTileList1, result[2]);
        Assert.Equal(fuuroTileList2, result[3]);
    }

    [Fact]
    public void ConcatFuuro_空の副露と結合_元の手牌と同じ内容の牌リストリストが返される()
    {
        // Arrange
        var tileList1 = new TileList(man: "123");
        var tileList2 = new TileList(pin: "456");
        var hand = new Hand([tileList1, tileList2]);

        var emptyFuuroList = new FuuroList();

        // Act
        var result = hand.ConcatFuuro(emptyFuuroList);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(tileList1, result[0]);
        Assert.Equal(tileList2, result[1]);
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
}