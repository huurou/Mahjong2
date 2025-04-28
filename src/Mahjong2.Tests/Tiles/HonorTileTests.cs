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
    public void HonorTile_TryFromChar_無効な文字の場合_変換に失敗する()
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
}
