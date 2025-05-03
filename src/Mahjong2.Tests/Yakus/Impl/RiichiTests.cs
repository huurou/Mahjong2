using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class RiichiTests
{
    [Fact]
    public void Name_立直が返る()
    {
        // Arrange
        var riichi = Yaku.Riichi;

        // Act
        var actual = riichi.Name;

        // Assert
        Assert.Equal("立直", actual);
    }

    [Fact]
    public void HanOpen_0が返る()
    {
        // Arrange
        var riichi = Yaku.Riichi;

        // Act
        var actual = riichi.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var riichi = Yaku.Riichi;

        // Act
        var actual = riichi.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var riichi = Yaku.Riichi;

        // Act
        var actual = riichi.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_立直かつダブル立直でなく面前の場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsRiichi = true,
            IsDoubleRiichi = false
        };
        var fuuroList = new FuuroList(); // 副露なし（面前）

        // Act
        var actual = Riichi.Valid(winSituation, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_立直でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsRiichi = false,
            IsDoubleRiichi = false
        };
        var fuuroList = new FuuroList();

        // Act
        var actual = Riichi.Valid(winSituation, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_ダブル立直の場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsRiichi = true,
            IsDoubleRiichi = true
        };
        var fuuroList = new FuuroList();

        // Act
        var actual = Riichi.Valid(winSituation, fuuroList);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_副露がある場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsRiichi = true,
            IsDoubleRiichi = false
        };
        var fuuroList = new FuuroList([new Pon(new(man: "111"))]);

        // Act
        var actual = Riichi.Valid(winSituation, fuuroList);

        // Assert
        Assert.False(actual);
    }
}