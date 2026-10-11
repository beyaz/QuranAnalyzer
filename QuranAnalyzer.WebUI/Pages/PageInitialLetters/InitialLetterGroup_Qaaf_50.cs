using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Qaaf_50 : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 3, SearchScript = GetLetterCountingScript("50:*", Qaf) };

    static string IdOfCountingResult => $"Qaaf_50-{nameof(IdOfCountingResult)}";

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
                            new Chapter { ChapterNumber = 50, ChapterName = "Kaf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(50, Qaf), Letter = Qaf }
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

            new Note
            {
                "Kuranda 50. surenin adı  'Kaf Suresi' dir. Surenin başında sadece bir tane ", AsLetter(Qaf), " harfi vardır.",

                " Bu surede toplamda ", 57.AsMultipleOf19(), " tane ", AsLetter(Qaf), " harfi içerir.",
                " İsterseniz incele linkine tıklayarak bu sayımları kendiniz yapabilirsiniz."
            },

            new Arrow { start = Id(50, Qaf), end = IdOfCountingResult, StartAnchorFromRight = true }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Qaaf_50-{chapterNumber}-{letter}";
    }
}