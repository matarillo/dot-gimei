using DotGimei;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Test
{
    [TestFixture]
    public class GimeiTest
    {
        [TestCase]
        public void Gimei_SharedGeneratorプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var before = Gimei.SharedGenerator;
            Assert.NotNull(before);
            Assert.Catch(() => Gimei.SharedGenerator = null);
            var after = Gimei.SharedGenerator;
            Assert.AreSame(before, after);
        }

        [TestCase]
        public void Gimei_NewNameメソッドについて_100回連続で呼び出しても_KanjiプロパティはBMPの全角文字列とスペース_Hiraganaプロパティはひらがなとスペース_Katakanaプロパティはカタカナとスペースを返すこと()
        {
            // 埋め込まれたデータはBMP内の文字しかないという想定
            const string kanjiPattern =
                "^["
                + @" "
                + @"\p{IsCJKRadicalsSupplement}"
                + @"\p{IsCJKSymbolsandPunctuation}"
                + @"\p{IsHiragana}"
                + @"\p{IsKatakana}"
                + @"\p{IsCJKUnifiedIdeographsExtensionA}"
                + @"\p{IsCJKUnifiedIdeographs}"
                + @"\p{IsCJKCompatibilityIdeographs}"
                + "]+$";

            for (var i = 0; i < 100; i++)
            {
                var target = Gimei.NewName();
                Assert.True(Regex.IsMatch(target.Kanji, kanjiPattern), target.Kanji);
                Assert.True(Regex.IsMatch(target.Hiragana, @"^[ \p{IsHiragana}]+$"), target.Hiragana);
                Assert.True(Regex.IsMatch(target.Katakana, @"^[ \p{IsKatakana}]+$"), target.Katakana);
            }
        }

        [TestCase]
        public void Gimei_NewNameメソッドについて_100回連続で呼び出すと男性名と女性名がそれぞれ1個以上_計100個返ってくること()
        {
            var counter = new Dictionary<GenderIdentity, int>
            {
                { GenderIdentity.Male, 0 }, { GenderIdentity.Female, 0 }
            };
            for (var i = 0; i < 100; i++)
            {
                var target = Gimei.NewName();
                counter[target.Gender]++;
            }
            Assert.GreaterOrEqual(counter[GenderIdentity.Male], 1);
            Assert.GreaterOrEqual(counter[GenderIdentity.Female], 1);
            Assert.AreEqual(100, counter[GenderIdentity.Male] + counter[GenderIdentity.Female]);
        }

        [TestCase]
        public void Gimei_NewMaleメソッドについて_データが1行の時にIsMaleプロパティ_IsFemaleプロパティ_ToStringメソッドがそれぞれ期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewMale();
            Assert.AreEqual(true, target.IsMale);
            Assert.AreEqual(false, target.IsFemale);
            Assert.AreEqual("佐藤 翔太", target.ToString());
        }

        [TestCase]
        public void Gimei_NewFemaleメソッドについて_データが1行の時にIsMaleプロパティ_IsFemaleプロパティ_ToStringメソッドがそれぞれ期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewFemale();
            Assert.AreEqual(false, target.IsMale);
            Assert.AreEqual(true, target.IsFemale);
            Assert.AreEqual("佐藤 美咲", target.ToString());
        }

        [TestCase]
        public void Gimei_NewAddressメソッドについて_100回連続で呼び出しても_KanjiプロパティはBMPの全角文字列_Hiraganaプロパティはひらがな_Katakanaプロパティはカタカナを返すこと()
        {
            // 埋め込まれたデータはBMP内の文字しかないという想定
            const string kanjiPattern =
                "^["
                + @"\p{IsCJKRadicalsSupplement}"
                + @"\p{IsCJKSymbolsandPunctuation}"
                + @"\p{IsHiragana}"
                + @"\p{IsKatakana}"
                + @"\p{IsCJKUnifiedIdeographsExtensionA}"
                + @"\p{IsCJKUnifiedIdeographs}"
                + @"\p{IsCJKCompatibilityIdeographs}"
                + "]+$";

            for (var i = 0; i < 100; i++)
            {
                var target = Gimei.NewAddress();
                Assert.True(Regex.IsMatch(target.Kanji, kanjiPattern), target.Kanji);
                Assert.True(Regex.IsMatch(target.Hiragana, @"^\p{IsHiragana}+$"), target.Hiragana);
                Assert.True(Regex.IsMatch(target.Katakana, @"^\p{IsKatakana}+$"), target.Katakana);
            }
        }

        [TestCase]
        public void Gimei_NewAddressメソッドについて_データが1行の時にPrefecture_City_Townプロパティがそれぞれ期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewAddress();
            Assert.AreEqual("東京都", target.Prefecture.ToString());
            Assert.AreEqual("千代田区", target.City.ToString());
            Assert.AreEqual("千代田", target.Town.ToString());
        }

        [TestCase]
        public void Gimei_NewPrefectureメソッドについて_データが1行の時に期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewPrefecture();
            Assert.AreEqual("東京都", target.ToString());
        }

        [TestCase]
        public void Gimei_NewCityメソッドについて_データが1行の時に期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewCity();
            Assert.AreEqual("千代田区", target.ToString());
        }

        [TestCase]
        public void Gimei_NewTownメソッドについて_データが1行の時に期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewTown();
            Assert.AreEqual("千代田", target.ToString());
        }
    }
}
