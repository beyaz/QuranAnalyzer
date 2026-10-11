using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_HaMimSeparated : InitialLetterGroup
{
    static string IdOfCountingResult_1 => $"HaMimSeparated-{nameof(IdOfCountingResult_1)}";
    static string IdOfCountingResult_2 => $"HaMimSeparated-{nameof(IdOfCountingResult_2)}";
    bool ShowCounts => Query[QueryKey.ShowNumbers] == "1";

    protected override Element render()
    {
        const string firstColor = "#871F78";
        const string secondColor = "#c75fe0";

        (int? count, string url, string color) getOnlyOneLetterCountingInfo(string verseSelectScript, char letter, int? count, string color)
        {
            if (!ShowCounts)
            {
                return default;
            }

            return (count, Extensions.GetUrlOfLetterCountingSearchScript(GetLetterCountingScript(verseSelectScript, letter)), color);
        }

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
                            new Chapter { ChapterNumber = 40, ChapterName = "Mümin" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter
                                {
                                    Id     = Id(40, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("40:*", Hah, 64, firstColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(40, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("40:*", Meem, 380, firstColor)
                                }
                            }
                        },
                        new td
                        {
                            rowSpan = 5,
                            children =
                            {
                                new FlexRow(JustifyContentCenter, MarginTop(-50))
                                {
                                    new CountingResult
                                    {
                                        id              = IdOfCountingResult_1,
                                        MultipleOf      = 59,
                                        MultipleOfColor = ShowCounts ? firstColor : null,
                                        SearchScript    = GetLetterCountingScript("40:*,41:*,42:*", Hah, Meem)
                                    }
                                }
                            }
                        }
                    },
                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 41, ChapterName = "Fussilet" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter
                                {
                                    Id     = Id(41, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("41:*", Hah, 48, firstColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(41, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("41:*", Meem, 276, firstColor)
                                }
                            }
                        }
                    },

                    RowSpace,
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
                                new InitialLetter
                                {
                                    Id     = Id(42, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("42:*", Hah, 53, firstColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(42, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("42:*", Meem, 300, firstColor)
                                }
                            }
                        }
                    },
                    RowSpace,
                    RowSpace,
                    new tr
                    {
                        new td(),

                        new td(DisplayFlex, JustifyContentCenter, When(ShowCounts is false, DisplayNone))
                        {
                            new div(TextAlignCenter, MaxWidth(300))
                            {
                                "Yukarıdaki geçiş adetlerinin rakamları toplamı ", (span)"59" + Color(firstColor), "'dur",
                                br,
                                (small)"59 = (6+4 + 3+8+0 + 4+8 + 2+7+6 + 5+3 + 3+0+0)"
                            }
                        },
                        new td()
                    },

                    RowSpace,
                    RowSpace,

                    new tr
                    {
                        new td(),

                        new td(DisplayFlex, JustifyContentCenter)
                        {
                            new FlexRow(AlignItemsCenter, Gap(5))
                            {
                                CreateSeparationSwitch,
                                "Geçiş adetlerini göster"
                            }
                        },
                        new td()
                    },
                    RowSpace,
                    RowSpace,
                    new tr
                    {
                        new td(),

                        new td(DisplayFlex, JustifyContentCenter, When(ShowCounts is false, DisplayNone))
                        {
                            new div(TextAlignCenter, MaxWidth(300))
                            {
                                "Aşağıdaki geçiş adetlerinin rakamları toplamı ", (span)"54" + Color(firstColor), "'dür",
                                br,
                                (small)"54 = (4+4 + 3+2+4 + 1+6 + 1+5+0 + 3+1 + 2+0+0 + 3+6 + 2+2+5)"
                            }
                        },
                        new td()
                    },

                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 43, ChapterName = "Zuhruf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter
                                {
                                    Id     = Id(43, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("43:*", Hah, 44, secondColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(43, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("43:*", Meem, 324, secondColor)
                                }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 44, ChapterName = "Duhan" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter
                                {
                                    Id     = Id(44, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("44:*", Hah, 16, secondColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(44, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("44:*", Meem, 150, secondColor)
                                }
                            }
                        },
                        new td
                        {
                            rowSpan = 6,
                            children =
                            {
                                new FlexRow(JustifyContentCenter, MarginTop(-50))
                                {
                                    new CountingResult
                                    {
                                        id              = IdOfCountingResult_2,
                                        MultipleOf      = 54,
                                        MultipleOfColor = ShowCounts ? secondColor : null,
                                        SearchScript    = GetLetterCountingScript("43:*,44:*,45:*,46:*", Hah, Meem)
                                    }
                                }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 45, ChapterName = "Casiye" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter
                                {
                                    Id     = Id(45, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("45:*", Hah, 31, secondColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(45, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("45:*", Meem, 200, secondColor)
                                }
                            }
                        }
                    },

                    RowSpace,
                    new tr
                    {
                        new td
                        {
                            new Chapter { ChapterNumber = 46, ChapterName = "Ahkaf" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter
                                {
                                    Id     = Id(46, Hah),
                                    Letter = Hah,
                                    Count  = getOnlyOneLetterCountingInfo("46:*", Hah, 36, secondColor)
                                },
                                new InitialLetter
                                {
                                    Id     = Id(46, Meem),
                                    Letter = Meem,
                                    Count  = getOnlyOneLetterCountingInfo("46:*", Meem, 225, secondColor)
                                }
                            }
                        }
                    }
                }
            },

            new Note
            {
                " Başlangıç harfleri genelde surelerin ilk ayetinde olur. Bunun tek istisnası 42. suredir. ",
                " 42. sure diğerlerinden farklı olarak 2. ayetinde de başlangıç harfi barındırır.",
                br,
                " Şekilden de görüldüğü üzere 42. suredeki bu olay farklı bir ahenk daha katar. ",
                " Sanki bu 7 surede var olan ", AsLetter(Hah), " - ", AsLetter(Meem), " tablosunu 19.un katları şeklinde ikiye bölüyormuş gibi düşünebilirsiniz. ",
                "Hatta bu iki şemadaki sayımların rakamları toplamı dahi kendi çarpanı vermektedir."
            },

            new Arrow { start = Id(40, Hah), end  = IdOfCountingResult_1, StartAnchorFromRight = true },
            new Arrow { start = Id(40, Meem), end = IdOfCountingResult_1, StartAnchorFromRight = true },
            new Arrow { start = Id(41, Hah), end  = IdOfCountingResult_1, StartAnchorFromRight = true },
            new Arrow { start = Id(41, Meem), end = IdOfCountingResult_1, StartAnchorFromRight = true },
            new Arrow { start = Id(42, Hah), end  = IdOfCountingResult_1, StartAnchorFromRight = true },
            new Arrow { start = Id(42, Meem), end = IdOfCountingResult_1, StartAnchorFromRight = true },

            new Arrow { start = Id(43, Hah), end  = IdOfCountingResult_2, StartAnchorFromRight = true },
            new Arrow { start = Id(43, Meem), end = IdOfCountingResult_2, StartAnchorFromRight = true },

            new Arrow { start = Id(44, Hah), end  = IdOfCountingResult_2, StartAnchorFromRight = false },
            new Arrow { start = Id(44, Meem), end = IdOfCountingResult_2, StartAnchorFromRight = false },

            new Arrow { start = Id(45, Hah), end  = IdOfCountingResult_2, StartAnchorFromTop   = true },
            new Arrow { start = Id(45, Meem), end = IdOfCountingResult_2, StartAnchorFromRight = true },
            new Arrow { start = Id(46, Hah), end  = IdOfCountingResult_2, StartAnchorFromTop   = true },
            new Arrow { start = Id(46, Meem), end = IdOfCountingResult_2, StartAnchorFromRight = true }
        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"HaMimSeparated-{chapterNumber}-{letter}";
    }

    Element CreateSeparationSwitch()
    {
        var query = Query;

        var isChecked = query[QueryKey.ShowNumbers] == "1";

        query[QueryKey.ShowNumbers] = isChecked ? "0" : "1";

        return new a(Href($"?{query}"))
        {
            new Switch
            {
                IsChecked  = isChecked,
                IsDisabled = true
            }
        };
    }
}