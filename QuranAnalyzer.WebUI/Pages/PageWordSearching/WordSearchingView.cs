using QuranAnalyzer.WebUI.Pages.PageCharacterCounting;
using QuranAnalyzer.WebUI.Pages.Shared;
using Switch = ReactWithDotNet.ThirdPartyLibraries.MUI.Material.Switch;

namespace QuranAnalyzer.WebUI.Pages.PageWordSearching;

class WordSearchingViewModel
{
    public int ClickCount { get; set; }

    public bool IsBlocked { get; set; }

    public string SearchOption { get; set; } = WordSearchOption.Same;

    public string SearchScript { get; set; }

    public string SearchScriptErrorMessage { get; set; }
}

class WordSearchingView : ReactComponent<WordSearchingViewModel>
{
    protected override Task componentDidMount()
    {
        Client.OnArabicKeyboardPressed(ArabicKeyboardPressed);

        return Task.CompletedTask;
    }

    protected override Task constructor()
    {
        state = new();

        var value = Query[QueryKey.SearchQuery];
        if (value is not null)
        {
            var parseResponse = SearchScript.ParseScript(value);
            if (parseResponse.HasError)
            {
                state.SearchScriptErrorMessage = parseResponse.Error.Message;
                Client.GotoMethod(3000, ClearErrorMessage);

                return Task.CompletedTask;
            }

            state.SearchScript = parseResponse.Value.AsReadableString();
        }

        state.SearchOption = Query[QueryKey.SearchOption] ?? WordSearchOption.Same;

        return Task.CompletedTask;
    }

    protected override Element render()
    {
        if (state.ClickCount == 0)
        {
            return Container(Panel(searchPanel()));
        }

        var searchScript = SearchScript.ParseScript(state.SearchScript).Unwrap();

        if (state.IsBlocked)
        {
            return Container(Panel(searchPanel()));
        }

        return calculate().Match
        (
            success: r =>
            {
                var thStyle = ComponentBorder + PositionSticky + Top(0) + Background(WhiteSmoke);

                Element[] results =
                [
                    new h4 { "Sonuçlar" } + TextAlignCenter,

                    new CountsSummaryView { Counts = r.Summaries },
                    SpaceY(30),

                    new FreeScrollBar
                    {
                        Height(300), WidthFull,

                        new table(TableLayout("fixed"))
                        {
                            new thead
                            {
                                new tr
                                {
                                    new th(thStyle)
                                    {
                                        new FlexRowCentered(Width(70))
                                        {
                                            "Sure No"
                                        }
                                    },
                                    new th(thStyle)
                                    {
                                        new FlexRowCentered(Width(70))
                                        {
                                            "Ayet No"
                                        }
                                    },
                                    from x in r.Summaries
                                    select new th(thStyle)
                                    {
                                        new FlexRowCentered(Width(40))
                                        {
                                            x.Name,
                                            Color(x.Color)
                                        }
                                    },
                                    new th(thStyle)
                                    {
                                        new FlexRowCentered(JustifyContentFlexStart, MarginLeft(40))
                                        {
                                            "Arapça Metin"
                                        }
                                    }
                                }
                            },
                            new tbody
                            {
                                from model in r.Details
                                select new tr(ComponentBorder)
                                {
                                    new td(ComponentBorder)
                                    {
                                        new FlexRowCentered { model.ChapterNumber }
                                    },
                                    new td(ComponentBorder)
                                    {
                                        new FlexRowCentered { model.VerseNumber }
                                    },

                                    from summary in r.Summaries
                                    select new td(ComponentBorder)
                                    {
                                        new FlexRowCentered
                                        {
                                            model.Words.FirstOrDefault(x => x.Word == summary.Name)?.Count ?? 0
                                        }
                                    },

                                    new td(ComponentBorder, WhiteSpaceNoWrap)
                                    {
                                        DangerouslySetInnerHTML(model.HtmlString),

                                        FontFamily_Lateef
                                    }
                                }
                            }
                        }
                    }
                ];

                return Container(Panel(searchPanel()), Panel(results));
            },
            fail =>
            {
                state.SearchScriptErrorMessage = fail.Message;

                return Container(Panel(searchPanel()));
            }
        );

        IEnumerable<Element> searchPanel()
        {
            return
            [
                When(state.IsBlocked, Backdrop),
                When(state.IsBlocked, ProcessingText),

                new h4 { text = "Kelime Arama", style = { textAlign = "center" } },

                new FlexColumn(Gap(15))
                {
                    new FlexColumn
                    {
                        new div { text = "Arama Komutu", style = { FontWeight500, FontSize14, MarginBottom(2) } },

                        new TextArea { TextArea.Bind(() => state.SearchScript), FontSize22 },

                        new ErrorText { Text = state.SearchScriptErrorMessage }
                    },

                    PartOption,

                    new div { "Not: Kelime aramalarında 'besmele' dahil edilmeden arama yapılmaktadır." } + FontSize(0.9 * rem),

                    new FlexRow(JustifyContentSpaceBetween)
                    {
                        new HelpComponent(),
                        new ActionButton { Label = "Ara", OnClick = OnCalculateClicked } + Height(22)
                    }
                }
            ];
        }

        Result<(IReadOnlyList<WordColorizedVerseModel> Details, IReadOnlyList<SummaryInfo> Summaries)> calculate()
        {
            var matchMap = new Dictionary<string, List<(IReadOnlyList<LetterInfo> searchWord, IReadOnlyList<(LetterInfo start, LetterInfo end)> startPoints)>>();

            var summaries = new List<SummaryInfo>();

            var searchOption = state.SearchOption;

            foreach (var (chapterFilter, searchWord) in searchScript.Lines)
            {
                var filteredVersesResponse = VerseFilter.GetVerseList(chapterFilter);
                if (filteredVersesResponse.HasError)
                {
                    return filteredVersesResponse.Error;
                }

                var filteredVerses = filteredVersesResponse.Value;

                foreach (var verse in filteredVerses)
                {
                    var startAndEndPoints = searchOption switch
                    {
                        WordSearchOption.Same       => verse.GetStartAndEndPointsOfSameWords(searchWord),
                        WordSearchOption.Contains   => verse.GetStartAndEndPointsOfContainsWords(searchWord),
                        WordSearchOption.EndsWith   => verse.GetStartAndEndPointsOfEndsWithWords(searchWord),
                        WordSearchOption.StartsWith => verse.GetStartAndEndPointsOfStartsWithWords(searchWord),
                        _                           => null
                    };

                    if (startAndEndPoints?.Count > 0)
                    {
                        if (!matchMap.ContainsKey(verse.Id))
                        {
                            matchMap.Add(verse.Id, []);
                        }

                        matchMap[verse.Id].Add((searchWord, startAndEndPoints));

                        // update summary
                        {
                            summaries.AddOrUpdate
                            (
                                predicate: x => x.Name == searchWord.AsText(),
                                notFound: () => new()
                                {
                                    Name  = searchWord.AsText(),
                                    Count = startAndEndPoints.Count
                                },
                                found: x => x with
                                {
                                    Count = x.Count + startAndEndPoints.Count
                                }
                            );
                        }
                    }
                }
            }

            List<WordColorizedVerseModel> details =
            [
                ..
                from x in matchMap.ToList().OrderBy(x => x.Key, new VerseNumberComparer())
                let verseId = x.Key
                let matchList = x.Value
                select WordColorizedVerse.Calculate(VerseFilter.GetVerseById(verseId), matchList)
            ];

            return (details, summaries);
        }
    }

    static Element Backdrop()
    {
        return new div
        {
            PositionAbsolute, LeftRight(0), TopBottom(0), BackgroundColor("rgba(0, 0, 0, 0.3)"), Zindex(3), BorderRadiusForPanels
        };
    }

    static Element Container(params Element[] panels)
    {
        return new FlexColumn(Gap(10), AlignItemsStretch, WidthFull)
        {
            panels
        };
    }

    static Element Panel(IEnumerable<Element> rows)
    {
        return new FlexColumn(BorderRadiusForPanels, ComponentBorder, PaddingLeftRight(15), PaddingBottom(15), PositionRelative)
        {
            rows
        };
    }

    static Element ProcessingText()
    {
        return new FlexRowCentered
        {
            PositionAbsolute, FontWeight700, LeftRight(0), TopBottom(0), Zindex(4),
            new LoadingIcon { Size(17), MarginRight(5) }, new span(Color("white")) { "Lütfen bekleyiniz..." }
        };
    }

    Task ArabicKeyboardPressed(string letter)
    {
        state.SearchScriptErrorMessage = null;
        state.ClickCount               = 0;
        state.SearchScript             = state.SearchScript?.Trim() + " " + letter;

        return Task.CompletedTask;
    }

    Task ClearErrorMessage()
    {
        state.SearchScriptErrorMessage = null;

        return Task.CompletedTask;
    }

    Task OnCalculateClicked()
    {
        return Task.Run(() =>
        {
            state.SearchScriptErrorMessage = null;
            if (state.SearchScript.HasNoValue())
            {
                state.SearchScriptErrorMessage = "Arama Komutu doldurulmalıdır";
                Client.GotoMethod(1000, ClearErrorMessage);
                return;
            }

            var scriptParseResponse = SearchScript.ParseScript(state.SearchScript);
            if (scriptParseResponse.HasError)
            {
                state.SearchScriptErrorMessage = scriptParseResponse.Error.Message;
                Client.GotoMethod(3000, ClearErrorMessage);
                return;
            }

            var script = scriptParseResponse.Value;

            state.ClickCount++;

            if (!state.IsBlocked)
            {
                state.IsBlocked = true;
                Client.HistoryReplaceState(null, "", $"/?{QueryKey.Page}={PageId.WordSearching}&{QueryKey.SearchQuery}={script.AsString()}&{QueryKey.SearchOption}={state.SearchOption}");
                Client.GotoMethod(OnCalculateClicked);
                return;
            }

            state.IsBlocked = false;
        });
    }

    Element PartOption()
    {
        return new FlexRow(BorderRadiusForPanels, ComponentBorder, JustifyContentSpaceEvenly, AlignContentCenter)
        {
            new FlexRowCentered { new Switch { @checked = state.SearchOption == WordSearchOption.StartsWith, onChange = SearchOptionChanged, value = WordSearchOption.StartsWith }, "başlar" },
            new FlexRowCentered { new Switch { @checked = state.SearchOption == WordSearchOption.EndsWith, onChange   = SearchOptionChanged, value = WordSearchOption.EndsWith }, "biter" },
            new FlexRowCentered { new Switch { @checked = state.SearchOption == WordSearchOption.Contains, onChange   = SearchOptionChanged, value = WordSearchOption.Contains }, "içerir" },
            new FlexRowCentered { new Switch { @checked = state.SearchOption == WordSearchOption.Same, onChange       = SearchOptionChanged, value = WordSearchOption.Same }, "aynısı" }
        };
    }

    Task SearchOptionChanged(ChangeEvent changeEvent, bool? value)
    {
        state.SearchOption = changeEvent.target.value;

        state.SearchScriptErrorMessage = null;

        state.ClickCount = 0;

        return Task.CompletedTask;
    }
}