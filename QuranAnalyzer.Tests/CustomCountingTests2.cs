using System;
using System.Collections.Generic;
using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer;

[TestClass]
public class CustomCountingTests2
{
    [TestMethod]
    public void AllWordsTest()
    {
        var arabicText = QuranArabicVersionWithNoBismillah.AllQuranAsString;

        var lines = arabicText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(QuranArabicVersionWithNoBismillah.TryParseVerseNumbers).ToList();

        var allWords = new List<string>();
        

        allWords.AddRange(lines.SelectMany(x => x.verseText.Split(' ', StringSplitOptions.RemoveEmptyEntries)));
        
        allWords.AddRange(QuranArabicVersionChapterNames.ChapterNames);
        
        allWords = allWords.Distinct().ToList();


        
        


        
    }
    [TestMethod]
    public void ABC()
    {
        Console.WriteLine("S T A R T E D");
        
        //var bismillah = AnalyzeText("بِسْمِ ٱللَّهِ ٱلرَّحْمَٰنِ ٱلرَّحِيمِ");

        var inputA = AnalyzeText(string.Empty+Baa + Raa + Kaaf + Raa + Yaa + Waaw  +Raa + Kaaf + Waaw + Jiim);
        var inputB = AnalyzeText(string.Empty + Raa + Shiin + Alif + Daal + Khaa + Laam + Yaa + Faa + Haa_);
        
        var arabicText = QuranArabicVersionWithNoBismillah.AllQuranAsString;

        var lines = arabicText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(QuranArabicVersionWithNoBismillah.TryParseVerseNumbers).ToList();

        var allVerseList = lines.Select(x => new
        {
            ChapterNumber =x.chapterNumber,
            VerseNumber   = x.verseNumber, 
            Letters       = AnalyzeText(x.verseText),
            CountA        = getCountA(x.verseText),
            CountB        = getCountB(x.verseText)
        }).ToList();

        var matchedIndexes = new List<(int start, int end, int count)>();

        {
            for (var i = 0; i < allVerseList.Count; i++)
            {
                //if (allVerseList[i].ChapterNumber != 44)
                //{
                //    continue;
                //}
            
            
            
                for (var j = i + 1; j < allVerseList.Count; j++)
                {
                    if (j - i < 5)
                    {
                        continue;
                    }
                
                    var matchResult = hasMatch(i, j);
                    if (matchResult.success)
                    {
                        Console.WriteLine($"Start: {i} - End: {j} : Count: {matchResult.count}");
                        matchedIndexes.Add((i, j, matchResult.count));
                    }
                }
            }
        }

        Console.WriteLine("Matched Indexes:");
        matchedIndexes.ForEach(x => Console.WriteLine($"{x.start} - {x.end} : {x.count}"));
        
        Console.WriteLine("F I N I S H E D");
        return;

        int getCountA(string verseText)
        {
            var letters = AnalyzeText(verseText);

            return inputA.Sum(letterInfo => letters.Count(x => x.OrderValue == letterInfo.OrderValue));
        }

        int getCountB(string verseText)
        {
            var letters = AnalyzeText(verseText);

            return inputB.Sum(letterInfo => letters.Count(x => x.OrderValue == letterInfo.OrderValue));
        }

        (bool success, int count) hasMatch(int verseIndexStart, int verseIndexEnd)
        {
            var countA = 0;
            var countB = 0;
                
            for (var i = verseIndexStart; i < verseIndexEnd; i++)
            {
                countA += allVerseList[i].CountA;
                countB += allVerseList[i].CountB;
            }
            if (countA == 0)
            {
                return default;
            }
            if (countA == countB)
            {
                return (true, countA);
            }

            return default;
        }
    }
}