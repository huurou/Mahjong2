using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Mahjong2.Lib.Yakus;

[CollectionBuilder(typeof(YakuListBuilder), "Create")]
public record YakuList() : IEnumerable<Yaku>
{
    public int HanOpen => yakus_.Sum(x => x.HanOpen);
    public int HanClosed => yakus_.Sum(x => x.HanClosed);

    private readonly ImmutableList<Yaku> yakus_ = [];

    public YakuList(IEnumerable<Yaku> yakus) : this()
    {
        yakus_ = [.. yakus];
    }

    public IEnumerator<Yaku> GetEnumerator()
    {
        return yakus_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public sealed override string ToString()
    {
        return string.Join(" ", yakus_);
    }

    public static class YakuListBuilder
    {
        /// <summary>
        /// 指定された牌の配列から新しい<see cref="YakuList"/>を作成します
        /// </summary>
        /// <param name="values">YakuListに含める役の配列</param>
        /// <returns>指定された牌を含む新しい<see cref="YakuList"/></returns>
        public static YakuList Create(ReadOnlySpan<Yaku> values)
        {
            // [.. ]を使用すると無限ループが発生する
#pragma warning disable IDE0306 // コレクションの初期化を簡略化します
            return new(values.ToArray());
#pragma warning restore IDE0306 // コレクションの初期化を簡略化します
        }
    }
}
