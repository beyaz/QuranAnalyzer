﻿using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Alif_Laam_Miim_Sad : InitialLetterGroup
{
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
                            new Chapter { ChapterNumber = 7, ChapterName = "Araf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(7, Alif), Letter = Alif },
                                new InitialLetter { Id = Id(7, Laam), Letter = Laam },
                                new InitialLetter { Id = Id(7, Miim), Letter = Miim },
                                new InitialLetter { Id = Id(7, Saad), Letter = Saad }
                            }
                        },
                        new td
                        {
                            new FlexRow(JustifyContentCenter, MarginTop(65))
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(7), MultipleOf = 280, SearchScript = GetLetterCountingScript("7:*", Alif, Laam, Miim, Saad)
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(7, Alif), end = IdOfCountingResult(7) },
            new Arrow { start = Id(7, Laam), end = IdOfCountingResult(7) },
            new Arrow { start = Id(7, Miim), end = IdOfCountingResult(7) },
            new Arrow { start = Id(7, Saad), end = IdOfCountingResult(7) }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Alif_Laam_Miim_Sad-{chapterNumber}-{letter}";
    }

    static string IdOfCountingResult(int chapterNumber)
    {
        return $"Alif_Laam_Miim_Sad-{chapterNumber}";
    }
}