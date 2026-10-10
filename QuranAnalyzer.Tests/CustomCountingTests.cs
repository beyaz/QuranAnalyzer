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
    public void Zkr()
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
               where map.ContainsKey(c) && map[c].IsArabic select map[c]
        ];


        // 19:* should be 109 * 17
        {
            var query =
                from verse in AllQuranVerses.Where(x => x.ChapterNumber == 19).Select(x => x.Verse)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(109 * 17);
        }

        // *:19 should be 114 * 17
        {
            var query =
                from verse in AllQuranVerses.Where(x => x.VerseNumber == 19).Select(x => x.Verse)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(114 * 17);
        }

        // 19:19 should be 17
        {
            var query =
                from verse in AllQuranVerses.Where(x => x.ChapterNumber == 19 && x.VerseNumber == 19).Select(x => x.Verse)
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