using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Qaf_42 : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 3, SearchScript = GetLetterCountingScript("42:*", Qaf) };

    static string IdOfCountingResult => $"Qaf_42-{nameof(IdOfCountingResult)}";

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
                            new Chapter { ChapterNumber = 42, ChapterName = "Şura" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(42, Qaf), Letter = Qaf }
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
                "42. surede yine ", AsLetter(Qaf), " başlangıç harfi vardır.",
                " Bu surede toplamda ", 57.AsMultipleOf19(), " adet ", AsLetter(Qaf), " harfi vardır.",
                br, br,
                "Kuranda ", AsLetter(Qaf), " başlangıç harfi içeren iki tane sure vardır.",
                "  Bu iki sure de kendi içlerinde eşit sayıda yani ", 57.AsMultipleOf19(), " adet ", AsLetter(Qaf), " harfi içerir."
            },

            new Arrow { start = Id(42, Qaf), end = IdOfCountingResult, StartAnchorFromRight = true }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Qaf_42-{chapterNumber}-{letter}";
    }
}