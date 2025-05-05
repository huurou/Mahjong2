using Mahjong2.Lib.Scoring.Fuuros;
using Mahjong2.Lib.Scoring.Yakus.Impl;
using Mahjong2.Lib.Scoring.Tiles;

namespace Mahjong2.Tests.Scoring.Yakus.Impl;

public class DaisuushiiTests
{
    [Fact]
    public void Number_38を返す()
    {
        // Arrange
        var daisuushii = new Daisuushii();
        // Act
        var actual = daisuushii.Number;
        // Assert
        Assert.Equal(38, actual);
    }

    [Fact]
    public void Name_大四喜を返す()
    {
        // Arrange
        var daisuushii = new Daisuushii();

        // Act
        var actual = daisuushii.Name;

        // Assert
        Assert.Equal("大四喜", actual);
    }

    [Fact]
    public void HanOpen_13を返す()
    {
        // Arrange
        var daisuushii = new Daisuushii();

        // Act
        var actual = daisuushii.HanOpen;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var daisuushii = new Daisuushii();

        // Act
        var actual = daisuushii.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var daisuushii = new Daisuushii();

        // Act
        var actual = daisuushii.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌4種類_刻子_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "ttt"), new(honor: "sss")]);
        var fuuroList = new FuuroList([
            new Pon(new TileList(honor: "nnn")),
            new Pon(new TileList(honor: "ppp")),
        ]);

        // Act
        var actual = Daisuushii.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌4種類_槓子_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11")]);
        var fuuroList = new FuuroList([
            new Ankan(new TileList(honor: "tttt")),
            new Minkan(new TileList(honor: "ssss")),
            new Minkan(new TileList(honor: "nnnn")),
            new Ankan(new TileList(honor: "pppp")),
        ]);

        // Act
        var actual = Daisuushii.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌4種類_刻子と槓子の混合_成立する()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "ttt"), new(honor: "sss")]);
        var fuuroList = new FuuroList([
            new Minkan(new TileList(honor: "nnnn")),
            new Ankan(new TileList(honor: "pppp")),
        ]);

        // Act
        var actual = Daisuushii.Valid(hand, fuuroList);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_風牌の刻子が3つだけ_成立しない()
    {
        // Arrange
        var hand = new Hand([new(pin: "11"), new(honor: "ttt"), new(honor: "sss"), new(pin: "234")]);
        var fuuroList = new FuuroList([new Pon(new TileList(honor: "nnn"))]);

        // Act
        var actual = Daisuushii.Valid(hand, fuuroList);

        // Assert
        Assert.False(actual);
    }
}