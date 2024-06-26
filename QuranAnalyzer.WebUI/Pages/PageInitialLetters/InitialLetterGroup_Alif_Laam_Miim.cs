﻿using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Alif_Laam_Miim : InitialLetterGroup
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
                                new InitialLetter { Id = Id(2, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(2, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(2, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(2), MultipleOf = 521, SearchScript = GetLetterCountingScript("2:*", Alif, Laam, Miim)
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
                                new InitialLetter { Id = Id(3, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(3, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(3, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(3), MultipleOf = 298, SearchScript = GetLetterCountingScript("3:*", Alif, Laam, Miim)
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
                                new InitialLetter { Id = Id(29, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(29, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(29, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(29), MultipleOf = 88, SearchScript = GetLetterCountingScript("29:*", Alif, Laam, Miim)
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
                                new InitialLetter { Id = Id(30, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(30, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(30, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(30), MultipleOf = 66, SearchScript = GetLetterCountingScript("30:*", Alif, Laam, Miim)
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
                                new InitialLetter { Id = Id(31, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(31, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(31, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(31), MultipleOf = 43, SearchScript = GetLetterCountingScript("31:*", Alif, Laam, Miim)
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
                                new InitialLetter { Id = Id(32, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(32, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(32, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            new FlexRow(resultContainerCss)
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(32), MultipleOf = 30, SearchScript = GetLetterCountingScript("32:*", Alif, Laam, Miim)
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(2, Alif), end = IdOfCountingResult(2) },
            new Arrow { start = Id(2, Laam), end = IdOfCountingResult(2) },
            new Arrow { start = Id(2, Miim), end = IdOfCountingResult(2) },

            new Arrow { start = Id(3, Alif), end = IdOfCountingResult(3) },
            new Arrow { start = Id(3, Laam), end = IdOfCountingResult(3) },
            new Arrow { start = Id(3, Miim), end = IdOfCountingResult(3) },

            new Arrow { start = Id(29, Alif), end = IdOfCountingResult(29) },
            new Arrow { start = Id(29, Laam), end = IdOfCountingResult(29) },
            new Arrow { start = Id(29, Miim), end = IdOfCountingResult(29) },

            new Arrow { start = Id(30, Alif), end = IdOfCountingResult(30) },
            new Arrow { start = Id(30, Laam), end = IdOfCountingResult(30) },
            new Arrow { start = Id(30, Miim), end = IdOfCountingResult(30) },

            new Arrow { start = Id(31, Alif), end = IdOfCountingResult(31) },
            new Arrow { start = Id(31, Laam), end = IdOfCountingResult(31) },
            new Arrow { start = Id(31, Miim), end = IdOfCountingResult(31) },

            new Arrow { start = Id(32, Alif), end = IdOfCountingResult(32) },
            new Arrow { start = Id(32, Laam), end = IdOfCountingResult(32) },
            new Arrow { start = Id(32, Miim), end = IdOfCountingResult(32) }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Alif_Laam_Miim-{chapterNumber}-{letter}";
    }

    static string IdOfCountingResult(int chapterNumber)
    {
        return $"Alif_Laam_Miim-{chapterNumber}";
    }
}