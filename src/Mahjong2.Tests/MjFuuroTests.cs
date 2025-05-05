using Mahjong2.Lib;
using Mahjong2.Lib.Internals.Fuuros;

namespace Mahjong2.Tests;

public class MjFuuroTests
{
    [Fact]
    public void ポンを作成_プロパティが正しく設定される()
    {
        // Arrange
        var type = MjFuuroType.Pon;
        var tiles = new List<MjTileKind> { MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1 };

        // Act
        var fuuro = new MjFuuro(type, tiles);

        // Assert
        Assert.Equal(type, fuuro.Type);
        Assert.Equal(tiles, fuuro.Tiles);
    }

    [Fact]
    public void ToFuuro_ポンを内部表現に変換_正しく変換される()
    {
        // Arrange
        var mjFuuro = new MjFuuro(
            MjFuuroType.Pon,
            [MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1]
        );

        // Act
        var fuuro = mjFuuro.ToFuuro();

        // Assert
        Assert.IsType<Pon>(fuuro);
        Assert.Equal(3, fuuro.TileList.Count);
    }

    [Fact]
    public void ToFuuro_チーを内部表現に変換_正しく変換される()
    {
        // Arrange
        var mjFuuro = new MjFuuro(
            MjFuuroType.Chi,
            [MjTileKind.Man1, MjTileKind.Man2, MjTileKind.Man3]
        );

        // Act
        var fuuro = mjFuuro.ToFuuro();

        // Assert
        Assert.IsType<Chi>(fuuro);
        Assert.Equal(3, fuuro.TileList.Count);
    }

    [Fact]
    public void ToFuuro_暗槓を内部表現に変換_正しく変換される()
    {
        // Arrange
        var mjFuuro = new MjFuuro(
            MjFuuroType.Ankan,
            [MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1]
        );

        // Act
        var fuuro = mjFuuro.ToFuuro();

        // Assert
        Assert.IsType<Ankan>(fuuro);
        Assert.Equal(4, fuuro.TileList.Count);
    }

    [Fact]
    public void ToFuuro_明槓を内部表現に変換_正しく変換される()
    {
        // Arrange
        var mjFuuro = new MjFuuro(
            MjFuuroType.Minkan,
            [MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1]
        );

        // Act
        var fuuro = mjFuuro.ToFuuro();

        // Assert
        Assert.IsType<Minkan>(fuuro);
        Assert.Equal(4, fuuro.TileList.Count);
    }

    [Fact]
    public void ToFuuroList_複数の副露を内部表現に変換_正しく変換される()
    {
        // Arrange
        var mjFuuros = new List<MjFuuro>
        {
            new(MjFuuroType.Pon, [MjTileKind.Man1, MjTileKind.Man1, MjTileKind.Man1]),
            new(MjFuuroType.Chi, [MjTileKind.Man1, MjTileKind.Man2, MjTileKind.Man3])
        };

        // Act
        var fuuroList = mjFuuros.ToFuuroList();

        // Assert
        Assert.Equal(2, fuuroList.Count);
        Assert.IsType<Pon>(fuuroList.ElementAt(0));
        Assert.IsType<Chi>(fuuroList.ElementAt(1));
    }
}