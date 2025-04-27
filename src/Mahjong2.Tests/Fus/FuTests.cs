using Mahjong2.Lib.Fus;
using Xunit;

namespace Mahjong2.Tests.Fus
{
    /// <summary>
    /// Fuクラスとその派生クラスのテスト
    /// </summary>
    public class FuTests
    {
        /// <summary>
        /// Futei_値取得_20が返る
        /// </summary>
        [Fact]
        public void Futei_値取得_20が返る()
        {
            // Arrange
            var futei = Fu.Futei;

            // Act
            var value = futei.Value;

            // Assert
            Assert.Equal(20, value);
        }

        /// <summary>
        /// Shuntsu_値取得_0が返る
        /// </summary>
        [Fact]
        public void Shuntsu_値取得_0が返る()
        {
            // Arrange
            var shuntsu = Fu.Shuntsu;

            // Act
            var value = shuntsu.Value;

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        /// MinkoChuchan_値取得_2が返る
        /// </summary>
        [Fact]
        public void MinkoChuchan_値取得_2が返る()
        {
            // Arrange
            var minkoChuchan = Fu.MinkoChuchan;

            // Act
            var value = minkoChuchan.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// MinkoYaochu_値取得_4が返る
        /// </summary>
        [Fact]
        public void MinkoYaochu_値取得_4が返る()
        {
            // Arrange
            var minkoYaochu = Fu.MinkoYaochu;

            // Act
            var value = minkoYaochu.Value;

            // Assert
            Assert.Equal(4, value);
        }

        /// <summary>
        /// AnkoChuchan_値取得_4が返る
        /// </summary>
        [Fact]
        public void AnkoChuchan_値取得_4が返る()
        {
            // Arrange
            var ankoChuchan = Fu.AnkoChuchan;

            // Act
            var value = ankoChuchan.Value;

            // Assert
            Assert.Equal(4, value);
        }

        /// <summary>
        /// AnkoYaochu_値取得_8が返る
        /// </summary>
        [Fact]
        public void AnkoYaochu_値取得_8が返る()
        {
            // Arrange
            var ankoYaochu = Fu.AnkoYaochu;

            // Act
            var value = ankoYaochu.Value;

            // Assert
            Assert.Equal(8, value);
        }

        /// <summary>
        /// MinkanChuchan_値取得_8が返る
        /// </summary>
        [Fact]
        public void MinkanChuchan_値取得_8が返る()
        {
            // Arrange
            var minkanChuchan = Fu.MinkanChuchan;

            // Act
            var value = minkanChuchan.Value;

            // Assert
            Assert.Equal(8, value);
        }

        /// <summary>
        /// MinkanYaochu_値取得_16が返る
        /// </summary>
        [Fact]
        public void MinkanYaochu_値取得_16が返る()
        {
            // Arrange
            var minkanYaochu = Fu.MinkanYaochu;

            // Act
            var value = minkanYaochu.Value;

            // Assert
            Assert.Equal(16, value);
        }

        /// <summary>
        /// AnkanChuchan_値取得_16が返る
        /// </summary>
        [Fact]
        public void AnkanChuchan_値取得_16が返る()
        {
            // Arrange
            var ankanChuchan = Fu.AnkanChuchan;

            // Act
            var value = ankanChuchan.Value;

            // Assert
            Assert.Equal(16, value);
        }

        /// <summary>
        /// AnkanYaochu_値取得_32が返る
        /// </summary>
        [Fact]
        public void AnkanYaochu_値取得_32が返る()
        {
            // Arrange
            var ankanYaochu = Fu.AnkanYaochu;

            // Act
            var value = ankanYaochu.Value;

            // Assert
            Assert.Equal(32, value);
        }

        /// <summary>
        /// JantoNumber_値取得_0が返る
        /// </summary>
        [Fact]
        public void JantoNumber_値取得_0が返る()
        {
            // Arrange
            var jantoNumber = Fu.JantoNumber;

            // Act
            var value = jantoNumber.Value;

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        /// JantoOtherWind_値取得_0が返る
        /// </summary>
        [Fact]
        public void JantoOtherWind_値取得_0が返る()
        {
            // Arrange
            var jantoOtherWind = Fu.JantoOtherWind;

            // Act
            var value = jantoOtherWind.Value;

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        /// JantouPlayerWind_値取得_2が返る
        /// </summary>
        [Fact]
        public void JantouPlayerWind_値取得_2が返る()
        {
            // Arrange
            var jantouPlayerWind = Fu.JantouPlayerWind;

            // Act
            var value = jantouPlayerWind.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// JantouRoundWind_値取得_2が返る
        /// </summary>
        [Fact]
        public void JantouRoundWind_値取得_2が返る()
        {
            // Arrange
            var jantouRoundWind = Fu.JantouRoundWind;

            // Act
            var value = jantouRoundWind.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// JantouDragon_値取得_2が返る
        /// </summary>
        [Fact]
        public void JantouDragon_値取得_2が返る()
        {
            // Arrange
            var jantouDragon = Fu.JantouDragon;

            // Act
            var value = jantouDragon.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// WaitRyanmen_値取得_0が返る
        /// </summary>
        [Fact]
        public void WaitRyanmen_値取得_0が返る()
        {
            // Arrange
            var waitRyanmen = Fu.WaitRyanmen;

            // Act
            var value = waitRyanmen.Value;

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        /// WaitShanpon_値取得_0が返る
        /// </summary>
        [Fact]
        public void WaitShanpon_値取得_0が返る()
        {
            // Arrange
            var waitShanpon = Fu.WaitShanpon;

            // Act
            var value = waitShanpon.Value;

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        /// WaitKanchan_値取得_2が返る
        /// </summary>
        [Fact]
        public void WaitKanchan_値取得_2が返る()
        {
            // Arrange
            var waitKanchan = Fu.WaitKanchan;

            // Act
            var value = waitKanchan.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// WaitPenchan_値取得_2が返る
        /// </summary>
        [Fact]
        public void WaitPenchan_値取得_2が返る()
        {
            // Arrange
            var waitPenchan = Fu.WaitPenchan;

            // Act
            var value = waitPenchan.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// WaitTanki_値取得_2が返る
        /// </summary>
        [Fact]
        public void WaitTanki_値取得_2が返る()
        {
            // Arrange
            var waitTanki = Fu.WaitTanki;

            // Act
            var value = waitTanki.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// MenzenFu_値取得_10が返る
        /// </summary>
        [Fact]
        public void MenzenFu_値取得_10が返る()
        {
            // Arrange
            var menzenFu = Fu.MenzenFu;

            // Act
            var value = menzenFu.Value;

            // Assert
            Assert.Equal(10, value);
        }

        /// <summary>
        /// TsumoFu_値取得_2が返る
        /// </summary>
        [Fact]
        public void TsumoFu_値取得_2が返る()
        {
            // Arrange
            var tsumoFu = Fu.TsumoFu;

            // Act
            var value = tsumoFu.Value;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        /// ToString_フォーマット確認_正しい形式の文字列が返る
        /// </summary>
        [Fact]
        public void ToString_フォーマット確認_正しい形式の文字列が返る()
        {
            // Arrange
            var futei = Fu.Futei;
            var shuntsu = Fu.Shuntsu;
            var minkoChuchan = Fu.MinkoChuchan;

            // Act
            var futeiString = futei.ToString();
            var shuntsuString = shuntsu.ToString();
            var minkoChuchanString = minkoChuchan.ToString();

            // Assert
            Assert.Equal("副底:20符", futeiString);
            Assert.Equal("順子:0符", shuntsuString);
            Assert.Equal("中張牌の明刻:2符", minkoChuchanString);
        }

        /// <summary>
        /// シングルトンの一意性をテストする
        /// </summary>
        [Fact]
        public void Fu_シングルトンインスタンス取得_同一インスタンスが返る()
        {
            // Arrange & Act
            var futei1 = Fu.Futei;
            var futei2 = Fu.Futei;
            
            var shuntsu1 = Fu.Shuntsu;
            var shuntsu2 = Fu.Shuntsu;

            // Assert
            Assert.Same(futei1, futei2);
            Assert.Same(shuntsu1, shuntsu2);
        }

        /// <summary>
        /// 継承関係の検証
        /// </summary>
        [Fact]
        public void Fu_継承関係の検証_正しい型に変換できる()
        {
            // Arrange & Act & Assert
            Assert.IsType<Futei>(Fu.Futei);
            Assert.IsType<Shuntsu>(Fu.Shuntsu);
            
            Assert.IsType<MinkoChuchan>(Fu.MinkoChuchan);
            Assert.IsType<MinkoYaochu>(Fu.MinkoYaochu);
            Assert.IsType<AnkoChuchan>(Fu.AnkoChuchan);
            Assert.IsType<AnkoYaochu>(Fu.AnkoYaochu);
            Assert.IsType<MinkanChuchan>(Fu.MinkanChuchan);
            Assert.IsType<MinkanYaochu>(Fu.MinkanYaochu);
            Assert.IsType<AnkanChuchan>(Fu.AnkanChuchan);
            Assert.IsType<AnkanYaochu>(Fu.AnkanYaochu);
            
            Assert.IsType<JantoNumber>(Fu.JantoNumber);
            Assert.IsType<JantoOtherWind>(Fu.JantoOtherWind);
            Assert.IsType<JantouPlayerWind>(Fu.JantouPlayerWind);
            Assert.IsType<JantouRoundWind>(Fu.JantouRoundWind);
            Assert.IsType<JantouDragon>(Fu.JantouDragon);
            
            Assert.IsType<WaitRyanmen>(Fu.WaitRyanmen);
            Assert.IsType<WaitShanpon>(Fu.WaitShanpon);
            Assert.IsType<WaitKanchan>(Fu.WaitKanchan);
            Assert.IsType<WaitPenchan>(Fu.WaitPenchan);
            Assert.IsType<WaitTanki>(Fu.WaitTanki);
            
            Assert.IsType<MenzenFu>(Fu.MenzenFu);
            Assert.IsType<TsumoFu>(Fu.TsumoFu);
        }
    }
}