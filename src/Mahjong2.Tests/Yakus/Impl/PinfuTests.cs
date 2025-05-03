using Mahjong2.Lib.Fus;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class PinfuTests
{
    [Fact]
    public void Number_11を返す()
    {
        // Arrange
        var pinfu = new Pinfu();
        // Act
        var result = pinfu.Number;
        // Assert
        Assert.Equal(11, result);
    }

    [Fact]
    public void Name_平和を返す()
    {
        // Arrange
        var pinfu = new Pinfu();

        // Act
        var result = pinfu.Name;

        // Assert
        Assert.Equal("平和", result);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var pinfu = new Pinfu();

        // Act
        var result = pinfu.HanOpen;

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void HanClosed_1を返す()
    {
        // Arrange
        var pinfu = new Pinfu();

        // Act
        var result = pinfu.HanClosed;

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var pinfu = new Pinfu();

        // Act
        var result = pinfu.IsYakuman;

        // Assert
        Assert.False(result);
    }

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