using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Alef_Lam_Raa : InitialLetterGroup
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
                            new Chapter { ChapterNumber = 10, ChapterName = "Yunus" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(10, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(10, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(10, Reh), Letter  = Reh }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(10), MultipleOf = 131, SearchScript = GetLetterCountingScript("10:*", Alef, Lam, Reh)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 11, ChapterName = "Hûd" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(11, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(11, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(11, Reh), Letter  = Reh }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(11), MultipleOf = 131, SearchScript = GetLetterCountingScript("11:*", Alef, Lam, Reh)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 12, ChapterName = "Yusuf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(12, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(12, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(12, Reh), Letter  = Reh }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(12), MultipleOf = 125, SearchScript = GetLetterCountingScript("12:*", Alef, Lam, Reh)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 14, ChapterName = "İbrahim" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(14, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(14, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(14, Reh), Letter  = Reh }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(14), MultipleOf = 63, SearchScript = GetLetterCountingScript("14:*", Alef, Lam, Reh)
                                }
                            }
                        }
                    },

                    RowSpace,

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 15, ChapterName = "Hicr" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(15, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(15, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(15, Reh), Letter  = Reh }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(15), MultipleOf = 48, SearchScript = GetLetterCountingScript("15:*", Alef, Lam, Reh)
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(10, Alef), end = IdOfCountingResult(10) },
            new Arrow { start = Id(10, Lam), end = IdOfCountingResult(10) },
            new Arrow { start = Id(10, Reh), end  = IdOfCountingResult(10) },

            new Arrow { start = Id(11, Alef), end = IdOfCountingResult(11) },
            new Arrow { start = Id(11, Lam), end = IdOfCountingResult(11) },
            new Arrow { start = Id(11, Reh), end  = IdOfCountingResult(11) },

            new Arrow { start = Id(12, Alef), end = IdOfCountingResult(12) },
            new Arrow { start = Id(12, Lam), end = IdOfCountingResult(12) },
            new Arrow { start = Id(12, Reh), end  = IdOfCountingResult(12) },

            new Arrow { start = Id(14, Alef), end = IdOfCountingResult(14) },
            new Arrow { start = Id(14, Lam), end = IdOfCountingResult(14) },
            new Arrow { start = Id(14, Reh), end  = IdOfCountingResult(14) },

            new Arrow { start = Id(15, Alef), end = IdOfCountingResult(15) },
            new Arrow { start = Id(15, Lam), end = IdOfCountingResult(15) },
            new Arrow { start = Id(15, Reh), end  = IdOfCountingResult(15) }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Alef_Lam_Raa-{chapterNumber}-{letter}";
    }

    static string IdOfCountingResult(int chapterNumber)
    {
        return $"Alef_Lam_Raa-{chapterNumber}";
    }
}