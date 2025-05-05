using Mahjong2.Lib.Games;
using Mahjong2.Lib.Yakus;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class AkadoraTests
{
    [Fact]
    public void Number_53を返す()
    {
        // Arrange
        var akadora = Yaku.Akadora;
        // Act
        var actual = akadora.Number;
        // Assert
        Assert.Equal(53, actual);
    }

    [Fact]
    public void Name_赤ドラを返す()
    {
        // Arrange
        var akadora = Yaku.Akadora;

        // Act
        var actual = akadora.Name;

        // Assert
        Assert.Equal("赤ドラ", actual);
    }

    [Fact]
    public void HanOpen_1を返す()
    {
        // Arrange
        var akadora = Yaku.Akadora;

        // Act
        var actual = akadora.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var akadora = Yaku.Akadora;
        // Act
        var actual = akadora.HanClosed;
        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var akadora = Yaku.Akadora;

        // Act
        var actual = akadora.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_赤ドラが1つ_成立する()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            AkadoraCount = 1
        };

        // Act
        var actual = Akadora.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_赤ドラが複数_成立する()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            AkadoraCount = 3
        };

        // Act
        var actual = Akadora.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_赤ドラなし_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation
        {
            AkadoraCount = 0
        };

        // Act
        var actual = Akadora.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}