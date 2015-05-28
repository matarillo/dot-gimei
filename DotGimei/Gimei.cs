using System;
using System.IO;
using System.Reflection;

namespace DotGimei
{
    /// <summary>
    /// 日本人の氏名や、日本の住所をランダムに返すための静的ユーティリティクラスです。
    /// </summary>
    /// <remarks>
    /// <see cref="SharedGenerator"/>プロパティに設定された既定の<see cref="Generator"/>オブジェクトの各種メソッドを呼び出します。
    /// </remarks>
    /// <threadsafety static="false" instance="false" />
    public static class Gimei
    {
        private static Generator generator = new Generator();

        /// <summary>
        /// 既定の<see cref="Generator"/>オブジェクトを取得または設定します。
        /// </summary>
        public static Generator SharedGenerator
        {
            get { return generator; }
            set { generator = EnsureNotNull(value); }
        }

        private static Generator EnsureNotNull(Generator value)
        {
            if (value == null) throw new ArgumentNullException("value");
            return value;
        }

        /// <summary>
        /// <see cref="Name"/>オブジェクトをランダムに返します。
        /// 男女の氏名を等確率で返します。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewName"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns><see cref="Name"/>オブジェクト。</returns>
        public static Name NewName()
        {
            return generator.NewName();
        }
        /// <summary>
        /// 男性名の<see cref="Name"/>オブジェクトをランダムに返します。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewMale"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns>男性名の<see cref="Name"/>オブジェクト。</returns>
        public static Name NewMale()
        {
            return generator.NewMale();
        }
        /// <summary>
        /// 女性名の<see cref="Name"/>オブジェクトをランダムに返します。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewFemale"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns><see cref="Name"/>女性名のオブジェクト。</returns>
        public static Name NewFemale()
        {
            return generator.NewFemale();
        }
        /// <summary>
        /// <see cref="Address"/>オブジェクトをランダムに返します。
        /// 都道府県名、市区町村名、町字名がランダムに組み合わされるため、ほとんどの場合は実在しない住所となります。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewAddress"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns><see cref="Address"/>オブジェクト。</returns>
        public static Address NewAddress()
        {
            return generator.NewAddress();
        }
        /// <summary>
        /// 都道府県名を表す<see cref="JapaneseText"/>オブジェクトをランダムに返します。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewPrefecture"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns>都道府県名を表す<see cref="JapaneseText"/>オブジェクト。</returns>
        public static JapaneseText NewPrefecture()
        {
            return generator.NewPrefecture();
        }
        /// <summary>
        /// 市区町村名を表す<see cref="JapaneseText"/>オブジェクトをランダムに返します。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewCity"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns>市区町村名を表す<see cref="JapaneseText"/>オブジェクト。</returns>
        public static JapaneseText NewCity()
        {
            return generator.NewCity();
        }
        /// <summary>
        /// 町字名を表す<see cref="JapaneseText"/>オブジェクトをランダムに返します。
        /// </summary>
        /// <remarks>
        /// <see cref="SharedGenerator"/>プロパティの<see cref="Generator.NewTown"/>メソッドを呼び出します。
        /// </remarks>
        /// <returns>町字名を表す<see cref="JapaneseText"/>オブジェクト。</returns>
        public static JapaneseText NewTown()
        {
            return generator.NewTown();
        }

        /// <summary>
        /// 日本人の氏名や、日本の住所をランダムに返します。
        /// YAML形式のデータを読み取って、氏名や住所の候補とします。
        /// </summary>
        /// <threadsafety static="true" instance="false" />
        public class Generator
        {
            private readonly Random _r;
            private readonly Addresses _addresses;
            private readonly Names _names;

            /// <summary>
            /// <see cref="Generator"/>クラスの新しいインスタンスを初期化します。
            /// </summary>
            /// <param name="random">
            /// 疑似乱数ジェネレータ（省略可）。
            /// 省略した場合は、時間に応じて決定される既定のシード値を使用して初期化された
            /// <see cref="Random"/>クラスの新しいインスタンスが使用されます。
            /// </param>
            /// <param name="addresses">
            /// YAML形式の住所データを読み取るリーダー（省略可）。
            /// 省略した場合は、アセンブリに埋め込まれた既定の住所データが使用されます。
            /// </param>
            /// <param name="names">
            /// YAML形式の氏名データを読み取るリーダー（省略可）。
            /// 省略した場合は、アセンブリに埋め込まれた既定の氏名データが使用されます。
            /// </param>
            /// <example>
            /// <para>
            /// YAML形式の住所データの例を次に示します。
            /// </para>
            /// <code language="yaml">
            /// addresses:
            ///   prefecture:
            ///     - ['群馬県', 'ぐんまけん', 'グンマケン']
            ///     - ['長野県', 'ながのけん', 'ナガノケン']
            ///   city:
            ///     - ['山本郡藤里町', 'やまもとぐんふじさとまち', 'ヤマモトグンフジサトマチ']
            ///     - ['遠賀郡岡垣町', 'おんがぐんおかがきまち', 'オンガグンオカガキマチ']
            ///   town:
            ///     - ['吾妻橋', 'あづまばし', 'アヅマバシ']
            ///     - ['米山町愛宕前', 'よねやまちょうあたごまえ', 'ヨネヤマチョウアタゴマエ']
            ///     - ['宇目河内', 'うめかわち', 'ウメカワチ']
            /// </code>
            /// <para>
            /// YAML形式の氏名データの例を次に示します。
            /// </para>
            /// <code language="yaml">
            /// first_name:
            ///   male:
            ///     - ['修斗', 'しゅうと', 'シュウト']
            ///     - ['天', 'てん', 'テン']
            ///     - ['弘志', 'ひろし', 'ヒロシ']
            ///     - ['円', 'まどか', 'マドカ']
            ///   female:
            ///     - ['杏樹', 'あんじゅ', 'アンジュ']
            ///     - ['智未', 'さとみ', 'サトミ']
            ///     - ['晴子', 'はるこ', 'ハルコ']
            ///     - ['雅美', 'まさみ', 'マサミ']
            /// 
            /// last_name:
            ///   - ['佐藤', 'さとう', 'サトウ']
            ///   - ['林', 'はやし', 'ハヤシ']
            ///   - ['清水', 'しみず', 'シミズ']
            ///   - ['鈴木', 'すずき', 'スズキ']
            ///   - ['高橋', 'たかはし', 'タカハシ']
            /// </code>
            /// </example>
            public Generator(Random random = null, TextReader addresses = null, TextReader names = null)
            {
                _r = random ?? new Random();
                if (addresses == null)
                {
                    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DotGimei.data.addresses.yml"))
                    {
                        _addresses = Addresses.Load(new StreamReader(stream));
                    }
                }
                else
                {
                    _addresses = Addresses.Load(addresses);
                }
                if (names == null)
                {
                    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DotGimei.data.names.yml"))
                    {
                        _names = Names.Load(new StreamReader(stream));
                    }
                }
                else
                {
                    _names = Names.Load(names);
                }
            }
            /// <summary>
            /// <see cref="Name"/>オブジェクトをランダムに返します。
            /// およそ1/2ずつの確率で、男性名もしくは女性名が返ります。
            /// </summary>
            /// <returns><see cref="Name"/>オブジェクト。</returns>
            public Name NewName()
            {
                return _r.Next() % 2 == 0 ? NewMale() : NewFemale();
            }
            /// <summary>
            /// 男性名の<see cref="Name"/>オブジェクトをランダムに返します。
            /// </summary>
            /// <returns>男性名の<see cref="Name"/>オブジェクト。</returns>
            public Name NewMale()
            {
                return _names.NextMale(_r);
            }
            /// <summary>
            /// 女性名の<see cref="Name"/>オブジェクトをランダムに返します。
            /// </summary>
            /// <returns><see cref="Name"/>女性名のオブジェクト。</returns>
            public Name NewFemale()
            {
                return _names.NextFemale(_r);
            }
            /// <summary>
            /// <see cref="Address"/>オブジェクトをランダムに返します。
            /// 都道府県名、市区町村名、町字名がランダムに組み合わされるため、ほとんどの場合は実在しない住所となります。
            /// </summary>
            /// <returns><see cref="Address"/>オブジェクト。</returns>
            public Address NewAddress()
            {
                return _addresses.Next(_r);
            }
            /// <summary>
            /// 都道府県名を表す<see cref="JapaneseText"/>オブジェクトをランダムに返します。
            /// </summary>
            /// <returns>都道府県名を表す<see cref="JapaneseText"/>オブジェクト。</returns>
            public JapaneseText NewPrefecture()
            {
                return NewAddress().Prefecture;
            }
            /// <summary>
            /// 市区町村名を表す<see cref="JapaneseText"/>オブジェクトをランダムに返します。
            /// </summary>
            /// <returns>市区町村名を表す<see cref="JapaneseText"/>オブジェクト。</returns>
            public JapaneseText NewCity()
            {
                return NewAddress().City;
            }
            /// <summary>
            /// 町字名を表す<see cref="JapaneseText"/>オブジェクトをランダムに返します。
            /// </summary>
            /// <returns>町字名を表す<see cref="JapaneseText"/>オブジェクト。</returns>
            public JapaneseText NewTown()
            {
                return NewAddress().Town;
            }
        }
    }
}

