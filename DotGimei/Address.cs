using System;

namespace DotGimei
{
    /// <summary>
    /// 日本の住所を表現します。
    /// </summary>
    public class Address : IJapaneseText
    {
        private JapaneseText _prefecture = new JapaneseText();
        private JapaneseText _city = new JapaneseText();
        private JapaneseText _town = new JapaneseText();

        private JapaneseText EnsureNotNull(JapaneseText value)
        {
            if (value == null) throw new ArgumentNullException("value");
            return value;
        }

        /// <summary>
        /// 都道府県名を表す<see cref="JapaneseText"/>オブジェクトを取得または設定します。
        /// </summary>
        public JapaneseText Prefecture
        {
            get { return _prefecture; }
            set { _prefecture = EnsureNotNull(value); }
        }
        /// <summary>
        /// 市区町村名を表す<see cref="JapaneseText"/>オブジェクトを取得または設定します。
        /// </summary>
        public JapaneseText City
        {
            get { return _city; }
            set { _city = EnsureNotNull(value); }
        }
        /// <summary>
        /// 町字名を表す<see cref="JapaneseText"/>オブジェクトを取得または設定します。
        /// </summary>
        public JapaneseText Town
        {
            get { return _town; }
            set { _town = EnsureNotNull(value); }
        }
        /// <summary>
        /// カタカナの住所を取得します。
        /// </summary>
        /// <remarks>
        /// 都道府県名、市区町村名、および町字名を結合します。
        /// </remarks>
        public string Katakana
        {
            get { return _prefecture.Katakana + _city.Katakana + _town.Katakana; }
        }
        /// <summary>
        /// ひらがなの住所を取得します。
        /// </summary>
        /// <remarks>
        /// 都道府県名、市区町村名、および町字名を結合します。
        /// </remarks>
        public string Hiragana
        {
            get { return _prefecture.Hiragana + _city.Hiragana + _town.Hiragana; }
        }
        /// <summary>
        /// 漢字の住所を取得します。
        /// </summary>
        /// <remarks>
        /// 都道府県名、市区町村名、および町字名を結合します。
        /// </remarks>
        public string Kanji
        {
            get { return _prefecture.Kanji + _city.Kanji + _town.Kanji; }
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// 返される文字列は、漢字の住所です。
        /// </summary>
        /// <returns>漢字の住所。</returns>
        public override string ToString()
        {
            return Kanji;
        }
    }
}

