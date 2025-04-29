using Mahjong2.Lib.Fus;
using System.Collections;

namespace Mahjong2.Tests.Fus;

/// <summary>
/// FuListクラスのテスト
/// </summary>
public class FuListTests
{
    [Fact]
    public void 空のコンストラクタ_空のリストを作成できる()
    {
        // Arrange & Act
        var fuList = new FuList();

        // Assert
        Assert.Empty(fuList);
        Assert.Equal(0, fuList.Count);
        Assert.Equal(0, fuList.Total);
    }

    [Fact]
    public void 空のFuListを作成した場合_符数が0であること_符の合計も0であること()
    {
        // Arrange & Act
        var fuList = new FuList([]);

        // Assert
        Assert.Empty(fuList);
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
    public void FuListBuilder_Create_スパンからFuListを正しく作成できること()
    {
        // Arrange
        Span<Fu> fuSpan = [Fu.Futei, Fu.TsumoFu, Fu.WaitKanchan];

        // Act
        var fuList = FuList.FuListBuilder.Create(fuSpan);

        // Assert
        Assert.Equal(3, fuList.Count);
        Assert.Contains(Fu.Futei, fuList);
        Assert.Contains(Fu.TsumoFu, fuList);
        Assert.Contains(Fu.WaitKanchan, fuList);
    }

    [Fact]
    public void FuListBuilder_Create_空のスパンから空のFuListを作成できること()
    {
        // Arrange
        Span<Fu> emptySpan = [];

        // Act
        var fuList = FuList.FuListBuilder.Create(emptySpan);

        // Assert
        Assert.Empty(fuList);
        Assert.Equal(0, fuList.Count);
        Assert.Equal(0, fuList.Total);
    }

    [Fact]
    public void FuListBuilder_Create_コレクション初期化構文で使用できること()
    {
        // Arrange & Act
        FuList fuList = [Fu.Futei, Fu.TsumoFu];

        // Assert
        Assert.Equal(2, fuList.Count);
        Assert.Contains(Fu.Futei, fuList);
        Assert.Contains(Fu.TsumoFu, fuList);
        Assert.Equal(30, fuList.Total); // 20 + 2 = 22 → 30に切り上げ
    }
}