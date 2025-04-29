using Mahjong2.Lib.Scores;

namespace Mahjong2.Tests.Scores;

/// <summary>
/// ScoreCalculatorクラスのテスト
/// </summary>
public class ScoreCalculatorTests
{
    [Theory]
    [InlineData(20, 2, 700, 400)]       // 20符2翻
    [InlineData(20, 3, 1300, 700)]      // 20符3翻
    [InlineData(20, 4, 2600, 1300)]     // 20符4翻
    [InlineData(25, 3, 1600, 800)]      // 25符3翻
    [InlineData(25, 4, 3200, 1600)]     // 25符4翻
    [InlineData(30, 1, 500, 300)]       // 30符1翻
    [InlineData(30, 2, 1000, 500)]      // 30符2翻
    [InlineData(30, 3, 2000, 1000)]     // 30符3翻
    [InlineData(30, 4, 3900, 2000)]     // 30符4翻
    [InlineData(40, 1, 700, 400)]       // 40符1翻
    [InlineData(40, 2, 1300, 700)]      // 40符2翻
    [InlineData(40, 3, 2600, 1300)]     // 40符3翻
    [InlineData(50, 1, 800, 400)]       // 50符1翻
    [InlineData(50, 2, 1600, 800)]      // 50符2翻
    [InlineData(50, 3, 3200, 1600)]     // 50符3翻
    [InlineData(60, 1, 1000, 500)]      // 60符1翻
    [InlineData(60, 2, 2000, 1000)]     // 60符2翻
    [InlineData(60, 3, 3900, 2000)]     // 60符3翻
    [InlineData(70, 1, 1200, 600)]      // 70符1翻
    [InlineData(70, 2, 2300, 1200)]     // 70符2翻
    [InlineData(80, 1, 1300, 700)]      // 80符1翻
    [InlineData(80, 2, 2600, 1300)]     // 80符2翻
    [InlineData(90, 1, 1500, 800)]      // 90符1翻
    [InlineData(90, 2, 2900, 1500)]     // 90符2翻
    [InlineData(100, 1, 1600, 800)]     // 100符1翻
    [InlineData(100, 2, 3200, 1600)]    // 100符2翻
    [InlineData(110, 2, 3600, 1800)]    // 110符2翻
    public void Calc_子のツモ_満貫未満_符と翻に応じた点数を返す(int fu, int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules();

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(30, 4, 4000, 2000)]     // 30符4翻
    [InlineData(60, 3, 4000, 2000)]     // 60符3翻
    public void Calc_子のツモ_切り上げ満貫_符と翻に応じた点数を返す(int fu, int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KiriageEnabled = true };

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(5, 4000, 2000)]     // 満貫 5翻
    [InlineData(6, 6000, 3000)]     // 跳満 6翻
    [InlineData(7, 6000, 3000)]     // 跳満 7翻
    [InlineData(8, 8000, 4000)]     // 倍満 8翻
    [InlineData(9, 8000, 4000)]     // 倍満 9翻
    [InlineData(10, 8000, 4000)]    // 倍満 10翻
    [InlineData(11, 12000, 6000)]   // 三倍満 11翻
    [InlineData(12, 12000, 6000)]   // 三倍満 12翻
    public void Calc_子のツモ_満貫以上役満未満_翻に応じた点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 16000, 8000)]   // 役満 13翻
    [InlineData(26, 16000, 8000)]   // 役満 26翻
    [InlineData(39, 16000, 8000)]   // 役満 39翻
    [InlineData(52, 16000, 8000)]   // 役満 52翻
    [InlineData(65, 16000, 8000)]   // 役満 65翻
    [InlineData(78, 16000, 8000)]   // 役満 78翻
    public void Calc_子のツモ_数え役満_Limited_13翻以上はすべて役満の点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Limited };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 12000, 6000)]   // 三倍満 13翻
    [InlineData(26, 12000, 6000)]   // 三倍満 26翻
    [InlineData(39, 12000, 6000)]   // 三倍満 39翻
    [InlineData(52, 12000, 6000)]   // 三倍満 52翻
    [InlineData(65, 12000, 6000)]   // 三倍満 65翻
    [InlineData(78, 12000, 6000)]   // 三倍満 78翻
    public void Calc_子のツモ_数え役満_Sanbaiman_13翻以上はすべて三倍満の点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Sanbaiman };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 16000, 8000)]   // 役満 13翻
    [InlineData(26, 32000, 16000)]  // ダブル役満 26翻
    [InlineData(39, 48000, 24000)]  // トリプル役満 39翻
    [InlineData(52, 64000, 32000)]  // 四倍役満 52翻
    [InlineData(65, 80000, 40000)]  // 五倍役満 65翻
    [InlineData(78, 96000, 48000)]  // 六倍役満 78翻
    public void Calc_子のツモ_数え役満_NoLimit_13翻ごとに役満がかさなった点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Nolimit };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 16000, 8000)]   // 役満 13翻
    [InlineData(26, 32000, 16000)]  // ダブル役満 26翻
    [InlineData(39, 48000, 24000)]  // トリプル役満 39翻
    [InlineData(52, 64000, 32000)]  // 四倍役満 52翻
    [InlineData(65, 80000, 40000)]  // 五倍役満 65翻
    [InlineData(78, 96000, 48000)]  // 六倍役満 78翻
    public void Calc_子のツモ_役満_翻に応じた点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: true);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(25, 2, 1600)]      // 25符3翻
    [InlineData(25, 3, 3200)]      // 25符3翻
    [InlineData(25, 4, 6400)]     // 25符4翻
    [InlineData(30, 1, 1000)]       // 30符1翻
    [InlineData(30, 2, 2000)]      // 30符2翻
    [InlineData(30, 3, 3900)]     // 30符3翻
    [InlineData(30, 4, 7700)]     // 30符4翻
    [InlineData(40, 1, 1300)]       // 40符1翻
    [InlineData(40, 2, 2600)]      // 40符2翻
    [InlineData(40, 3, 5200)]     // 40符3翻
    [InlineData(50, 1, 1600)]       // 50符1翻
    [InlineData(50, 2, 3200)]      // 50符2翻
    [InlineData(50, 3, 6400)]     // 50符3翻
    [InlineData(60, 1, 2000)]      // 60符1翻
    [InlineData(60, 2, 3900)]     // 60符2翻
    [InlineData(60, 3, 7700)]     // 60符3翻
    [InlineData(70, 1, 2300)]      // 70符1翻
    [InlineData(70, 2, 4500)]     // 70符2翻
    [InlineData(80, 1, 2600)]      // 80符1翻
    [InlineData(80, 2, 5200)]     // 80符2翻
    [InlineData(90, 1, 2900)]      // 90符1翻
    [InlineData(90, 2, 5800)]     // 90符2翻
    [InlineData(100, 1, 3200)]     // 100符1翻
    [InlineData(100, 2, 6400)]    // 100符2翻
    [InlineData(110, 1, 3600)]    // 110符2翻
    [InlineData(110, 2, 7100)]    // 110符2翻
    public void Calc_子のロン_満貫未満_符と翻に応じた点数を返す(int fu, int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules();

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(30, 4, 8000)]     // 30符4翻
    [InlineData(60, 3, 8000)]     // 60符3翻
    public void Calc_子のロン_切り上げ満貫_符と翻に応じた点数を返す(int fu, int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KiriageEnabled = true };

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(5, 8000)]     // 満貫 5翻
    [InlineData(6, 12000)]     // 跳満 6翻
    [InlineData(7, 12000)]     // 跳満 7翻
    [InlineData(8, 16000)]     // 倍満 8翻
    [InlineData(9, 16000)]     // 倍満 9翻
    [InlineData(10, 16000)]    // 倍満 10翻
    [InlineData(11, 24000)]   // 三倍満 11翻
    [InlineData(12, 24000)]   // 三倍満 12翻
    public void Calc_子のロン_満貫以上役満未満_翻に応じた点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 32000)]   // 役満 13翻
    [InlineData(26, 32000)]   // 役満 26翻
    [InlineData(39, 32000)]   // 役満 39翻
    [InlineData(52, 32000)]   // 役満 52翻
    [InlineData(65, 32000)]   // 役満 65翻
    [InlineData(78, 32000)]   // 役満 78翻
    public void Calc_子のロン_数え役満_Limited_13翻以上はすべて役満の点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Limited };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 24000)]   // 三倍満 13翻
    [InlineData(26, 24000)]   // 三倍満 26翻
    [InlineData(39, 24000)]   // 三倍満 39翻
    [InlineData(52, 24000)]   // 三倍満 52翻
    [InlineData(65, 24000)]   // 三倍満 65翻
    [InlineData(78, 24000)]   // 三倍満 78翻
    public void Calc_子のロン_数え役満_Sanbaiman_13翻以上はすべて三倍満の点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Sanbaiman };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 32000)]   // 役満 13翻
    [InlineData(26, 64000)]  // ダブル役満 26翻
    [InlineData(39, 96000)]  // トリプル役満 39翻
    [InlineData(52, 128000)]  // 四倍役満 52翻
    [InlineData(65, 160000)]  // 五倍役満 65翻
    [InlineData(78, 192000)]  // 六倍役満 78翻
    public void Calc_子のロン_数え役満_NoLimit_13翻ごとに役満がかさなった点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Nolimit };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 32000)]   // 役満 13翻
    [InlineData(26, 64000)]  // ダブル役満 26翻
    [InlineData(39, 96000)]  // トリプル役満 39翻
    [InlineData(52, 128000)]  // 四倍役満 52翻
    [InlineData(65, 160000)]  // 五倍役満 65翻
    [InlineData(78, 192000)]  // 六倍役満 78翻
    public void Calc_子のロン_役満_翻に応じた点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.South,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: true);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(20, 2, 700, 700)]       // 20符2翻
    [InlineData(20, 3, 1300, 1300)]     // 20符3翻
    [InlineData(20, 4, 2600, 2600)]     // 20符4翻
    [InlineData(25, 3, 1600, 1600)]     // 25符3翻
    [InlineData(25, 4, 3200, 3200)]     // 25符4翻
    [InlineData(30, 1, 500, 500)]       // 30符1翻
    [InlineData(30, 2, 1000, 1000)]     // 30符2翻
    [InlineData(30, 3, 2000, 2000)]     // 30符3翻
    [InlineData(30, 4, 3900, 3900)]     // 30符4翻
    [InlineData(40, 1, 700, 700)]       // 40符1翻
    [InlineData(40, 2, 1300, 1300)]     // 40符2翻
    [InlineData(40, 3, 2600, 2600)]     // 40符3翻
    [InlineData(50, 1, 800, 800)]       // 50符1翻
    [InlineData(50, 2, 1600, 1600)]     // 50符2翻
    [InlineData(50, 3, 3200, 3200)]     // 50符3翻
    [InlineData(60, 1, 1000, 1000)]     // 60符1翻
    [InlineData(60, 2, 2000, 2000)]     // 60符2翻
    [InlineData(60, 3, 3900, 3900)]     // 60符3翻
    [InlineData(70, 1, 1200, 1200)]     // 70符1翻
    [InlineData(70, 2, 2300, 2300)]     // 70符2翻
    [InlineData(80, 1, 1300, 1300)]     // 80符1翻
    [InlineData(80, 2, 2600, 2600)]     // 80符2翻
    [InlineData(90, 1, 1500, 1500)]     // 90符1翻
    [InlineData(90, 2, 2900, 2900)]     // 90符2翻
    [InlineData(100, 1, 1600, 1600)]    // 100符1翻
    [InlineData(100, 2, 3200, 3200)]    // 100符2翻
    [InlineData(110, 2, 3600, 3600)]    // 110符2翻
    public void Calc_親のツモ_満貫未満_符と翻に応じた点数を返す(int fu, int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules();

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(30, 4, 4000, 4000)]     // 30符4翻
    [InlineData(60, 3, 4000, 4000)]     // 60符3翻
    public void Calc_親のツモ_切り上げ満貫_符と翻に応じた点数を返す(int fu, int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KiriageEnabled = true };

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(5, 4000, 4000)]     // 満貫 5翻
    [InlineData(6, 6000, 6000)]     // 跳満 6翻
    [InlineData(7, 6000, 6000)]     // 跳満 7翻
    [InlineData(8, 8000, 8000)]     // 倍満 8翻
    [InlineData(9, 8000, 8000)]     // 倍満 9翻
    [InlineData(10, 8000, 8000)]    // 倍満 10翻
    [InlineData(11, 12000, 12000)]  // 三倍満 11翻
    [InlineData(12, 12000, 12000)]  // 三倍満 12翻
    public void Calc_親のツモ_満貫以上役満未満_翻に応じた点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 16000, 16000)]  // 役満 13翻
    [InlineData(26, 16000, 16000)]  // 役満 26翻
    [InlineData(39, 16000, 16000)]  // 役満 39翻
    [InlineData(52, 16000, 16000)]  // 役満 52翻
    [InlineData(65, 16000, 16000)]  // 役満 65翻
    [InlineData(78, 16000, 16000)]  // 役満 78翻
    public void Calc_親のツモ_数え役満_Limited_13翻以上はすべて役満の点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Limited };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 12000, 12000)]  // 三倍満 13翻
    [InlineData(26, 12000, 12000)]  // 三倍満 26翻
    [InlineData(39, 12000, 12000)]  // 三倍満 39翻
    [InlineData(52, 12000, 12000)]  // 三倍満 52翻
    [InlineData(65, 12000, 12000)]  // 三倍満 65翻
    [InlineData(78, 12000, 12000)]  // 三倍満 78翻
    public void Calc_親のツモ_数え役満_Sanbaiman_13翻以上はすべて三倍満の点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Sanbaiman };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 16000, 16000)]  // 役満 13翻
    [InlineData(26, 32000, 32000)]  // ダブル役満 26翻
    [InlineData(39, 48000, 48000)]  // トリプル役満 39翻
    [InlineData(52, 64000, 64000)]  // 四倍役満 52翻
    [InlineData(65, 80000, 80000)]  // 五倍役満 65翻
    [InlineData(78, 96000, 96000)]  // 六倍役満 78翻
    public void Calc_親のツモ_数え役満_NoLimit_13翻ごとに役満がかさなった点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Nolimit };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(13, 16000, 16000)]  // 役満 13翻
    [InlineData(26, 32000, 32000)]  // ダブル役満 26翻
    [InlineData(39, 48000, 48000)]  // トリプル役満 39翻
    [InlineData(52, 64000, 64000)]  // 四倍役満 52翻
    [InlineData(65, 80000, 80000)]  // 五倍役満 65翻
    [InlineData(78, 96000, 96000)]  // 六倍役満 78翻
    public void Calc_親のツモ_役満_翻に応じた点数を返す(int han, int expectedMain, int expectedSub)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = true,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: true);

        // Assert
        Assert.Equal(new Score(expectedMain, expectedSub), actual);
    }

    [Theory]
    [InlineData(25, 2, 2400)]   // 25符3翻
    [InlineData(25, 3, 4800)]   // 25符3翻
    [InlineData(25, 4, 9600)]   // 25符4翻
    [InlineData(30, 1, 1500)]   // 30符1翻
    [InlineData(30, 2, 2900)]   // 30符2翻
    [InlineData(30, 3, 5800)]   // 30符3翻
    [InlineData(30, 4, 11600)]  // 30符4翻
    [InlineData(40, 1, 2000)]   // 40符1翻
    [InlineData(40, 2, 3900)]   // 40符2翻
    [InlineData(40, 3, 7700)]   // 40符3翻
    [InlineData(50, 1, 2400)]   // 50符1翻
    [InlineData(50, 2, 4800)]   // 50符2翻
    [InlineData(50, 3, 9600)]   // 50符3翻
    [InlineData(60, 1, 2900)]   // 60符1翻
    [InlineData(60, 2, 5800)]   // 60符2翻
    [InlineData(60, 3, 11600)]  // 60符3翻
    [InlineData(70, 1, 3400)]   // 70符1翻
    [InlineData(70, 2, 6800)]   // 70符2翻
    [InlineData(80, 1, 3900)]   // 80符1翻
    [InlineData(80, 2, 7700)]   // 80符2翻
    [InlineData(90, 1, 4400)]   // 90符1翻
    [InlineData(90, 2, 8700)]   // 90符2翻
    [InlineData(100, 1, 4800)]  // 100符1翻
    [InlineData(100, 2, 9600)]  // 100符2翻
    [InlineData(110, 1, 5300)]  // 110符1翻
    [InlineData(110, 2, 10600)] // 110符2翻
    public void Calc_親のロン_満貫未満_符と翻に応じた点数を返す(int fu, int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules();

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(30, 4, 12000)]    // 30符4翻
    [InlineData(60, 3, 12000)]    // 60符3翻
    public void Calc_親のロン_切り上げ満貫_符と翻に応じた点数を返す(int fu, int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KiriageEnabled = true };

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(5, 12000)]  // 満貫 5翻
    [InlineData(6, 18000)]  // 跳満 6翻
    [InlineData(7, 18000)]  // 跳満 7翻
    [InlineData(8, 24000)]  // 倍満 8翻
    [InlineData(9, 24000)]  // 倍満 9翻
    [InlineData(10, 24000)] // 倍満 10翻
    [InlineData(11, 36000)] // 三倍満 11翻
    [InlineData(12, 36000)] // 三倍満 12翻
    public void Calc_親のロン_満貫以上役満未満_翻に応じた点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 48000)] // 役満 13翻
    [InlineData(26, 48000)] // 役満 26翻
    [InlineData(39, 48000)] // 役満 39翻
    [InlineData(52, 48000)] // 役満 52翻
    [InlineData(65, 48000)] // 役満 65翻
    [InlineData(78, 48000)] // 役満 78翻
    public void Calc_親のロン_数え役満_Limited_13翻以上はすべて役満の点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Limited };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 36000)]   // 三倍満 13翻
    [InlineData(26, 36000)]   // 三倍満 26翻
    [InlineData(39, 36000)]   // 三倍満 39翻
    [InlineData(52, 36000)]   // 三倍満 52翻
    [InlineData(65, 36000)]   // 三倍満 65翻
    [InlineData(78, 36000)]   // 三倍満 78翻
    public void Calc_親のロン_数え役満_Sanbaiman_13翻以上はすべて三倍満の点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Sanbaiman };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 48000)]   // 役満 13翻
    [InlineData(26, 96000)]   // ダブル役満 26翻
    [InlineData(39, 144000)]  // トリプル役満 39翻
    [InlineData(52, 192000)]  // 四倍役満 52翻
    [InlineData(65, 240000)]  // 五倍役満 65翻
    [InlineData(78, 288000)]  // 六倍役満 78翻
    public void Calc_親のロン_数え役満_NoLimit_13翻ごとに役満がかさなった点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules { KazoeLimit = KazoeLimit.Nolimit };
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: false);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Theory]
    [InlineData(13, 48000)]   // 役満 13翻
    [InlineData(26, 96000)]   // ダブル役満 26翻
    [InlineData(39, 144000)]  // トリプル役満 39翻
    [InlineData(52, 192000)]  // 四倍役満 52翻
    [InlineData(65, 240000)]  // 五倍役満 65翻
    [InlineData(78, 288000)]  // 六倍役満 78翻
    public void Calc_親のロン_役満_翻に応じた点数を返す(int han, int expectedMain)
    {
        // Arrange
        var winSituation = new WinSituation
        {
            IsTsumo = false,
            PlayerWind = Wind.East,
        };
        var gameRules = new GameRules();
        var fu = 30; // 満貫以上は符に関係なく点数が固定されるので適当な値を使用

        // Act
        var actual = ScoreCalculator.Calc(fu, han, winSituation, gameRules, isYakuman: true);

        // Assert
        Assert.Equal(new Score(expectedMain), actual);
    }

    [Fact]
    public void Calc_符が0_例外をスロー()
    {
        // Arrange
        var winSituation = new WinSituation();
        var gameRules = new GameRules();

        // Act
        var exception = Record.Exception(() => ScoreCalculator.Calc(0, 1, winSituation, gameRules));

        // Assert
        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Calc_翻が0_例外をスロー()
    {
        // Arrange
        var winSituation = new WinSituation();
        var gameRules = new GameRules();

        // Act
        Assert.Throws<ArgumentException>(() => ScoreCalculator.Calc(30, 0, winSituation, gameRules));
        var exception = Record.Exception(() => ScoreCalculator.Calc(30, 0, winSituation, gameRules));

        // Assert
        Assert.IsType<ArgumentException>(exception);
    }
}