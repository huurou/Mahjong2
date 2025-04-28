using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;

namespace Mahjong2.Tests.Tiles;

/// <summary>
/// NumberTileクラスのテスト
/// </summary>
public class NumberTileTests
{
    [Fact]
    public void ManTile_TryFromNumber_正常な入力値で正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        for (var i = 1; i <= 9; i++)
        {
            // 正常な入力値（1～9）で対応する萬子が取得できることを確認
            Assert.True(ManTile.TryFromNumber(i, out var manTile));
            Assert.NotNull(manTile);
            Assert.Equal(i, manTile.Number);

            // 本当に対応する牌かどうかチェック
            ManTile? expectedMan = i switch
            {
                1 => Tile.Man1,
                2 => Tile.Man2,
                3 => Tile.Man3,
                4 => Tile.Man4,
                5 => Tile.Man5,
                6 => Tile.Man6,
                7 => Tile.Man7,
                8 => Tile.Man8,
                9 => Tile.Man9,
                _ => null
            };
            Assert.Equal(expectedMan, manTile);
        }
    }

    [Fact]
    public void ManTile_TryFromNumber_範囲外の入力値でfalseを返す()
    {
        // Arrange & Act & Assert
        // 範囲外の小さい値
        Assert.False(ManTile.TryFromNumber(0, out var manTile));
        Assert.Null(manTile);
        Assert.False(ManTile.TryFromNumber(-1, out manTile));
        Assert.Null(manTile);

        // 範囲外の大きい値
        Assert.False(ManTile.TryFromNumber(10, out manTile));
        Assert.Null(manTile);
        Assert.False(ManTile.TryFromNumber(100, out manTile));
        Assert.Null(manTile);
    }

    [Fact]
    public void PinTile_TryFromNumber_正常な入力値で正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        for (var i = 1; i <= 9; i++)
        {
            // 正常な入力値（1～9）で対応する筒子が取得できることを確認
            Assert.True(PinTile.TryFromNumber(i, out var pinTile));
            Assert.NotNull(pinTile);
            Assert.Equal(i, pinTile.Number);

            // 本当に対応する牌かどうかチェック
            PinTile? expectedPin = i switch
            {
                1 => Tile.Pin1,
                2 => Tile.Pin2,
                3 => Tile.Pin3,
                4 => Tile.Pin4,
                5 => Tile.Pin5,
                6 => Tile.Pin6,
                7 => Tile.Pin7,
                8 => Tile.Pin8,
                9 => Tile.Pin9,
                _ => null
            };
            Assert.Equal(expectedPin, pinTile);
        }
    }

    [Fact]
    public void PinTile_TryFromNumber_範囲外の入力値でfalseを返す()
    {
        // Arrange & Act & Assert
        // 範囲外の小さい値
        Assert.False(PinTile.TryFromNumber(0, out var pinTile));
        Assert.Null(pinTile);
        Assert.False(PinTile.TryFromNumber(-5, out pinTile));
        Assert.Null(pinTile);

        // 範囲外の大きい値
        Assert.False(PinTile.TryFromNumber(10, out pinTile));
        Assert.Null(pinTile);
        Assert.False(PinTile.TryFromNumber(50, out pinTile));
        Assert.Null(pinTile);
    }

    [Fact]
    public void SouTile_TryFromNumber_正常な入力値で正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        for (var i = 1; i <= 9; i++)
        {
            // 正常な入力値（1～9）で対応する索子が取得できることを確認
            Assert.True(SouTile.TryFromNumber(i, out var souTile));
            Assert.NotNull(souTile);
            Assert.Equal(i, souTile.Number);

            // 本当に対応する牌かどうかチェック
            SouTile? expectedSou = i switch
            {
                1 => Tile.Sou1,
                2 => Tile.Sou2,
                3 => Tile.Sou3,
                4 => Tile.Sou4,
                5 => Tile.Sou5,
                6 => Tile.Sou6,
                7 => Tile.Sou7,
                8 => Tile.Sou8,
                9 => Tile.Sou9,
                _ => null
            };
            Assert.Equal(expectedSou, souTile);
        }
    }

    [Fact]
    public void SouTile_TryFromNumber_範囲外の入力値でfalseを返す()
    {
        // Arrange & Act & Assert
        // 範囲外の小さい値
        Assert.False(SouTile.TryFromNumber(0, out var souTile));
        Assert.Null(souTile);
        Assert.False(SouTile.TryFromNumber(-10, out souTile));
        Assert.Null(souTile);

        // 範囲外の大きい値
        Assert.False(SouTile.TryFromNumber(10, out souTile));
        Assert.Null(souTile);
        Assert.False(SouTile.TryFromNumber(20, out souTile));
        Assert.Null(souTile);
    }
}
