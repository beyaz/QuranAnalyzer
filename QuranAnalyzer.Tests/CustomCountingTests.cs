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

                        for (var i4 = minValue; i4 < maxValue; i4++)
                        {
                            var remainingTotalSum_4 = remainingTotalSum_3 - i4;
                            var remainingTotalSumOfNumbers_4 = remainingTotalSumOfNumbers_3 - sumOfNumbers(i4);

                            iterationCount++;
                                                
                            if (remainingTotalSum_4 == 0 &&
                                remainingTotalSumOfNumbers_4 == 0)
                            {
                                sb.AppendLine($"{i0}, {i1}, {i2}, {i3}, {i4}");
                            }
                        }
                    }
                }
            }
        }
        
        /*for (var i0 = minValue; i0 < maxValue; i0++)
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

                        for (var i4 = minValue; i4 < maxValue; i4++)
                        {
                            var remainingTotalSum_4 = remainingTotalSum_3 - i4;
                            var remainingTotalSumOfNumbers_4 = remainingTotalSumOfNumbers_3 - sumOfNumbers(i4);

                            for (var i5 = minValue; i5 < maxValue; i5++)
                            {
                                var remainingTotalSum_5 = remainingTotalSum_4 - i5;
                                var remainingTotalSumOfNumbers_5 = remainingTotalSumOfNumbers_4 - sumOfNumbers(i5);

                                for (var i6 = minValue; i6 < maxValue; i6++)
                                {
                                    var remainingTotalSum_6 = remainingTotalSum_5 - i6;
                                    var remainingTotalSumOfNumbers_6 = remainingTotalSumOfNumbers_5 - sumOfNumbers(i6);
                                    
                                    for (var i7 = minValue; i7 < maxValue; i7++)
                                    {
                                        var remainingTotalSum_7 = remainingTotalSum_6 - i7;
                                        var remainingTotalSumOfNumbers_7 = remainingTotalSumOfNumbers_6 - sumOfNumbers(i7);

                                        for (var i8 = minValue; i8 < maxValue; i8++)
                                        {
                                            var remainingTotalSum_8 = remainingTotalSum_7 - i8;
                                            var remainingTotalSumOfNumbers_8 = remainingTotalSumOfNumbers_7 - sumOfNumbers(i8);

                                            for (var i9 = minValue; i9 < maxValue; i9++)
                                            {
                                                var remainingTotalSum_9 = remainingTotalSum_8 - i9;
                                                var remainingTotalSumOfNumbers_9 = remainingTotalSumOfNumbers_8 - sumOfNumbers(i9);

                                                iterationCount++;
                                                
                                                if (remainingTotalSum_9 == 0 &&
                                                    remainingTotalSumOfNumbers_9 == 0)
                                                {
                                                    sb.AppendLine($"{i0}, {i1}, {i2}, {i3}, {i4}, {i5}, {i6}, {i7}, {i8}, {i9}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }*/

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