using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;

namespace Mahjong2.Tests.Tiles;

public class TileTests
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
    public void All_要素数の確認_34種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(34, Tile.All.Count);
    }

    [Fact]
    public void Numbers_要素数の確認_27種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(27, Tile.Numbers.Count);
    }

    [Fact]
    public void Mans_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Mans.Count);
    }

    [Fact]
    public void Pins_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Pins.Count);
    }

    [Fact]
    public void Sous_要素数の確認_9種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(9, Tile.Sous.Count);
    }

    [Fact]
    public void Honors_要素数の確認_7種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(7, Tile.Honors.Count);
    }

    [Fact]
    public void Winds_要素数の確認_4種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(4, Tile.Winds.Count);
    }

    [Fact]
    public void Dragons_要素数の確認_3種類の牌がある()
    {
        // Arrange & Act & Assert
        Assert.Equal(3, Tile.Dragons.Count);
    }

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

    [Fact]
    public void Chuchans_リストの確認_中張牌のみを含む()
    {
        // Arrange & Act
        var expected = 21; // 3色 × (2から8の7種)

        // Assert
        Assert.Equal(expected, Tile.Chuchans.Count);
        Assert.All(Tile.Chuchans, tile => Assert.True(tile.IsChucahn));
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
    public void Yaochus_リストの確認_么九牌のみを含む()
    {
        // Arrange & Act
        var expected = 13; // 数牌の1,9 (3色×2種=6種) + 字牌(7種)

        // Assert
        Assert.Equal(expected, Tile.Yaochus.Count);
        Assert.All(Tile.Yaochus, tile => Assert.True(tile.IsYaochu));
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

    [Fact]
    public void Tile_リスト内容の確認_重複がなく漏れもない()
    {
        // Arrange & Act & Assert
        // 全ての牌の確認
        Assert.Equal(Tile.Numbers.Count + Tile.Honors.Count, Tile.All.Count);
        Assert.All(Tile.Numbers, tile => Assert.Contains(tile, Tile.All));
        Assert.All(Tile.Honors, tile => Assert.Contains(tile, Tile.All));

        // 数牌の確認
        Assert.Equal(Tile.Mans.Count + Tile.Pins.Count + Tile.Sous.Count, Tile.Numbers.Count);
        Assert.All(Tile.Mans, tile => Assert.Contains(tile, Tile.Numbers));
        Assert.All(Tile.Pins, tile => Assert.Contains(tile, Tile.Numbers));
        Assert.All(Tile.Sous, tile => Assert.Contains(tile, Tile.Numbers));

        // 字牌の確認
        Assert.Equal(Tile.Winds.Count + Tile.Dragons.Count, Tile.Honors.Count);
        Assert.All(Tile.Winds, tile => Assert.Contains(tile, Tile.Honors));
        Assert.All(Tile.Dragons, tile => Assert.Contains(tile, Tile.Honors));

        // 中張牌の確認
        Assert.All(Tile.Chuchans, tile =>
        {
            Assert.True(tile.IsNumber);
            Assert.True(tile.Number >= 2 && tile.Number <= 8);
        });

        // 么九牌の確認
        Assert.All(Tile.Yaochus, tile => Assert.True(tile.IsHonor || tile is NumberTile { Number: 1 } || tile is NumberTile { Number: 9 }));

        // 老頭牌の確認
        Assert.All(Tile.Routous, tile =>
        {
            Assert.True(tile.IsNumber);
            Assert.True(tile.Number == 1 || tile.Number == 9);
        });
    }

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

    [Fact]
    public void ToString_文字列表現の確認_正しい文字列が取得できる()
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
        Assert.Equal("(1)", Tile.Pin1.ToString());
        Assert.Equal("(2)", Tile.Pin2.ToString());
        Assert.Equal("(3)", Tile.Pin3.ToString());
        Assert.Equal("(4)", Tile.Pin4.ToString());
        Assert.Equal("(5)", Tile.Pin5.ToString());
        Assert.Equal("(6)", Tile.Pin6.ToString());
        Assert.Equal("(7)", Tile.Pin7.ToString());
        Assert.Equal("(8)", Tile.Pin8.ToString());
        Assert.Equal("(9)", Tile.Pin9.ToString());
        Assert.Equal("1", Tile.Sou1.ToString());
        Assert.Equal("2", Tile.Sou2.ToString());
        Assert.Equal("3", Tile.Sou3.ToString());
        Assert.Equal("4", Tile.Sou4.ToString());
        Assert.Equal("5", Tile.Sou5.ToString());
        Assert.Equal("6", Tile.Sou6.ToString());
        Assert.Equal("7", Tile.Sou7.ToString());
        Assert.Equal("8", Tile.Sou8.ToString());
        Assert.Equal("9", Tile.Sou9.ToString());
        Assert.Equal("東", Tile.Ton.ToString());
        Assert.Equal("南", Tile.Nan.ToString());
        Assert.Equal("西", Tile.Sha.ToString());
        Assert.Equal("北", Tile.Pei.ToString());
        Assert.Equal("白", Tile.Haku.ToString());
        Assert.Equal("發", Tile.Hatsu.ToString());
        Assert.Equal("中", Tile.Chun.ToString());
    }

    [Fact]
    public void CompareTo_牌の種類での比較_正しい順序で比較できる()
    {
        // Arrange & Act & Assert
        // 萬子 < 筒子 < 索子 < 風牌 < 三元牌
        Assert.True(Tile.Man1.CompareTo(Tile.Pin1) < 0); // 萬子 < 筒子
        Assert.True(Tile.Pin1.CompareTo(Tile.Sou1) < 0);  // 筒子 < 索子
        Assert.True(Tile.Sou1.CompareTo(Tile.Ton) < 0);   // 索子 < 風牌
        Assert.True(Tile.Ton.CompareTo(Tile.Haku) < 0);   // 風牌 < 三元牌

        // 逆の比較も確認
        Assert.True(Tile.Pin1.CompareTo(Tile.Man1) > 0);
        Assert.True(Tile.Sou1.CompareTo(Tile.Pin1) > 0);
        Assert.True(Tile.Ton.CompareTo(Tile.Sou1) > 0);
        Assert.True(Tile.Haku.CompareTo(Tile.Ton) > 0);
    }

    [Fact]
    public void CompareTo_同じ種類の牌での比較_数字順で比較できる()
    {
        // Arrange & Act & Assert
        // 萬子での比較（数字の昇順）
        Assert.True(Tile.Man1.CompareTo(Tile.Man2) < 0);
        Assert.True(Tile.Man5.CompareTo(Tile.Man9) < 0);

        // 筒子での比較
        Assert.True(Tile.Pin3.CompareTo(Tile.Pin7) < 0);
        Assert.True(Tile.Pin9.CompareTo(Tile.Pin5) > 0);

        // 索子での比較
        Assert.True(Tile.Sou1.CompareTo(Tile.Sou4) < 0);
        Assert.True(Tile.Sou8.CompareTo(Tile.Sou2) > 0);

        // 同じ牌どうしの比較は0
        Assert.Equal(0, Tile.Man5.CompareTo(Tile.Man5));
        Assert.Equal(0, Tile.Pin7.CompareTo(Tile.Pin7));
        Assert.Equal(0, Tile.Sou3.CompareTo(Tile.Sou3));
    }

    [Fact]
    public void CompareTo_風牌どうしの比較_東南西北の順で比較できる()
    {
        // Arrange & Act & Assert
        // 風牌の順序: 東 < 南 < 西 < 北
        Assert.True(Tile.Ton.CompareTo(Tile.Nan) < 0); // 東 < 南
        Assert.True(Tile.Nan.CompareTo(Tile.Sha) < 0); // 南 < 西
        Assert.True(Tile.Sha.CompareTo(Tile.Pei) < 0); // 西 < 北

        // 逆の比較も確認
        Assert.True(Tile.Nan.CompareTo(Tile.Ton) > 0);
        Assert.True(Tile.Sha.CompareTo(Tile.Nan) > 0);
        Assert.True(Tile.Pei.CompareTo(Tile.Sha) > 0);

        // 同じ牌どうしの比較は0
        Assert.Equal(0, Tile.Ton.CompareTo(Tile.Ton));
        Assert.Equal(0, Tile.Nan.CompareTo(Tile.Nan));
        Assert.Equal(0, Tile.Sha.CompareTo(Tile.Sha));
        Assert.Equal(0, Tile.Pei.CompareTo(Tile.Pei));
    }

    [Fact]
    public void CompareTo_三元牌どうしの比較_白發中の順で比較できる()
    {
        // Arrange & Act & Assert
        // 三元牌の順序: 白 < 發 < 中
        Assert.True(Tile.Haku.CompareTo(Tile.Hatsu) < 0);  // 白 < 發
        Assert.True(Tile.Hatsu.CompareTo(Tile.Chun) < 0);  // 發 < 中

        // 逆の比較も確認
        Assert.True(Tile.Hatsu.CompareTo(Tile.Haku) > 0);
        Assert.True(Tile.Chun.CompareTo(Tile.Hatsu) > 0);

        // 同じ牌どうしの比較は0
        Assert.Equal(0, Tile.Haku.CompareTo(Tile.Haku));
        Assert.Equal(0, Tile.Hatsu.CompareTo(Tile.Hatsu));
        Assert.Equal(0, Tile.Chun.CompareTo(Tile.Chun));
    }

    /// <summary>
    /// CompareTo()メソッドがnullと比較した場合に正しく動作することを確認
    /// </summary>
    [Fact]
    public void CompareTo_null値との比較_正の値を返す()
    {
        // Arrange & Act & Assert
        // null値との比較は常に1(正の値)を返す
        Assert.True(Tile.Man1.CompareTo(null) > 0);
        Assert.True(Tile.Pin5.CompareTo(null) > 0);
        Assert.True(Tile.Sou9.CompareTo(null) > 0);
        Assert.True(Tile.Ton.CompareTo(null) > 0);
        Assert.True(Tile.Haku.CompareTo(null) > 0);
    }

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

    /// <summary>
    /// ManTileのTryFromNumberメソッドが正常な入力値で正しく動作することを確認
    /// </summary>
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

    /// <summary>
    /// ManTileのTryFromNumberメソッドが範囲外の入力値で正しく動作することを確認
    /// </summary>
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

    /// <summary>
    /// PinTileのTryFromNumberメソッドが正常な入力値で正しく動作することを確認
    /// </summary>
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

    /// <summary>
    /// PinTileのTryFromNumberメソッドが範囲外の入力値で正しく動作することを確認
    /// </summary>
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

    /// <summary>
    /// SouTileのTryFromNumberメソッドが正常な入力値で正しく動作することを確認
    /// </summary>
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

    /// <summary>
    /// SouTileのTryFromNumberメソッドが範囲外の入力値で正しく動作することを確認
    /// </summary>
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

    /// <summary>
    /// 比較演算子が正しく動作することを確認
    /// </summary>
    [Fact]
    public void 比較演算子_各種比較演算子_正しく比較できる()
    {
        // Arrange & Act & Assert
        // < 演算子のテスト
        Assert.True(Tile.Man1 < Tile.Pin1); // 萬子 < 筒子
        Assert.True(Tile.Man1 < Tile.Man2); // 同じ種類では数字順
        Assert.True(Tile.Ton < Tile.Nan);   // 字牌も順序通り
        Assert.False(Tile.Pin1 < Tile.Man1);
        Assert.False(Tile.Man2 < Tile.Man2); // 等しい場合はfalse

        // > 演算子のテスト
        Assert.True(Tile.Pin1 > Tile.Man1);
        Assert.True(Tile.Man5 > Tile.Man3);
        Assert.True(Tile.Hatsu > Tile.Haku);
        Assert.False(Tile.Man1 > Tile.Pin1);
        Assert.False(Tile.Man2 > Tile.Man2); // 等しい場合はfalse

        // <= 演算子のテスト
        Assert.True(Tile.Man1 <= Tile.Pin1);
        Assert.True(Tile.Man1 <= Tile.Man2);
        Assert.True(Tile.Man2 <= Tile.Man2); // 等しい場合はtrue
        Assert.False(Tile.Pin1 <= Tile.Man1);

        // >= 演算子のテスト
        Assert.True(Tile.Pin1 >= Tile.Man1);
        Assert.True(Tile.Man5 >= Tile.Man3);
        Assert.True(Tile.Man2 >= Tile.Man2); // 等しい場合はtrue
        Assert.False(Tile.Man1 >= Tile.Pin1);
    }

    /// <summary>
    /// null値との比較演算子が正しく動作することを確認
    /// </summary>
    [Fact]
    public void 比較演算子_null値との比較_正しく比較できる()
    {
        // Arrange & Act & Assert
        // null との比較
        Assert.True(Tile.Man1 > null);      // 任意の牌 > null
        Assert.True(Tile.Pin9 > null);
        Assert.True(Tile.Chun > null);

        Assert.False(Tile.Man1 < null);     // null < 任意の牌
        Assert.False(Tile.Pin9 < null);
        Assert.False(Tile.Chun < null);

        Assert.True(Tile.Man1 >= null);     // 任意の牌 >= null
        Assert.True(null <= Tile.Man1);     // null <= 任意の牌

        Assert.False(Tile.Man1 <= null);    // 任意の牌 <= null
        Assert.False(null >= Tile.Man1);    // null >= 任意の牌
    }

    /// <summary>
    /// ソートが正しく動作することを確認
    /// </summary>
    [Fact]
    public void 比較演算子_ソートでの利用_順序通りにソートできる()
    {
        // Arrange
        var unsortedTiles = new List<Tile>
        {
            Tile.Chun, Tile.Ton, Tile.Man5, Tile.Sou1, Tile.Pin9,
            Tile.Haku, Tile.Pei, Tile.Man1, Tile.Pin1, Tile.Sou9,
            Tile.Sha, Tile.Man9, Tile.Hatsu, Tile.Nan, Tile.Pin3
        };

        var expectedOrder = new List<Tile>
        {
            // 萬子
            Tile.Man1, Tile.Man5, Tile.Man9,
            // 筒子
            Tile.Pin1, Tile.Pin3, Tile.Pin9,
            // 索子
            Tile.Sou1, Tile.Sou9,
            // 風牌
            Tile.Ton, Tile.Nan, Tile.Sha, Tile.Pei,
            // 三元牌
            Tile.Haku, Tile.Hatsu, Tile.Chun
        };

        // Act
        var sortedTiles = unsortedTiles.OrderBy(t => t).ToList();

        // Assert
        Assert.Equal(expectedOrder, sortedTiles);
    }
}