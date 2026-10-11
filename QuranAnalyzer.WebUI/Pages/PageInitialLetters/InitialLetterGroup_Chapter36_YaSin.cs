using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Chapter36_YaSin : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 15, SearchScript = GetLetterCountingScript("36:*", Yeh, Seen) };

    static string IdOfCountingResult => $"Chapter36_YaSin-{nameof(IdOfCountingResult)}";

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
                            new Chapter { ChapterNumber = 36, ChapterName = "Yasin" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(36, Yeh), Letter  = Yeh },
                                new InitialLetter { Id = Id(36, Seen), Letter = Seen }
                            }
                        },
                        new td
                        {
                            rowSpan = 99,
                            children =
                            {
                                new FlexRow(JustifyContentCenter, MarginTop(70))
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
                "Belki de ismi en yaygın olarak bilinen sure Yasin suresidir.",
                " Bu sure ", AsLetter(Yeh), " ve ", AsLetter(Seen), " olmak üzere iki tane başlangıç harfi ile başlar.",
                " Bu iki harfin bu suredeki toplam geçiş adeti ise ", 285.AsMultipleOf19(), "' tir."
            },

            new Arrow { start = Id(36, Yeh), end  = IdOfCountingResult },
            new Arrow { start = Id(36, Seen), end = IdOfCountingResult }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"Chapter36_YaSin-{chapterNumber}-{letter}";
    }
}