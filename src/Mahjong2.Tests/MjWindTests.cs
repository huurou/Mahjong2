using Mahjong2.Lib;

namespace Mahjong2.Tests;

public class MjWindTests
{
    [Fact]
    public void MjWind_列挙型の値_正しく定義されている()
    {
        // Arrange & Act & Assert
        Assert.Equal(0, (int)MjWind.East);
        Assert.Equal(1, (int)MjWind.South);
        Assert.Equal(2, (int)MjWind.West);
        Assert.Equal(3, (int)MjWind.North);
    }

    [Fact]
    public void MjWind_すべての風の列挙_4種類存在する()
    {
        // Arrange & Act
        var values = Enum.GetValues<MjWind>();

        // Assert
        Assert.Equal(4, values.Length);
    }
}