using System;
using System.Collections.Generic;

namespace QuranAnalyzer;

[TestClass]
public class WordSearchingTests
{
    [TestMethod]
    public void Adem_Isa()
    {
        // a d e m
        const string adem = "اادم";
        const string ya_adem = "يادم";
        const string li_adem = "لِـَٔادَمَ";
        const string veya_adem = "و يادم";

        CountShouldBe(adem, 15);
        CountShouldBe(ya_adem, 4);
        CountShouldBe(li_adem, 5);
        CountShouldBe(veya_adem, 1);

        // i s a
        const string isa = "عيسي";
        const string ve_isa = "وعيسي";
        const string ya_isa = "يعيسي";
        const string bi_isa = "بعيسي";

        CountShouldBe(isa, 12);
        CountShouldBe(ve_isa, 7);
        CountShouldBe(ya_isa, 4);
        CountShouldBe(bi_isa, 2);
    }

    [TestMethod]
    public void Beyyine()
    {
        var source = AnalyzeText("الْبَيِّنَةُۜ");
        var beyyine = AnalyzeText("بينة");

        source.Contains(beyyine).Count.Should().Be(1);

        source = AnalyzeText(" الْبَيِّنَةُۜ-- الْبَيِّنَةُۜ");

        source.Contains(beyyine).Count.Should().Be(2);
    }

    [TestMethod]
    public void CommonCounts()
    {
        // zikr
        CountShouldBe("ذكري", 11);
        CountShouldBe("وذكري", 7);
        CountShouldBe("الذكري", 6);
        CountShouldBe("لذكري", 3);

        // chnm
        CountShouldBe("جهنم", 72);
        CountShouldBe("بجهنم", 2);
        CountShouldBe("لجهنم", 3);

        // dny
        CountShouldBe("الدّنيا", 115);

        // ahrt
        CountShouldBe("ٱلْـَٔاخِرَةُ", 71);
        CountShouldBe("بِٱلْـَٔاخِرَةِ", 21);
        CountShouldBe("وَٱلْـَٔاخِرَةِ", 19);
        CountShouldBe("وَلَلْـَٔاخِرَةُ", 2);
        CountShouldBe("وَبِٱلْـَٔاخِرَةِ", 1);
        CountShouldBe("لَلْـَٔاخِرَةَ", 1);

        // nur
        CountShouldBe("النّور", 10);
        CountShouldBe("نورا", 9);
        CountShouldBe("نور", 8);
        CountShouldBe("ونور", 2);
        CountShouldBe("والنّور", 3);
        CountShouldBe("بنور", 1);

        // şems
        CountShouldBe("الشمس", 20);
        CountShouldBe("والشمس", 9);
        CountShouldBe("بالشمس", 1);
        CountShouldBe("للشمس", 2);
        CountShouldBe("شمسا", 1);

        // kamer
        CountShouldBe("والقمر", 20);
        CountShouldBe("القمر", 5);
        CountShouldBe("وقمرا", 1);
        CountShouldBe("للقمر", 1);

        // şhr
        CountShouldBe("شهر", 4);
        CountShouldBe("الشهر", 4);
        CountShouldBe("شهرا", 2);
        CountShouldBe("بالشهر", 1);
        CountShouldBe("والشهر", 1);

        // rahim
        CountShouldBe("ٱلرَّحِيمِ", 34);
        CountShouldBe("رَّحِيمٌ", 61);
        CountShouldBe("رَّحِيمًا", 20);

        // rahman
        //CountShouldBe("الرحمن", 45);
        CountShouldBe("للرحمن", 9);
        CountShouldBe("بالرحمن", 3);

        // Allah
        CountShouldBe("الله", 2153);
        CountShouldBe("والله", 240);
        CountShouldBe("بالله", 139);
        CountShouldBe("لله", 116);
        CountShouldBe("ولله", 27);
        CountShouldBe("تالله", 8);
        CountShouldBe("فالله", 6);
        CountShouldBe("فلله", 6);
        CountShouldBe("ءالله", 2);
        CountShouldBe("ابالله", 1);
        CountShouldBe("وتالله", 1);
    }

    [TestMethod]
    public void Day_365()
    {
        const string yevm = "يوم";
        const string ve_yevm = "ويوم";
        const string el_yevm = "اليوم";
        const string vel_yevm = "واليوم";
        const string yevmen = "يوما";
        const string li_yevm = "ليوم";
        const string fel_yevm = "فاليوم";
        const string bi_yevm = "بيوم";
        const string bil_yevm = "باليوم";
        const string vebil_yevm = "وباليوم";

        CountShouldBe(yevm, 217);
        CountShouldBe(ve_yevm, 44);
        CountShouldBe(el_yevm, 41);
        CountShouldBe(vel_yevm, 23);
        CountShouldBe(yevmen, 16);
        CountShouldBe(li_yevm, 8);
        CountShouldBe(fel_yevm, 8);
        CountShouldBe(bi_yevm, 5);
        CountShouldBe(bil_yevm, 2);
        CountShouldBe(vebil_yevm, 1);
    }

    [TestMethod]
    public void EndsWithNunVavNun()
    {
        var nunVavNun = AnalyzeText("نون");

        VerseFilter.GetVerseList("*").Value.SumOf(v => v.TextWithBismillahWordList.Last().EndsWith(nunVavNun) is null ? 0 : 1).Unwrap().Should().Be(133);
    }

    static void CountShouldBe(string searchWord, int expected)
    {
        var search = AnalyzeText(searchWord);

        var verses = VerseFilter.GetVerseList("*").Unwrap();

        int matchCountOfSameAsExactly(Verse v)
        {
            return v.TextWordList.Count(w => w.Same(search));
        }

        verses.Sum(matchCountOfSameAsExactly).Should().Be(expected);
    }
    
    
    [TestMethod]
    public void DistinctWordsCount()
    {
        var filter = "*,-9:128,-9:129";

        var allWords = new List<string>();
        
        foreach (var verse in VerseFilter.GetVerseList(filter).Value)
        {
            var words = verse.TextWithBismillah.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (allWords.IndexOf(word) < 0)
                {
                    allWords.Add(word);
                }
            }
        }

        allWords.Count.Should().Be(18993);
    }
    
    [TestMethod]
    public void StartsWithTest()
    {
        // " abc".StartsWith("abc")
        {
            var searchWord = AnalyzeText("نون");
        
            var source = AnalyzeText("نون");

            var response = source.StartsWith(searchWord);

            response.HasValue.Should().BeTrue();

            response!.Value.start.OrderValue.Should().Be(ArabicLetterOrder.Nun);
            response!.Value.end.OrderValue.Should().Be(ArabicLetterOrder.Nun);
        }
        
        // " abcd".StartsWith("abc")
        {
            var searchWord = AnalyzeText("نون");
        
            var source = AnalyzeText("نونم");

            var response = source.StartsWith(searchWord);

            response.HasValue.Should().BeTrue();
            
            response!.Value.start.OrderValue.Should().Be(ArabicLetterOrder.Nun);
            response!.Value.end.OrderValue.Should().Be(ArabicLetterOrder.Nun);
        }
        
        // " abc".StartsWith("abcd")
        {
            
            var source = AnalyzeText("نون");
            
            var searchWord = AnalyzeText("نونم");

            var response = source.StartsWith(searchWord);

            response.HasValue.Should().BeFalse();
            
        }
        
        // " abc".StartsWith("abc")
        {
            
            var source = AnalyzeText("نونم ");
            
            var searchWord =  AnalyzeText("نون");

            var response = source.StartsWith(searchWord);

            response.HasValue.Should().BeTrue();
            
            response!.Value.start.OrderValue.Should().Be(ArabicLetterOrder.Nun);
            response!.Value.end.OrderValue.Should().Be(ArabicLetterOrder.Nun);
            
        }
    }
    
    
    [TestMethod]
    public void EndsWithTest()
    {
        // " abc".EndsWith("abc")
        {
            
            var source = AnalyzeText("" + ArabicLetter.Miim + ArabicLetter.Faa + ArabicLetter.Qaaf);
            
            var searchWord = AnalyzeText("" + ArabicLetter.Miim + ArabicLetter.Faa + ArabicLetter.Qaaf);
        
            var response = source.EndsWith(searchWord);

            response.HasValue.Should().BeTrue();

            response!.Value.start.OrderValue.Should().Be(ArabicLetterOrder.Miim);
            response!.Value.end.OrderValue.Should().Be(ArabicLetterOrder.Qaaf);
        }
        
        // "dabc".EndsWith("abc")
        {
            var source = AnalyzeText("" +   ArabicLetter.Yaa + ArabicLetter.Miim + ArabicLetter.Faa + ArabicLetter.Qaaf);
            
            var searchWord = AnalyzeText("" + ArabicLetter.Miim + ArabicLetter.Faa + ArabicLetter.Qaaf);
        
            

            var response = source.EndsWith(searchWord);

            response.HasValue.Should().BeTrue();
            
            response!.Value.start.OrderValue.Should().Be(ArabicLetterOrder.Miim);
            response!.Value.end.OrderValue.Should().Be(ArabicLetterOrder.Qaaf);
        }
       
    }
}