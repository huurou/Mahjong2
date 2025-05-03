using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class IppatsuTests
{
    [Fact]
    public void Name_一発が返る()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.Name;

        // Assert
        Assert.Equal("一発", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_一発とリーチがあり面前の場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsIppatsu = true,
            IsRiichi = true,
        };
        var fuuroList = new FuuroList(); // 副露なし（面前）

        // Act
        var actual = Ippatsu.Valid(winSituation, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_一発が成立していない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsIppatsu = false };
        var fuuroList = new FuuroList();

        // Act
        var actual = Ippatsu.Valid(winSituation, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_一発が成立するが副露がある場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsIppatsu = true };
        // 副露あり
        var fuuroList = new FuuroList([
            new Pon(new TileList(man: "111"))
        ]);

        // Act
        var actual = Ippatsu.Valid(winSituation, fuuroList);

        // Assert
        Assert.False(actual);
    }
}