using Mahjong2.Lib;

namespace Mahjong2.Tests;

public class MjScoreCalculatorTests
{
    [Fact]
    public void CalculateScore_基本テスト_結果が生成される()
    {
        // Arrange
        var tiles = new List<MjTileKind>
        {
            // 理牌（頭：中、順子：1-2-3m, 1-2-3p, 1-2-3s, 刻子：東）
            MjTileKind.Chun, MjTileKind.Chun,
            MjTileKind.Man1, MjTileKind.Man2, MjTileKind.Man3,
            MjTileKind.Pin1, MjTileKind.Pin2, MjTileKind.Pin3,
            MjTileKind.Sou1, MjTileKind.Sou2, MjTileKind.Sou3,
            MjTileKind.Ton, MjTileKind.Ton
        };
        var winTile = MjTileKind.Ton;
        var fuuros = new List<MjFuuro>();
        var doraIndicators = new List<MjTileKind>();
        var uradoraIndicators = new List<MjTileKind>();

        // Act
        var result = MjScoreCalculator.CalculateScore(tiles, winTile, fuuros, doraIndicators, uradoraIndicators);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void CalculateScore_MjScoreインスタンスが返る()
    {
        // Arrange
        var tiles = new List<MjTileKind>
        {
            // 理牌（七対子）
            MjTileKind.Man1, MjTileKind.Man1,
            MjTileKind.Man2, MjTileKind.Man2,
            MjTileKind.Man3, MjTileKind.Man3,
            MjTileKind.Man4, MjTileKind.Man4,
            MjTileKind.Man5, MjTileKind.Man5,
            MjTileKind.Man6, MjTileKind.Man6,
            MjTileKind.Man7
        };
        var winTile = MjTileKind.Man7;
        var fuuros = new List<MjFuuro>();
        var doraIndicators = new List<MjTileKind>();
        var uradoraIndicators = new List<MjTileKind>();

        // Act
        var result = MjScoreCalculator.CalculateScore(tiles, winTile, fuuros, doraIndicators, uradoraIndicators);

        // Assert
        Assert.NotNull(result);
    }
}