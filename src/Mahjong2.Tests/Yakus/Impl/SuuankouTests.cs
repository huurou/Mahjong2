using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.Scores;
using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Yakus.Impl;

namespace Mahjong2.Tests.Yakus.Impl;

public class SuuankouTests
{
    [Fact]
    public void Name_四暗刻を返す()
    {
        // Arrange
        var suuankou = new Suuankou();

        // Act
        var actual = suuankou.Name;

        // Assert
        Assert.Equal("四暗刻", actual);
    }

    [Fact]
    public void HanOpen_0を返す()
    {
        // Arrange
        var suuankou = new Suuankou();

        // Act
        var actual = suuankou.HanOpen;

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void HanClosed_13を返す()
    {
        // Arrange
        var suuankou = new Suuankou();

        // Act
        var actual = suuankou.HanClosed;

        // Assert
        Assert.Equal(13, actual);
    }

    [Fact]
    public void IsYakuman_Trueを返す()
    {
        // Arrange
        var suuankou = new Suuankou();

        // Act
        var actual = suuankou.IsYakuman;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ツモアガリで4つの暗刻がある_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(pin: "444"), new(sou: "55")]);
        var winGroup = new TileList(pin: "444");
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ロンアガリで4つの暗刻がありアガリ牌が暗刻に含まれない_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(pin: "444"), new(sou: "55")]);
        var winGroup = new TileList(sou: "55");
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = false };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_ロンアガリで4つの暗刻がありアガリ牌が暗刻に含まれる_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(pin: "444"), new(sou: "55")]);
        var winGroup = new TileList(pin: "444"); // アガリ牌を含む暗刻
        var fuuroList = new FuuroList();
        var winSituation = new WinSituation { IsTsumo = false };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_3つの暗刻と1つの暗槓がある_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(sou: "55")]);
        var ankan = new Ankan(new(pin: "4444"));
        var fuuroList = new FuuroList([ankan]);
        var winGroup = new TileList(sou: "55");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_2つの暗刻と2つの暗槓がある_成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "55")]);
        var fuuroList = new FuuroList([(new Ankan(new(sou: "3333"))), (new Ankan(new(pin: "4444")))]);
        var winGroup = new TileList(sou: "55");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void Valid_3つの暗刻しかない_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "333"), new(man: "456"), new(sou: "55")]);
        var fuuroList = new FuuroList();
        var winGroup = new TileList(sou: "55");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Valid_暗刻4個ない_不成立()
    {
        // Arrange
        var hand = new Hand([new(man: "111"), new(pin: "222"), new(sou: "55")]);
        var fuuroList = new FuuroList([(new Pon(new(sou: "333")))]);
        var winGroup = new TileList(sou: "55");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = Suuankou.Valid(hand, winGroup, fuuroList, winSituation);

        // Assert
        Assert.False(actual);
    }
}