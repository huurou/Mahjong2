using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class ChankanTests
{
    [Fact]
    public void Valid_槍槓の場合_成立する()
    {
        // Arrange
        var winSituation = new WinSituation { IsChankan = true };

        // Act
        var actual = Chankan.Valid(winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_槍槓でない場合_成立しない()
    {
        // Arrange
        var winSituation = new WinSituation { IsChankan = false };

        // Act
        var actual = Chankan.Valid(winSituation);

        // Assert
        Assert.False(actual);
    }
}