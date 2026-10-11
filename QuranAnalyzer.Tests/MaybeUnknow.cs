using System.Numerics;
using System.Text;

namespace QuranAnalyzer;

[TestClass]
public class MaybeUnknow
{
    [TestMethod]
    public void All_Sad_Combined_as_ChapterNumber_VerseNumber_is_114_667()
    {
        var sb = new StringBuilder();

        var option = new MushafOption();

        var verseList = VerseFilter.GetVerseList("*,-9:128,-9:129").Value;
        foreach (var verse in verseList)
        {
            var count = QuranAnalyzerMixin.GetCountOfLetterInVerse(verse, ArabicLetterOrder.Sad, option, true);
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
}