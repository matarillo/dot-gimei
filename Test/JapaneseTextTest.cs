using DotGimei;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class JapaneseTextTest
    {
        [TestCase]
        public void JapaneseText_Kanjiプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.NotNull(target.Kanji);
        }

        [TestCase]
        public void JapaneseText_Kanjiプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText();
            target.Kanji = "漢字";
            Assert.AreEqual("漢字", target.Kanji);
        }

        [TestCase]
        public void JapaneseText_Kanjiプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText();
            target.Kanji = null;
            Assert.AreEqual("", target.Kanji);
        }

        [TestCase]
        public void JapaneseText_Hiraganaプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.NotNull(target.Hiragana);
        }

        [TestCase]
        public void JapaneseText_Hiraganaプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText();
            target.Hiragana = "ひらがな";
            Assert.AreEqual("ひらがな", target.Hiragana);
        }

        [TestCase]
        public void JapaneseText_Hiraganaプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText();
            target.Hiragana = null;
            Assert.AreEqual("", target.Hiragana);
        }

        [TestCase]
        public void JapaneseText_Katakanaプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.NotNull(target.Katakana);
        }

        [TestCase]
        public void JapaneseText_Katakanaプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText();
            target.Katakana = "カタカナ";
            Assert.AreEqual("カタカナ", target.Katakana);
        }

        [TestCase]
        public void JapaneseText_Katakanaプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText();
            target.Katakana = null;
            Assert.AreEqual("", target.Katakana);
        }

        [TestCase]
        public void JapaneseText_ToStringメソッドについて_Kanjiプロパティと同じ文字列であること()
        {
            var target = new JapaneseText();
            target.Kanji = "漢字";
            Assert.AreEqual(target.Kanji, target.ToString());
        }
    }
}
