using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_TaSinMim : InitialLetterGroup
{
    static Element countingResult => new CountingResult
    {
        id         = IdOfCountingResult,
        MultipleOf = 93,

        SearchScript = GetLetterCountingScript("19:*", Heh) + ";" +
                       GetLetterCountingScript("20:*", Tah, Heh) + ";" +
                       GetLetterCountingScript("26:*", Tah, Seen, Meem) + ";" +
                       GetLetterCountingScript("27:*", Tah, Seen) + ";" +
                       GetLetterCountingScript("28:*", Tah, Seen, Meem)
    };

    static string IdOfCountingResult => $"TaSinMim-{nameof(IdOfCountingResult)}";

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
                            new Chapter { ChapterNumber = 19, ChapterName = "Meryem" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(19, Qaf), Letter = Qaf },
                                new InitialLetter { Id = Id(19, Hah), Letter  = Heh, IsSelected = true },
                                new InitialLetter { Id = Id(19, Yeh), Letter  = Yeh },
                                new InitialLetter { Id = Id(19, Ain), Letter  = Ain },
                                new InitialLetter { Id = Id(19, Sad), Letter = Sad }
                            }
                        },
                        new td
                        {
                            rowSpan = 99,
                            children =
                            {
                                new FlexRow(JustifyContentCenter, MarginTop(-50))
                                {
                                    countingResult
                                }
                            }
                        }
                    },
                    RowSpace,
                    new tr
                    {
                        new td { new Chapter { ChapterNumber = 20, ChapterName = "Taha" } },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(20, Tah), Letter = Tah, IsSelected = true },
                                new InitialLetter { Id = Id(20, Heh), Letter = Heh, IsSelected  = true }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td { new Chapter { ChapterNumber = 26, ChapterName = "Şuara" } },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(26, Tah), Letter = Tah, IsSelected = true },
                                new InitialLetter { Id = Id(26, Seen), Letter = Seen, IsSelected = true },
                                new InitialLetter { Id = Id(26, Meem), Letter = Meem, IsSelected = true }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td { new Chapter { ChapterNumber = 27, ChapterName = "Neml" } },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(27, Tah), Letter = Tah, IsSelected = true },
                                new InitialLetter { Id = Id(27, Seen), Letter = Seen, IsSelected = true }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td { new Chapter { ChapterNumber = 28, ChapterName = "Kasas" } },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(28, Tah), Letter = Tah, IsSelected = true },
                                new InitialLetter { Id = Id(28, Seen), Letter = Seen, IsSelected = true },
                                new InitialLetter { Id = Id(28, Meem), Letter = Meem, IsSelected = true }
                            }
                        }
                    }
                }
            },

            new Arrow { start = Id(19, Hah), end  = IdOfCountingResult },
            new Arrow { start = Id(20, Tah), end = IdOfCountingResult },
            new Arrow { start = Id(20, Heh), end = IdOfCountingResult, StartAnchorFromRight = true },
            new Arrow { start = Id(26, Tah), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(26, Seen), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(26, Meem), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(27, Tah), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(27, Seen), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(28, Tah), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(28, Seen), end = IdOfCountingResult, StartAnchorFromTop   = true },
            new Arrow { start = Id(28, Meem), end = IdOfCountingResult, StartAnchorFromTop   = true },

            new Note
            {
                AsLetter(Tah), " harfi başlangıç harfi olarak ilk defa 20. surede karşımıza çıkar.",
                " Kuranda bulunan tüm ", AsLetter(Tah), " harflerinin tam ortasındadır. Solunda toplamda ",
                new a
                {
                    Href(GetPageLink(PageId.CharacterCounting) + "&" + QueryKey.SearchQuery + "=" + "1:1-->19:98|ط"),
                    " 636 tane, "
                },
                " sağında toplamda ",
                new a
                {
                    Href(GetPageLink(PageId.CharacterCounting) + "&" + QueryKey.SearchQuery + "=" + "20:2-->114:6|ط"),
                    " 636 tane "
                },
                AsLetter(Tah), " harfi bulunur.",
                br,
                "Ta-Sin-Mim-He grubu Kurandaki diğer başlangıç harf gruplarına pek benzemiyor.",
                " Belki ileride burası ile ilgili daha başka veriler açığa çıkabilir diye düşünüyorum."
            }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"TaSinMim-{chapterNumber}-{letter}";
    }
}