using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;
using System.Text;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterIndex;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer;

[TestClass]
public class CustomCountingTests
{
    [TestMethod]
    public void __667__()
    {
        var allCharachters = "ا ب ت ث ج ح خ د ذ ر ز س ش ص ض ط ظ ع غ ف ق ك ل م ن ه و ي";
        var allCharachtersNumericValues = "1 2 400 500 3 8 600 4 700 200 7 60 300 90 800 9 900 70 1000 80 100 20 30 40 50 5 6 10";
        var targetLength = 12;
        var requestedNumericValue = 667;
        var requestedOrderNumber = 109;

        var allCharachtersAsList = allCharachters.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x[0]).ToImmutableList();
        var allCharachtersNumericValuesAsList = allCharachtersNumericValues.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToImmutableList();

        if (allCharachtersAsList.Count != allCharachtersNumericValuesAsList.Count)
        {
            throw new Exception("wrong input");
        }

        const int maxOccurenceLength = 3;
        
        BigInteger numberOfProcessedItem = 0;

        BigInteger numberOfFounds = 0;

        for (var i0 = 0; i0 < maxOccurenceLength; i0++)
        {
            var v0 = allCharachtersNumericValuesAsList[i0];
            var o0 = i0 + 1;
            
            for (var i1 = 0; i1 < maxOccurenceLength; i1++)
            {
                var v1 = allCharachtersNumericValuesAsList[i1];
                var o1 = i1 + 1;
                
                var sum1 = v0 + v1;
                var orderSum1 = o0 + o1;
                
                for (var i2 = 0; i2 < maxOccurenceLength; i2++)
                {
                    var v2 = allCharachtersNumericValuesAsList[i2];
                    var o2 = i2 + 1;

                    var sum2 = sum1 + v2;
                    var orderSum2 = orderSum1 + o2;
                    
                    for (var i3 = 0; i3 < maxOccurenceLength; i3++)
                    {
                        var v3 = allCharachtersNumericValuesAsList[i3];
                        var o3 = i3 + 1;
                        
                        var sum3 = sum2 + v3;
                        var orderSum3 = orderSum2 + o3;
                        
                        for (var i4 = 0; i4 < maxOccurenceLength; i4++)
                        {
                            var v4 = allCharachtersNumericValuesAsList[i4];
                            var o4 = i4 + 1;

                            var sum4 = sum3 + v4;
                            var orderSum4 = orderSum3 + o4;
                            
                            for (var i5 = 0; i5 < maxOccurenceLength; i5++)
                            {
                                var v5 = allCharachtersNumericValuesAsList[i5];
                                var o5 = i5 + 1;
                                
                                var sum5 = sum4 + v5;
                                var orderSum5 = orderSum4 + o5;
                                
                                for (var i6 = 0; i6 < maxOccurenceLength; i6++)
                                {
                                    var v6 = allCharachtersNumericValuesAsList[i6];
                                    var o6 = i6 + 1;
                                    
                                    var sum6 = sum5 + v6;
                                    var orderSum6 = orderSum5 + o6;
                                    
                                    for (var i7 = 0; i7 < maxOccurenceLength; i7++)
                                    {
                                        var v7 = allCharachtersNumericValuesAsList[i7];
                                        var o7 = i7 + 1;
                                        
                                        var sum7 = sum6 + v7;
                                        var orderSum7 = orderSum6 + o7;
                                        
                                        for (var i8 = 0; i8 < maxOccurenceLength; i8++)
                                        {
                                            var v8 = allCharachtersNumericValuesAsList[i8];
                                            var o8 = i8 + 1;
                                            
                                            var sum8 = sum7 + v8;
                                            var orderSum8 = orderSum7 + o8;
                                            
                                            for (var i9 = 0; i9 < maxOccurenceLength; i9++)
                                            {
                                                var v9 = allCharachtersNumericValuesAsList[i9];
                                                var o9 = i9 + 1;
                                                
                                                var sum9 = sum8 + v9;
                                                var orderSum9 = orderSum8 + o9;
                                                
                                                for (var i10 = 0; i10 < maxOccurenceLength; i10++)
                                                {
                                                    var v10 = allCharachtersNumericValuesAsList[i10];
                                                    var o10 = i10 + 1;
                                                    
                                                    
                                                    var sum10 = sum9 + v10;
                                                    var orderSum10 = orderSum9 + o10;
                                                    
                                                    for (var i11 = 0; i11 < maxOccurenceLength; i11++)
                                                    {
                                                        var v11 = allCharachtersNumericValuesAsList[i11];
                                                        var o11 = i11 + 1;

                                                        var sum = sum10 + v11;

                                                        var orderSum = orderSum10 + o11;

                                                        if (sum == 667 && orderSum == 109)
                                                        {
                                                            numberOfFounds++;
                                                        }

                                                        numberOfProcessedItem++;
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
                
            }
            
        }
                            
        
        
        

        throw new Exception($"Total combination: {numberOfProcessedItem}, numberOfFounds: {numberOfFounds}");
        
        static IEnumerable<string> CreateCombinations(string input, int length)
        {
            foreach (var c in input)
            {
                if (length == 1)
                {
                    yield return c.ToString();
                }
                else
                {
                    foreach (var s in CreateCombinations(input, length - 1))
                    {
                        yield return c + s;
                    }
                }
            }
        }

        static bool isOk(string value)
        {
            return Calculator.GetNumericValue(value) == 667 && Calculator.GetOrderValue(value) == 109;
        }
    }

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

 
}