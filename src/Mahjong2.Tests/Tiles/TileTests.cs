using Mahjong2.Lib.Tiles;

namespace Mahjong2.Tests.Tiles;

/// <summary>
/// Tileクラスのテスト
/// </summary>
public class TileTests
{
    /// <summary>
    /// 萬子の数値が正しく設定されているかテスト
    /// </summary>
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

    /// <summary>
    /// 筒子の数値が正しく設定されているかテスト
    /// </summary>
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

    /// <summary>
    /// 索子の数値が正しく設定されているかテスト
    /// </summary>
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

    /// <summary>
    /// 字牌の数値がすべて0であることを確認
    /// </summary>
    [Fact]
    public void HonorTiles_数値の確認_すべて0が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal(0, Tile.Ton.Number);
        Assert.Equal(0, Tile.Nan.Number);
        Assert.Equal(0, Tile.Sha.Number);
        Assert.Equal(0, Tile.Pei.Number);
        Assert.Equal(0, Tile.Haku.Number);
        Assert.Equal(0, Tile.Hatsu.Number);
        Assert.Equal(0, Tile.Chun.Number);
    }

    /// <summary>
    /// 全ての牌リストの要素数が34であることを確認
    /// </summary>
    [Fact]
    public void All_要素数の確認_34種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(34, Tile.All.Count);
    }

    /// <summary>
    /// 数牌リストの要素数が27であることを確認
    /// </summary>
    [Fact]
    public void Numbers_要素数の確認_27種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(27, Tile.Numbers.Count);
    }

    /// <summary>
    /// 萬子リストの要素数が9であることを確認
    /// </summary>
    [Fact]
    public void Mans_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Mans.Count);
    }

    /// <summary>
    /// 筒子リストの要素数が9であることを確認
    /// </summary>
    [Fact]
    public void Pins_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Pins.Count);
    }

    /// <summary>
    /// 索子リストの要素数が9であることを確認
    /// </summary>
    [Fact]
    public void Sous_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Sous.Count);
    }

    /// <summary>
    /// 字牌リストの要素数が7であることを確認
    /// </summary>
    [Fact]
    public void Honors_要素数の確認_7種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(7, Tile.Honors.Count);
    }

    /// <summary>
    /// 風牌リストの要素数が4であることを確認
    /// </summary>
    [Fact]
    public void Winds_要素数の確認_4種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(4, Tile.Winds.Count);
    }

    /// <summary>
    /// 三元牌リストの要素数が3であることを確認
    /// </summary>
    [Fact]
    public void Dragons_要素数の確認_3種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(3, Tile.Dragons.Count);
    }

    /// <summary>
    /// 中張牌の判定が正しいことの確認
    /// </summary>
    [Fact]
    public void IsChucahn_中張牌の判定_正しい判定ができる()
    {
        // Arrange & Act & Assert
        // 中張牌である牌のチェック (2-8)
        // 萬子
        Assert.True(Tile.Man2.IsChucahn);
        Assert.True(Tile.Man3.IsChucahn);
        Assert.True(Tile.Man4.IsChucahn);
        Assert.True(Tile.Man5.IsChucahn);
        Assert.True(Tile.Man6.IsChucahn);
        Assert.True(Tile.Man7.IsChucahn);
        Assert.True(Tile.Man8.IsChucahn);

        // 筒子
        Assert.True(Tile.Pin2.IsChucahn);
        Assert.True(Tile.Pin3.IsChucahn);
        Assert.True(Tile.Pin4.IsChucahn);
        Assert.True(Tile.Pin5.IsChucahn);
        Assert.True(Tile.Pin6.IsChucahn);
        Assert.True(Tile.Pin7.IsChucahn);
        Assert.True(Tile.Pin8.IsChucahn);

        // 索子
        Assert.True(Tile.Sou2.IsChucahn);
        Assert.True(Tile.Sou3.IsChucahn);
        Assert.True(Tile.Sou4.IsChucahn);
        Assert.True(Tile.Sou5.IsChucahn);
        Assert.True(Tile.Sou6.IsChucahn);
        Assert.True(Tile.Sou7.IsChucahn);
        Assert.True(Tile.Sou8.IsChucahn);

        // 中張牌でない牌のチェック
        // 数牌の1と9
        Assert.False(Tile.Man1.IsChucahn);
        Assert.False(Tile.Man9.IsChucahn);
        Assert.False(Tile.Pin1.IsChucahn);
        Assert.False(Tile.Pin9.IsChucahn);
        Assert.False(Tile.Sou1.IsChucahn);
        Assert.False(Tile.Sou9.IsChucahn);

        // 字牌
        Assert.False(Tile.Ton.IsChucahn);
        Assert.False(Tile.Nan.IsChucahn);
        Assert.False(Tile.Sha.IsChucahn);
        Assert.False(Tile.Pei.IsChucahn);
        Assert.False(Tile.Haku.IsChucahn);
        Assert.False(Tile.Hatsu.IsChucahn);
        Assert.False(Tile.Chun.IsChucahn);
    }

    /// <summary>
    /// 中張牌リストが正しいか確認
    /// </summary>
    [Fact]
    public void Chuchans_リストの確認_中張牌のみを含む()
    {
        // Arrange & Act
        var expected = 21; // 3色 × (2から8の7種)

        // Assert
        Assert.Equal(expected, Tile.Chuchans.Count);
        Assert.All(Tile.Chuchans, tile => Assert.True(tile.IsChucahn));
    }

    /// <summary>
    /// 么九牌の判定が正しいことの確認
    /// </summary>
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

    /// <summary>
    /// 么九牌リストが正しいか確認
    /// </summary>
    [Fact]
    public void Yaochus_リストの確認_么九牌のみを含む()
    {
        // Arrange & Act
        var expected = 13; // 数牌の1,9 (3色×2種=6種) + 字牌(7種)

        // Assert
        Assert.Equal(expected, Tile.Yaochus.Count);
        Assert.All(Tile.Yaochus, tile => Assert.True(tile.IsYaochu));
    }

    /// <summary>
    /// 老頭牌の判定が正しいことの確認
    /// </summary>
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

    /// <summary>
    /// 各タイプ判定が正しく機能するか確認
    /// </summary>
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

    /// <summary>
    /// 各グループの牌リストが正しく、漏れなく設定されているか確認
    /// </summary>
    [Fact]
    public void TileLists_リスト内容の確認_重複がなく漏れもない()
    {
        // Arrange & Act & Assert
        // 数牌の確認
        Assert.Equal(Tile.Mans.Count + Tile.Pins.Count + Tile.Sous.Count, Tile.Numbers.Count);
        Assert.All(Tile.Mans, tile => Assert.Contains(tile, Tile.Numbers));
        Assert.All(Tile.Pins, tile => Assert.Contains(tile, Tile.Numbers));
        Assert.All(Tile.Sous, tile => Assert.Contains(tile, Tile.Numbers));

        // 字牌の確認
        Assert.Equal(Tile.Winds.Count + Tile.Dragons.Count, Tile.Honors.Count);
        Assert.All(Tile.Winds, tile => Assert.Contains(tile, Tile.Honors));
        Assert.All(Tile.Dragons, tile => Assert.Contains(tile, Tile.Honors));

        // 全ての牌の確認
        Assert.Equal(Tile.Numbers.Count + Tile.Honors.Count, Tile.All.Count);
        Assert.All(Tile.Numbers, tile => Assert.Contains(tile, Tile.All));
        Assert.All(Tile.Honors, tile => Assert.Contains(tile, Tile.All));

        // 中張牌の確認
        Assert.All(Tile.Chuchans, tile =>
        {
            Assert.True(tile.IsNumber);
            Assert.True(tile.Number >= 2 && tile.Number <= 8);
        });

        // 么九牌の確認
        Assert.All(Tile.Yaochus, tile => Assert.True(tile.IsHonor || tile.Number == 1 || tile.Number == 9));

        // 老頭牌の確認
        Assert.All(Tile.Routous, tile =>
        {
            Assert.True(tile.IsNumber);
            Assert.True(tile.Number == 1 || tile.Number == 9);
        });
    }

    /// <summary>
    /// 萬子リストにすべての萬子が漏れなく重複なく含まれているか確認
    /// </summary>
    [Fact]
    public void Mans_リスト内容の確認_すべての萬子が重複なく含まれている()
    {
        // Arrange
        Tile[] allMans = [Tile.Man1, Tile.Man2, Tile.Man3, Tile.Man4, Tile.Man5, Tile.Man6, Tile.Man7, Tile.Man8, Tile.Man9];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allMans.Length, Tile.Mans.Count);

        // すべての萬子が含まれているか
        foreach (var man in allMans)
        {
            Assert.Contains(man, Tile.Mans);
        }

        // 萬子以外の牌が含まれていないか
        Assert.All(Tile.Mans, tile => Assert.True(tile.IsMan));

        // 重複がないか
        Assert.Equal(Tile.Mans.Count, Tile.Mans.Distinct().Count());
    }

    /// <summary>
    /// 筒子リストにすべての筒子が漏れなく重複なく含まれているか確認
    /// </summary>
    [Fact]
    public void Pins_リスト内容の確認_すべての筒子が重複なく含まれている()
    {
        // Arrange
        Tile[] allPins = [Tile.Pin1, Tile.Pin2, Tile.Pin3, Tile.Pin4, Tile.Pin5, Tile.Pin6, Tile.Pin7, Tile.Pin8, Tile.Pin9];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allPins.Length, Tile.Pins.Count);

        // すべての筒子が含まれているか
        foreach (var pin in allPins)
        {
            Assert.Contains(pin, Tile.Pins);
        }

        // 筒子以外の牌が含まれていないか
        Assert.All(Tile.Pins, tile => Assert.True(tile.IsPin));

        // 重複がないか
        Assert.Equal(Tile.Pins.Count, Tile.Pins.Distinct().Count());
    }

    /// <summary>
    /// 索子リストにすべての索子が漏れなく重複なく含まれているか確認
    /// </summary>
    [Fact]
    public void Sous_リスト内容の確認_すべての索子が重複なく含まれている()
    {
        // Arrange
        Tile[] allSous = [Tile.Sou1, Tile.Sou2, Tile.Sou3, Tile.Sou4, Tile.Sou5, Tile.Sou6, Tile.Sou7, Tile.Sou8, Tile.Sou9];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allSous.Length, Tile.Sous.Count);

        // すべての索子が含まれているか
        foreach (var sou in allSous)
        {
            Assert.Contains(sou, Tile.Sous);
        }

        // 索子以外の牌が含まれていないか
        Assert.All(Tile.Sous, tile => Assert.True(tile.IsSou));

        // 重複がないか
        Assert.Equal(Tile.Sous.Count, Tile.Sous.Distinct().Count());
    }

    /// <summary>
    /// 風牌リストにすべての風牌が漏れなく重複なく含まれているか確認
    /// </summary>
    [Fact]
    public void Winds_リスト内容の確認_すべての風牌が重複なく含まれている()
    {
        // Arrange
        Tile[] allWinds = [Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allWinds.Length, Tile.Winds.Count);

        // すべての風牌が含まれているか
        foreach (var wind in allWinds)
        {
            Assert.Contains(wind, Tile.Winds);
        }

        // 風牌以外の牌が含まれていないか
        Assert.All(Tile.Winds, tile => Assert.True(tile.IsWind));

        // 重複がないか
        Assert.Equal(Tile.Winds.Count, Tile.Winds.Distinct().Count());
    }

    /// <summary>
    /// 三元牌リストにすべての三元牌が漏れなく重複なく含まれているか確認
    /// </summary>
    [Fact]
    public void Dragons_リスト内容の確認_すべての三元牌が重複なく含まれている()
    {
        // Arrange
        Tile[] allDragons = [Tile.Haku, Tile.Hatsu, Tile.Chun];

        // Act & Assert
        // 要素数が正しいか
        Assert.Equal(allDragons.Length, Tile.Dragons.Count);

        // すべての三元牌が含まれているか
        foreach (var dragon in allDragons)
        {
            Assert.Contains(dragon, Tile.Dragons);
        }

        // 三元牌以外の牌が含まれていないか
        Assert.All(Tile.Dragons, tile => Assert.True(tile.IsDragon));

        // 重複がないか
        Assert.Equal(Tile.Dragons.Count, Tile.Dragons.Distinct().Count());
    }

    /// <summary>
    /// 萬子のToString()メソッドの結果を確認
    /// </summary>
    [Fact]
    public void ManTiles_文字列表現の確認_正しい文字列が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal("一", Tile.Man1.ToString());
        Assert.Equal("二", Tile.Man2.ToString());
        Assert.Equal("三", Tile.Man3.ToString());
        Assert.Equal("四", Tile.Man4.ToString());
        Assert.Equal("五", Tile.Man5.ToString());
        Assert.Equal("六", Tile.Man6.ToString());
        Assert.Equal("七", Tile.Man7.ToString());
        Assert.Equal("八", Tile.Man8.ToString());
        Assert.Equal("九", Tile.Man9.ToString());
    }

    /// <summary>
    /// 筒子のToString()メソッドの結果を確認
    /// </summary>
    [Fact]
    public void PinTiles_文字列表現の確認_正しい文字列が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal("(1)", Tile.Pin1.ToString());
        Assert.Equal("(2)", Tile.Pin2.ToString());
        Assert.Equal("(3)", Tile.Pin3.ToString());
        Assert.Equal("(4)", Tile.Pin4.ToString());
        Assert.Equal("(5)", Tile.Pin5.ToString());
        Assert.Equal("(6)", Tile.Pin6.ToString());
        Assert.Equal("(7)", Tile.Pin7.ToString());
        Assert.Equal("(8)", Tile.Pin8.ToString());
        Assert.Equal("(9)", Tile.Pin9.ToString());
    }

    /// <summary>
    /// 索子のToString()メソッドの結果を確認
    /// </summary>
    [Fact]
    public void SouTiles_文字列表現の確認_正しい文字列が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal("1", Tile.Sou1.ToString());
        Assert.Equal("2", Tile.Sou2.ToString());
        Assert.Equal("3", Tile.Sou3.ToString());
        Assert.Equal("4", Tile.Sou4.ToString());
        Assert.Equal("5", Tile.Sou5.ToString());
        Assert.Equal("6", Tile.Sou6.ToString());
        Assert.Equal("7", Tile.Sou7.ToString());
        Assert.Equal("8", Tile.Sou8.ToString());
        Assert.Equal("9", Tile.Sou9.ToString());
    }

    /// <summary>
    /// 風牌のToString()メソッドの結果を確認
    /// </summary>
    [Fact]
    public void WindTiles_文字列表現の確認_正しい文字列が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal("東", Tile.Ton.ToString());
        Assert.Equal("南", Tile.Nan.ToString());
        Assert.Equal("西", Tile.Sha.ToString());
        Assert.Equal("北", Tile.Pei.ToString());
    }

    /// <summary>
    /// 三元牌のToString()メソッドの結果を確認
    /// </summary>
    [Fact]
    public void DragonTiles_文字列表現の確認_正しい文字列が取得できる()
    {
        // Arrange & Act & Assert
        Assert.Equal("白", Tile.Haku.ToString());
        Assert.Equal("發", Tile.Hatsu.ToString());
        Assert.Equal("中", Tile.Chun.ToString());
    }
}