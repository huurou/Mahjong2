using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Games;
using Mahjong2.Lib.Scoring.Yakus;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class IppatsuTests
{
    [Fact]
    public void Number_4を返す()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;
        // Act
        var actual = ippatsu.Number;
        // Assert
        Assert.Equal(4, actual);
    }

    [Fact]
    public void Name_一発を返す()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.Name;

        // Assert
        Assert.Equal("一発", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var ippatsu = Yaku.Ippatsu;

        // Act
        var actual = ippatsu.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_一発と立直があり面前の場合_成立する()
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