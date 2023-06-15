using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterIndex;
using static QuranAnalyzer.VerseFilter;
using System;
using System.Collections.Immutable;

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
            var count = GetCountOfLetterInVerse(verse, Saad, option, includeBismillah: true);
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
    public void __667__()
    {

        var allCharachters = "ا ب ت ث ج ح خ د ذ ر ز س ش ص ض ط ظ ع غ ف ق ك ل م ن ه و ي";
        var allCharachtersNumericValues = "1 2 400 500 3 8 600 4 700 200 7 60 300 90 800 9 900 70 1000 80 100 20 30 40 50 5 6 10";
        var targetLength = 8;
        var requestedNumericValue = 667;
        var requestedOrderNumber = 109;
        

        var allCharachtersAsList = allCharachters.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x=>x[0]).ToImmutableList();
        var allCharachtersNumericValuesAsList = allCharachtersNumericValues.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToImmutableList();
        
        if (allCharachtersAsList.Count != allCharachtersNumericValuesAsList.Count)
        {
            throw new Exception("wrong input");
        }    
        
        //var outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "A.txt");
        
        BigInteger numberOfProcessedItem = 0;

        BigInteger numberOfFounds = 0;
        
        //using (var w = File.AppendText(outputFilePath))
        {
            foreach (var combination in CreateCombinations(string.Join(string.Empty,allCharachtersAsList), targetLength))
            {
                //if (Calculator.GetNumericValue(combination) == requestedNumericValue)
                //{
                //    if (Calculator.GetOrderValue(combination) == requestedOrderNumber)
                //    {
                //        numberOfFounds++;
                //        //w.WriteLine(string.Join(" ", combination.Select(c=>c.ToString())));    
                //    }
                //}

                numberOfProcessedItem++;
            }
            
            //w.WriteLine($"numberOfProcessedItem: {numberOfProcessedItem}");

            throw new Exception($"Total combination: {numberOfProcessedItem}, numberOfFounds: {numberOfFounds}");
        }





        
    }
    
    public IEnumerable<string> CreateCombinations(string input, int length)
    {
        foreach (var c in input)
        {
            if (length == 1)
                yield return c.ToString();
            else 
            {
                foreach (var s in CreateCombinations(input, length - 1))
                    yield return c + s;
            }
        }
    }
}