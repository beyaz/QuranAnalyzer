using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer;

[TestClass]
public class Zkr
{
    const string LatinCharToArabicCharMap =
        """

        a : ا  ,  b : ب  ,  c : ج  ,  d : د  ,
        f : ف  ,  ç : ج  ,  g : ك  ,  h : ح  ,
        i : ي  ,  j : ج  ,  k : ك  ,  l : ل  ,
        m : م  ,  n : ن  ,  o : و  ,  p : پ  ,
        q : ق  ,  r : ر  ,  s : س  ,  t : ت  ,
        u : ع  ,  v : ڤ  ,  w : و  ,  ö : و  ,
        ü : و  ,  x : خ  ,  y : ي  ,  z : ز  ,

        """;

    [TestMethod]
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
                sb.Append(verse.VerseNumber);
            }
        }

        var num = BigInteger.Parse(sb.ToString());

        var remaining = num % 667;

        remaining.ShouldBe(114);
    }

    [TestMethod]
    public void ___A()
    {
        var input = new
        {
            LatinText = "berker yörgüç",

            LatinCharToArabicCharMap
        };

        IReadOnlyList<LetterInfo> searchLetters =
        [
            .. from c in input.LatinText.ToCharArray()
               let map = GetLatinCharToArabicCharMap(input.LatinCharToArabicCharMap)
               where map.ContainsKey(c) && map[c].IsArabic
               select map[c]
        ];

        // Page: 41
        {
            {
                var query =
                    from verse in Filter(x => x.ChapterNumber == 37 && x.VerseNumber == 181)
                    from letter in verse.TextLetters
                    select letter.NumericValue;

                query.Sum().ShouldBe(667);
            }

            {
                var searchWord = AnalyzeText("الْمرْسلِي");
                
                var query =
                    from verse in Filter(x => true)
                    from range in  verse.GetStartAndEndPointsOfStartsWithWords(searchWord)
                    where range.start.NumericValue >= 0
                    from letter in verse.TextLetters
                    select new[]{ArabicLetter.Baa, ArabicLetter.Raa, ArabicLetter.Kaaf }.Select(x => AnalyzeText(x.ToString())[0]).Count(x => IsSame(x, letter));

                query.Sum().ShouldBe(114);
            }
        }
        
        // 19:* should be 109 * 17
        {
            var query =
                from verse in Filter(x => x.ChapterNumber == 19)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(109 * 17);
        }

        // *:19 should be 114 * 17
        {
            var query =
                from verse in Filter(x => x.VerseNumber == 19)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(114 * 17);
        }

        // 19:19 should be 17
        {
            var query =
                from verse in Filter(x => x.ChapterNumber == 19 && x.VerseNumber == 19)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(17);
        }

        // Numeric value should be 667
        {
            var query =
                from letter in searchLetters
                select letter.NumericValue;

            query.Sum().ShouldBe(667);
        }

        // order value should be 109
        {
            var query =
                from letter in searchLetters
                select letter.OrderValue;

            query.Sum().ShouldBe(109);
        }
        return;

        static IEnumerable<Verse> Filter(Func<Verse, bool> predicate)
        {
            return AllQuranVerses.Where(x => predicate(x.Verse)).Select(x => x.Verse);
        }

        static bool IsSame(LetterInfo a, LetterInfo b)
        {
            if (a is null || b is null)
            {
                return false;
            }

            if (a.NumericValue > 0 && a.NumericValue == b.NumericValue)
            {
                return true;
            }

            return false;
        }
    }
}