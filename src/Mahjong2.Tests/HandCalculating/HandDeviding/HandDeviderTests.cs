using Mahjong2.Lib.Internals.HandCalculating.HandDeviding;
using Mahjong2.Lib.Internals.Tiles;

namespace Mahjong2.Tests.HandCalculating.HandDeviding
{
    public class HandDeviderTests
    {
        [Fact]
        public void Devide_シンプルな手牌_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(man: "234567", sou: "23455", honor: "ccc");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected = new Hand([new(man: "234"), new(man: "567"), new(sou: "234"), new(sou: "55"), new(honor: "ccc")]);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void Devide_シンプルな手牌2_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(man: "123", pin: "123", sou: "123", honor: "ttnnn");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected = new Hand([new(man: "123"), new(pin: "123"), new(sou: "123"), new(honor: "tt"), new(honor: "nnn")]);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void Devide_順子の中に対子を含む手牌_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(man: "23444", pin: "344556", sou: "333");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected = new Hand([new(man: "234"), new(man: "44"), new(pin: "345"), new(pin: "456"), new(sou: "333")]);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void Device_順子3つとも刻子3つとも取れる手牌_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(man: "11333444555888");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected0 = new Hand([new(man: "11"), new(man: "333"), new(man: "444"), new(man: "555"), new(man: "888")]);
            var expected1 = new Hand([new(man: "11"), new(man: "345"), new(man: "345"), new(man: "345"), new(man: "888")]);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected0, actual[0]);
            Assert.Equal(expected1, actual[1]);
        }

        [Fact]
        public void Device_順子3つを2通りとも刻子3つとも取れる手牌_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(man: "11222333444888");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected0 = new Hand([new(man: "11"), new(man: "222"), new(man: "333"), new(man: "444"), new(man: "888")]);
            var expected1 = new Hand([new(man: "11"), new(man: "234"), new(man: "234"), new(man: "234"), new(man: "888")]);
            var expected2 = new Hand([new(man: "123"), new(man: "123"), new(man: "234"), new(man: "44"), new(man: "888")]);
            Assert.Equal(3, actual.Count);
            Assert.Equal(expected0, actual[0]);
            Assert.Equal(expected1, actual[1]);
            Assert.Equal(expected2, actual[2]);
        }

        [Fact]
        public void Devide_手牌が14枚未満_副露を想定_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(pin: "778899", honor: "nn");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected = new Hand([new(pin: "789"), new(pin: "789"), new(honor: "nn")]);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void Device_二盃口の形_正しく分解される()
        {
            // Arrange
            var tileList = new TileList(man: "112233", pin: "99", sou: "445566");

            // Act
            var actual = HandDevider.Devide(tileList);

            // Assert
            var expected0 = new Hand([new(man: "11"), new(man: "22"), new(man: "33"), new(pin: "99"), new(sou: "44"), new(sou: "55"), new(sou: "66")]);
            var expected1 = new Hand([new(man: "123"), new(man: "123"), new(pin: "99"), new(sou: "456"), new(sou: "456")]);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected0, actual[0]);
            Assert.Equal(expected1, actual[1]);
        }
    }
}