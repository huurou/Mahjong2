using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Tiles;

/// <summary>
/// Tileクラスのプロパティに関するテスト
/// </summary>
public class TilePropertyTests
{
    [Fact]
    public void ManTiles_数値の確認_正しい値が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal(1, Tile.Man1.Number);
        Assert.Equal(2, Tile.Man2.Number);
        Assert.Equal(3, Tile.Man3.Number);
        Assert.Equal(4, Tile.Man4.Number);
        Assert.Equal(5, Tile.Man5.Number);
        Assert.Equal(6, Tile.Man6.Number);
        Assert.Equal(7, Tile.Man7.Number);
        Assert.Equal(8, Tile.Man8.Number);
        Assert.Equal(9, Tile.Man9.Number);
    }

    [Fact]
    public void PinTiles_数値の確認_正しい値が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal(1, Tile.Pin1.Number);
        Assert.Equal(2, Tile.Pin2.Number);
        Assert.Equal(3, Tile.Pin3.Number);
        Assert.Equal(4, Tile.Pin4.Number);
        Assert.Equal(5, Tile.Pin5.Number);
        Assert.Equal(6, Tile.Pin6.Number);
        Assert.Equal(7, Tile.Pin7.Number);
        Assert.Equal(8, Tile.Pin8.Number);
        Assert.Equal(9, Tile.Pin9.Number);
    }

    [Fact]
    public void SouTiles_数値の確認_正しい値が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal(1, Tile.Sou1.Number);
        Assert.Equal(2, Tile.Sou2.Number);
        Assert.Equal(3, Tile.Sou3.Number);
        Assert.Equal(4, Tile.Sou4.Number);
        Assert.Equal(5, Tile.Sou5.Number);
        Assert.Equal(6, Tile.Sou6.Number);
        Assert.Equal(7, Tile.Sou7.Number);
        Assert.Equal(8, Tile.Sou8.Number);
        Assert.Equal(9, Tile.Sou9.Number);
    }

    [Fact]
    public void IsChuchan_中張牌の判定_正しい判定ができる()
    {
        // Arrange & Act & Assert
        // 中張牌である牌のチェック (2-8)
        // 萬子
        Assert.True(Tile.Man2.IsChuchan);
        Assert.True(Tile.Man3.IsChuchan);
        Assert.True(Tile.Man4.IsChuchan);
        Assert.True(Tile.Man5.IsChuchan);
        Assert.True(Tile.Man6.IsChuchan);
        Assert.True(Tile.Man7.IsChuchan);
        Assert.True(Tile.Man8.IsChuchan);

        // 筒子
        Assert.True(Tile.Pin2.IsChuchan);
        Assert.True(Tile.Pin3.IsChuchan);
        Assert.True(Tile.Pin4.IsChuchan);
        Assert.True(Tile.Pin5.IsChuchan);
        Assert.True(Tile.Pin6.IsChuchan);
        Assert.True(Tile.Pin7.IsChuchan);
        Assert.True(Tile.Pin8.IsChuchan);

        // 索子
        Assert.True(Tile.Sou2.IsChuchan);
        Assert.True(Tile.Sou3.IsChuchan);
        Assert.True(Tile.Sou4.IsChuchan);
        Assert.True(Tile.Sou5.IsChuchan);
        Assert.True(Tile.Sou6.IsChuchan);
        Assert.True(Tile.Sou7.IsChuchan);
        Assert.True(Tile.Sou8.IsChuchan);

        // 中張牌でない牌のチェック
        // 数牌の1と9
        Assert.False(Tile.Man1.IsChuchan);
        Assert.False(Tile.Man9.IsChuchan);
        Assert.False(Tile.Pin1.IsChuchan);
        Assert.False(Tile.Pin9.IsChuchan);
        Assert.False(Tile.Sou1.IsChuchan);
        Assert.False(Tile.Sou9.IsChuchan);

        // 字牌
        Assert.False(Tile.Ton.IsChuchan);
        Assert.False(Tile.Nan.IsChuchan);
        Assert.False(Tile.Sha.IsChuchan);
        Assert.False(Tile.Pei.IsChuchan);
        Assert.False(Tile.Haku.IsChuchan);
        Assert.False(Tile.Hatsu.IsChuchan);
        Assert.False(Tile.Chun.IsChuchan);
    }

    [Fact]
    public void IsYaochu_么九牌の判定_正しい判定ができる()
    {
        // Arrange & Act & Assert
        // 么九牌である牌のチェック (1, 9と字牌)
        // 数牌の1と9
        Assert.True(Tile.Man1.IsYaochu);
        Assert.True(Tile.Man9.IsYaochu);
        Assert.True(Tile.Pin1.IsYaochu);
        Assert.True(Tile.Pin9.IsYaochu);
        Assert.True(Tile.Sou1.IsYaochu);
        Assert.True(Tile.Sou9.IsYaochu);

        // 字牌
        Assert.True(Tile.Ton.IsYaochu);
        Assert.True(Tile.Nan.IsYaochu);
        Assert.True(Tile.Sha.IsYaochu);
        Assert.True(Tile.Pei.IsYaochu);
        Assert.True(Tile.Haku.IsYaochu);
        Assert.True(Tile.Hatsu.IsYaochu);
        Assert.True(Tile.Chun.IsYaochu);

        // 么九牌でない牌のチェック (2-8)
        // 萬子
        Assert.False(Tile.Man2.IsYaochu);
        Assert.False(Tile.Man3.IsYaochu);
        Assert.False(Tile.Man4.IsYaochu);
        Assert.False(Tile.Man5.IsYaochu);
        Assert.False(Tile.Man6.IsYaochu);
        Assert.False(Tile.Man7.IsYaochu);
        Assert.False(Tile.Man8.IsYaochu);

        // 筒子
        Assert.False(Tile.Pin2.IsYaochu);
        Assert.False(Tile.Pin3.IsYaochu);
        Assert.False(Tile.Pin4.IsYaochu);
        Assert.False(Tile.Pin5.IsYaochu);
        Assert.False(Tile.Pin6.IsYaochu);
        Assert.False(Tile.Pin7.IsYaochu);
        Assert.False(Tile.Pin8.IsYaochu);

        // 索子
        Assert.False(Tile.Sou2.IsYaochu);
        Assert.False(Tile.Sou3.IsYaochu);
        Assert.False(Tile.Sou4.IsYaochu);
        Assert.False(Tile.Sou5.IsYaochu);
        Assert.False(Tile.Sou6.IsYaochu);
        Assert.False(Tile.Sou7.IsYaochu);
        Assert.False(Tile.Sou8.IsYaochu);
    }

    [Fact]
    public void IsRoutou_老頭牌の判定_正しい判定ができる()
    {
        // Arrange & Act & Assert
        // 老頭牌である牌のチェック (1, 9)
        Assert.True(Tile.Man1.IsRoutou);
        Assert.True(Tile.Man9.IsRoutou);
        Assert.True(Tile.Pin1.IsRoutou);
        Assert.True(Tile.Pin9.IsRoutou);
        Assert.True(Tile.Sou1.IsRoutou);
        Assert.True(Tile.Sou9.IsRoutou);

        // 老頭牌でない牌のチェック (2-8)
        // 萬子
        Assert.False(Tile.Man2.IsRoutou);
        Assert.False(Tile.Man3.IsRoutou);
        Assert.False(Tile.Man4.IsRoutou);
        Assert.False(Tile.Man5.IsRoutou);
        Assert.False(Tile.Man6.IsRoutou);
        Assert.False(Tile.Man7.IsRoutou);
        Assert.False(Tile.Man8.IsRoutou);

        // 筒子
        Assert.False(Tile.Pin2.IsRoutou);
        Assert.False(Tile.Pin3.IsRoutou);
        Assert.False(Tile.Pin4.IsRoutou);
        Assert.False(Tile.Pin5.IsRoutou);
        Assert.False(Tile.Pin6.IsRoutou);
        Assert.False(Tile.Pin7.IsRoutou);
        Assert.False(Tile.Pin8.IsRoutou);

        // 索子
        Assert.False(Tile.Sou2.IsRoutou);
        Assert.False(Tile.Sou3.IsRoutou);
        Assert.False(Tile.Sou4.IsRoutou);
        Assert.False(Tile.Sou5.IsRoutou);
        Assert.False(Tile.Sou6.IsRoutou);
        Assert.False(Tile.Sou7.IsRoutou);
        Assert.False(Tile.Sou8.IsRoutou);

        // 字牌
        Assert.False(Tile.Ton.IsRoutou);
        Assert.False(Tile.Nan.IsRoutou);
        Assert.False(Tile.Sha.IsRoutou);
        Assert.False(Tile.Pei.IsRoutou);
        Assert.False(Tile.Haku.IsRoutou);
        Assert.False(Tile.Hatsu.IsRoutou);
        Assert.False(Tile.Chun.IsRoutou);
    }

    [Fact]
    public void TypeChecks_タイプ判定_正しく判定できる()
    {
        // Arrange & Act & Assert
        // 萬子の確認
        foreach (var tile in Tile.Mans)
        {
            Assert.True(tile.IsMan);
            Assert.False(tile.IsPin);
            Assert.False(tile.IsSou);
            Assert.True(tile.IsNumber);
            Assert.False(tile.IsHonor);
            Assert.False(tile.IsWind);
            Assert.False(tile.IsDragon);
        }

        // 筒子の確認
        foreach (var tile in Tile.Pins)
        {
            Assert.False(tile.IsMan);
            Assert.True(tile.IsPin);
            Assert.False(tile.IsSou);
            Assert.True(tile.IsNumber);
            Assert.False(tile.IsHonor);
            Assert.False(tile.IsWind);
            Assert.False(tile.IsDragon);
        }

        // 索子の確認
        foreach (var tile in Tile.Sous)
        {
            Assert.False(tile.IsMan);
            Assert.False(tile.IsPin);
            Assert.True(tile.IsSou);
            Assert.True(tile.IsNumber);
            Assert.False(tile.IsHonor);
            Assert.False(tile.IsWind);
            Assert.False(tile.IsDragon);
        }

        // 風牌の確認
        foreach (var tile in Tile.Winds)
        {
            Assert.False(tile.IsMan);
            Assert.False(tile.IsPin);
            Assert.False(tile.IsSou);
            Assert.False(tile.IsNumber);
            Assert.True(tile.IsHonor);
            Assert.True(tile.IsWind);
            Assert.False(tile.IsDragon);
        }

        // 三元牌の確認
        foreach (var tile in Tile.Dragons)
        {
            Assert.False(tile.IsMan);
            Assert.False(tile.IsPin);
            Assert.False(tile.IsSou);
            Assert.False(tile.IsNumber);
            Assert.True(tile.IsHonor);
            Assert.False(tile.IsWind);
            Assert.True(tile.IsDragon);
        }
    }
}
