using Mahjong2.Lib.Fus;
using System.Collections;

namespace Mahjong2.Tests.Fus;

/// <summary>
/// FuListクラスのテスト
/// </summary>
public class FuListTests
{
    [Fact]
    public void 空のFuListを作成した場合_符数が0であること_符の合計も0であること()
    {
        // Arrange & Act
        var fuList = new FuList([]);

        // Assert
        Assert.Equal(0, fuList.Count);
        Assert.Equal(0, fuList.Total);
    }

    [Fact]
    public void Total_七対子を含むFuListの場合_合計符数が25固定であること()
    {
        // Arrange
        var fuList = new FuList([Fu.Chiitoitsu, Fu.MenzenFu]);

        // Act
        var total = fuList.Total;

        // Assert
        Assert.Equal(25, total);
    }

    [Fact]
    public void Total_符の合計値が10の単位に切り上げられること()
    {
        // Arrange
        var testCases = new[]
       {
            (Fus: new FuList([Fu.Futei, Fu.TsumoFu]), Expected: 30),                    // 20 + 2 = 22 → 30
            (Fus: new FuList([Fu.Futei, Fu.MinkoYaochu, Fu.TsumoFu]), Expected: 30),    // 20 + 4 + 2 = 26 → 30
            (Fus: new FuList([Fu.Futei, Fu.MinkoYaochu, Fu.MinkoYaochu]), Expected: 30) // 20 + 4 + 4 = 28 → 30
        };

        foreach (var testCase in testCases)
        {
            // Act
            var total = testCase.Fus.Total;

            // Assert
            Assert.Equal(testCase.Expected, total);
        }
    }

    [Fact]
    public void ToString_FuListの文字列表現が正しく生成されること()
    {
        // Arrange
        var fuList = new FuList([Fu.Futei, Fu.TsumoFu]);
        var expectedString = "30符 副底:20符,ツモ符:2符";

        // Act
        var result = fuList.ToString();

        // Assert
        Assert.Equal(expectedString, result);
    }

    [Fact]
    public void GetEnumerator_FuListが正しくIEnumerable機能を提供すること()
    {
        // Arrange
        List<Fu> fus = [Fu.Futei, Fu.TsumoFu, Fu.WaitKanchan];
        var fuList = new FuList(fus);

        // Act
        var count = 0;
        foreach (var fu in fuList)
        {
            count++;
        }

        // Assert
        Assert.Equal(fus.Count, count);
        Assert.Contains(Fu.Futei, fuList);
        Assert.Contains(Fu.TsumoFu, fuList);
        Assert.Contains(Fu.WaitKanchan, fuList);
    }

    [Fact]
    public void GetEnumerator_FuListの非ジェネリックGetEnumeratorが正しく動作すること()
    {
        // Arrange
        List<Fu> fus = [Fu.Futei, Fu.TsumoFu, Fu.WaitKanchan];
        var fuList = new FuList(fus);

        // Act
        IEnumerable enumerable = fuList;
        var count = 0;
        foreach (var item in enumerable)
        {
            Assert.IsType<Fu>(item, exactMatch: false);
            count++;
        }

        // Assert
        Assert.Equal(fus.Count, count);
    }

    [Fact]
    public void Add_符を追加すると_新しいFuListが返されること()
    {
        // Arrange
        var fuList = new FuList();
        var fu = Fu.TsumoFu;

        // Act
        var newFuList = fuList.Add(fu);

        // Assert
        Assert.NotSame(fuList, newFuList);
        Assert.Equal(0, fuList.Count);
        Assert.Equal(1, newFuList.Count);
        Assert.Contains(fu, newFuList);
    }

    [Fact]
    public void Add_複数の符を追加すると_すべての符が含まれる新しいFuListが返されること()
    {
        // Arrange
        var fuList = new FuList();

        // Act
        var newFuList = fuList
            .Add(Fu.Futei)
            .Add(Fu.TsumoFu)
            .Add(Fu.WaitKanchan);

        // Assert
        Assert.Equal(3, newFuList.Count);
        Assert.Contains(Fu.Futei, newFuList);
        Assert.Contains(Fu.TsumoFu, newFuList);
        Assert.Contains(Fu.WaitKanchan, newFuList);
        Assert.Equal(30, newFuList.Total); // 20 + 2 + 2 = 24 → 30に切り上げ
    }
}