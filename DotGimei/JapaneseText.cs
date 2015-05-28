using System;

namespace DotGimei
{
    /// <summary>
    /// カタカナ、ひらがな、漢字で表現される日本語テキストのインターフェースです。
    /// </summary>
    public interface IJapaneseText
    {
        /// <summary>
        /// カタカナを取得します。
        /// </summary>
        string Katakana { get; }
        /// <summary>
        /// ひらがなを取得します。
        /// </summary>
        string Hiragana { get; }
        /// <summary>
        /// 漢字を取得します。
        /// </summary>
        string Kanji { get; }
    }

    /// <summary>
    /// カタカナ、ひらがな、漢字で表現される日本語テキストの実装クラスです。
    /// </summary>
    public class JapaneseText : IJapaneseText
    {
        private string _katakana = "";
        private string _hiragana = "";
        private string _kanji = "";

        /// <summary>
        /// カタカナを取得または設定します。
        /// </summary>
        public string Katakana
        {
            get { return _katakana; }
            set { _katakana = value ?? ""; }
        }
        /// <summary>
        /// ひらがなを取得または設定します。
        /// </summary>
        public string Hiragana
        {
            get { return _hiragana; }
            set { _hiragana = value ?? ""; }
        }
        /// <summary>
        /// 漢字を取得または設定します。
        /// </summary>
        public string Kanji
        {
            get { return _kanji; }
            set { _kanji = value ?? ""; }
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// 返される文字列は、漢字です。
        /// </summary>
        /// <returns>漢字。</returns>
        public override string ToString()
        {
            return Kanji;
        }
    }
}

