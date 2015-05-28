using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace DotGimei
{
    internal class Addresses
    {
        private const int KanjiIndex = 0;
        private const int HiraganaIndex = 1;
        private const int KatakanaIndex = 2;

        internal class Inner
        {
            public List<string[]> prefecture { get; set; }
            public List<string[]> city { get; set; }
            public List<string[]> town { get; set; }
        }
        public Inner addresses { get; set; }

        internal static Addresses Load(TextReader reader)
        {
            var deserializer = new Deserializer();
            var addr = deserializer.Deserialize<Addresses>(reader);
            return addr;
        }

        internal Address Next(Random r)
        {
            var pref = addresses.prefecture[r.Next(addresses.prefecture.Count)];
            var city = addresses.city[r.Next(addresses.city.Count)];
            var town = addresses.town[r.Next(addresses.town.Count)];
            return new Address
            {
                Prefecture = new JapaneseText
                {
                    Kanji = pref[KanjiIndex],
                    Hiragana = pref[HiraganaIndex],
                    Katakana = pref[KatakanaIndex]
                },
                City = new JapaneseText
                {
                    Kanji = city[KanjiIndex],
                    Hiragana = city[HiraganaIndex],
                    Katakana = city[KatakanaIndex]
                },
                Town = new JapaneseText
                {
                    Kanji = town[KanjiIndex],
                    Hiragana = town[HiraganaIndex],
                    Katakana = town[KatakanaIndex]
                }
            };
        }
    }
}

