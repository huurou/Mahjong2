using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.HonotTiles;

namespace Mahjong2.Tests.Tiles;

/// <summary>
/// HonorTileクラスのテスト
/// </summary>
public class HonorTileTests
{
    [Fact]
    public void WindTile_TryFromChar_風牌の文字からの変換_変換に成功する()
    {
        // Arrange & Act & Assert
        // 風牌の文字からの変換テスト（小文字アルファベット）
        Assert.True(HonorTile.TryFromChar('t', out var honorTile));
        Assert.Equal(Tile.Ton, honorTile);

        Assert.True(HonorTile.TryFromChar('n', out honorTile));
        Assert.Equal(Tile.Nan, honorTile);

        Assert.True(HonorTile.TryFromChar('s', out honorTile));
        Assert.Equal(Tile.Sha, honorTile);

        Assert.True(HonorTile.TryFromChar('p', out honorTile));
        Assert.Equal(Tile.Pei, honorTile);

        // 風牌の文字からの変換テスト（日本語文字）
        Assert.True(HonorTile.TryFromChar('東', out honorTile));
        Assert.Equal(Tile.Ton, honorTile);

        Assert.True(HonorTile.TryFromChar('南', out honorTile));
        Assert.Equal(Tile.Nan, honorTile);

        Assert.True(HonorTile.TryFromChar('西', out honorTile));
        Assert.Equal(Tile.Sha, honorTile);

        Assert.True(HonorTile.TryFromChar('北', out honorTile));
        Assert.Equal(Tile.Pei, honorTile);
    }

    [Fact]
    public void DragonTile_TryFromChar_三元牌の文字からの変換_変換に成功する()
    {
        // Arrange & Act & Assert
        // 三元牌の文字からの変換テスト（小文字アルファベット）
        Assert.True(HonorTile.TryFromChar('h', out var honorTile));
        Assert.Equal(Tile.Haku, honorTile);

        Assert.True(HonorTile.TryFromChar('r', out honorTile));
        Assert.Equal(Tile.Hatsu, honorTile);

        Assert.True(HonorTile.TryFromChar('c', out honorTile));
        Assert.Equal(Tile.Chun, honorTile);

        // 三元牌の文字からの変換テスト（日本語文字）
        Assert.True(HonorTile.TryFromChar('白', out honorTile));
        Assert.Equal(Tile.Haku, honorTile);

        Assert.True(HonorTile.TryFromChar('發', out honorTile));
        Assert.Equal(Tile.Hatsu, honorTile);

        Assert.True(HonorTile.TryFromChar('中', out honorTile));
        Assert.Equal(Tile.Chun, honorTile);
    }

    [Fact]
    public void TryFromChar_無効な文字の場合_変換に失敗する()
    {
        // Arrange & Act & Assert
        Assert.False(HonorTile.TryFromChar('a', out var honorTile));
        Assert.Null(honorTile);

        Assert.False(HonorTile.TryFromChar('z', out honorTile));
        Assert.Null(honorTile);

        Assert.False(HonorTile.TryFromChar('1', out honorTile));
        Assert.Null(honorTile);

        Assert.False(HonorTile.TryFromChar('9', out honorTile));
        Assert.Null(honorTile);

        Assert.False(HonorTile.TryFromChar('?', out honorTile));
        Assert.Null(honorTile);

        Assert.False(HonorTile.TryFromChar('あ', out honorTile));
        Assert.Null(honorTile);
    }

    [Fact]
    public void CompareTo_不明な字牌タイプが渡された場合_例外が発生する()
    {
        // Arrange
        var mockHonorTile = new MockHonorTile();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => mockHonorTile.CompareTo(mockHonorTile));
        Assert.Contains("不明な字牌です", exception.Message);
    }

    [Fact]
    public void WindTile_CompareTo_不明な風牌が指定された場合_例外が発生する()
    {
        // Arrange
        var validTile = Tile.Ton;
        var mockWindTile = new MockWindTile();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => validTile.CompareTo(mockWindTile));
        Assert.Contains("不明な風牌です", exception.Message);
    }

    [Fact]
    public void DragonTile_CompareTo_不明な三元牌が指定された場合_例外が発生する()
    {
        // Arrange
        var validTile = Tile.Haku;
        var mockDragonTile = new MockDragonTile();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => validTile.CompareTo(mockDragonTile));
        Assert.Contains("不明な三元牌です", exception.Message);
    }

    [Fact]
    public void WindTile_ToString_不明な風牌の場合_例外が発生する()
    {
        // Arrange
        var mockWindTile = new MockWindTile();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(mockWindTile.ToString);
        Assert.Contains("不明な風牌です", exception.Message);
    }

    [Fact]
    public void DragonTile_ToString_不明な三元牌の場合_例外が発生する()
    {
        // Arrange
        var mockDragonTile = new MockDragonTile();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(mockDragonTile.ToString);
        Assert.Contains("不明な字牌です", exception.Message);
    }

    /// <summary>
    /// テスト用の字牌モッククラス
    /// </summary>
    private record MockHonorTile : HonorTile;

    /// <summary>
    /// テスト用の風牌モッククラス
    /// </summary>
    private record MockWindTile : WindTile;

    /// <summary>
    /// テスト用の三元牌モッククラス
    /// </summary>
    private record MockDragonTile : DragonTile;
}
