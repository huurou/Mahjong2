using Mahjong2.Lib.Tiles;
using Mahjong2.Lib.Tiles.NumberTiles;

namespace Mahjong2.Lib.Shantens;

/// <summary>
/// シャンテン数計算のためのコンテキスト
/// </summary>
/// <param name="TileList">計算対象の牌リスト</param>
public record ShantenContext(TileList TileList)
{
    /// <summary>
    /// 現在処理中の牌
    /// </summary>
    public Tile Tile { get; init; } = Tile.Man1;

    /// <summary>
    /// 面子の数
    /// </summary>
    public int MentsuCount { get; init; }

    /// <summary>
    /// 対子の数
    /// </summary>
    public int ToitsuCount { get; init; }

    /// <summary>
    /// 塔子の数
    /// </summary>
    public int TatsuCount { get; init; }

    /// <summary>
    /// 槓子の数
    /// </summary>
    public int KantsuCount { get; init; }

    /// <summary>
    /// 孤立している牌の集合
    /// </summary>
    public IsolationSet IsolationSet { get; init; } = [];

    /// <summary>
    /// 槓子になっている数牌のリスト
    /// </summary>
    public List<Tile> KantsuNumbers { get; init; } = [];

    /// <summary>
    /// 字牌をスキャンし、面子や対子などの情報を更新したコンテキストを返す
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    public ShantenContext ScanHonor()
    {
        var context = this;
        foreach (var honor in Tile.Honors)
        {
            context = context.TileList.CountOf(honor) switch
            {
                1 => context with { IsolationSet = [.. context.IsolationSet, honor] },
                2 => context with { ToitsuCount = context.ToitsuCount + 1 },
                3 => context with { MentsuCount = context.MentsuCount + 1 },
                4 => context with
                {
                    MentsuCount = context.MentsuCount + 1,
                    KantsuCount = context.KantsuCount + 1,
                    IsolationSet = [.. context.IsolationSet, honor],
                },
                _ => context,
            };
        }
        if (context.KantsuCount != 0 && context.TileList.Count % 3 == 2)
        {
            context = context with { KantsuCount = context.KantsuCount - 1 };
        }
        return context;
    }

    /// <summary>
    /// 数牌をスキャンしてシャンテン数を計算する
    /// </summary>
    /// <returns>シャンテン数</returns>
    public int ScanNumber()
    {
        var context = this;
        var allTiles = Tile.All.ToList();
        while (context.TileList.CountOf(context.Tile) == 0)
        {
            // 今のTileの次の種類の牌を取得する
            var nextTile = allTiles[allTiles.IndexOf(context.Tile) + 1];
            context = context with { Tile = nextTile };
            if (context.Tile.IsHonor)
            {
                return context.CalcShanten();
            }
        }
        return context.TileList.CountOf(context.Tile) switch
        {
            1 => context.ScanNumber1(),
            2 => context.ScanNumber2(),
            3 => context.ScanNumber3(),
            4 => context.ScanNumber4(),
            _ => throw new InvalidOperationException(),
        };
    }

    /// <summary>
    /// 対象の牌が1枚の場合の処理を行い、シャンテン数を計算する
    /// </summary>
    /// <returns>シャンテン数</returns>
    private int ScanNumber1()
    {
        if (Tile is not NumberTile tile) { throw new InvalidOperationException($"Tile:{Tile}"); }

        List<int> shantens = [];
        if (tile.TryGetAtDistance(1, out var tile1) && tile.TryGetAtDistance(2, out var tile2) && tile.TryGetAtDistance(3, out var tile3) &&
            TileList.CountOf(tile1) == 1 && TileList.CountOf(tile2) > 0 && TileList.CountOf(tile3) != 4)
        {
            shantens.Add(RemoveShuntsu().ScanNumber());
        }
        else
        {
            shantens.Add(RemoveIsolation().ScanNumber());
            if (tile.TryGetAtDistance(1, out tile1) && tile.TryGetAtDistance(2, out tile2) &&
                TileList.CountOf(tile2) > 0)
            {
                if (TileList.CountOf(tile1) > 0)
                {
                    shantens.Add(RemoveShuntsu().ScanNumber());
                }
                shantens.Add(RemoveKanchan().ScanNumber());
            }
            if (tile.TryGetAtDistance(1, out tile1) &&
                TileList.CountOf(tile1) > 0)
            {
                shantens.Add(RemoveRyanmen().ScanNumber());
            }
        }
        return shantens.Min();
    }

    /// <summary>
    /// 対象の牌が2枚の場合の処理を行い、シャンテン数を計算する
    /// </summary>
    /// <returns>シャンテン数</returns>
    private int ScanNumber2()
    {
        if (Tile is not NumberTile tile) { throw new InvalidOperationException($"Tile:{Tile}"); }

        List<int> shantens = [];
        shantens.Add(RemoveToitsu().ScanNumber());
        if (tile.TryGetAtDistance(1, out var tile1) && tile.TryGetAtDistance(2, out var tile2) &&
            TileList.CountOf(tile1) > 0 && TileList.CountOf(tile2) > 0)
        {
            shantens.Add(RemoveShuntsu().ScanNumber());
        }
        return shantens.Min();
    }

    /// <summary>
    /// 対象の牌が3枚の場合の処理を行い、シャンテン数を計算する
    /// </summary>
    /// <returns>シャンテン数</returns>
    private int ScanNumber3()
    {
        if (Tile is not NumberTile tile) { throw new InvalidOperationException($"Tile:{Tile}"); }

        List<int> shantens = [];
        shantens.Add(RemoveKoutsu().ScanNumber());
        var toitsuRemoved = RemoveToitsu();
        if (tile.TryGetAtDistance(1, out var tile1) && tile.TryGetAtDistance(2, out var tile2) &&
            TileList.CountOf(tile1) > 0 && TileList.CountOf(tile2) > 0)
        {
            shantens.Add(toitsuRemoved.RemoveShuntsu().ScanNumber());
        }
        else
        {
            if (tile.TryGetAtDistance(2, out tile2) &&
                toitsuRemoved.TileList.CountOf(tile2) > 0)
            {
                shantens.Add(toitsuRemoved.RemoveKanchan().ScanNumber());
            }
            if (tile.TryGetAtDistance(1, out tile1) &&
                toitsuRemoved.TileList.CountOf(tile1) > 0)
            {
                shantens.Add(toitsuRemoved.RemoveRyanmen().ScanNumber());
            }
        }
        if (tile.TryGetAtDistance(1, out tile1) && tile.TryGetAtDistance(2, out tile2) &&
            TileList.CountOf(tile1) >= 2 && TileList.CountOf(tile2) >= 2)
        {
            shantens.Add(RemoveShuntsu().RemoveShuntsu().ScanNumber());
        }
        return shantens.Min();
    }

    /// <summary>
    /// 対象の牌が4枚の場合の処理を行い、シャンテン数を計算する
    /// </summary>
    /// <returns>シャンテン数</returns>
    private int ScanNumber4()
    {
        if (Tile is not NumberTile tile) { throw new InvalidOperationException($"Tile:{Tile}"); }

        List<int> shantens = [];
        var koutsuRemoved = RemoveKoutsu();
        if (tile.TryGetAtDistance(2, out var tile2) &&
            koutsuRemoved.TileList.CountOf(tile2) > 0)
        {
            if (tile.TryGetAtDistance(1, out var tile1_) &&
                koutsuRemoved.TileList.CountOf(tile1_) > 0)
            {
                shantens.Add(koutsuRemoved.RemoveShuntsu().ScanNumber());
            }
            shantens.Add(koutsuRemoved.RemoveKanchan().ScanNumber());
        }
        if (tile.TryGetAtDistance(1, out var tile1) &&
            koutsuRemoved.TileList.CountOf(tile1) > 0)
        {
            shantens.Add(koutsuRemoved.RemoveRyanmen().ScanNumber());
        }
        shantens.Add(koutsuRemoved.RemoveIsolation().ScanNumber());
        var toitsuRemoved = RemoveToitsu();
        if (tile.TryGetAtDistance(2, out tile2) &&
            toitsuRemoved.TileList.CountOf(tile2) > 0)
        {
            if (tile.TryGetAtDistance(1, out var tile1_) &&
                toitsuRemoved.TileList.CountOf(tile1_) > 0)
            {
                shantens.Add(toitsuRemoved.RemoveShuntsu().ScanNumber());
            }
            shantens.Add(toitsuRemoved.RemoveKanchan().ScanNumber());
        }
        if (tile.TryGetAtDistance(1, out tile1) &&
            toitsuRemoved.TileList.CountOf(tile1) > 0)
        {
            shantens.Add(toitsuRemoved.RemoveRyanmen().ScanNumber());
        }
        return shantens.Min();
    }

    /// <summary>
    /// 面子や対子などの情報からシャンテン数を計算する
    /// </summary>
    /// <returns>シャンテン数</returns>
    private int CalcShanten()
    {
        var shanten = 8 - MentsuCount * 2 - ToitsuCount - TatsuCount;
        var mentsuKouho = MentsuCount + TatsuCount;
        if (ToitsuCount != 0)
        {
            mentsuKouho += ToitsuCount - 1;
        }
        // 同種の数牌を4枚持っているときに刻子&単騎待ちとみなされないようにする
        else if (IsolationSet.Count > 0 && KantsuNumbers.Count > 0 && IsolationSet.All(KantsuNumbers.Contains))
        {
            shanten++;
        }
        if (mentsuKouho > 4)
        {
            shanten += mentsuKouho - 4;
        }
        if (shanten != ShantenCalculator.AGARI_SHANTEN && shanten < KantsuCount)
        {
            shanten = KantsuCount;
        }
        return shanten;
    }

    /// <summary>
    /// 刻子を除去した新しいコンテキストを返す
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    private ShantenContext RemoveKoutsu()
    {
        return this with
        {
            TileList = TileList.Remove(Tile, 3),
            MentsuCount = MentsuCount + 1,
        };
    }

    /// <summary>
    /// 順子を除去した新しいコンテキストを返す
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    private ShantenContext RemoveShuntsu()
    {
        if (Tile is NumberTile tile && tile.TryGetAtDistance(1, out var tile1) && tile.TryGetAtDistance(2, out var tile2))
        {
            return this with
            {
                TileList = TileList.Remove([Tile, tile1, tile2]),
                MentsuCount = MentsuCount + 1,
            };
        }
        else { throw new InvalidOperationException($"Tile:{Tile}"); }
    }

    /// <summary>
    /// 対子を除去した新しいコンテキストを返す
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    private ShantenContext RemoveToitsu()
    {
        return this with
        {
            TileList = TileList.Remove(Tile, 2),
            ToitsuCount = ToitsuCount + 1,
        };
    }

    /// <summary>
    /// 両面を除去した新しいコンテキストを返す
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    private ShantenContext RemoveRyanmen()
    {
        if (Tile is NumberTile tile && tile.TryGetAtDistance(1, out var tile1))
        {
            return this with
            {
                TileList = TileList.Remove([Tile, tile1]),
                TatsuCount = TatsuCount + 1,
            };
        }
        else { throw new InvalidOperationException($"Tile:{Tile}"); }
    }

    /// <summary>
    /// 嵌張を除去した新しいコンテキストを返す 
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    private ShantenContext RemoveKanchan()
    {
        if (Tile is NumberTile tile && tile.TryGetAtDistance(2, out var tile2))
        {
            return this with
            {
                TileList = TileList.Remove([Tile, tile2]),
                TatsuCount = TatsuCount + 1,
            };
        }
        else { throw new InvalidOperationException($"Tile:{Tile}"); }
    }

    /// <summary>
    /// 孤立牌を除去した新しいコンテキストを返す 孤立牌のリストを更新する
    /// </summary>
    /// <returns>更新されたシャンテンコンテキスト</returns>
    private ShantenContext RemoveIsolation()
    {
        return this with
        {
            TileList = TileList.Remove(Tile),
            IsolationSet = [.. IsolationSet, Tile],
        };
    }
}