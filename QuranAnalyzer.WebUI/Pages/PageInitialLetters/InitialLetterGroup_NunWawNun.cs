using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_NunWawNun : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 7, SearchScript = GetLetterCountingScript("68:*", Nun) };

    static string IdOfCountingResult => $"NunWawNun-{nameof(IdOfCountingResult)}";

    protected override Element render()
    {
        return new div
        {
            new table(WidthMaximized)
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
                                new InitialLetter { Id = Id(68, Nun), Letter = Nun }
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
                    },
                }
            },

            new Arrow { start = Id(68, Nun), end = IdOfCountingResult, StartAnchorFromRight = true },

            new Note
            {
                "Bu surenin başlangıç harfinin tek ", AsLetter(Nun)," değil ",AsLetter(Nun),AsLetter(Waaw),AsLetter(Nun), " şeklinde yazıldığı iddiası vardır.",
                " Soru-cevap kısmında açıklanmıştır."
            }
        };
    }

    static string Id(int chapterNumber, string letter) => $"NunWawNun-{chapterNumber}-{letter}";
}