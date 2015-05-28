using DotGimei;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class NameTest
    {
        [TestCase]
        public void Name_Firstプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Name();
            var before = target.First;
            Assert.Catch(() => target.First = null);
            var after = target.First;
            Assert.AreSame(before, after);
        }

        [TestCase]
        public void Name_Lastプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Name();
            var before = target.Last;
            Assert.Catch(() => target.Last = null);
            var after = target.Last;
            Assert.AreSame(before, after);
        }

        [TestCase]
        public void Name_IsMaleプロパティについて_GenderがMaleの時はtrue_GenderがFemaleの時はfalse_それ以外の時はnullを返すこと()
        {
            var male = new Name { Gender = GenderIdentity.Male };
            Assert.AreEqual(true, male.IsMale, "Male");
            var female = new Name { Gender = GenderIdentity.Female };
            Assert.AreEqual(false, female.IsMale, "Female");
            var notKnown = new Name { Gender = GenderIdentity.NotKnown };
            Assert.AreEqual(null, notKnown.IsMale, "Not Known");
            var notApplicable = new Name { Gender = GenderIdentity.NotApplicable };
            Assert.AreEqual(null, notApplicable.IsMale, "Not Applicable");
        }

        [TestCase]
        public void Name_IsFemaleプロパティについて_GenderがMaleの時はfalse_GenderがFemaleの時はtrue_それ以外の時はnullを返すこと()
        {
            var male = new Name { Gender = GenderIdentity.Male };
            Assert.AreEqual(false, male.IsFemale, "Male");
            var female = new Name { Gender = GenderIdentity.Female };
            Assert.AreEqual(true, female.IsFemale, "Female");
            var notKnown = new Name { Gender = GenderIdentity.NotKnown };
            Assert.AreEqual(null, notKnown.IsFemale, "Not Known");
            var notApplicable = new Name { Gender = GenderIdentity.NotApplicable };
            Assert.AreEqual(null, notApplicable.IsFemale, "Not Applicable");
        }

        [TestCase]
        public void Name_Kanjiプロパティについて_Lastの漢字_スペース_Firstの漢字が結合されること()
        {
            var target = new Name();
            target.Last = new JapaneseText { Kanji = "佐藤" };
            target.First = new JapaneseText { Kanji = "美咲" };
            Assert.AreEqual("佐藤 美咲", target.Kanji);
        }

        [TestCase]
        public void Name_Hiraganaプロパティについて_Lastのひらがな_スペース_Firstのひらがなが結合されること()
        {
            var target = new Name();
            target.Last = new JapaneseText { Hiragana = "さとう" };
            target.First = new JapaneseText { Hiragana = "みさき" };
            Assert.AreEqual("さとう みさき", target.Hiragana);
        }

        [TestCase]
        public void Name_Katakanaプロパティについて_Lastのカタカナ_スペース_Firstのカタカナが結合されること()
        {
            var target = new Name();
            target.Last = new JapaneseText { Katakana = "サトウ" };
            target.First = new JapaneseText { Katakana = "ミサキ" };
            Assert.AreEqual("サトウ ミサキ", target.Katakana);
        }

        [TestCase]
        public void Name_ToStringメソッドについて_Kanjiプロパティと同じ文字列であること()
        {
            var target = new Name();
            target.Last = new JapaneseText { Kanji = "佐藤" };
            target.First = new JapaneseText { Kanji = "美咲" };
            Assert.AreEqual(target.Kanji, target.ToString());
        }
    }
}
