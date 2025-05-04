using Mahjong2.Lib.Internals.Fuuros;
using Mahjong2.Lib.Internals.HandCalculating;
using Mahjong2.Lib.Internals.HandCalculating.Games;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.HandCalculating.HandCalculators;

public class HandCalculatorTestsForError
{
    [Fact]
    public void Calc_アガリ形ではない手牌_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "12345");
        var winTile = Tile.Sou5;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Equal("手牌がアガリ形ではありません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_手牌にアガリ牌がない_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou5;

        // Act
        var actual = HandCalculator.Calc(tileList, winTile);

        // Assert
        Assert.Equal("手牌にアガリ牌がありません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_立直かつ非面前_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var fuuroList = new FuuroList([new Chi(new(man: "123"))]);
        var winSituation = new WinSituation { IsRiichi = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList, winSituation: winSituation);

        // Assert
        Assert.Equal("立直と非面前は両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_ダブル立直かつ非面前_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var fuuroList = new FuuroList([new Chi(new(man: "123"))]);
        var winSituation = new WinSituation { IsDoubleRiichi = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList, winSituation: winSituation);

        // Assert
        Assert.Equal("ダブル立直と非面前は両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_一発かつ非面前_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var fuuroList = new FuuroList([new Chi(new(man: "123"))]);
        var winSituation = new WinSituation { IsIppatsu = true, IsRiichi = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList, winSituation: winSituation);

        // Assert
        Assert.Equal("一発と非面前は両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_一発かつ立直なし_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsIppatsu = true, IsRiichi = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("一発は立直orダブル立直時にしか成立しません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_槍槓かつツモアガリ_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsChankan = true, IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("槍槓とツモアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_嶺上開花かつロンアガリ_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRinshan = true, IsTsumo = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("嶺上開花とロンアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_海底撈月かつロンアガリ_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsHaitei = true, IsTsumo = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("海底撈月とロンアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_河底撈魚かつツモアガリ_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsHoutei = true, IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("河底撈魚とツモアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_海底撈月かつ嶺上開花_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsHaitei = true, IsRinshan = true, IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("海底撈月と嶺上開花は両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_河底撈魚かつ槍槓_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsHoutei = true, IsChankan = true, IsTsumo = false };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("河底撈魚と槍槓は両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_天和かつ子_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winSituation = new WinSituation { IsTenhou = true, PlayerWind = Wind.South, IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, null, winSituation: winSituation);

        // Assert
        Assert.Equal("天和はプレイヤーが親の時のみ有効です。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_天和かつロン和了_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = null as Tile;
        var winSituation = new WinSituation { IsTenhou = true, IsTsumo = false, PlayerWind = Wind.East };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("天和とロンアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_副露を伴う天和_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "66", sou: "123444");
        var winTile = null as Tile;
        var fuuroList = new FuuroList([new Chi(new(man: "789"))]);
        var winSituation = new WinSituation { IsTenhou = true, IsTsumo = true, PlayerWind = Wind.East };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList, winSituation: winSituation);

        // Assert
        Assert.Equal("副露を伴う天和は無効です。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_天和時に和了牌が指定されている_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsTenhou = true, IsTsumo = true, PlayerWind = Wind.East };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("天和の時は和了牌にnullを指定してください。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_流し満貫時に和了牌が指定されている_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Man1;
        var winSituation = new WinSituation { IsNagashimangan = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("流し満貫の時は和了牌にnullを指定してください。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_地和かつ親_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsChiihou = true, PlayerWind = Wind.East, IsTsumo = true };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("地和はプレイヤーが子の時のみ有効です。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_地和かつロン和了_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsChiihou = true, IsTsumo = false, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("地和とロンアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_地和かつ副露_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var fuuroList = new FuuroList([new Chi(new(man: "789"))]);
        var winSituation = new WinSituation { IsChiihou = true, IsTsumo = true, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList, winSituation: winSituation);

        // Assert
        Assert.Equal("副露を伴う地和は無効です。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_人和かつ親_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRenhou = true, PlayerWind = Wind.East };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("人和はプレイヤーが子の時のみ有効です。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_人和かつツモ和了_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123456", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var winSituation = new WinSituation { IsRenhou = true, IsTsumo = true, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, winSituation: winSituation);

        // Assert
        Assert.Equal("人和とロンアガリは両立できません。", actual.ErrorMessage);
    }

    [Fact]
    public void Calc_人和かつ副露_エラーメッセージが返される()
    {
        // Arrange
        var tileList = new TileList(man: "123", pin: "66", sou: "123444");
        var winTile = Tile.Sou4;
        var fuuroList = new FuuroList([new Chi(new(man: "789"))]);
        var winSituation = new WinSituation { IsRenhou = true, IsTsumo = false, PlayerWind = Wind.South };

        // Act
        var actual = HandCalculator.Calc(tileList, winTile, fuuroList, winSituation: winSituation);

        // Assert
        Assert.Equal("副露を伴う人和は無効です。", actual.ErrorMessage);
    }
}
