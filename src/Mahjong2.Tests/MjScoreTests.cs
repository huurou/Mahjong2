using Mahjong2.Lib;

namespace Mahjong2.Tests;

public class MjScoreTests
{
    [Fact]
    public void MjScore_スコア情報を作成_プロパティが正しく設定される()
    {
        // Arrange
        var fu = 30;
        var han = 4;
        var yakuResults = new List<MjYakuResult>
        {
            new(MjYaku.Pinfu, 1),
            new(MjYaku.Tanyao, 1),
            new(MjYaku.Dora, 2)
        };
        var scoreMain = 8000;
        var scoreSub = 4000;

        // Act
        var score = new MjScore(fu, han, yakuResults, scoreMain, scoreSub);

        // Assert
        Assert.Equal(fu, score.Fu);
        Assert.Equal(han, score.Han);
        Assert.Equal(yakuResults, score.YakuResults);
        Assert.Equal(scoreMain, score.ScoreMain);
        Assert.Equal(scoreSub, score.ScoreSub);
    }

    [Fact]
    public void MjScore_プロパティ比較_同じ値なら個別に等しい()
    {
        // Arrange
        var yakuResults1 = new List<MjYakuResult> { new(MjYaku.Pinfu, 1) };
        var yakuResults2 = new List<MjYakuResult> { new(MjYaku.Pinfu, 1) };

        var score1 = new MjScore(30, 1, yakuResults1, 1000, 500);
        var score2 = new MjScore(30, 1, yakuResults2, 1000, 500);

        // Act & Assert
        Assert.Equal(score1.Fu, score2.Fu);
        Assert.Equal(score1.Han, score2.Han);
        Assert.Equal(score1.ScoreMain, score2.ScoreMain);
        Assert.Equal(score1.ScoreSub, score2.ScoreSub);
        Assert.Equal(score1.YakuResults.Count, score2.YakuResults.Count);
        Assert.Equal(score1.YakuResults[0].Yaku, score2.YakuResults[0].Yaku);
        Assert.Equal(score1.YakuResults[0].Han, score2.YakuResults[0].Han);
    }

    [Fact]
    public void MjScore_プロパティ比較_異なる内容なら個別に等しくない()
    {
        // Arrange
        var yakuResults1 = new List<MjYakuResult> { new(MjYaku.Pinfu, 1) };
        var yakuResults2 = new List<MjYakuResult> { new(MjYaku.Tanyao, 1) };

        var score1 = new MjScore(30, 1, yakuResults1, 1000, 500);
        var score2 = new MjScore(30, 1, yakuResults2, 1000, 500);

        // Act & Assert
        Assert.NotEqual(score1.YakuResults[0].Yaku, score2.YakuResults[0].Yaku);
    }
}