using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;
using System.Diagnostics.CodeAnalysis;

namespace Mahjong2.Tests.Tiles;

/// <summary>
/// NumberTileクラスのテスト
/// </summary>
public class NumberTileTests
{
    /// <summary>
    /// TryGetAtDistanceメソッドが正の距離で範囲内の場合に正しく動作することを確認
    /// </summary>
    [Fact]
    public void TryGetAtDistance_範囲内_正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        // 三萬から2つ先の五萬
        Assert.True(Tile.Man3.TryGetAtDistance(2, out var nextTile));
        Assert.Equal(Tile.Man5, nextTile);

        // 五筒から4つ先の九筒
        Assert.True(Tile.Pin5.TryGetAtDistance(4, out nextTile));
        Assert.Equal(Tile.Pin9, nextTile);

        // 一索から1つ先の二索
        Assert.True(Tile.Sou1.TryGetAtDistance(1, out nextTile));
        Assert.Equal(Tile.Sou2, nextTile);

        // 五萬から-2つ先の三萬
        Assert.True(Tile.Man5.TryGetAtDistance(-2, out nextTile));
        Assert.Equal(Tile.Man3, nextTile);

        // 九筒から-4つ先の五筒
        Assert.True(Tile.Pin9.TryGetAtDistance(-4, out nextTile));
        Assert.Equal(Tile.Pin5, nextTile);

        // 三索から-2つ先の一索
        Assert.True(Tile.Sou3.TryGetAtDistance(-2, out nextTile));
        Assert.Equal(Tile.Sou1, nextTile);
    }

    /// <summary>
    /// TryGetAtDistanceメソッドが正の距離で範囲外の場合に正しく動作することを確認
    /// </summary>
    [Fact]
    public void TryGetAtDistance_範囲外_falseを返し牌はnull()
    {
        // Arrange & Act & Assert
        // 八萬から2つ先は範囲外
        Assert.False(Tile.Man8.TryGetAtDistance(2, out var nextTile));
        Assert.Null(nextTile);

        // 七筒から3つ先は範囲外
        Assert.False(Tile.Pin7.TryGetAtDistance(3, out nextTile));
        Assert.Null(nextTile);

        // 九索から1つ先は範囲外
        Assert.False(Tile.Sou9.TryGetAtDistance(1, out nextTile));
        Assert.Null(nextTile);

        // 二萬から-2つ先は範囲外
        Assert.False(Tile.Man2.TryGetAtDistance(-2, out nextTile));
        Assert.Null(nextTile);

        // 一筒から-1つ先は範囲外
        Assert.False(Tile.Pin1.TryGetAtDistance(-1, out nextTile));
        Assert.Null(nextTile);

        // 三索から-3つ先は範囲外
        Assert.False(Tile.Sou3.TryGetAtDistance(-3, out nextTile));
        Assert.Null(nextTile);
    }

    /// <summary>
    /// TryGetAtDistanceメソッドが0の距離の場合に正しく動作することを確認
    /// </summary>
    [Fact]
    public void TryGetAtDistance_距離が0_同じ牌を取得できる()
    {
        // Arrange
        var man5 = Tile.Man5;
        var pin3 = Tile.Pin3;
        var sou7 = Tile.Sou7;

        // Act & Assert
        // 距離0は同じ牌を返す
        Assert.True(man5.TryGetAtDistance(0, out var nextTile));
        Assert.Equal(man5, nextTile);

        Assert.True(pin3.TryGetAtDistance(0, out nextTile));
        Assert.Equal(pin3, nextTile);

        Assert.True(sou7.TryGetAtDistance(0, out nextTile));
        Assert.Equal(sou7, nextTile);
    }

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

    [Fact]
    public void ManTile_TryFromChar_正常な入力値で正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        for (var i = 1; i <= 9; i++)
        {
            var c = i.ToString()[0]; // 数字を文字に変換

            // 正常な入力値（1～9）で対応する萬子が取得できることを確認
            Assert.True(ManTile.TryFromChar(c, out var manTile));
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
    public void ManTile_TryFromChar_不正な入力値でfalseを返す()
    {
        // Arrange & Act & Assert
        // 数字以外の文字
        Assert.False(ManTile.TryFromChar('a', out var manTile));
        Assert.Null(manTile);
        Assert.False(ManTile.TryFromChar('あ', out manTile));
        Assert.Null(manTile);
        Assert.False(ManTile.TryFromChar('!', out manTile));
        Assert.Null(manTile);

        // 範囲外の数字
        Assert.False(ManTile.TryFromChar('0', out manTile));
        Assert.Null(manTile);
        Assert.False(ManTile.TryFromChar('/', out manTile)); // ASCII '/' は '0' の直前
        Assert.Null(manTile);
    }

    [Fact]
    public void PinTile_TryFromChar_正常な入力値で正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        for (var i = 1; i <= 9; i++)
        {
            var c = i.ToString()[0]; // 数字を文字に変換

            // 正常な入力値（1～9）で対応する筒子が取得できることを確認
            Assert.True(PinTile.TryFromChar(c, out var pinTile));
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
    public void PinTile_TryFromChar_不正な入力値でfalseを返す()
    {
        // Arrange & Act & Assert
        // 数字以外の文字
        Assert.False(PinTile.TryFromChar('a', out var pinTile));
        Assert.Null(pinTile);
        Assert.False(PinTile.TryFromChar('あ', out pinTile));
        Assert.Null(pinTile);
        Assert.False(PinTile.TryFromChar('#', out pinTile));
        Assert.Null(pinTile);

        // 範囲外の数字
        Assert.False(PinTile.TryFromChar('0', out pinTile));
        Assert.Null(pinTile);
        Assert.False(PinTile.TryFromChar(':', out pinTile)); // ASCII ':' は '9' の直後
        Assert.Null(pinTile);
    }

    [Fact]
    public void SouTile_TryFromChar_正常な入力値で正しい牌を取得できる()
    {
        // Arrange & Act & Assert
        for (var i = 1; i <= 9; i++)
        {
            var c = i.ToString()[0]; // 数字を文字に変換

            // 正常な入力値（1～9）で対応する索子が取得できることを確認
            Assert.True(SouTile.TryFromChar(c, out var souTile));
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
    public void SouTile_TryFromChar_不正な入力値でfalseを返す()
    {
        // Arrange & Act & Assert
        // 数字以外の文字
        Assert.False(SouTile.TryFromChar('x', out var souTile));
        Assert.Null(souTile);
        Assert.False(SouTile.TryFromChar('漢', out souTile));
        Assert.Null(souTile);
        Assert.False(SouTile.TryFromChar('%', out souTile));
        Assert.Null(souTile);

        // 範囲外の数字
        Assert.False(SouTile.TryFromChar('0', out souTile));
        Assert.Null(souTile);
        Assert.False(SouTile.TryFromChar('A', out souTile)); // ASCII 'A' は数字の範囲外
        Assert.Null(souTile);
    }

    [Fact]
    public void CompareTo_不明な数牌_ArgumentExceptionをスロー()
    {
        // Arrange
        var man1 = Tile.Man1;
        var mockNumberTile = new MockNumberTile();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => man1.CompareTo(mockNumberTile));
        Assert.Equal("不明な数牌です (Parameter 'numberTile')", exception.Message);
    }
}

/// <summary>
/// テスト用の未知の数牌クラス
/// </summary>
internal record MockNumberTile : NumberTile
{
    public override int Number => 1;

    public override bool TryGetAtDistance(int distance, [NotNullWhen(true)] out NumberTile? tile)
    {
        tile = null;
        return false;
    }
}
