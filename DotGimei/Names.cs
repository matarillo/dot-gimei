using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace DotGimei
{
    internal class Names
    {
        private const int KanjiIndex = 0;
        private const int HiraganaIndex = 1;
        private const int KatakanaIndex = 2;

        internal class FirstName
        {
            public List<string[]> male { get; set; }
            public List<string[]> female { get; set; }
        }
        public FirstName first_name { get; set; }
        public List<string[]> last_name { get; set; }

        internal static Names Load(TextReader reader)
        {
            var deserializer = new Deserializer();
            var names = deserializer.Deserialize<Names>(reader);
            return names;
        }

        internal Name NextMale(Random r)
        {
            var first = first_name.male[r.Next(first_name.male.Count)];
            var last = last_name[r.Next(last_name.Count)];
            return NewName(first, last, GenderIdentity.Male);
        }
        internal Name NextFemale(Random r)
        {
            var first = first_name.female[r.Next(first_name.female.Count)];
            var last = last_name[r.Next(last_name.Count)];
            return NewName(first, last, GenderIdentity.Female);
        }
        private Name NewName(string[] first, string[] last, GenderIdentity gender)
        {
            return new Name
            {
                First = new JapaneseText
                {
                    Kanji = first[KanjiIndex],
                    Hiragana = first[HiraganaIndex],
                    Katakana = first[KatakanaIndex]
                },
                Last = new JapaneseText
                {
                    Kanji = last[KanjiIndex],
                    Hiragana = last[HiraganaIndex],
                    Katakana = last[KatakanaIndex]
                },
                Gender = gender
            };
        }

    }
}

