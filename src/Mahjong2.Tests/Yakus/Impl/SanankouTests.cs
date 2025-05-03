using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class SanankouTests
{
    [Fact]
    public void Name_三暗刻を返す()
    {
        // Arrange
        var sanankou = new Sanankou();

        // Act
        var actual = sanankou.Name;

        // Assert
        Assert.Equal("三暗刻", actual);
    }

    [Fact]
    public void HanOpen_2を返す()
    {
        // Arrange
        var sanankou = new Sanankou();

        // Act
        var actual = sanankou.HanOpen;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void HanClosed_2を返す()
    {
        // Arrange
        var sanankou = new Sanankou();

        // Act
        var actual = sanankou.HanClosed;

        // Assert
        Assert.Equal(2, actual);
    }

    [Fact]
    public void IsYakuman_Falseを返す()
    {
        // Arrange
        var sanankou = new Sanankou();

        // Act
        var actual = sanankou.IsYakuman;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_暗刻2つシャンポンツモアガリ_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "123"), new(pin: "222"), new(sou: "333"), new(sou: "55")]);
        var winGroup = new TileList(sou: "333");
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Sanankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_暗刻3つロンアガリ_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(man: "456"), new(sou: "55")]);
        var winGroup = new TileList(man: "456");
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = false };

        // Act
        var actual = Sanankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_暗刻2つシャンポンロンアガリ_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(man: "123"), new(pin: "222"), new(sou: "333"), new(sou: "55")]);
        var winGroup = new TileList(sou: "333"); // アガリ牌を含む暗刻
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = false };

        // Act
        var actual = Sanankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_暗刻2つ暗槓1つ_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "55")]);
        var fuuroList = new FuuroList([new Ankan(new(sou: "3333"))]);
        var winGroup = new TileList(man: "111");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Sanankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_暗槓3つ_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "234"), new(sou: "55")]);
        var fuuroList = new FuuroList([(new Ankan(new(man: "1111"))), (new Ankan(new(pin: "2222"))), (new Ankan(new(sou: "3333")))]);
        var winGroup = new TileList(sou: "55");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Sanankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_暗刻2つ_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "123"), new(pin: "222"), new(man: "456"), new(sou: "55")]);
        var fuuroList = new FuuroList();
        var winGroup = new TileList(man: "456");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Sanankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }
}