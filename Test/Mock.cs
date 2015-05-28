using DotGimei;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Mock
    {
        public static Gimei.Generator SingleDataGenerator()
        {
            var addressesReader = new StringReader(
@"addresses:
  prefecture:
    - ['東京都', 'とうきょうと', 'トウキョウト']
  city:
    - ['千代田区', 'ちよだく', 'チヨダク']
  town:
    - ['千代田', 'ちよだ', 'チヨダ']");

            var namesReader = new StringReader(
@"first_name:
  male:
    - ['翔太', 'しょうた', 'ショウタ']
  female:
    - ['美咲', 'みさき', 'ミサキ']
last_name:
  - ['佐藤', 'さとう', 'サトウ']");

            return new Gimei.Generator(addresses: addressesReader, names: namesReader);
        }
    }
}
