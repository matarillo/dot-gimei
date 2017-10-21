# dot-gimei
.NET port of [gimei](https://github.com/willnet/gimei), inspired by [go-gimei](https://github.com/mattn/go-gimei)

## Installation
Available via [Nuget](https://www.nuget.org/packages/dot-gimei/)

```powershell
PM> Install-Package dot-gimei
```

## Usage
```csharp
using System;
using DotGimei;

class Program
{
    public static void Main(string[] args)
    {
        var name = Gimei.NewName();
        Console.WriteLine(name);                // 斎藤 陽菜
        Console.WriteLine(name.Kanji);          // 斎藤 陽菜
        Console.WriteLine(name.Hiragana);       // さいとう はるな
        Console.WriteLine(name.Katakana);       // サイトウ ハルナ
        Console.WriteLine(name.Last.Kanji);     // 斎藤
        Console.WriteLine(name.Last.Hiragana);  // さいとう
        Console.WriteLine(name.Last.Katakana);  // サイトウ
        Console.WriteLine(name.First.Kanji);    // 陽菜
        Console.WriteLine(name.First.Hiragana); // はるな
        Console.WriteLine(name.First.Katakana); // ハルナ
        Console.WriteLine(name.IsMale);         // false

        var male = Gimei.NewMale();
        Console.WriteLine(male);          // 小林 顕士
        Console.WriteLine(male.IsMale);   // true
        Console.WriteLine(male.IsFemale); // false

        var address = Gimei.NewAddress();
        Console.WriteLine(address);                     // 岡山県大島郡大和村稲木町
        Console.WriteLine(address.Kanji);               // 岡山県大島郡大和村稲木町
        Console.WriteLine(address.Hiragana);            // おかやまけんおおしまぐんやまとそんいなぎちょう
        Console.WriteLine(address.Katakana);            // オカヤマケンオオシマグンヤマトソンイナギチョウ
        Console.WriteLine(address.Prefecture);          // 岡山県
        Console.WriteLine(address.Prefecture.Kanji);    // 岡山県
        Console.WriteLine(address.Prefecture.Hiragana); // おかやまけん
        Console.WriteLine(address.Prefecture.Katakana); // オカヤマケン
        Console.WriteLine(address.Town);                // 大島郡大和村
        Console.WriteLine(address.Town.Kanji);          // 大島郡大和村
        Console.WriteLine(address.Town.Hiragana);       // おおしまぐんやまとそん
        Console.WriteLine(address.Town.Katakana);       // オオシマグンヤマトソン
        Console.WriteLine(address.City);                // 稲木町
        Console.WriteLine(address.City.Kanji);          // 稲木町
        Console.WriteLine(address.City.Hiragana);       // いなぎちょう
        Console.WriteLine(address.City.Katakana);       // イナギチョウ

        var prefecture = Gimei.NewPrefecture();
        Console.WriteLine(prefecture); // 青森県
    }
}
```
## Notes

* [Default data](https://github.com/matarillo/dot-gimei/tree/master/data) is embedded into the DLL.
* If you want to replace the default data into custom one, use [Generator](https://github.com/matarillo/dot-gimei/blob/8bfb595576b61c6c30ea1a686346f9a170b7400b/DotGimei/Gimei.cs#L118) class.
* Now [Name](https://github.com/matarillo/dot-gimei/blob/master/DotGimei/Name.cs) class has a property `Gender` which type is [GenderIdentity](https://github.com/matarillo/dot-gimei/blob/master/DotGimei/GenderIdentity.cs).

## License
MIT

## Author
INOMATA Kentaro (@matarillo)
