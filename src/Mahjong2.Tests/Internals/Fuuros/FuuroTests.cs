using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Internals.Fuuros;

/// <summary>
/// Fuuroクラスとそのサブクラスのテスト
/// </summary>
public class FuuroTests
{
    [Fact]
    public void Chi_正しい順子の牌リストで初期化_正常に作成できる()
    {
        // Arrange
        var tiles = new TileList(man: "123");

        // Act
        var chi = new Chi(tiles);

        // Assert
        Assert.True(chi.IsChi);
        Assert.False(chi.IsPon);
        Assert.False(chi.IsKan);
        Assert.False(chi.IsAnkan);
        Assert.False(chi.IsMinkan);
        Assert.False(chi.IsDaiminkan);
        Assert.False(chi.IsShouminkan);
        Assert.False(chi.IsNuki);
        Assert.True(chi.IsOpen);
    }

    [Fact]
    public void Chi_順子でない牌リストで初期化_例外がスローされる()
    {
        // Arrange
        var notShuntsu1 = new TileList(man: "124");                     // 連続していない
        var notShuntsu2 = new TileList(man: "111");                     // 刻子
        var notShuntsu3 = new TileList(man: "1", pin: "2", sou: "3");   // 異なる種類

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Chi(notShuntsu1));
        Assert.Throws<ArgumentException>(() => new Chi(notShuntsu2));
        Assert.Throws<ArgumentException>(() => new Chi(notShuntsu3));
    }

    [Fact]
    public void Pon_正しい刻子の牌リストで初期化_正常に作成できる()
    {
        // Arrange
        var tiles = new TileList(man: "555");

        // Act
        var pon = new Pon(tiles);

        // Assert
        Assert.Equal(tiles, pon.TileList);
        Assert.False(pon.IsChi);
        Assert.True(pon.IsPon);
        Assert.False(pon.IsKan);
        Assert.False(pon.IsAnkan);
        Assert.False(pon.IsMinkan);
        Assert.False(pon.IsDaiminkan);
        Assert.False(pon.IsShouminkan);
        Assert.False(pon.IsNuki);
        Assert.True(pon.IsOpen);
    }

    [Fact]
    public void Pon_刻子でない牌リストで初期化_例外がスローされる()
    {
        // Arrange
        var notKoutsu1 = new TileList(man: "123");  // 順子
        var notKoutsu2 = new TileList(man: "112");  // 同じ牌が2枚しかない
        var notKoutsu3 = new TileList(man: "1111"); // 槓子

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Pon(notKoutsu1));
        Assert.Throws<ArgumentException>(() => new Pon(notKoutsu2));
        Assert.Throws<ArgumentException>(() => new Pon(notKoutsu3));
    }

    [Fact]
    public void Ankan_正しい槓子の牌リストで初期化_正常に作成できる()
    {
        // Arrange
        var tiles = new TileList(pin: "2222");

        // Act
        var ankan = new Ankan(tiles);

        // Assert
        Assert.Equal(tiles, ankan.TileList);
        Assert.False(ankan.IsChi);
        Assert.False(ankan.IsPon);
        Assert.True(ankan.IsKan);
        Assert.True(ankan.IsAnkan);
        Assert.False(ankan.IsMinkan);
        Assert.False(ankan.IsDaiminkan);
        Assert.False(ankan.IsShouminkan);
        Assert.False(ankan.IsNuki);
        Assert.False(ankan.IsOpen);
    }

    [Fact]
    public void Daiminkan_正しい槓子の牌リストで初期化_正常に作成できる()
    {
        // Arrange
        var tiles = new TileList(sou: "9999");

        // Act
        var daiminkan = new Daiminkan(tiles);

        // Assert
        Assert.Equal(tiles, daiminkan.TileList);
        Assert.False(daiminkan.IsChi);
        Assert.False(daiminkan.IsPon);
        Assert.True(daiminkan.IsKan);
        Assert.False(daiminkan.IsAnkan);
        Assert.True(daiminkan.IsMinkan);
        Assert.True(daiminkan.IsDaiminkan);
        Assert.False(daiminkan.IsShouminkan);
        Assert.False(daiminkan.IsNuki);
        Assert.True(daiminkan.IsOpen);
    }

    [Fact]
    public void Shouminkan_正しい槓子の牌リストで初期化_正常に作成できる()
    {
        // Arrange
        var tiles = new TileList(honor: "tttt"); // 東

        // Act
        var shouminkan = new Shouminkan(tiles);

        // Assert
        Assert.Equal(tiles, shouminkan.TileList);
        Assert.False(shouminkan.IsChi);
        Assert.False(shouminkan.IsPon);
        Assert.True(shouminkan.IsKan);
        Assert.False(shouminkan.IsAnkan);
        Assert.True(shouminkan.IsMinkan);
        Assert.False(shouminkan.IsDaiminkan);
        Assert.True(shouminkan.IsShouminkan);
        Assert.False(shouminkan.IsNuki);
        Assert.True(shouminkan.IsOpen);
    }

    [Fact]
    public void Kan_槓子でない牌リストで初期化_例外がスローされる()
    {
        // Arrange
        var notKantsu1 = new TileList(man: "1234"); // 連続牌
        var notKantsu2 = new TileList(man: "111");  // 3枚しかない（刻子）
        var notKantsu3 = new TileList(man: "11");   // 2枚しかない（対子）

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Ankan(notKantsu1));
        Assert.Throws<ArgumentException>(() => new Ankan(notKantsu2));
        Assert.Throws<ArgumentException>(() => new Ankan(notKantsu3));

        Assert.Throws<ArgumentException>(() => new Daiminkan(notKantsu1));
        Assert.Throws<ArgumentException>(() => new Daiminkan(notKantsu2));
        Assert.Throws<ArgumentException>(() => new Daiminkan(notKantsu3));

        Assert.Throws<ArgumentException>(() => new Shouminkan(notKantsu1));
        Assert.Throws<ArgumentException>(() => new Shouminkan(notKantsu2));
        Assert.Throws<ArgumentException>(() => new Shouminkan(notKantsu3));
    }

    [Fact]
    public void Nuki_初期化_正常に作成できる()
    {
        // Arrange
        var tiles = new TileList(honor: "p");

        // Act
        var nuki = new Nuki(tiles);

        // Assert
        Assert.Equal(tiles, nuki.TileList);
        Assert.False(nuki.IsChi);
        Assert.False(nuki.IsPon);
        Assert.False(nuki.IsKan);
        Assert.False(nuki.IsAnkan);
        Assert.False(nuki.IsMinkan);
        Assert.False(nuki.IsDaiminkan);
        Assert.False(nuki.IsShouminkan);
        Assert.True(nuki.IsNuki);
        Assert.False(nuki.IsOpen);
    }

    [Fact]
    public void Chi_ToString_正しい文字列表現を返す()
    {
        // Arrange
        var tiles = new TileList(man: "123");
        var chi = new Chi(tiles);

        // Act
        var result = chi.ToString();

        // Assert
        Assert.Equal($"チー-{tiles}", result);
    }

    [Fact]
    public void Pon_ToString_正しい文字列表現を返す()
    {
        // Arrange
        var tiles = new TileList(man: "555");
        var pon = new Pon(tiles);

        // Act
        var result = pon.ToString();

        // Assert
        Assert.Equal($"ポン-{tiles}", result);
    }

    [Fact]
    public void Ankan_ToString_正しい文字列表現を返す()
    {
        // Arrange
        var tiles = new TileList(pin: "2222");
        var ankan = new Ankan(tiles);

        // Act
        var result = ankan.ToString();

        // Assert
        Assert.Equal($"暗槓-{tiles}", result);
    }

    [Fact]
    public void Daiminkan_ToString_正しい文字列表現を返す()
    {
        // Arrange
        var tiles = new TileList(sou: "9999");
        var daiminkan = new Daiminkan(tiles);

        // Act
        var result = daiminkan.ToString();

        // Assert
        Assert.Equal($"大明槓-{tiles}", result);
    }

    [Fact]
    public void Shouminkan_ToString_正しい文字列表現を返す()
    {
        // Arrange
        var tiles = new TileList(honor: "tttt");
        var shouminkan = new Shouminkan(tiles);

        // Act
        var result = shouminkan.ToString();

        // Assert
        Assert.Equal($"小明槓-{tiles}", result);
    }

    [Fact]
    public void Nuki_ToString_正しい文字列表現を返す()
    {
        // Arrange
        var tiles = new TileList(honor: "p");
        var nuki = new Nuki(tiles);

        // Act
        var result = nuki.ToString();

        // Assert
        Assert.Equal($"抜き-{tiles}", result);
    }
}