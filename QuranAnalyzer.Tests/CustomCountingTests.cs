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
        var targetLength = 6;
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
                if (combination.Select(GetNumericValue).Sum() == requestedNumericValue)
                {
                    if (combination.Select(GetOrderNumber).Sum() == requestedOrderNumber)
                    {
                        numberOfFounds++;
                        //w.WriteLine(string.Join(" ", combination.Select(c=>c.ToString())));    
                    }
                }

                numberOfProcessedItem++;
            }
            
            //w.WriteLine($"numberOfProcessedItem: {numberOfProcessedItem}");

            throw new Exception($"Total combination: {numberOfProcessedItem}, numberOfFounds: {numberOfFounds}");
        }

        
       
        
        
        
        

                          

static int GetNumericValue(char c)
        {
            
            if(c == 'ا')
            {
                return 1;
            }

            if(c == 'ب')
            {
                return 2;
            }

            if(c == 'ت')
            {
                return 400;
            }

            if(c == 'ث')
            {
                return 500;
            }

            if(c == 'ج')
            {
                return 3;
            }

            if(c == 'ح')
            {
                return 8;
            }

            if(c == 'خ')
            {
                return 600;
            }

            if(c == 'د')
            {
                return 4;
            }

            if(c == 'ذ')
            {
                return 700;
            }

            if(c == 'ر')
            {
                return 200;
            }

            if(c == 'ز')
            {
                return 7;
            }

            if(c == 'س')
            {
                return 60;
            }

            if(c == 'ش')
            {
                return 300;
            }

            if(c == 'ص')
            {
                return 90;
            }

            if(c == 'ض')
            {
                return 800;
            }

            if(c == 'ط')
            {
                return 9;
            }

            if(c == 'ظ')
            {
                return 900;
            }

            if(c == 'ع')
            {
                return 70;
            }

            if(c == 'غ')
            {
                return 1000;
            }

            if(c == 'ف')
            {
                return 80;
            }

            if(c == 'ق')
            {
                return 100;
            }

            if(c == 'ك')
            {
                return 20;
            }

            if(c == 'ل')
            {
                return 30;
            }

            if(c == 'م')
            {
                return 40;
            }

            if(c == 'ن')
            {
                return 50;
            }

            if(c == 'ه')
            {
                return 5;
            }

            if(c == 'و')
            {
                return 6;
            }

            if(c == 'ي')
            {
                return 10;
            }

            throw new Exception($"Not recognized Arabic Letter:'{c}'");
        }

        static int GetOrderNumber(char c)
        {
            
            if(c == 'ا')
            {
                return 1;
            }

            if(c == 'ب')
            {
                return 2;
            }

            if(c == 'ت')
            {
                return 3;
            }

            if(c == 'ث')
            {
                return 4;
            }

            if(c == 'ج')
            {
                return 5;
            }

            if(c == 'ح')
            {
                return 6;
            }

            if(c == 'خ')
            {
                return 7;
            }

            if(c == 'د')
            {
                return 8;
            }

            if(c == 'ذ')
            {
                return 9;
            }

            if(c == 'ر')
            {
                return 10;
            }

            if(c == 'ز')
            {
                return 11;
            }

            if(c == 'س')
            {
                return 12;
            }

            if(c == 'ش')
            {
                return 13;
            }

            if(c == 'ص')
            {
                return 14;
            }

            if(c == 'ض')
            {
                return 15;
            }

            if(c == 'ط')
            {
                return 16;
            }

            if(c == 'ظ')
            {
                return 17;
            }

            if(c == 'ع')
            {
                return 18;
            }

            if(c == 'غ')
            {
                return 19;
            }

            if(c == 'ف')
            {
                return 20;
            }

            if(c == 'ق')
            {
                return 21;
            }

            if(c == 'ك')
            {
                return 22;
            }

            if(c == 'ل')
            {
                return 23;
            }

            if(c == 'م')
            {
                return 24;
            }

            if(c == 'ن')
            {
                return 25;
            }

            if(c == 'ه')
            {
                return 26;
            }

            if(c == 'و')
            {
                return 27;
            }

            if(c == 'ي')
            {
                return 28;
            }

            throw new Exception($"Not recognized Arabic Letter:'{c}'");
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