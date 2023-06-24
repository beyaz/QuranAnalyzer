using System.Numerics;
using System.Text;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer;

[TestClass]
public class CustomCountingTests
{
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

        remaining.Should().Be(114);
    }
    
    
    [TestMethod]
    public void ______1()
    {
        var verseCount = 0;

        var totalSum = 0;
        
        var verseList = GetVerseList("*,-9:128,-9:129").Value;
        foreach (var verse in verseList)
        {
            verseCount++;
            
            totalSum += getCount(verse, Baa, Raa, Kaaf,Raa, Yaa, Waaw,Raa,Kaaf,Waaw, Jiim);

            if (verseCount == 2280)
            {
                break;
            }
        }

        totalSum.Should().Be(667*114);

        static int getCount(Verse verse, params int[] arabicLetterOrderValues)
        {
            var option = new MushafOption();
            return Enumerable.Sum(arabicLetterOrderValues.Select(orderValueOfLetter => GetCountOfLetterInVerse(verse, orderValueOfLetter, option, false)));
        }
    }
}