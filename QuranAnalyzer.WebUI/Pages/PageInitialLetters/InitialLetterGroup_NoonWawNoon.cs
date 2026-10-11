using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_NoonWawNoon : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 7, SearchScript = GetLetterCountingScript("68:*", Noon) };

    static string IdOfCountingResult => $"NunWawNun-{nameof(IdOfCountingResult)}";

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
                            new Chapter { ChapterNumber = 68, ChapterName = "Kalem" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(68, Noon), Letter = Noon }
                            }
                        },
                        new td
                        {
                            rowSpan = 99,
                            children =
                            {
                                new FlexRow(JustifyContentCenter)
                                {
                                    countingResult
                                }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(68, Noon), end = IdOfCountingResult, StartAnchorFromRight = true },

            new Note
            {
                "Bu surenin başlangıç harfinin tek ", AsLetter(Noon), " değil ", AsLetter(Noon), AsLetter(Waw), AsLetter(Noon), " şeklinde yazıldığı iddiası vardır.",
                " Soru-cevap kısmında açıklanmıştır."
            }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"NunWawNun-{chapterNumber}-{letter}";
    }
}