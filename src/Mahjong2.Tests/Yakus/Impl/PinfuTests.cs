using Mahjong2.Lib.Fus;
using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class PinfuTests
{
    [Fact]
    public void Valid_ツモアガリでピンヅモあり_成立()
    {
        // Arrange
        var fuList = new FuList([Fu.Futei]);
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { PinzumoEnabled = true };

        // Act
        var result = Pinfu.Valid(fuList, winSituation, gameRules);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Valid_ツモアガリでピンヅモなし_不成立()
    {
        // Arrange
        // ピンヅモなしのときはツモ符がついて30符になる
        var fuList = new FuList([Fu.Futei, Fu.TsumoFu]);
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { PinzumoEnabled = false };

        // Act
        var result = Pinfu.Valid(fuList, winSituation, gameRules);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Valid_ツモアガリでツモ符がある_不成立()
    {
        // Arrange
        var fuList = new FuList([Fu.Futei, Fu.TsumoFu]);
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { PinzumoEnabled = true };

        // Act
        var result = Pinfu.Valid(fuList, winSituation, gameRules);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Valid_ロンアガリで副底と面前符だけ_成立()
    {
        // Arrange
        var fuList = new FuList([Fu.Futei, Fu.MenzenFu]);
        var winSituation = new WinSituation { IsTsumo = false };
        var gameRules = new GameRules();

        // Act
        var result = Pinfu.Valid(fuList, winSituation, gameRules);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Valid_ロンアガリで他の符がある_不成立()
    {
        // Arrange
        var fuList = new FuList([Fu.Futei, Fu.MenzenFu, Fu.WaitKanchan]);
        var winSituation = new WinSituation { IsTsumo = false };
        var gameRules = new GameRules();

        // Act
        var result = Pinfu.Valid(fuList, winSituation, gameRules);

        // Assert
        Assert.False(result);
    }
}