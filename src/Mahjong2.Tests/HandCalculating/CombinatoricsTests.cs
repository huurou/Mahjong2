using Mahjong2.Lib.HandCalculating;

namespace Mahjong2.Tests.HandCalculating
{
    public class CombinatoricsTests
    {
        [Fact]
        public void Permutations_通常の順列生成_正しい順列が返る()
        {
            // Arrange
            var source = new[] { 1, 2, 3, 4, 4 };
            var k = 3;

            // Act
            var actual = Combinatorics.PermutationsUnique(source, k).Select(x => x.ToArray()).ToArray();

            // Assert
            int[][] expected = 
            [
                [1, 2, 3],
                [1, 2, 4],
                [1, 3, 2],
                [1, 3, 4],
                [1, 4, 2],
                [1, 4, 3],
                [1, 4, 4],
                [2, 1, 3],
                [2, 1, 4],
                [2, 3, 1],
                [2, 3, 4],
                [2, 4, 1],
                [2, 4, 3],
                [2, 4, 4],
                [3, 1, 2],
                [3, 1, 4],
                [3, 2, 1],
                [3, 2, 4],
                [3, 4, 1],
                [3, 4, 2],
                [3, 4, 4],
                [4, 1, 2],
                [4, 1, 3],
                [4, 2, 1],
                [4, 2, 3],
                [4, 3, 1],
                [4, 3, 2],
                [4, 1, 4],
                [4, 2, 4],
                [4, 3, 4],
                [4, 4, 1],
                [4, 4, 2],
                [4, 4, 3],
            ];
            Assert.Equal(expected.Length, actual.Length);
            foreach (var perm in expected)
            {
                Assert.Contains(actual, r => r.SequenceEqual(perm));
            }
        }

        [Fact]
        public void Permutations_kが0_空の順列のみ返る()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 0;

            // Act
            var result = Combinatorics.PermutationsUnique(source, k).ToArray();

            // Assert
            Assert.Single(result);
            Assert.Empty(result[0]);
        }

        [Fact]
        public void Permutations_kが負数_何も返さない()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = -1;

            // Act
            var result = Combinatorics.PermutationsUnique(source, k).ToArray();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Permutations_kが要素数より大きい_何も返さない()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 4;

            // Act
            var result = Combinatorics.PermutationsUnique(source, k).ToArray();

            // Assert
            Assert.Empty(result);
        }
    }
}
