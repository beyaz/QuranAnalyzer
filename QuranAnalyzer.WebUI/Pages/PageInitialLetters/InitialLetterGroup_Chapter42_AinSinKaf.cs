using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_Chapter42_AinSinKaf : InitialLetterGroup
{
    static Element countingResult => new CountingResult { id = IdOfCountingResult, MultipleOf = 11, SearchScript = GetLetterCountingScript("42:*", Ain, Seen, Qaf) };

    static string IdOfCountingResult => $"42_AinSinKaf-{nameof(IdOfCountingResult)}";

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
                                new InitialLetter { Id = Id(42, Ain), Letter  = Ain },
                                new InitialLetter { Id = Id(42, Seen), Letter = Seen },
                                new InitialLetter { Id = Id(42, Qaf), Letter = Qaf }
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
                "Kurandaki başlangıç harfleri surenin sadece ilk ayetinde olur.",
                " Bunun tek istisnası 42. suredir.",
                " Bu surenin hem 1. ayeti hem 2.ayeti başlangıç harflerinden oluşur. ",
                AsLetter(Ain), " , ", AsLetter(Seen), " , ", AsLetter(Qaf), " harflerinin bu sure boyunca geçiş adeti ise yine 19 un katı olan ",
                209.AsMultipleOf19(), " sayısıdır."
            },

            new Arrow { start = Id(42, Ain), end  = IdOfCountingResult },
            new Arrow { start = Id(42, Seen), end = IdOfCountingResult },
            new Arrow { start = Id(42, Qaf), end = IdOfCountingResult }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"42_AinSinKaf-{chapterNumber}-{letter}";
    }
}