using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Alef_Laam_Miim_Sad : InitialLetterGroup
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
                                new InitialLetter { Id = Id(7, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(7, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(7, Meem), Letter = Meem },
                                new InitialLetter { Id = Id(7, Sad), Letter = Sad }
                            }
                        },
                        new td
                        {
                            new FlexRow(JustifyContentCenter, MarginTop(65))
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(7), MultipleOf = 280, SearchScript = GetLetterCountingScript("7:*", Alef, Lam, Meem, Sad)
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(7, Alef), end = IdOfCountingResult(7) },
            new Arrow { start = Id(7, Lam), end = IdOfCountingResult(7) },
            new Arrow { start = Id(7, Meem), end = IdOfCountingResult(7) },
            new Arrow { start = Id(7, Sad), end = IdOfCountingResult(7) }
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