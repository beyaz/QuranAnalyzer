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
        state = new WordSearchingViewModel();

        var value = Query[QueryKey.SearchQuery];
        if (value is not null)
        {
            var parseResponse = SearchScript.ParseScript(value);
            if (parseResponse.IsFail)
            {
                state.SearchScriptErrorMessage = parseResponse.FailMessage;
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

        if (state.ClickCount == 0)
        {
            return Container(Panel(searchPanel()));
        }

        var searchScript = SearchScript.ParseScript(state.SearchScript).Unwrap();

        if (state.IsBlocked)
        {
            return Container(Panel(searchPanel()));
        }

        Response<(List<WordColorizedVerse> resultVerseList, List<SummaryInfo> summaryInfoList, (int sumOfChapterNumbers, int sumOfVerseNumbers, int sumOfCounts))> calculate()
        {
            var matchMap = new Dictionary<string, List<(IReadOnlyList<LetterInfo> searchWord, IReadOnlyList<(LetterInfo start, LetterInfo end)> startPoints)>>();

            var summaries = new List<SummaryInfo>();

            var searchOption = state.SearchOption;

            foreach (var (chapterFilter, searchWord) in searchScript.Lines)
            {
                var filteredVersesResponse = VerseFilter.GetVerseList(chapterFilter);
                if (filteredVersesResponse.IsFail)
                {
                    return filteredVersesResponse.ErrorsAsArray;
                }

                var filteredVerses = filteredVersesResponse.Value;

                foreach (var verse in filteredVerses)
                {
                    IReadOnlyList<(LetterInfo start, LetterInfo end)> startAndEndPoints = null;
                    if (searchOption == WordSearchOption.Same)
                    {
                        startAndEndPoints = verse.GetStartAndEndPointsOfSameWords(searchWord);
                    }
                    else if (searchOption == WordSearchOption.Contains)
                    {
                        startAndEndPoints = verse.GetStartAndEndPointsOfContainsWords(searchWord);
                    }
                    else if (searchOption == WordSearchOption.EndsWith)
                    {
                        startAndEndPoints = verse.GetStartAndEndPointsOfEndsWithWords(searchWord);
                    }
                    else if (searchOption == WordSearchOption.StartsWith)
                    {
                        startAndEndPoints = verse.GetStartAndEndPointsOfStartsWithWords(searchWord);
                    }

                    if (startAndEndPoints?.Count > 0)
                    {
                        if (!matchMap.ContainsKey(verse.Id))
                        {
                            matchMap.Add(verse.Id, []);
                        }

                        matchMap[verse.Id].Add((searchWord, startAndEndPoints));

                        // update summary
                        {
                            if (summaries.All(x => x.Name != searchWord.AsText()))
                            {
                                summaries.Add(new SummaryInfo { Name = searchWord.AsText() });
                            }

                            summaries.First(x => x.Name == searchWord.AsText()).Count += startAndEndPoints.Count;
                        }
                    }
                }
            }

            var sumOfChapterNumbers = 0;
            var sumOfVerseNumbers = 0;
            var sumOfCounts = 0;

            var resultVerses = new List<WordColorizedVerse>();

            foreach (var (verseId, matchList) in matchMap.ToList().OrderBy(x => x.Key, new VerseNumberComparer()))
            {
                resultVerses.Add(new WordColorizedVerse
                {
                    Verse     = VerseFilter.GetVerseById(verseId),
                    MatchList = matchList
                });

                sumOfChapterNumbers += int.Parse(verseId.Split(':')[0]);
                sumOfVerseNumbers   += int.Parse(verseId.Split(':')[1]);

                sumOfCounts += matchList.SumOf(x => x.startPoints.Count).Unwrap();
            }

            return (resultVerses, summaries, (sumOfChapterNumbers, sumOfVerseNumbers, sumOfCounts));
        }

        return calculate().Then((resultVerseList, summaryInfoList, _) =>
                                {
                                    Element[] results =
                                    [
                                        new h4{ "Sonuçlar" } + TextAlignCenter,

                                        new CountsSummaryView { Counts = summaryInfoList },
                                        SpaceY(30),
                                        new div
                                        {
                                            resultVerseList
                                        }
                                    ];

                                    return Container(Panel(searchPanel()), Panel(results));
                                },
                                failMessage =>
                                {
                                    state.SearchScriptErrorMessage = failMessage;

                                    return Container(Panel(searchPanel()));
                                });
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
        return new FlexColumn(Gap(10), AlignItemsStretch, WidthFull, MaxWidth(800))
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
            if (scriptParseResponse.IsFail)
            {
                state.SearchScriptErrorMessage = scriptParseResponse.FailMessage;
                Client.GotoMethod(3000, ClearErrorMessage);
                return;
            }

            var script = scriptParseResponse.Value;

            state.ClickCount++;

            if (state.IsBlocked == false)
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

    Task SearchOptionChanged(ChangeEvent changeEvent)
    {
        state.SearchOption = changeEvent.target.value;

        state.SearchScriptErrorMessage = null;

        state.ClickCount = 0;
        
        return Task.CompletedTask;
    }
}