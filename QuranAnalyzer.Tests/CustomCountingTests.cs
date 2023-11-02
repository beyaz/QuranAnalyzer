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
        var sb = new StringBuilder();
        
        const int minValue = 1;
        const int maxValue = 130;
        const int requestedTotalSumOfNumbers = 109;
        const int requestedTotalSum = 667;

        var iterationCount = 0L;

        for (var i0 = minValue; i0 < maxValue; i0++)
        {
            var remainingTotalSum_0 = requestedTotalSum - i0;
            var remainingTotalSumOfNumbers_0 = requestedTotalSumOfNumbers - sumOfNumbers(i0);

            for (var i1 = minValue; i1 < maxValue; i1++)
            {
                var remainingTotalSum_1 = remainingTotalSum_0 - i1;
                var remainingTotalSumOfNumbers_1 = remainingTotalSumOfNumbers_0 - sumOfNumbers(i1);

                for (var i2 = minValue; i2 < maxValue; i2++)
                {
                    var remainingTotalSum_2 = remainingTotalSum_1 - i2;
                    var remainingTotalSumOfNumbers_2 = remainingTotalSumOfNumbers_1 - sumOfNumbers(i2);

                    for (var i3 = minValue; i3 < maxValue; i3++)
                    {
                        var remainingTotalSum_3 = remainingTotalSum_2 - i3;
                        var remainingTotalSumOfNumbers_3 = remainingTotalSumOfNumbers_2 - sumOfNumbers(i3);

                        iterationCount++;
                        if (remainingTotalSum_3 == 0 &&
                            remainingTotalSumOfNumbers_3 == 0)
                        {
                            sb.AppendLine($"{i0}, {i1}, {i2}, {i3}");
                        }
                    }
                }
            }
        }

        throw new Exception($"Iteration: {iterationCount}, items: {sb}");


        static int sumOfNumbers(int number)
        {
            if (number < 10)
            {
                return number;
            }
            
            if (number < 100)
            {
                var second = number%10;

                var first = (number - second) / 10;

                return first + second;
            }
            
            if (number < 1000)
            {
                var part_2_3 = number % 100;
                
                var third = part_2_3 % 10;

                var second = (part_2_3 - third) / 10;

                var first = (number - part_2_3) / 100;

                return first + second + third;
            }
            
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