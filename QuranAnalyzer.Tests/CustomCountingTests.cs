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
                sb.Append(verse.IndexAsNumber);
            }
        }

        var num = BigInteger.Parse(sb.ToString());

        var remaining = num % 667;

        remaining.ShouldBe(114);
    }

    [TestMethod]
    public void LatinAllphabetEbjedCalculate()
    {
        var input = new
        {
            LatinText = "abc",

            LatinCharToArabicCharMap
        };

        var map = GetLatinCharToArabicCharMap(input.LatinCharToArabicCharMap);

        6.ShouldBe((
            from c in input.LatinText.ToCharArray()
            let letterInfo = map.ContainsKey(c) switch
            {
                true  => map[c],
                false => new()
            }
            select letterInfo.NumericValue
        ).Sum());

        6.ShouldBe((
            from c in input.LatinText.ToCharArray()
            let letterInfo = map.ContainsKey(c) switch
            {
                true  => map[c],
                false => new()
            }
            select letterInfo.OrderValue
        ).Sum());
    }
}