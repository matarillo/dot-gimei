using DotGimei;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class AddressTest
    {
        [TestCase]
        public void Address_Prefectureプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Address();
            var before = target.Prefecture;
            Assert.Catch(() => target.Prefecture = null);
            var after = target.Prefecture;
            Assert.AreSame(before, after);
        }

        [TestCase]
        public void Address_Cityプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Address();
            var before = target.City;
            Assert.Catch(() => target.City = null);
            var after = target.City;
            Assert.AreSame(before, after);
        }

        [TestCase]
        public void Address_Townプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Address();
            var before = target.Town;
            Assert.Catch(() => target.Town = null);
            var after = target.Town;
            Assert.AreSame(before, after);
        }

        [TestCase]
        public void Address_Kanjiプロパティについて_Prefecture_City_Townの漢字が結合されること()
        {
            var target = new Address();
            target.Prefecture = new JapaneseText { Kanji = "東京都" };
            target.City = new JapaneseText { Kanji = "千代田区" };
            target.Town = new JapaneseText { Kanji = "千代田" };
            Assert.AreEqual("東京都千代田区千代田", target.Kanji);
        }

        [TestCase]
        public void Address_Hiraganaプロパティについて_Prefecture_City_Townのひらがなが結合されること()
        {
            var target = new Address();
            target.Prefecture = new JapaneseText { Hiragana = "とうきょうと" };
            target.City = new JapaneseText { Hiragana = "ちよだく" };
            target.Town = new JapaneseText { Hiragana = "ちよだ" };
            Assert.AreEqual("とうきょうとちよだくちよだ", target.Hiragana);
        }

        [TestCase]
        public void Address_Katakanaプロパティについて_Prefecture_City_Townのカタカナが結合されること()
        {
            var target = new Address();
            target.Prefecture = new JapaneseText { Katakana = "トウキョウト" };
            target.City = new JapaneseText { Katakana = "チヨダク" };
            target.Town = new JapaneseText { Katakana = "チヨダ" };
            Assert.AreEqual("トウキョウトチヨダクチヨダ", target.Katakana);
        }

        [TestCase]
        public void Address_ToStringメソッドについて_Kanjiプロパティと同じ文字列であること()
        {
            var target = new Address();
            target.Prefecture = new JapaneseText { Kanji = "東京都" };
            target.City = new JapaneseText { Kanji = "千代田区" };
            target.Town = new JapaneseText { Kanji = "千代田" };
            Assert.AreEqual(target.Kanji, target.ToString());
        }
    }
}
