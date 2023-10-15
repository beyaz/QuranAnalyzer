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
    
    [TestMethod]
    public void CheckSpecialNumberProbability()
    {
        var table = new List<List<int>>();

        //Calculate(table, new List<int> { 0, 0 }, 0, 23, 5);

        // Calculate(table, new List<int> { 0,0,0 },0, 36, 9);
        
        // Calculate(table, new List<int> { 0,0,0,0,0 },0, 65, 20);
        
        Calculate(table, new List<int> { 0,0,0,0,0,0,0,0 },0, 667, 109);

        var sb = new StringBuilder();
        foreach (var list in table)
        {
            sb.AppendLine(string.Join(", ", list));
        }

        if (table.Count == 0)
        {
            sb.AppendLine("Count is zero.");
        }

        throw new Exception(sb.ToString());

        static void Calculate(List<List<int>> table, List<int> numberList, int numberIndex, int remainingTotalSum, int remainingTotalSumOfNumbers)
        {
            if (numberIndex == numberList.Count)
            {
                var hasMatch = remainingTotalSum == 0 && remainingTotalSumOfNumbers == 0;
                if (hasMatch)
                {
                    table.Add(new List<int>(numberList));
                }

                return;
            }



            //numberIndex++;

            for (var i = numberIndex; i < numberList.Count; i++)
            {
                for (var j = 1; j <= 130; j++)
                {
                    numberList[i] = j;
                    
                    Calculate(table,numberList, i + 1, remainingTotalSum - j, remainingTotalSumOfNumbers - sumOfNumbers(j));
                }
                
            }
            
            
            

        }

        static int sumOfNumbers(int number)
        {
            return number.ToString().Select(c => int.Parse(c.ToString())).Sum();
        }
    }
    
    
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
}