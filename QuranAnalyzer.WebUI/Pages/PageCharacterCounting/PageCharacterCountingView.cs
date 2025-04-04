﻿using System.Text;
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

class PageCharacterCountingView : ReactComponent<PageCharacterCountingViewModel>
{
    protected override Task constructor()
    {
        state = new PageCharacterCountingViewModel();

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

        if (Query[QueryKey.IncludeBismillah] == "0")
        {
            state.IncludeBismillah = false;
        }

        Client.OnArabicKeyboardPressed(ArabicKeyboardPressed);

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

        if (state.ClickCount == 0)
        {
            return Container(Panel(searchPanel()));
        }

        var searchScript = SearchScript.ParseScript(state.SearchScript).Unwrap();

        if (state.IsBlocked)
        {
            return Container(Panel(searchPanel()));
        }

        Response<(List<LetterColorizer> resultVerseList, List<SummaryInfo> summaryInfoList)> calculate()
        {
            var resultVerses = new List<LetterColorizer>();

            var summaries = new List<SummaryInfo>();

            foreach (var (chapterFilter, searchLetters) in searchScript.Lines)
            {
                var filteredVersesResponse = VerseFilter.GetVerseList(chapterFilter);
                if (filteredVersesResponse.IsFail)
                {
                    return filteredVersesResponse.ErrorsAsArray;
                }

                var filteredVerses = filteredVersesResponse.Value;

                SummaryInfo getSummaryInfo(LetterInfo letterInfo)
                {
                    return new SummaryInfo
                    {
                        Count = QuranAnalyzerMixin.GetCountOfLetter(filteredVerses, letterInfo.OrderValue, state.MushafOption, state.IncludeBismillah),
                        Name  = letterInfo.Letter.ToString()
                    };
                }

                summaries.AddRange(searchLetters.AsListOf(getSummaryInfo));

                foreach (var verse in filteredVerses)
                {
                    var analyzedTextOfVerse = state.IncludeBismillah ? verse.TextWithBismillahAnalyzed : verse.TextAnalyzed;

                    if (analyzedTextOfVerse.Any(x => searchLetters.Any(l => l.NumericValue == x.NumericValue)))
                    {
                        var letterColorizer = new LetterColorizer
                        {
                            VerseTextNodes          = analyzedTextOfVerse,
                            ChapterNumber           = verse.ChapterNumber.ToString(),
                            VerseNumber             = verse.Index,
                            LettersForColorizeNodes = searchLetters,
                            VerseText               = state.IncludeBismillah ? verse.TextWithBismillah : verse.Text,
                            Verse                   = verse,
                            MushafOption            = state.MushafOption
                        };

                        resultVerses.Add(letterColorizer);
                    }
                }
            }

            return (resultVerses, summaries);
        }

        return calculate().Then((resultVerseList, summaryInfoList) =>
                                {
#pragma warning disable CS8321
                                    a downloadAsExcel()

                                    {
                                        var header = "Sure No; Ayet No; Ayet";

                                        var rows = string.Join('\n', resultVerseList.Select(x => $"{x.ChapterNumber};{x.VerseNumber};{x.VerseText}"));

                                        var data = string.Join('\n', header, rows);

                                        data = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

                                        return new a
                                        {
                                            href     = "data:text/csv;base64,77u/" + data,
                                            text     = "Exel olarak indir",
                                            target   = "_blank",
                                            download = "Arama Sonuçları.csv"
                                        };
                                    }
#pragma warning restore CS8321

                                    Element[] results =
                                    [
                                        new h4{"Sonuçlar"} + TextAlignCenter,
                                        new CountsSummaryView { Counts = summaryInfoList },
                                        SpaceY(30),
                                        new div
                                        {
                                            dangerouslySetInnerHTML = new div
                                            {
                                                resultVerseList
                                            }.ToHtml()
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
        if (scriptParseResponse.IsFail)
        {
            state.SearchScriptErrorMessage = scriptParseResponse.FailMessage;
            Client.GotoMethod(3000, ClearErrorMessage);
            return Task.CompletedTask;
        }

        var script = scriptParseResponse.Value;

        state.ClickCount++;

        if (state.IsBlocked == false)
        {
            state.IsBlocked = true;
            Client.HistoryReplaceState(null, "", $"/?{QueryKey.Page}={PageId.CharacterCounting}&{QueryKey.SearchQuery}={script.AsString()}&{QueryKey.IncludeBismillah}={state.IncludeBismillah.AsNumber()}");
            Client.GotoMethod(OnCalculateClicked);
            return Task.CompletedTask;
        }

        state.IsBlocked = false;
        
        return Task.CompletedTask;
    }

    Task OnIncludeBismillahChanged(ChangeEvent changeEvent)
    {
        state.ClickCount = 0;

        state.IncludeBismillah = Convert.ToBoolean(changeEvent.target.value);
        
        return Task.CompletedTask;
    }
}