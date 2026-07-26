using System.Collections.Immutable;
using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageInitialLetters;

class InitialLetterGroup_HaMimAll : InitialLetterGroup
{
    static string IdOfCountingResult_19_59 => $"HaMimSeparated-{nameof(IdOfCountingResult_19_59)}";

    static string IdOfCountingResult_19_55 => $"HaMimSeparated-{nameof(IdOfCountingResult_19_55)}";
    
    static string IdOfCountingResult_19_113 => $"HaMim-{nameof(IdOfCountingResult_19_113)}";
    
    static string IdOfCountingResult_19_54 => $"HaMimSeparated-{nameof(IdOfCountingResult_19_54)}";

    static string IdOfCountingResult_19_58 => $"HaMimSeparated-{nameof(IdOfCountingResult_19_58)}";

    public string SelectedCountResultId { get; set; }


    public bool SimulationIsActive { get; set; } = true;
    
    Task onMouseEntered(MouseEvent e)
    {
        
        SimulationIsActive = false;
        
        SelectedCountResultId = e.currentTarget.id;

        return Task.CompletedTask;
    }

    static readonly ImmutableList<string> IdListOfAllCountResults =
    [
        IdOfCountingResult_19_59,
        IdOfCountingResult_19_55,
        IdOfCountingResult_19_113,
        IdOfCountingResult_19_54,
        IdOfCountingResult_19_58
    ];
    
    Task FocusNextCount()
    {
        if (!SimulationIsActive)
        {
            return Task.CompletedTask;
        }
        
        var index = IdListOfAllCountResults.IndexOf(SelectedCountResultId);
        
        index++;

        if (index >= IdListOfAllCountResults.Count)
        {
            index = 0;
        }
        
        SelectedCountResultId = IdListOfAllCountResults[index];
        
        Client.GotoMethod(FocusNextCount,TimeSpan.FromSeconds(1));

        return Task.CompletedTask;
    }

    protected override Task constructor()
    {
        Client.GotoMethod(FocusNextCount,TimeSpan.FromSeconds(1));
        return base.constructor();
    }

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
                            new Chapter { ChapterNumber = 40, ChapterName = "Mümin" }
                        },
                        new td
                        {
                            new InitialLetterLineGroup
                            {
                                new InitialLetter { Id = Id(40, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(40, Miim), Letter = Miim }
                            }
                        },
                        new td
                        {
                            rowSpan = 99,
                            children =
                            {
                                new FlexRow(JustifyContentCenter)
                                {
                                    new CountingResult
                                    {
                                        id             = IdOfCountingResult_19_59,
                                        MultipleOf     = 59,
                                        SearchScript   = GetLetterCountingScript("40:*,41:*,42:*", Haa, Miim),
                                        OnMouseEntered = onMouseEntered
                                    }
                                },


                                SpaceY(100),

                                new FlexRow(JustifyContentCenter)
                                {
                                    new CountingResult
                                    {
                                        id             = IdOfCountingResult_19_55,
                                        MultipleOf     = 55,
                                        SearchScript   = GetLetterCountingScript("41:*,42:*,43:*", Haa, Miim),
                                        OnMouseEntered = onMouseEntered
                                    }
                                },

                                SpaceY(100),

                                new FlexRow(JustifyContentCenter)
                                {
                                    new CountingResult
                                    {
                                        id           = IdOfCountingResult_19_113,
                                        MultipleOf   = 113,
                                        SearchScript = GetLetterCountingScript("40:*,41:*,42:*,43:*,44:*,45:*,46:*", Haa, Miim),

                                        OnMouseEntered = onMouseEntered
                                    }
                                },

                                SpaceY(100),

                                new FlexRow(JustifyContentCenter)
                                {
                                    new CountingResult
                                    {
                                        id           = IdOfCountingResult_19_54,
                                        MultipleOf   = 54,
                                        SearchScript = GetLetterCountingScript("43:*,44:*,45:*,46:*", Haa, Miim),

                                        OnMouseEntered = onMouseEntered
                                    }

                                },



                                SpaceY(100),

                                new FlexRow(JustifyContentCenter)
                                {
                                    new CountingResult
                                    {
                                        id             = IdOfCountingResult_19_58,
                                        MultipleOf     = 58,
                                        SearchScript   = GetLetterCountingScript("40:*,44:*,45:*,46:*", Haa, Miim),
                                        OnMouseEntered = onMouseEntered
                                    }
                                },
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
                                new InitialLetter { Id = Id(41, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(41, Miim), Letter = Miim }
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
                                new InitialLetter { Id = Id(42, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(42, Miim), Letter = Miim }
                            }
                        }
                    },

                    RowSpace,
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
                                new InitialLetter { Id = Id(43, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(43, Miim), Letter = Miim }
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
                                new InitialLetter { Id = Id(44, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(44, Miim), Letter = Miim }
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
                                new InitialLetter { Id = Id(45, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(45, Miim), Letter = Miim }
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
                                new InitialLetter { Id = Id(46, Haa), Letter  = Haa },
                                new InitialLetter { Id = Id(46, Miim), Letter = Miim }
                            }
                        }
                    }
                }
            },

            new Note
            {
                "Şekilden de anlaşılacağı üzere ", AsLetter(Haa), " ve ", AsLetter(Miim), " harfleri bu 7 sure boyunca kendi içinde alt gruplar da oluşturmaktadır.",
            },

            SelectedCountResultId == IdOfCountingResult_19_59
                ? new div
                {
                    new Arrow { start = Id(40, Haa), end  = IdOfCountingResult_19_59, StartAnchorFromRight = true },
                    new Arrow { start = Id(40, Miim), end = IdOfCountingResult_19_59, StartAnchorFromRight = true },
                    
                    new Arrow { start = Id(41, Haa), end  = IdOfCountingResult_19_59, StartAnchorFromRight = true },
                    new Arrow { start = Id(41, Miim), end = IdOfCountingResult_19_59, StartAnchorFromRight = true },
                    
                    new Arrow { start = Id(42, Haa), end  = IdOfCountingResult_19_59, StartAnchorFromRight = true },
                    new Arrow { start = Id(42, Miim), end = IdOfCountingResult_19_59, StartAnchorFromRight = true },
                }
                : null,

            SelectedCountResultId == IdOfCountingResult_19_55
                ? new div
                {
                    new Arrow { start = Id(41, Haa), end  = IdOfCountingResult_19_55, StartAnchorFromRight = true, },
                    new Arrow { start = Id(41, Miim), end = IdOfCountingResult_19_55, StartAnchorFromRight = true },

                    new Arrow { start = Id(42, Haa), end  = IdOfCountingResult_19_55, StartAnchorFromRight = true },
                    new Arrow { start = Id(42, Miim), end = IdOfCountingResult_19_55, StartAnchorFromRight = true },

                    new Arrow { start = Id(43, Haa), end  = IdOfCountingResult_19_55, StartAnchorFromRight = true, },
                    new Arrow { start = Id(43, Miim), end = IdOfCountingResult_19_55, StartAnchorFromRight = true },
                }
                : null,

            SelectedCountResultId == IdOfCountingResult_19_113
                ? new div
                {


                    // 19 x 113
                    new Arrow { start = Id(40, Haa), end  = IdOfCountingResult_19_113 },
                    new Arrow { start = Id(40, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                    new Arrow { start = Id(41, Haa), end  = IdOfCountingResult_19_113 },
                    new Arrow { start = Id(41, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                    new Arrow { start = Id(42, Haa), end  = IdOfCountingResult_19_113 },
                    new Arrow { start = Id(42, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                    new Arrow { start = Id(43, Haa), end  = IdOfCountingResult_19_113, StartAnchorFromTop   = true },
                    new Arrow { start = Id(43, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                    new Arrow { start = Id(44, Haa), end  = IdOfCountingResult_19_113, StartAnchorFromTop   = true },
                    new Arrow { start = Id(44, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                    new Arrow { start = Id(45, Haa), end  = IdOfCountingResult_19_113, StartAnchorFromTop   = true },
                    new Arrow { start = Id(45, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                    new Arrow { start = Id(46, Haa), end  = IdOfCountingResult_19_113, StartAnchorFromTop   = true },
                    new Arrow { start = Id(46, Miim), end = IdOfCountingResult_19_113, StartAnchorFromRight = true },
                }
                : null,

            SelectedCountResultId == IdOfCountingResult_19_54
                ? new div
                {


                    new Arrow { start = Id(43, Haa), end  = IdOfCountingResult_19_54, StartAnchorFromRight  = true },
                    new Arrow { start = Id(43, Miim), end = IdOfCountingResult_19_54 , StartAnchorFromRight = true},

                    new Arrow { start = Id(44, Haa), end  = IdOfCountingResult_19_54 , StartAnchorFromRight = true},
                    new Arrow { start = Id(44, Miim), end = IdOfCountingResult_19_54, StartAnchorFromRight  = true },

                    new Arrow { start = Id(45, Haa), end  = IdOfCountingResult_19_54, StartAnchorFromRight = true },
                    new Arrow { start = Id(45, Miim), end = IdOfCountingResult_19_54, StartAnchorFromRight = true },

                    new Arrow { start = Id(46, Haa), end  = IdOfCountingResult_19_54, StartAnchorFromRight = true },
                    new Arrow { start = Id(46, Miim), end = IdOfCountingResult_19_54, StartAnchorFromRight = true },
                }
                : null,

            SelectedCountResultId == IdOfCountingResult_19_58
                ? new div
                {
                    // 19 x 58
                    new Arrow { start = Id(40, Haa), end  = IdOfCountingResult_19_58, StartAnchorFromRight = true },
                    new Arrow { start = Id(40, Miim), end = IdOfCountingResult_19_58, StartAnchorFromRight = true },

                    new Arrow { start = Id(44, Haa), end  = IdOfCountingResult_19_58, StartAnchorFromRight = true },
                    new Arrow { start = Id(44, Miim), end = IdOfCountingResult_19_58, StartAnchorFromRight = true },

                    new Arrow { start = Id(45, Haa), end  = IdOfCountingResult_19_58, StartAnchorFromRight = true },
                    new Arrow { start = Id(45, Miim), end = IdOfCountingResult_19_58, StartAnchorFromRight = true },

                    new Arrow { start = Id(46, Haa), end  = IdOfCountingResult_19_58, StartAnchorFromRight   = true },
                    new Arrow { start = Id(46, Miim), end = IdOfCountingResult_19_58, StartAnchorFromRight = true },

                }
                : null


        };
    }

    static string Id(int chapterNumber, char letter)
    {
        return $"HaMim-{chapterNumber}-{letter}";
    }
}