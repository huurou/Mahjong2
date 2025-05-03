using Mahjong2.Lib.Fus;
using Mahjong2.Lib.Fuuros;
using Mahjong2.Lib.HandCalculating.Games;
using Mahjong2.Lib.Tiles;

namespace Mahjong2.Tests.Fus;

/// <summary>
/// FuCalculatorクラスのテスト
/// </summary>
public class FuCalculatorTests
{
    [Fact]
    public void Calc_七対子_七対子の符を返す()
    {
        // Arrange
        var hand = new Hand([new(pin: "66"), new(sou: "11"), new(sou: "22"), new(sou: "44"), new(man: "11"), new(man: "55"), new(man: "99")]);
        var winTile = Tile.Pin6;
        var winGroup = new TileList(pin: "66");

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup);

        // Assert
        var expected = new FuList([Fu.ChiitoitsuFu]);
        Assert.Equal(expected, actual);
        Assert.Equal(25, actual.Total);
    }

    [Fact]
    public void Calc_食い平和_副底が30符となる()
    {
        // Arrange
        var hand = new Hand([new(man: "234"), new(man: "567"), new(pin: "22"), new(sou: "678")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var fuuroList = new FuuroList([new Chi(new(sou: "234"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.FuteiOpenPinfu]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_ツモ和了_基本の符とツモ符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "11"), new(sou: "222"), new(sou: "678")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.TsumoFu, Fu.AnkoChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_ツモ平和_ピンヅモ有効時はツモ符が加算されない()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "123"), new(sou: "22"), new(sou: "678")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei]);
        Assert.Equal(expected, actual);
        Assert.Equal(20, actual.Total);
    }

    [Fact]
    public void Calc_ツモ平和_ピンヅモ無効時はツモ符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "123"), new(sou: "22"), new(sou: "678")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { IsTsumo = true };
        var gameRules = new GameRules { PinzumoEnabled = false };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation, gameRules: gameRules);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.TsumoFu]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_ペンチャン待ち1_ペンチャン待ち符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "55"), new(sou: "123"), new(sou: "456")]);
        var winTile = Tile.Sou3;
        var winGroup = new TileList(sou: "123");

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.WaitPenchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_ペンチャン待ち2_ペンチャン待ち符が加算される()
    {
        // Arrang
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "55"), new(sou: "345"), new(sou: "789")]);
        var winTile = Tile.Sou7;
        var winGroup = new TileList(sou: "789");

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.WaitPenchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_カンチャン待ち_カンチャン待ち符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "55"), new(sou: "123"), new(sou: "567")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "567");
        var winSituation = new WinSituation();

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.WaitKanchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_単騎待ち_単騎待ち符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "11"), new(sou: "123"), new(sou: "567")]);
        var winTile = Tile.Pin1;
        var winGroup = new TileList(pin: "11");
        var winSituation = new WinSituation();

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.WaitTanki]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_自風牌雀頭_自風牌雀頭符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(sou: "123"), new(sou: "678"), new(honor: "tt")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { PlayerWind = Wind.East, RoundWind = Wind.South };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.JantouPlayerWind]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_場風牌雀頭_場風牌雀頭符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(sou: "123"), new(sou: "678"), new(honor: "nn")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { PlayerWind = Wind.East, RoundWind = Wind.South };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.JantouRoundWind]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_客風牌雀頭_雀頭符なし()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(sou: "123"), new(sou: "678"), new(honor: "pp")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { PlayerWind = Wind.East, RoundWind = Wind.South };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_ダブ東雀頭_自風牌雀頭と場風牌雀頭が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(sou: "123"), new(sou: "678"), new(honor: "tt")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { PlayerWind = Wind.East, RoundWind = Wind.East };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.JantouPlayerWind]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_三元牌雀頭_三元牌雀頭が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(sou: "123"), new(sou: "678"), new(honor: "hh")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");
        var winSituation = new WinSituation { PlayerWind = Wind.East, RoundWind = Wind.South };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.JantouDragon]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_中張牌明刻_中張牌明刻の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "456"), new(sou: "66")]);
        var winTile = Tile.Pin6;
        var winGroup = new TileList(pin: "456");
        var fuuroList = new FuuroList([new Pon(new(sou: "222"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MinkoChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_么九牌明刻_么九牌明刻の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "444"), new(sou: "123"), new(sou: "66")]);
        var winTile = Tile.Pin4;
        var winGroup = new TileList(pin: "444");
        var fuuroList = new FuuroList([new Pon(new(sou: "999"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MinkoChuchan, Fu.MinkoYaochu]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_シャンポン待ちロン和了_明刻の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "444"), new(sou: "123"), new(sou: "66")]);
        var winTile = Tile.Pin4;
        var winGroup = new TileList(pin: "444");

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.MinkoChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_中張牌暗刻_中張牌暗刻の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "11"), new(sou: "222"), new(sou: "678")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.AnkoChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_么九牌暗刻_么九牌暗刻の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "11"), new(sou: "678"), new(sou: "999")]);
        var winTile = Tile.Sou6;
        var winGroup = new TileList(sou: "678");

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.AnkoYaochu]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_シャンポン待ちツモ和了_暗刻の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "444"), new(sou: "123"), new(sou: "66")]);
        var winTile = Tile.Pin4;
        var winGroup = new TileList(pin: "444");
        var winSituation = new WinSituation { IsTsumo = true };

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, winSituation: winSituation);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.TsumoFu, Fu.AnkoChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_中張牌明槓_中張牌明槓の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "456"), new(sou: "66")]);
        var winTile = Tile.Pin6;
        var winGroup = new TileList(pin: "456");
        var fuuroList = new FuuroList([new Daiminkan(new(pin: "2222"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MinkanChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(30, actual.Total);
    }

    [Fact]
    public void Calc_么九牌明槓_么九牌明槓の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "456"), new(sou: "66")]);
        var winTile = Tile.Pin6;
        var winGroup = new TileList(pin: "456");
        var fuuroList = new FuuroList([new Daiminkan(new(honor: "cccc"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MinkanYaochu]);
        Assert.Equal(expected, actual);
        Assert.Equal(40, actual.Total);
    }

    [Fact]
    public void Calc_中張牌暗槓_中張牌暗槓の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "456"), new(sou: "66")]);
        var winTile = Tile.Pin6;
        var winGroup = new TileList(pin: "456");
        var fuuroList = new FuuroList([new Lib.Fuuros.Ankan(new(pin: "2222"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.AnkanChuchan]);
        Assert.Equal(expected, actual);
        Assert.Equal(50, actual.Total);
    }

    [Fact]
    public void Calc_么九牌暗槓_么九牌暗槓の符が加算される()
    {
        // Arrange
        var hand = new Hand([new(man: "123"), new(man: "456"), new(pin: "456"), new(sou: "66")]);
        var winTile = Tile.Pin6;
        var winGroup = new TileList(pin: "456");
        var fuuroList = new FuuroList([new Lib.Fuuros.Ankan(new(honor: "cccc"))]);

        // Act
        var actual = FuCalculator.Calc(hand, winTile, winGroup, fuuroList);

        // Assert
        var expected = new FuList([Fu.Futei, Fu.MenzenFu, Fu.AnkanYaochu]);
        Assert.Equal(expected, actual);
        Assert.Equal(70, actual.Total);
    }
}