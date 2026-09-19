using ReactWithDotNet.ThirdPartyLibraries.MUI.Material;
using Switch = ReactWithDotNet.ThirdPartyLibraries.MUI.Material.Switch;

namespace QuranAnalyzer.WebUI.Pages.PageCharacterCounting;

[Serializable]
public class PageCharacterCountingViewModel
{
    public int ClickCount { get; set; }

    public bool IncludeBismillah { get; set; } = true;

    public bool IsBlocked { get; set; }

    public MushafOption MushafOption { get; set; } = new();

    public string SearchScript { get; set; }

    public string SearchScriptErrorMessage { get; set; }
}

sealed class PageCharacterCountingView : ReactComponent<PageCharacterCountingViewModel>
{
    protected override Task constructor()
    {
        state = new PageCharacterCountingViewModel();

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

        if (Query[QueryKey.IncludeBismillah] == "0")
        {
            state.IncludeBismillah = false;
        }

        Client.OnArabicKeyboardPressed(ArabicKeyboardPressed);

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
                    new CountsSummaryView { Counts = r.summaryInfoList },
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
                                    from x in r.summaryInfoList
                                    select new th(thStyle)
                                    {
                                        new FlexRowCentered(Width(40))
                                        {
                                            new div
                                            {
                                                x.Name,
                                                Color(x.Color)
                                            },

                                            PositionRelative,
                                            GetDiff(x.Name)
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
                                from model in r.resultVerseList
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

                                    from letter in model.ColorizedLetters
                                    select new td(ComponentBorder)
                                    {
                                        new FlexRowCentered { letter.Count + letter.ExtraCount }
                                    },

                                    new td(ComponentBorder, WhiteSpaceNoWrap)
                                    {
                                        DangerouslySetInnerHTML(model.ArabicTextInHtmlFormat)
                                    }
                                }
                            }
                        }
                    }
                ];

                return Container(Panel(searchPanel()), Panel(results));

                Element GetDiff(string letterAsString)
                {
                    var query = from model in r.resultVerseList
                                from letter in model.ColorizedLetters
                                where letter.Letter == letterAsString && letter.ExtraCount is not null
                                select letter;

                    var count = query.Count();

                    if (count == 0)
                    {
                        return null;
                    }

                    return new Tooltip
                    {
                        title = $"Tanzil.net 'in sunduğu mushaf üzerindeki fark: {count}",
                        children =
                        {
                            new FlexRowCentered(FontWeight400, MarginLeft(2), FontSize10, LineHeight10, PositionAbsolute, TopRight(0), CursorDefault)
                            {
                                count
                            }
                        }
                    };
                }
            },
            fail =>
            {
                state.SearchScriptErrorMessage = fail.Message;

                return Container(Panel(searchPanel()));
            });

        Result<(List<LetterColorizerModel> resultVerseList, List<SummaryInfo> summaryInfoList)> calculate()
        {
            var resultVerses = new List<LetterColorizerModel>();

            var summaries = new List<SummaryInfo>();

            foreach (var (chapterFilter, searchLetters) in searchScript.Lines)
            {
                var filteredVersesResponse = VerseFilter.GetVerseList(chapterFilter);
                if (filteredVersesResponse.HasError)
                {
                    return filteredVersesResponse.Error;
                }

                var filteredVerses = filteredVersesResponse.Value;

                summaries.AddRange(searchLetters.Select(getSummaryInfo));

                foreach (var verse in filteredVerses)
                {
                    var analyzedTextOfVerse = state.IncludeBismillah ? verse.TextWithBismillahAnalyzed : verse.TextAnalyzed;

                    if (analyzedTextOfVerse.Any(x => searchLetters.Any(l => l.NumericValue == x.NumericValue)))
                    {
                        resultVerses.Add(LetterColorizer.Calculate(new()
                        {
                            VerseTextNodes          = analyzedTextOfVerse,
                            LettersForColorizeNodes = searchLetters,
                            VerseText               = state.IncludeBismillah ? verse.TextWithBismillah : verse.Text,
                            ChapterNumber           = verse.ChapterNumber,
                            VerseNumber             = verse.Index,
                            MushafOption            = state.MushafOption
                        }));
                    }
                }

                continue;

                SummaryInfo getSummaryInfo(LetterInfo letterInfo, int index)
                {
                    return new SummaryInfo
                    {
                        Count = QuranAnalyzerMixin.GetCountOfLetter(filteredVerses, letterInfo.OrderValue, state.MushafOption, state.IncludeBismillah),
                        Name  = letterInfo.Letter.ToString(),
                        Color = LetterColorPalette.GetColor(index)
                    };
                }
            }

            return (resultVerses, summaries);
        }

        IEnumerable<Element> searchPanel()
        {
            return
            [
                When(state.IsBlocked, Backdrop),
                When(state.IsBlocked, ProcessingText),

                new h4 { text = "Harf Arama", style = { TextAlignCenter } },
                new FlexColumn
                {
                    new FlexColumn
                    {
                        new div { text = "Arama Komutu", style = { FontWeight500, FontSize14, MarginBottom(2) } },

                        new TextArea { TextArea.Bind(() => state.SearchScript), FontSize17 },

                        new ErrorText { Text = state.SearchScriptErrorMessage }
                    },

                    SpaceY(10),

                    new FlexRow(AlignItemsFlexStart)
                    {
                        new CharacterCountingOptionView { MushafOption = state.MushafOption, MushafOptionChanged = MushafOptionChanged },

                        new FlexRowCentered
                        {
                            new Switch
                            {
                                @checked = state.IncludeBismillah,
                                onChange = OnIncludeBismillahChanged,
                                value    = (!state.IncludeBismillah).ToString()
                            },
                            new div { "Besmele'yi dahil et", WhiteSpaceNoWrap, MediaQuery("(max-width: 500px)", WhiteSpaceNormal) }
                        }
                    },

                    new FlexRow(JustifyContentFlexEnd)
                    {
                        new ActionButton { Label = "Ara", OnClick = OnCalculateClicked, IsProcessing = state.IsBlocked } + Height(22)
                    }
                }
            ];
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
        state.ClickCount = 0;

        state.SearchScriptErrorMessage = null;

        state.SearchScript = state.SearchScript?.Trim() + " " + letter;

        return Task.CompletedTask;
    }

    Task ClearErrorMessage()
    {
        state.SearchScriptErrorMessage = null;

        return Task.CompletedTask;
    }

    Task MushafOptionChanged(MushafOption mushafOption)
    {
        state.ClickCount   = 0;
        state.MushafOption = mushafOption;

        return Task.CompletedTask;
    }

    Task OnCalculateClicked()
    {
        state.SearchScriptErrorMessage = null;

        if (state.SearchScript.HasNoValue())
        {
            state.SearchScriptErrorMessage = "Arama Komutu doldurulmalıdır";
            Client.GotoMethod(1000, ClearErrorMessage);
            return Task.CompletedTask;
        }

        var scriptParseResponse = SearchScript.ParseScript(state.SearchScript);
        if (scriptParseResponse.HasError)
        {
            state.SearchScriptErrorMessage = scriptParseResponse.Error.Message;
            Client.GotoMethod(3000, ClearErrorMessage);
            return Task.CompletedTask;
        }

        var script = scriptParseResponse.Value;

        state.ClickCount++;

        if (!state.IsBlocked)
        {
            state.IsBlocked = true;
            Client.HistoryReplaceState(null, "", $"/?{QueryKey.Page}={PageId.CharacterCounting}&{QueryKey.SearchQuery}={script.AsString()}&{QueryKey.IncludeBismillah}={state.IncludeBismillah.AsNumber()}");
            Client.GotoMethod(OnCalculateClicked);
            return Task.CompletedTask;
        }

        state.IsBlocked = false;

        return Task.CompletedTask;
    }

    Task OnIncludeBismillahChanged(ChangeEvent changeEvent, bool? value)
    {
        state.ClickCount = 0;

        state.IncludeBismillah = Convert.ToBoolean(changeEvent.target.value);

        return Task.CompletedTask;
    }
}