using System;

namespace DotGimei
{
    /// <summary>
    /// 日本の氏名を表現します。
    /// </summary>
    public class Name : IJapaneseText
    {
        private JapaneseText _last = new JapaneseText();
        private JapaneseText _first = new JapaneseText();
        private JapaneseText EnsureNotNull(JapaneseText value)
        {
            if (value == null) throw new ArgumentNullException("value");
            return value;
        }

        /// <summary>
        /// 性自認を取得または設定します。
        /// </summary>
        public GenderIdentity Gender { get; set; }
        /// <summary>
        /// 氏（名字）を取得または設定します。
        /// </summary>
        public JapaneseText Last
        {
            get { return _last; }
            set { _last = EnsureNotNull(value); }
        }
        /// <summary>
        /// 名（名前）を取得または設定します。
        /// </summary>
        public JapaneseText First
        {
            get { return _first; }
            set { _first = EnsureNotNull(value); }
        }
        /// <summary>
        /// 男性を表す名前かどうかを返します。
        /// 不明の場合はnullを返します。
        /// </summary>
        public bool? IsMale
        {
            get
            {
                switch (Gender)
                {
                    case GenderIdentity.Male:
                        return true;
                    case GenderIdentity.Female:
                        return false;
                    default:
                        return null;
                }
            }
        }
        /// <summary>
        /// 女性を表す名前かどうかを返します。
        /// 不明の場合はnullを返します。
        /// </summary>
        public bool? IsFemale
        {
            get
            {
                switch (Gender)
                {
                    case GenderIdentity.Male:
                        return false;
                    case GenderIdentity.Female:
                        return true;
                    default:
                        return null;
                }
            }
        }
        /// <summary>
        /// ひらがなの氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Hiragana
        {
            get { return Last.Hiragana + " " + First.Hiragana; }
        }
        /// <summary>
        /// カタカナの氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Katakana
        {
            get { return Last.Katakana + " " + First.Katakana; }
        }
        /// <summary>
        /// 漢字の氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Kanji
        {
            get { return Last.Kanji + " " + First.Kanji; }
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// 返される文字列は、漢字の氏名です。
        /// </summary>
        /// <returns>漢字の氏名。</returns>
        public override string ToString()
        {
            return Kanji;
        }
    }
}

