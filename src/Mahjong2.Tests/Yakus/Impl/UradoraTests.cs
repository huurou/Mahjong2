using Mahjong2.Lib.Internals.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class UradoraTests
{
    [Fact]
    public void Number_52を返す()
    {
        // Arrange
        var uradora = new Uradora();

        // Act
        var actual = uradora.Number;

        // Assert
        Assert.Equal(52, actual);
    }

    [Fact]
    public void Name_裏ドラを返す()
    {
        // Arrange
        var uradora = new Uradora();

        // Act
        var actual = uradora.Name;

        // Assert
        Assert.Equal("裏ドラ", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var uradora = new Uradora();

        // Act
        var actual = uradora.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var uradora = new Uradora();

        // Act
        var actual = uradora.HanClosed;

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var uradora = new Uradora();

        // Act
        var actual = uradora.IsYakuman;

        // Assert
        Assert.False(actual);
    }
}