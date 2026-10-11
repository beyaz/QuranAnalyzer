using System;
using System.Collections.Generic;

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