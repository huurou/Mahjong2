using Mahjong2.Lib.HandCalculating.HandDeviding;

namespace Mahjong2.Tests.HandCalculating.HandDeviding
{
    public class CombinatoricsTests
    {
        [Fact]
        public void Permutations_通常の順列生成_正しい順列が返る()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 2;

            // Act
            var actual = Combinatorics.Permutations(source, k).Select(x => x.ToArray()).ToArray();

            // Assert
            int[][] expected = 
            [
                [1, 2],
                [1, 3],
                [2, 1],
                [2, 3],
                [3, 1],
                [3, 2]
            ];
            Assert.Equal(expected.Length, actual.Length);
            foreach (var perm in expected)
            {
                Assert.Contains(actual, r => r.SequenceEqual(perm));
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Permutations_kが0_空の順列のみ返る()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 0;

            // Act
            var result = Combinatorics.Permutations(source, k).ToArray();

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
            var result = Combinatorics.Permutations(source, k).ToArray();

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
            var result = Combinatorics.Permutations(source, k).ToArray();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Combinations_通常の組み合わせ生成_正しい組み合わせが返る()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 2;

            // Act
            var actual = Combinatorics.Combinations(source, k).Select(x => x.ToArray()).ToArray();

            // Assert
            int[][] expected =
            [
                [1, 2],
                [1, 3],
                [2, 3]
            ];
            Assert.Equal(expected.Length, actual.Length);
            foreach (var comb in expected)
            {
                Assert.Contains(actual, r => r.SequenceEqual(comb));
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Combinations_kが0_空の組み合わせのみ返る()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 0;

            // Act
            var result = Combinatorics.Combinations(source, k).ToArray();

            // Assert
            Assert.Single(result);
            Assert.Empty(result[0]);
        }

        [Fact]
        public void Combinations_kが負数_何も返さない()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = -1;

            // Act
            var result = Combinatorics.Combinations(source, k).ToArray();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Combinations_kが要素数より大きい_何も返さない()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var k = 4;

            // Act
            var result = Combinatorics.Combinations(source, k).ToArray();

            // Assert
            Assert.Empty(result);
        }
    }
}
