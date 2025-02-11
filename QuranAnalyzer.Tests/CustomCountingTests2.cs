using System;
using System.Collections.Generic;
using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer;

[TestClass]
public class CustomCountingTests2
{
    [TestMethod]
    public void ABC()
    {
        Console.WriteLine("S T A R T E D");
        
        //var bismillah = AnalyzeText("بِسْمِ ٱللَّهِ ٱلرَّحْمَٰنِ ٱلرَّحِيمِ");

        var inputA = AnalyzeText(string.Empty+Baa + Raa + Kaaf + Raa + Yaa + Waaw  +Raa + Kaaf + Waaw + Jiim);
        var inputB = AnalyzeText(string.Empty + Raa + Shiin + Alif + Daal + Khaa + Laam + Yaa + Faa + Haa_);
        
        var arabicText = QuranArabicVersionWithNoBismillah.AllQuranAsString;

        var lines = arabicText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(QuranArabicVersionWithNoBismillah.TryParseVerseNumbers).ToList();

        var allVerseList = lines.Select(x => new { ChapterNumber=x.chapterNumber, VerseNumber = x.verseNumber, Letters = AnalyzeText(x.verseText) }).ToList();

        var matchedIndexes = new List<(int start, int end, int count)>();
        
        for (var i = 0; i < allVerseList.Count; i++)
        {
            for (var j = i + 1; j < allVerseList.Count; j++)
            {
                var matchResult = hasMatch(i, j);
                if (matchResult.success)
                {
                    Console.WriteLine($"Start: {i} - End: {j} : Count: {matchResult.count}");
                    matchedIndexes.Add((i, j, matchResult.count));
                }
            }
        }

        Console.WriteLine("Matched Indexes:");
        matchedIndexes.ForEach(x => Console.WriteLine($"{x.start} - {x.end} : {x.count}"));
        
        Console.WriteLine("F I N I S H E D");


        (bool success, int count) hasMatch(int verseIndexStart, int verseIndexEnd)
        {
            var countA = getCount(verseIndexStart, verseIndexEnd, inputA);
            if (countA == 0)
            {
                return default;
            }
            var countB = getCount(verseIndexStart, verseIndexEnd, inputB);

            if (countA == countB)
            {
                return (true, countA);
            }

            return default;
        }
        
        int getCount(int verseIndexStart, int verseIndexEnd, IReadOnlyList<LetterInfo> searchLetters)
        {
            var sum = 0;
            foreach (var searchLetter in searchLetters)
            {
                var count = getLetterCountInRange(searchLetter);
                if (count == 0)
                {
                    return 0;
                }
                
                sum += count;
            }
            return sum;

            int getLetterCountInRange(LetterInfo letterInfo)
            {
                var count = 0;
                
                for (var i = verseIndexStart; i < verseIndexEnd; i++)
                {
                    //if (allVerseList[i].ChapterNumber != 9)
                    //{
                    //    if (allVerseList[i].VerseNumber == 0)
                    //    {
                    //        count += bismillah.Count(x => x.OrderValue == letterInfo.OrderValue);        
                    //    }
                    //}
                    
                    count += allVerseList[i].Letters.Count(x => x.OrderValue == letterInfo.OrderValue);
                }
                
                return count;
            }
        }

    }
}