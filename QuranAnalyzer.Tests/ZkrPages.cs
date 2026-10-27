using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace QuranAnalyzer;

[TestClass]
public class ZkrPages
{
    static readonly IReadOnlyList<LetterInfo> brk =
    [
        Letter.Beh, Letter.Reh, Letter.Kaf
    ];

    static readonly IReadOnlyList<LetterInfo> fullName =
    [
        Letter.Beh, Letter.Reh, Letter.Kaf, Letter.Reh,
        Letter.Yeh, Letter.Waw, Letter.Reh, Letter.Kaf, Letter.Waw, Letter.Jeem
    ];

    static readonly IReadOnlyList<int> initialLetteredChapters =
    [
        2, 3, 7, 10, 11, 12, 13, 14, 15, 19, 20, 26, 27, 28, 29, 30, 31, 32, 36, 38, 40, 41, 42, 43, 44, 45, 46, 50, 68
    ];

    [TestMethod]
    public void _41_()
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
                from verse in Filter(_ => true)
                from range in verse.GetStartAndEndPointsOfStartsWithWords(searchWord)
                where range.start.NumericValue >= 0
                from letter in verse.TextLetters
                select brk.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(114);
        }

        {
            var query =
                from verse in Filter(x => x.VerseNumber % 114 == 0)
                from letter in verse.TextLetters
                select brk.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(114);
        }

        {
            var query =
                from verse in Filter(x => x.VerseNumber % 114 == 0 && initialLetteredChapters.Contains(x.ChapterNumber))
                from letter in verse.TextLetters
                select brk.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(57);
        }
    }

    [TestMethod]
    public void _43_()
    {
        // 19:* should be 109 * 17
        {
            var query =
                from verse in Filter(x => x.ChapterNumber == 19)
                from letter in verse.TextLetters
                select fullName.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(109 * 17);
        }

        // *:19 should be 114 * 17
        {
            var query =
                from verse in Filter(x => x.VerseNumber == 19)
                from letter in verse.TextLetters
                select fullName.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(114 * 17);
        }

        // 19:19 should be 17
        {
            var query =
                from verse in Filter(x => x.ChapterNumber == 19 && x.VerseNumber == 19)
                from letter in verse.TextLetters
                select fullName.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(17);
        }

        // Numeric value should be 667
        {
            var query =
                from letter in fullName
                select letter.NumericValue;

            query.Sum().ShouldBe(667);
        }

        // order value should be 109
        {
            var query =
                from letter in fullName
                select letter.OrderValue;

            query.Sum().ShouldBe(109);
        }
    }

    [TestMethod]
    public void _44_to_46()
    {
        IReadOnlyList<LetterInfo> name =
        [
            Letter.Reh, Letter.Sheen, Letter.Alef, Letter.Dal
        ];

        {
            var query =
                from verse in Filter(isParenthesesRsd)
                from letter in verse.TextLetters
                select name.Count(x => IsSame(x, letter));

            query.Sum().ShouldBe(19 * 6);
        }
        return;

        static bool isParenthesesRsd(Verse verse)
        {
            return (verse.ChapterNumber is 13 && verse.VerseNumber is 30 or 38) ||
                   (verse.ChapterNumber is 25 && verse.VerseNumber is 56) ||
                   (verse.ChapterNumber is 34 && verse.VerseNumber is 28 or 46) ||
                   (verse.ChapterNumber is 36 && verse.VerseNumber is 3) ||
                   (verse.ChapterNumber is 42 && verse.VerseNumber is 24) ||
                   (verse.ChapterNumber is 81 && verse.VerseNumber is 22);
        }
    }

     [TestMethod]
    public void _47_to_51()
    {
        IReadOnlyList<LetterInfo> nameNonRepetitive =
        [
            Letter.Beh, Letter.Reh, Letter.Kaf
        ];
        
        IReadOnlyList<LetterInfo> lastNameNonRepetitive =
        [
            Letter.Yeh, Letter.Waw, Letter.Jeem
        ];
        
        IReadOnlyList<LetterInfo> fullNameNonRepetitive =
        [
            Letter.Beh, Letter.Reh, Letter.Kaf, 
            Letter.Yeh, Letter.Waw, Letter.Jeem
        ];
        
        

        IReadOnlyList<Verse> versesWithParenthesesNoName = [.. AllQuranVersesWithBismillah.Where(x => isParenthesesNoName(x.Verse)).Select(x => x.Verse)];

        (LetterInfo Letter, int Count)[] counts = 
        [
            ..
            from letter in fullNameNonRepetitive
            from verse in versesWithParenthesesNoName
            let count = verse.TextWithBismillahLetters.Count(x => IsSame(x, letter))
            where count > 0
            select
            (
                Letter: letter,
                Count: count
            )
        ];
        
        // 1
        {
            (from x in counts select x.Count).Sum().ShouldBe(19 * 6);
        }
        
        // 2
        {
            (from x in counts select GetNumberSum(x.Count)).Sum().ShouldBe(96);
        }
        
        // 3
        {
            {
                var query =
                    from letter in nameNonRepetitive
                    from verse in versesWithParenthesesNoName
                    let count = verse.TextWithBismillahLetters.Count(x => IsSame(x, letter))
                    where count > 0
                    select GetNumberSum(count);

                query.Sum().ShouldBe(48);
            }
            
            {
                var query =
                    from letter in lastNameNonRepetitive
                    from verse in versesWithParenthesesNoName
                    let count = verse.TextWithBismillahLetters.Count(x => IsSame(x, letter))
                    where count > 0
                    select GetNumberSum(count);

                query.Sum().ShouldBe(48);
            }
            
            // çift - tek
            {
                var query =
                    from letter in nameNonRepetitive
                    from verse in versesWithParenthesesNoName
                    let count = verse.TextWithBismillahLetters.Count(x => IsSame(x, letter))
                    where count > 0 && count % 2 == 0
                    select GetNumberSum(count);

                query.Sum().ShouldBe(24);
            }
            
            {
                var query =
                    from letter in nameNonRepetitive
                    from verse in versesWithParenthesesNoName
                    let count = verse.TextWithBismillahLetters.Count(x => IsSame(x, letter))
                    where count > 0 && count % 2 == 1
                    select GetNumberSum(count);

                query.Sum().ShouldBe(24);
            }
            
            {
                var query =
                    from letter in fullNameNonRepetitive
                    from verse in AllQuranVerses.Where(x => x.ChapterNumber < 4 || (x.ChapterNumber == 4 && x.VerseNumber < 41)).Select(x => x.Verse)
                    let count = verse.TextLetters.Count(x => IsSame(x, letter))
                    where count > 0
                    select count;

                query.Sum().ShouldBe(667*18);
            }
             
            {
                var query =
                    from letter in fullNameNonRepetitive
                    from verse in AllQuranVerses.Where(x => x.ChapterNumber is > 4 and < 72 
                                                             || 
                                                             (x.ChapterNumber == 4 && x.VerseNumber >= 41)
                                                             ||
                                                             (x.ChapterNumber == 72 && x.VerseNumber <= 7)
                                                             
                                                             
                                                             
                                                             ).Select(x => x.Verse)

                    where  !versesWithParenthesesNoName.Any(x=>x.ChapterNumber == verse.ChapterNumber && x.VerseNumber == verse.VerseNumber)
                    let count = verse.TextLetters.Count(x => IsSame(x, letter))
                    where count > 0
                    select count;

                query.Sum().ShouldBe(667*109);
            }
            
        }
        
        
        return;

        static bool isParenthesesNoName(Verse verse)
        {
            return (verse.ChapterNumber is 4 && verse.VerseNumber is 41) ||
                   (verse.ChapterNumber is 7 && verse.VerseNumber is 184) ||
                   (verse.ChapterNumber is 9 && verse.VerseNumber is 40) ||
                   (verse.ChapterNumber is 36 && verse.VerseNumber is 69) ||
                   (verse.ChapterNumber is 43 && verse.VerseNumber is 24) ||
                   (verse.ChapterNumber is 48 && verse.VerseNumber is 1) ||
                   (verse.ChapterNumber is 72 && verse.VerseNumber is 7);
        }
    }

    static int GetNumberSum(int number)
    {
        int sum = 0;
        number = Math.Abs(number);

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }

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