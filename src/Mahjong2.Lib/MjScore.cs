namespace Mahjong2.Lib;

public record MjScore(int Fu, int Han, List<MjYakuResult> YakuResults, int ScoreMain, int ScoreSub);
