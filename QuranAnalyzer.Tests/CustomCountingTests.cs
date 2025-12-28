using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer;

[TestClass]

public class CustomCountingTests
{
    
    
    //[TestMethod]
    public void ______1()
    {
        var verseCount = 0;

        var totalSum = 0;

        var verseList = GetVerseList("*,-9:128,-9:129").Value;
        foreach (var verse in verseList)
        {
            verseCount++;

            totalSum += getCount(verse, Baa, Raa, Kaaf, Raa, Yaa, Waaw, Raa, Kaaf, Waaw, Jiim);

            if (verseCount == 2280)
            {
                break;
            }
        }

        totalSum.Should().Be(667 * 114);

        static int getCount(Verse verse, params int[] arabicLetterOrderValues)
        {
            var option = new MushafOption();
            return arabicLetterOrderValues.Select(orderValueOfLetter => GetCountOfLetterInVerse(verse, orderValueOfLetter, option, false)).Sum();
        }
    }

    //[TestMethod]
    public void LastN()
    {
        var verseCount = 0;

        var totalSum = 0;

        var totalSaad = 0;

        var chapterIndex = 114;
        while (--chapterIndex >= 0)
        {
            var chapter = DataAccess.AllChapters[chapterIndex];

            var verseIndex = chapter.Verses.Count;
            while (--verseIndex >= 0)
            {
                var verse = chapter.Verses[verseIndex];

                if (verseCount < 667)
                {
                    verseCount++;
                    totalSum += getCount(verse, Baa, Raa, Kaaf, Yaa, Waaw, Jiim);
                    
                    totalSaad += getCount(verse, Saad);
                }
                else
                {
                    // ReSharper disable once EmptyStatement
                    ;
                }
            }
        }

        totalSum.Should().Be(190 * 19);
        totalSaad.Should().Be(5 * 19);

        static int getCount(Verse verse, params int[] arabicLetterOrderValues)
        {
            var option = new MushafOption();
            return arabicLetterOrderValues
                .Select(orderValueOfLetter => GetCountOfLetterInVerse(verse, orderValueOfLetter, option, true)).Sum();
        }
    }

   // [TestMethod]
    public void All_Saad_Combined_as_ChapterNumber_VerseNumber_is_114_667()
    {
        var sb = new StringBuilder();

        var option = new MushafOption();

        var verseList = GetVerseList("*,-9:128,-9:129").Value;
        foreach (var verse in verseList)
        {
            var count = GetCountOfLetterInVerse(verse, Saad, option, true);
            if (count > 0)
            {
                sb.Append(verse.ChapterNumber);
                sb.Append(verse.IndexAsNumber);
            }
        }

        var num = BigInteger.Parse(sb.ToString());

        var remaining = num % 667;

        remaining.Should().Be(114);
    }

    [TestMethod]
    public void LatinAllphabetEbjedCalculate()
    {
        var input = new
        {
            LatinText = "abdullah",

            AraibicToLatinAlphabetMap
                = """
                  a : ا    b : ب    c : ج    d : د
                  f : ف    ç : ج    g : ك    h : ح
                  i : ي    j : ج    k : ك    l : ل
                  m : م    n : ن    o : و    p : پ
                  q : ق    r : ر    s : س    t : ت
                  u : ع    v : ڤ    w : و    ö : و
                  ü : و    x : خ    y : ي    z : ز
                  """
        };


        var pairList = 
            from pair in input.AraibicToLatinAlphabetMap.Split(',')
            select (latin: pair.Split('=')[0][0], arabic: pair.Split('=')[1][0]);

        var map = pairList.ToDictionary(x => x.latin);

        var query = 
            from c in input.LatinText.ToCharArray()
            let letterInfo = map.ContainsKey(c) switch
            {
                true=>Analyzer.GetLetterInfo(map[c].arabic, 0, true),
                false=>new LetterInfo(),
            }
            select letterInfo.NumericValue;

        var sum = query.Sum();
        
        sum.Should().Be(146);



    }
   
}