using Mahjong2.Lib.Internals.Shantens;
using Mahjong2.Lib.Scores;

namespace Mahjong2.Tests;

public class MjShantenCalculatorTests
{
    [Fact]
    public void AGARI_SHANTEN_Internalsのものと等しいこと()
    {
        // Arrange
        var agariShanten = MjShantenCalculator.AGARI_SHANTEN;
        var internalsAgariShanten = ShantenCalculator.AGARI_SHANTEN;

        // Act && Assert
        Assert.Equal(agariShanten, internalsAgariShanten);
    }
}
