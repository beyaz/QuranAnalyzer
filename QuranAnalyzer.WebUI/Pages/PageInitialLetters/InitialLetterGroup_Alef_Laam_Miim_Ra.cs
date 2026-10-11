using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Alif_Lam_Miim_Ra : InitialLetterGroup
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
                            new Chapter { ChapterNumber = 13, ChapterName = "Rad" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(13, Alef), Letter = Alef },
                                new InitialLetter { Id = Id(13, Lam), Letter = Lam },
                                new InitialLetter { Id = Id(13, Meem), Letter = Meem },
                                new InitialLetter { Id = Id(13, Reh), Letter  = Reh }
                            }
                        },
                        new td
                        {
                            new FlexRow(JustifyContentCenter, MarginTop(65))
                            {
                                new CountingResult
                                {
                                    id = IdOfCountingResult(13), MultipleOf = 78, SearchScript = GetLetterCountingScript("13:*", Alef, Lam, Meem, Reh)
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(13, Alef), end = IdOfCountingResult(13) },
            new Arrow { start = Id(13, Lam), end = IdOfCountingResult(13) },
            new Arrow { start = Id(13, Meem), end = IdOfCountingResult(13) },
            new Arrow { start = Id(13, Reh), end  = IdOfCountingResult(13) }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Alef_Laam_Miim_Ra-{chapterNumber}-{letter}";
    }

    static string IdOfCountingResult(int chapterNumber)
    {
        return $"Alef_Laam_Miim_Ra-{chapterNumber}";
    }
}