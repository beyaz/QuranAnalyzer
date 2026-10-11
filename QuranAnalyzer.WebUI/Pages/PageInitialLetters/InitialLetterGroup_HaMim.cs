using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_HaMim : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 113, SearchScript = GetLetterCountingScript("40:*,41:*,42:*,43:*,44:*,45:*,46:*", Hah, Meem) };

    static string IdOfCountingResult => $"HaMim-{nameof(IdOfCountingResult)}";

    protected override Element render()
    {
        return new div
        {
            new table(WidthFull)
            {
                new tbody
                {
                    HeaderTr,
                    HeaderSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 40, ChapterName = "Mümin" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(40, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(40, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            rowSpan = 99,
                            children =
                            {
                                new FlexRow(JustifyContentCenter, MarginTop(-50))
                                {
                                    countingResult
                                }
                            }
                        }
                    },
                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 41, ChapterName = "Fussilet" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(41, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(41, Meem), Letter = Meem }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 42, ChapterName = "Şura" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(42, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(42, Meem), Letter = Meem }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 43, ChapterName = "Zuhruf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(43, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(43, Meem), Letter = Meem }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 44, ChapterName = "Duhan" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(44, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(44, Meem), Letter = Meem }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 45, ChapterName = "Casiye" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(45, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(45, Meem), Letter = Meem }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 46, ChapterName = "Ahkaf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(46, Hah), Letter  = Hah },
                                new InitialLetter { Id = Id(46, Meem), Letter = Meem }
                            }
                        }
                    }
                }
            },

            new Note
            {
                AsLetter(Hah), " ve ", AsLetter(Meem), " ile başlayan 7 tane sure vardır.",
                " Bu iki harfin bu 7 suredeki geçiş adeti ise ", 2147.AsMultipleOf19(), "'tür.",
                br,
                " Bu 7 sure neredeyse Kuranın 5 de 1'ine tekabül eder.",
                " Eğer bu iki harften bir tanesi fazla veya eksik olsaydı yukarıdaki şekildeki gibi bir ahenk olmazdı.",
                br,
                br,
                "Mesela Mekke şehri bu surelerde 'Mekke' yerine 'Bekke' şeklinde yazılmıştır.",
                " Neden Bekke şeklinde yazıldığı ile ilgili başka yorumlar da elbet var. Ama Yukarıdaki şekil incelendiğinde sanırım nedeni daha net anlaşılıyor.",
                " Eğer Mekke şeklinde yazılsaydı ", AsLetter(Meem), " harfleri bir fazla olurdu ve bu şekildeki ahenk olmazdı."
            },

            new Arrow { start = Id(40, Hah), end  = IdOfCountingResult },
            new Arrow { start = Id(40, Meem), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(41, Hah), end  = IdOfCountingResult },
            new Arrow { start = Id(41, Meem), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(42, Hah), end  = IdOfCountingResult },
            new Arrow { start = Id(42, Meem), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(43, Hah), end  = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(43, Meem), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(44, Hah), end  = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(44, Meem), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(45, Hah), end  = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(45, Meem), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(46, Hah), end  = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(46, Meem), end = IdOfCountingResult, StartAnchorFromRight = true }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"HaMim-{chapterNumber}-{letter}";
    }
}