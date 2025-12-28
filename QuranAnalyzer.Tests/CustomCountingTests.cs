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

    const string LatinCharToArabicCharMap =
        """

        a : ا  ,  b : ب  ,  c : ج  ,  d : د  ,
        f : ف  ,  ç : ج  ,  g : ك  ,  h : ح  ,
        i : ي  ,  j : ج  ,  k : ك  ,  l : ل  ,
        m : م  ,  n : ن  ,  o : و  ,  p : پ  ,
        q : ق  ,  r : ر  ,  s : س  ,  t : ت  ,
        u : ع  ,  v : ڤ  ,  w : و  ,  ö : و  ,
        ü : و  ,  x : خ  ,  y : ي  ,  z : ز  ,

        """;

    [TestMethod]
    public void LatinAllphabetEbjedCalculate()
    {
        var input = new
        {
            LatinText = "abc",

            LatinCharToArabicCharMap
        };

        var map = GetLatinCharToArabicCharMap(input.LatinCharToArabicCharMap);

        var query = 
            from c in input.LatinText.ToCharArray()
            let letterInfo = map.ContainsKey(c) switch
            {
                true=>map[c],
                false=>new()
            }
            select letterInfo.NumericValue;

        var sum = query.Sum();
        
        sum.Should().Be(146);

        
    }
    
    [TestMethod]
    public void LatinAllphabetEbjedCalculate2()
    {
        const string arabicText =
            """
            2249|19|1|كٓهيعٓصٓ
            2250|19|2|ذِكْرُ رَحْمَتِ رَبِّكَ عَبْدَهُۥ زَكَرِيَّآ
            2251|19|3|إِذْ نَادَىٰ رَبَّهُۥ نِدَآءً خَفِيًّا
            2252|19|4|قَالَ رَبِّ إِنِّى وَهَنَ ٱلْعَظْمُ مِنِّى وَٱشْتَعَلَ ٱلرَّأْسُ شَيْبًا وَلَمْ أَكُنۢ بِدُعَآئِكَ رَبِّ شَقِيًّا
            2253|19|5|وَإِنِّى خِفْتُ ٱلْمَوَٰلِىَ مِن وَرَآءِى وَكَانَتِ ٱمْرَأَتِى عَاقِرًا فَهَبْ لِى مِن لَّدُنكَ وَلِيًّا
            2254|19|6|يَرِثُنِى وَيَرِثُ مِنْ ءَالِ يَعْقُوبَ وَٱجْعَلْهُ رَبِّ رَضِيًّا
            2255|19|7|يَٰزَكَرِيَّآ إِنَّا نُبَشِّرُكَ بِغُلَٰمٍ ٱسْمُهُۥ يَحْيَىٰ لَمْ نَجْعَل لَّهُۥ مِن قَبْلُ سَمِيًّا
            2256|19|8|قَالَ رَبِّ أَنَّىٰ يَكُونُ لِى غُلَٰمٌ وَكَانَتِ ٱمْرَأَتِى عَاقِرًا وَقَدْ بَلَغْتُ مِنَ ٱلْكِبَرِ عِتِيًّا
            2257|19|9|قَالَ كَذَٰلِكَ قَالَ رَبُّكَ هُوَ عَلَىَّ هَيِّنٌ وَقَدْ خَلَقْتُكَ مِن قَبْلُ وَلَمْ تَكُ شَيْـًٔا
            2258|19|10|قَالَ رَبِّ ٱجْعَل لِّىٓ ءَايَةً قَالَ ءَايَتُكَ أَلَّا تُكَلِّمَ ٱلنَّاسَ ثَلَٰثَ لَيَالٍ سَوِيًّا
            2259|19|11|فَخَرَجَ عَلَىٰ قَوْمِهِۦ مِنَ ٱلْمِحْرَابِ فَأَوْحَىٰٓ إِلَيْهِمْ أَن سَبِّحُوا۟ بُكْرَةً وَعَشِيًّا
            2260|19|12|يَٰيَحْيَىٰ خُذِ ٱلْكِتَٰبَ بِقُوَّةٍ وَءَاتَيْنَٰهُ ٱلْحُكْمَ صَبِيًّا
            2261|19|13|وَحَنَانًا مِّن لَّدُنَّا وَزَكَوٰةً وَكَانَ تَقِيًّا
            2262|19|14|وَبَرًّۢا بِوَٰلِدَيْهِ وَلَمْ يَكُن جَبَّارًا عَصِيًّا
            2263|19|15|وَسَلَٰمٌ عَلَيْهِ يَوْمَ وُلِدَ وَيَوْمَ يَمُوتُ وَيَوْمَ يُبْعَثُ حَيًّا
            2264|19|16|وَٱذْكُرْ فِى ٱلْكِتَٰبِ مَرْيَمَ إِذِ ٱنتَبَذَتْ مِنْ أَهْلِهَا مَكَانًا شَرْقِيًّا
            2265|19|17|فَٱتَّخَذَتْ مِن دُونِهِمْ حِجَابًا فَأَرْسَلْنَآ إِلَيْهَا رُوحَنَا فَتَمَثَّلَ لَهَا بَشَرًا سَوِيًّا
            2266|19|18|قَالَتْ إِنِّىٓ أَعُوذُ بِٱلرَّحْمَٰنِ مِنكَ إِن كُنتَ تَقِيًّا
            2267|19|19|قَالَ إِنَّمَآ أَنَا۠ رَسُولُ رَبِّكِ لِأَهَبَ لَكِ غُلَٰمًا زَكِيًّا
            2268|19|20|قَالَتْ أَنَّىٰ يَكُونُ لِى غُلَٰمٌ وَلَمْ يَمْسَسْنِى بَشَرٌ وَلَمْ أَكُ بَغِيًّا
            2269|19|21|قَالَ كَذَٰلِكِ قَالَ رَبُّكِ هُوَ عَلَىَّ هَيِّنٌ وَلِنَجْعَلَهُۥٓ ءَايَةً لِّلنَّاسِ وَرَحْمَةً مِّنَّا وَكَانَ أَمْرًا مَّقْضِيًّا
            2270|19|22|فَحَمَلَتْهُ فَٱنتَبَذَتْ بِهِۦ مَكَانًا قَصِيًّا
            2271|19|23|فَأَجَآءَهَا ٱلْمَخَاضُ إِلَىٰ جِذْعِ ٱلنَّخْلَةِ قَالَتْ يَٰلَيْتَنِى مِتُّ قَبْلَ هَٰذَا وَكُنتُ نَسْيًا مَّنسِيًّا
            2272|19|24|فَنَادَىٰهَا مِن تَحْتِهَآ أَلَّا تَحْزَنِى قَدْ جَعَلَ رَبُّكِ تَحْتَكِ سَرِيًّا
            2273|19|25|وَهُزِّىٓ إِلَيْكِ بِجِذْعِ ٱلنَّخْلَةِ تُسَٰقِطْ عَلَيْكِ رُطَبًا جَنِيًّا
            2274|19|26|فَكُلِى وَٱشْرَبِى وَقَرِّى عَيْنًا فَإِمَّا تَرَيِنَّ مِنَ ٱلْبَشَرِ أَحَدًا فَقُولِىٓ إِنِّى نَذَرْتُ لِلرَّحْمَٰنِ صَوْمًا فَلَنْ أُكَلِّمَ ٱلْيَوْمَ إِنسِيًّا
            2275|19|27|فَأَتَتْ بِهِۦ قَوْمَهَا تَحْمِلُهُۥ قَالُوا۟ يَٰمَرْيَمُ لَقَدْ جِئْتِ شَيْـًٔا فَرِيًّا
            2276|19|28|يَٰٓأُخْتَ هَٰرُونَ مَا كَانَ أَبُوكِ ٱمْرَأَ سَوْءٍ وَمَا كَانَتْ أُمُّكِ بَغِيًّا
            2277|19|29|فَأَشَارَتْ إِلَيْهِ قَالُوا۟ كَيْفَ نُكَلِّمُ مَن كَانَ فِى ٱلْمَهْدِ صَبِيًّا
            2278|19|30|قَالَ إِنِّى عَبْدُ ٱللَّهِ ءَاتَىٰنِىَ ٱلْكِتَٰبَ وَجَعَلَنِى نَبِيًّا
            2279|19|31|وَجَعَلَنِى مُبَارَكًا أَيْنَ مَا كُنتُ وَأَوْصَٰنِى بِٱلصَّلَوٰةِ وَٱلزَّكَوٰةِ مَا دُمْتُ حَيًّا
            2280|19|32|وَبَرًّۢا بِوَٰلِدَتِى وَلَمْ يَجْعَلْنِى جَبَّارًا شَقِيًّا
            2281|19|33|وَٱلسَّلَٰمُ عَلَىَّ يَوْمَ وُلِدتُّ وَيَوْمَ أَمُوتُ وَيَوْمَ أُبْعَثُ حَيًّا
            
            """;

        var map = GetLatinCharToArabicCharMap(LatinCharToArabicCharMap);

        var letters = AnalyzeText(arabicText);


        var latinText = "berkeryörgüç";

        var count = 0;

        var countStr = "";
        
        foreach (var latinChar in latinText)
        {
            if (map.ContainsKey(latinChar))
            {
                var letter = map[latinChar];
                
                count+= letters.Count(x => x.HasValueAndSameAs(letter));
                
                countStr += letters.Count(x => x.HasValueAndSameAs(letter));
            }
        }

        count.Should().Be(667);

        var sumOfNumbers = (from c in countStr select int.Parse(c.ToString())).Sum();

        sumOfNumbers.Should().Be(109);
    }
   
}