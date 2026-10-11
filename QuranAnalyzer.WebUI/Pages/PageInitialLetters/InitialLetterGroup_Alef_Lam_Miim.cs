using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Alef_Lam_Miim : InitialLetterGroup
{
    protected override Element render()
    {
        var resultContainerCss = JustifyContentCenter + MarginTop(65);

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
                            new Chapter { ChapterNumber = 2, ChapterName = "Bakara" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(2, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(2, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(2, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(2), MultipleOf = 521, SearchScript = GetLetterCountingScript("2:*", Alef, Lam, Meem)
                                }
                            }
                        }
                    },
                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 3, ChapterName = "İmran Ailesi" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(3, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(3, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(3, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(3), MultipleOf = 298, SearchScript = GetLetterCountingScript("3:*", Alef, Lam, Meem)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 29, ChapterName = "Ankebut" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(29, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(29, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(29, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(29), MultipleOf = 88, SearchScript = GetLetterCountingScript("29:*", Alef, Lam, Meem)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 30, ChapterName = "Rum" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(30, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(30, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(30, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(30), MultipleOf = 66, SearchScript = GetLetterCountingScript("30:*", Alef, Lam, Meem)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 31, ChapterName = "Lokman" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(31, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(31, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(31, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(31), MultipleOf = 43, SearchScript = GetLetterCountingScript("31:*", Alef, Lam, Meem)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 32, ChapterName = "Secde" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(32, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(32, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(32, Meem), Letter = Meem }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(32), MultipleOf = 30, SearchScript = GetLetterCountingScript("32:*", Alef, Lam, Meem)
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(2, Alef), end = IdOfCountingResult(2) },
            new Arrow { start = Id(2, Lam), end = IdOfCountingResult(2) },
            new Arrow { start = Id(2, Meem), end = IdOfCountingResult(2) },

            new Arrow { start = Id(3, Alef), end = IdOfCountingResult(3) },
            new Arrow { start = Id(3, Lam), end = IdOfCountingResult(3) },
            new Arrow { start = Id(3, Meem), end = IdOfCountingResult(3) },

            new Arrow { start = Id(29, Alef), end = IdOfCountingResult(29) },
            new Arrow { start = Id(29, Lam), end = IdOfCountingResult(29) },
            new Arrow { start = Id(29, Meem), end = IdOfCountingResult(29) },

            new Arrow { start = Id(30, Alef), end = IdOfCountingResult(30) },
            new Arrow { start = Id(30, Lam), end = IdOfCountingResult(30) },
            new Arrow { start = Id(30, Meem), end = IdOfCountingResult(30) },

            new Arrow { start = Id(31, Alef), end = IdOfCountingResult(31) },
            new Arrow { start = Id(31, Lam), end = IdOfCountingResult(31) },
            new Arrow { start = Id(31, Meem), end = IdOfCountingResult(31) },

            new Arrow { start = Id(32, Alef), end = IdOfCountingResult(32) },
            new Arrow { start = Id(32, Lam), end = IdOfCountingResult(32) },
            new Arrow { start = Id(32, Meem), end = IdOfCountingResult(32) }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Alef_Laam_Miim-{chapterNumber}-{letter}";
    }

    static string IdOfCountingResult(int chapterNumber)
    {
        return $"Alef_Laam_Miim-{chapterNumber}";
    }
}