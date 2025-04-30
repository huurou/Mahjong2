using Mahjong2.Lib.Yakus;

namespace Mahjong2.Tests.Yakus.Impl;

public class DoraTests
{
    [Fact]
    public void Name_ドラが返る()
    {
        // Arrange
        var dora = Yaku.Dora;

        // Act
        var actual = dora.Name;

        // Assert
        Assert.Equal("ドラ", actual);
    }

    [Fact]
    public void HanOpen_1が返る()
    {
        // Arrange
        var dora = Yaku.Dora;

        // Act
        var actual = dora.HanOpen;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void HanClosed_1が返る()
    {
        // Arrange
        var dora = Yaku.Dora;
        
        // Act
        var actual = dora.HanClosed;
        
        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseが返る()
    {
        // Arrange
        var dora = Yaku.Dora;

        // Act
        var actual = dora.IsYakuman;

        // Assert
        Assert.False(actual);
    }
}