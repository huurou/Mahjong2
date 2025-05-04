using Mahjong2.Lib.Internals.Shantens;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.Shantens;

public class ShantenCalculatorTests
{
    [Theory]
    [InlineData("567", "11", "111234567", "", ShantenCalculator.AGARI_SHANTEN)]
    [InlineData("567", "11", "111345677", "", 0)]
    [InlineData("567", "15", "111345677", "", 1)]
    [InlineData("1578", "15", "11134567", "", 2)]
    [InlineData("1358", "1358", "113456", "", 3)]
    [InlineData("1358", "13588", "1589", "t", 4)]
    [InlineData("1358", "13588", "159", "tn", 5)]
    [InlineData("1358", "258", "1589", "tns", 6)]
    [InlineData("", "", "11123456788999", "", ShantenCalculator.AGARI_SHANTEN)]
    [InlineData("", "", "11122245679999", "", 0)]
    [InlineData("8", "1367", "4566677", "tn", 2)]
    [InlineData("3678", "3356", "15", "nhrc", 4)]
    [InlineData("359", "17", "159", "tnshrc", 7)]
    [InlineData("1111222235555", "", "", "t", 0)]
    [InlineData("1358", "13588", "589", "tt", 3)]
    [InlineData("1358", "13588", "59", "ttt", 3)]
    [InlineData("1358", "1388", "59", "tttt", 3)]
    [InlineData("", "11", "345677788899", "", ShantenCalculator.AGARI_SHANTEN)]
    public void Calc_通常形14枚_正しいシャンテン数を取得できる(string man, string pin, string sou, string honor, int expected)
    {
        // Arrange
        var hand = new TileList(man, pin, sou, honor);

        // Act
        var actual = ShantenCalculator.Calc(hand, useRegular: true, useChiitoitsu: false, useKokushi: false);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("567", "1", "111345677", "", 1)]
    [InlineData("567", "", "111345677", "", 1)]
    [InlineData("56", "", "111345677", "", 0)]
    public void Calc_通常形13枚_正しいシャンテン数を取得できる(string man, string pin, string sou, string honor, int expected)
    {
        // Arrange
        var hand = new TileList(man, pin, sou, honor);

        // Act
        var actual = ShantenCalculator.Calc(hand, useRegular: true, useChiitoitsu: false, useKokushi: false);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("77", "114477", "114477", "", ShantenCalculator.AGARI_SHANTEN)]
    [InlineData("76", "114477", "114477", "", 0)]
    [InlineData("76", "114479", "114477", "", 1)]
    [InlineData("76", "14479", "114477", "t", 2)]
    [InlineData("76", "13479", "114477", "t", 3)]
    [InlineData("76", "13479", "114467", "t", 4)]
    [InlineData("76", "13479", "113467", "t", 5)]
    [InlineData("76", "13479", "123467", "t", 6)]
    public void Calc_七対子_正しいシャンテン数を取得できる(string man, string pin, string sou, string honor, int expected)
    {
        // Arrange
        var hand = new TileList(man, pin, sou, honor);

        // Act
        var actual = ShantenCalculator.Calc(hand, useRegular: false, useChiitoitsu: true, useKokushi: false);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("19", "19", "19", "tnsphrcc", ShantenCalculator.AGARI_SHANTEN)]
    [InlineData("19", "19", "129", "tnsphrc", 0)]
    [InlineData("19", "129", "129", "tnsphr", 1)]
    [InlineData("129", "129", "129", "tnsph", 2)]
    [InlineData("129", "129", "1239", "nsph", 3)]
    [InlineData("129", "1239", "1239", "sph", 4)]
    [InlineData("1239", "1239", "1239", "ph", 5)]
    [InlineData("1239", "1239", "12349", "h", 6)]
    [InlineData("1239", "12349", "12349", "", 7)]
    public void Calc_国士無双_正しいシャンテン数を取得できる(string man, string pin, string sou, string honor, int expected)
    {
        // Arrange
        var hand = new TileList(man, pin, sou, honor);

        // Act
        var actual = ShantenCalculator.Calc(hand, useRegular: false, useChiitoitsu: false, useKokushi: true);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("123456789", "", "", "tttt", 1)]
    [InlineData("123456789", "1111", "", "", 1)]
    public void Calc_手牌に同種の牌が4枚ある_正しいシャンテン数を取得できる(string man, string pin, string sou, string honor, int expected)
    {
        // Arrange
        var hand = new TileList(man, pin, sou, honor);

        // Act
        var actual = ShantenCalculator.Calc(hand);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "222567", "44468", "", 0)]
    [InlineData("", "222567", "68", "", 0)]
    [InlineData("", "", "68", "", 0)]
    [InlineData("", "", "88", "", ShantenCalculator.AGARI_SHANTEN)]
    public void Calc_手牌が13枚より少ない_正しいシャンテン数を取得できる(string man, string pin, string sou, string honor, int expected)
    {
        // Arrange
        var hand = new TileList(man, pin, sou, honor);

        // Act
        var actual = ShantenCalculator.Calc(hand, useRegular: true, useChiitoitsu: false, useKokushi: false);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Calc_手牌が14枚を超える_例外がスローされる()
    {
        // Arrange
        var hand = new TileList("123456789", "123456", "", "");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => ShantenCalculator.Calc(hand));
        Assert.Contains("手牌の数が14個より多いです", exception.Message);
        Assert.Equal("tileList", exception.ParamName);
    }

    [Fact]
    public void Calc_全ての形が無効_例外がスローされる()
    {
        // Arrange
        var hand = new TileList("123456789", "1234", "", "");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => ShantenCalculator.Calc(hand, useRegular: false, useChiitoitsu: false, useKokushi: false));
        Assert.Contains("最低でも1つの形を指定してください", exception.Message);
    }
}