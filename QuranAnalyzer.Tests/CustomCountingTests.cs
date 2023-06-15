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

        BigInteger numberOfProcessedItem = 0;

        BigInteger numberOfFounds = 0;

        var allLetters = string.Join(string.Empty, allCharachtersAsList);

        for (var i0 = 0; i0 < 28; i0++)
            for (var i1 = 0; i1 < 28; i1++)
                for (var i2 = 0; i2 < 28; i2++)
                    for (var i3 = 0; i3 < 28; i3++)
                        for (var i4 = 0; i4 < 28; i4++)
                            for (var i5 = 0; i5 < 28; i5++)
                                for (var i6 = 0; i6 < 28; i6++)
                                    for (var i7 = 0; i7 < 28; i7++)
                                        for (var i8 = 0; i8 < 28; i8++)
                                            for (var i9 = 0; i9 < 28; i9++)
                                                for (var i10 = 0; i10 < 28; i10++)
                                                    for (var i11 = 0; i11 < 28; i11++)
                                                    {

                                                        var sum = allCharachtersNumericValuesAsList[i0] +
                                                                  allCharachtersNumericValuesAsList[i1] +
                                                                  allCharachtersNumericValuesAsList[i2] +
                                                                  allCharachtersNumericValuesAsList[i3] +
                                                                  allCharachtersNumericValuesAsList[i4] +
                                                                  allCharachtersNumericValuesAsList[i5] +
                                                                  allCharachtersNumericValuesAsList[i6] +
                                                                  allCharachtersNumericValuesAsList[i7] +
                                                                  allCharachtersNumericValuesAsList[i8] +
                                                                  allCharachtersNumericValuesAsList[i9] +
                                                                  allCharachtersNumericValuesAsList[i10] +
                                                                  allCharachtersNumericValuesAsList[i11];

                                                        var orderSum = i0 + 1 +
                                                                       i1 + 1 +
                                                                       i2 + 1 +
                                                                       i3 + 1 +
                                                                       i4 + 1 +
                                                                       i5 + 1 +
                                                                       i6 + 1 +
                                                                       i7 + 1 +
                                                                       i8 + 1 +
                                                                       i9 + 1 +
                                                                       i10 + 1 +
                                                                       i11 + 1;

                                                        if (sum == 667 && orderSum == 109)
                                                        {
                                                            numberOfFounds++;
                                                        }

                                                        numberOfProcessedItem++;
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