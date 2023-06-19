using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Numerics;
using System.Text;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterIndex;
using static QuranAnalyzer.VerseFilter;
using System.Linq;

namespace QuranAnalyzer;

[TestClass]
public class CustomCountingTests
{

    [TestMethod]
    public void __667__1()
    {
        const string allCharachters = "ا ب ت ث ج ح خ د ذ ر ز س ش ص ض ط ظ ع غ ف ق ك ل م ن ه و ي";
        const string allCharachtersNumericValues = "1 2 400 500 3 8 600 4 700 200 7 60 300 90 800 9 900 70 1000 80 100 20 30 40 50 5 6 10";
        const int requestedNumericValue = 77;

        var allCharachtersAsList = allCharachters.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x[0]).ToImmutableList();
        var numbers = allCharachtersNumericValues.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToImmutableList();

        if (allCharachtersAsList.Count != numbers.Count)
        {
            throw new Exception("wrong input");
        }

        const int combinationLength = 8;


        numbers = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30, 40, 50, 60, 70 }.ToImmutableList();
        
        BigInteger numberOfProcessedItem = 0;
        BigInteger numberOfFounds = 0;

        //using (var streamWriter = File.AppendText("C:\\Users\\beyaz\\OneDrive\\Documents\\A.txt"))
        {



            var founds = new List<string>();
            
        
        
            VisitCombinations(numbers, combinationLength,  new List<int>(), list =>
            {
                numberOfProcessedItem++;

                if (list.Sum() == requestedNumericValue && list.Select(Calculator.GetOrderValueByNumericValue).Sum() == 41)
                {
                    var key = string.Join(",", list.OrderBy(x => x));
                    
                    if (founds.IndexOf(key)<0)
                    {
                        founds.Add(key);
                        numberOfFounds++;
                    }
                    
                    //streamWriter.WriteLine(string.Join(" ", list));
                }

            });
        }

        throw new Exception($"Total combination: {numberOfProcessedItem}, numberOfFounds: {numberOfFounds}");


        static void VisitCombinations(IReadOnlyList<int> numberList, int requestedCombinationLength, List<int> combination, Action<List<int>> onMatch)
        {
            if (combination.Count == requestedCombinationLength)
            {
                onMatch(combination);
            }
            else
            {
                var numberListCount = numberList.Count;

                for (var i = 0; i < numberListCount; i++)
                {
                    var number = numberList[i];

                        combination.Add(number);
                        VisitCombinations(numberList, requestedCombinationLength, combination, onMatch);
                        combination.RemoveAt(combination.Count - 1);
                }
            }
        }
    }


    //[TestMethod]
    public void __667__()
    {
        const string allCharachters = "ا ب ت ث ج ح خ د ذ ر ز س ش ص ض ط ظ ع غ ف ق ك ل م ن ه و ي";
        const string allCharachtersNumericValues = "1 2 400 500 3 8 600 4 700 200 7 60 300 90 800 9 900 70 1000 80 100 20 30 40 50 5 6 10";
        const int requestedNumericValue = 667;
        const int requestedOrderNumber = 109;

        var allCharachtersAsList = allCharachters.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x[0]).ToImmutableList();
        var numbers = allCharachtersNumericValues.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToImmutableList();

        if (allCharachtersAsList.Count != numbers.Count)
        {
            throw new Exception("wrong input");
        }

        //numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToImmutableList();
        //const int combinationLength = 4;
        //const int maxOccurence = 3;

        var arrayLength = numbers.Count;

        BigInteger numberOfProcessedItem = 0;
        BigInteger numberOfFounds = 0;

        for (var i0 = 0; i0 < arrayLength; i0++)
        {
            var v0 = numbers[i0];
            var o0 = i0 + 1;

            for (var i1 = 0; i1 < arrayLength; i1++)
            {
                var v1 = numbers[i1];
                var o1 = i1 + 1;

                var sum1 = v0 + v1;
                var orderSum1 = o0 + o1;

                for (var i2 = 0; i2 < arrayLength; i2++)
                {
                    var v2 = numbers[i2];
                    var o2 = i2 + 1;

                    var sum2 = sum1 + v2;
                    var orderSum2 = orderSum1 + o2;

                    for (var i3 = 0; i3 < arrayLength; i3++)
                    {
                        if (i3==i2 && i3 == i1 && i3 == i0)
                        {
                            i3++;
                            if (i3 >= arrayLength)
                            {
                                continue;
                            }
                        }
                        
                        var v3 = numbers[i3];
                        var o3 = i3 + 1;

                        var sum3 = sum2 + v3;
                        var orderSum3 = orderSum2 + o3;

                        for (var i4 = 0; i4 < arrayLength; i4++)
                        {
                            if (i4==i3 && i4 == i2 && i4 == i1)
                            {
                                i4++;
                                if (i4 >= arrayLength)
                                {
                                    continue;
                                }
                            }
                            
                            var v4 = numbers[i4];
                            var o4 = i4 + 1;

                            var sum4 = sum3 + v4;
                            var orderSum4 = orderSum3 + o4;

                            for (var i5 = 0; i5 < arrayLength; i5++)
                            {
                                if (i5==i4 && i5==i3 && i5 == i2)
                                {
                                    i5++;
                                    if (i5 >= arrayLength)
                                    {
                                        continue;
                                    }
                                }
                                
                                var v5 = numbers[i5];
                                var o5 = i5 + 1;

                                var sum5 = sum4 + v5;
                                var orderSum5 = orderSum4 + o5;

                                for (var i6 = 0; i6 < arrayLength; i6++)
                                {
                                    if (i6==i5 && i6==i4 && i6==i3)
                                    {
                                        i6++;
                                        if (i6 >= arrayLength)
                                        {
                                            continue;
                                        }
                                    }
                                    
                                    var v6 = numbers[i6];
                                    var o6 = i6 + 1;

                                    var sum6 = sum5 + v6;
                                    var orderSum6 = orderSum5 + o6;

                                    for (var i7 = 0; i7 < arrayLength; i7++)
                                    {
                                        if (i7==i6 && i7==i5 && i7==i4)
                                        {
                                            i7++;
                                            if (i7 >= arrayLength)
                                            {
                                                continue;
                                            }
                                        }
                                        
                                        var v7 = numbers[i7];
                                        var o7 = i7 + 1;

                                        var sum7 = sum6 + v7;
                                        var orderSum7 = orderSum6 + o7;

                                        for (var i8 = 0; i8 < arrayLength; i8++)
                                        {
                                            if (i8==i7 && i8==i6 && i8==i5)
                                            {
                                                i8++;
                                                if (i8 >= arrayLength)
                                                {
                                                    continue;
                                                }
                                            }
                                            
                                            var v8 = numbers[i8];
                                            var o8 = i8 + 1;

                                            var sum8 = sum7 + v8;
                                            var orderSum8 = orderSum7 + o8;

                                            for (var i9 = 0; i9 < arrayLength; i9++)
                                            {
                                                if (i9==i8 && i9==i7 && i9==i6)
                                                {
                                                    i9++;
                                                    if (i9 >= arrayLength)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                
                                                var v9 = numbers[i9];
                                                var o9 = i9 + 1;

                                                var sum9 = sum8 + v9;
                                                var orderSum9 = orderSum8 + o9;

                                                for (var i10 = 0; i10 < arrayLength; i10++)
                                                {
                                                    if (i10==i9 && i10==i8 && i10==i7)
                                                    {
                                                        i10++;
                                                        if (i10 >= arrayLength)
                                                        {
                                                            continue;
                                                        }
                                                    }
                                                    
                                                    var v10 = numbers[i10];
                                                    var o10 = i10 + 1;

                                                    var sum10 = sum9 + v10;
                                                    var orderSum10 = orderSum9 + o10;

                                                    for (var i11 = 0; i11 < arrayLength; i11++)
                                                    {
                                                        if (i11==i10 && i11==i9 && i11==i8)
                                                        {
                                                            i11++;
                                                            if (i11 >= arrayLength)
                                                            {
                                                                continue;
                                                            }
                                                        }
                                                        
                                                        var v11 = numbers[i11];
                                                        var o11 = i11 + 1;

                                                        var sum = sum10 + v11;

                                                        var orderSum = orderSum10 + o11;

                                                        if (sum == requestedNumericValue && orderSum == requestedOrderNumber)
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
    
    
    //[TestMethod]
    public void ___6___()
    {
        var sb = new StringBuilder();

        
        var founds = new List<string>();

        void push(IReadOnlyList<LetterInfo> word)
        {
            var clearWord = word.Where(IsArabicLetter).ToList();

            var str = string.Join("", clearWord);

            if (founds.IndexOf(str)<0)
            {
                founds.Add(str);
            }
        }

        var verseList = GetVerseList("*,-9:128,-9:129").Value;
        foreach (var verse in verseList)
        {
            foreach (var word in verse.TextWordList)
            {
                if (Enumerable.Sum(word, l => l.NumericValue) == 142 && Enumerable.Sum(word, l=>l.OrderValue) == 62)
                {
                    push(word);
                }
            }
        }
        
        
        foreach (var chapter in DataAccess.AllChapters)
        {
            foreach (var word in AnalyzeText(chapter.Name).GetWords())
            {
                if (Enumerable.Sum(word, l => l.NumericValue) == 142 && Enumerable.Sum(word, l=>l.OrderValue) == 62)
                {
                    push(word);
                }
            }
        }

        //var a = AnalyzeText("ٱلنَّاس");

        //var b = Enumerable.Sum(a, l => l.NumericValue);
        //var c = Enumerable.Sum(a, l => l.OrderValue);

        var result = string.Join(Environment.NewLine, founds);
        
        var total = sb.ToString();

        
    }
}