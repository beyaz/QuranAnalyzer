using System;
using System.Collections.Generic;

namespace QuranAnalyzer;

[TestClass]
public class Zkr
{
    static IReadOnlyList<LetterInfo> FullName = AnalyzeText("");

    
   

    [TestMethod]
    public void ___A()
    {
        var input = new
        {
            LatinText = "berker yörgüç",

            LatinCharToArabicCharMap
        };

        IReadOnlyList<LetterInfo> searchLetters =
        [
            .. from c in input.LatinText.ToCharArray()
               let map = GetLatinCharToArabicCharMap(input.LatinCharToArabicCharMap)
               where map.ContainsKey(c) && map[c].IsArabic
               select map[c]
        ];

        // Page: 41
        {
            {
                var query =
                    from verse in Filter(x => x.ChapterNumber == 37 && x.VerseNumber == 181)
                    from letter in verse.TextLetters
                    select letter.NumericValue;

                query.Sum().ShouldBe(667);
            }

            {
                var searchWord = AnalyzeText("الْمرْسلِي");
                
                var query =
                    from verse in Filter(x => true)
                    from range in  verse.GetStartAndEndPointsOfStartsWithWords(searchWord)
                    where range.start.NumericValue >= 0
                    from letter in verse.TextLetters
                    select new[]{ArabicLetter.Beh, ArabicLetter.Reh, ArabicLetter.Kaf }.Select(x => AnalyzeText(x.ToString())[0]).Count(x => IsSame(x, letter));

                query.Sum().ShouldBe(114);
            }
        }
        
        // 19:* should be 109 * 17
        {
            var query =
                from verse in Filter(x => x.ChapterNumber == 19)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(109 * 17);
        }

        // *:19 should be 114 * 17
        {
            var query =
                from verse in Filter(x => x.VerseNumber == 19)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(114 * 17);
        }

        // 19:19 should be 17
        {
            var query =
                from verse in Filter(x => x.ChapterNumber == 19 && x.VerseNumber == 19)
                from letter in verse.TextLetters
                select searchLetters.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(17);
        }

        // Numeric value should be 667
        {
            var query =
                from letter in searchLetters
                select letter.NumericValue;

            query.Sum().ShouldBe(667);
        }

        // order value should be 109
        {
            var query =
                from letter in searchLetters
                select letter.OrderValue;

            query.Sum().ShouldBe(109);
        }
        return;

        static IEnumerable<Verse> Filter(Func<Verse, bool> predicate)
        {
            return AllQuranVerses.Where(x => predicate(x.Verse)).Select(x => x.Verse);
        }

        static bool IsSame(LetterInfo a, LetterInfo b)
        {
            if (a is null || b is null)
            {
                return false;
            }

            if (a.NumericValue > 0 && a.NumericValue == b.NumericValue)
            {
                return true;
            }

            return false;
        }
    }
}