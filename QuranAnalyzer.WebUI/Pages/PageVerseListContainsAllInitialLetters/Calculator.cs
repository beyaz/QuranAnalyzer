using System.Collections.Immutable;

namespace QuranAnalyzer.WebUI.Pages.PageVerseListContainsAllInitialLetters;

class CalculatorModel
{
    public string ErrorText { get; set; }
    public bool IsProcessing { get; set; }
    public string Letters { get; set; }
    public string SearchScript { get; set; }
    public bool ShowResults { get; set; }
}

class Calculator : ReactComponent<CalculatorModel>
{
    public string Letters, SearchScript;

    public bool ShowNumbers { get; set; }

    public bool ShowVerseList { get; set; }

    protected override Task constructor()
    {
        state = new()
        {
            SearchScript = SearchScript,
            Letters      = Letters
        };

        return Task.CompletedTask;
    }

    protected override Element render()
    {
        return new FlexColumn(Gap(10))
        {
            new FlexColumn
            {
                Gap(3),

                new Label { Text = "Ayet Seç" },
                new TextInput
                {
                    TextInput.Bind(() => state.SearchScript),
                    FlexGrow(1)
                }
            },

            new FlexColumn
            {
                Gap(3),

                new Label { Text = "Harfler" },
                new TextInput
                {
                    TextInput.Bind(() => state.Letters),
                    FlexGrow(1)
                }
            },

            new FlexRow(AlignItemsCenter, state.ErrorText.HasValue() ? JustifyContentSpaceBetween : JustifyContentFlexEnd)
            {
                new ErrorText { Text     = state.ErrorText },
                new ActionButton { Label = "Hesapla", OnClick = () => Task.Run(OnClick), IsProcessing = state.IsProcessing }
            },

            When(state.ShowResults, GetCalculationText)
        };
    }

    Task Calculate()
    {
        state.ShowResults  = true;
        state.IsProcessing = false;

        return Task.CompletedTask;
    }

    Element GetCalculationText()
    {
        var option = new MushafOption();

        var letterInfoList = AnalyzeText(state.Letters.Replace(" ", ""));
        var letterOrderList = letterInfoList.Select(x => x.OrderValue).ToImmutableList();
        var verseList = VerseFilter.GetVerseList(state.SearchScript).Unwrap().Where(isContainsGivenLetters).ToList();

        if (ShowNumbers)
        {
            return showNumbers();
        }

        if (ShowVerseList)
        {
            return showVerseList();
        }

        throw new InvalidOperationException();

        Element showVerseList()
        {
            var thStyle = ComponentBorder + PositionSticky + Top(0) +  Background(WhiteSmoke);

            return new FlexColumn(Padding(10), AlignItemsCenter)
            {
                (strong)$"{verseList.Count} adet ayet bulundu.",

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
                                from x in letterInfoList
                                select new th(thStyle)
                                {
                                    new FlexRowCentered(Width(30))
                                    {
                                        x.Letter.ToString()
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
                            from verse in verseList
                            let model = LetterColorizer.Calculate(new()
                            {
                                VerseTextNodes          = verse.TextWithBismillahAnalyzed,
                                LettersForColorizeNodes = letterInfoList,
                                VerseText               = verse.TextWithBismillah,
                                ChapterNumber           = verse.ChapterNumber,
                                VerseNumber             = verse.Index,
                                MushafOption            = option
                            })
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
                                    new FlexRowCentered { letter.Count }
                                },

                                new td(ComponentBorder, WhiteSpaceNoWrap)
                                {
                                    DangerouslySetInnerHTML(model.ArabicTextInHtmlFormat)
                                }
                            }
                        }
                    }
                }
            };
        }

        bool isContainsGivenLetters(Verse verse)
        {
            foreach (var arabicLetterOrder in letterOrderList)
            {
                if (QuranAnalyzerMixin.GetCountOfLetterInVerse(verse, arabicLetterOrder, option, true) <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        Element showNumbers()
        {
            var total = 0;

            var items = new List<Element>();

            var currentChapter = -1;

            foreach (var verse in verseList)
            {
                if (items.Count > 0)
                {
                    items.Add(new div(MarginLeftRight(3)) { "+" });
                }

                if (currentChapter == verse.ChapterNumber)
                {
                    items.Add(verse.Index);
                    total += verse.IndexAsNumber;
                    continue;
                }

                currentChapter = verse.ChapterNumber;

                items.Add(new span { currentChapter.ToString(), Color("red") });
                items.Add(new div { "+", MarginLeftRight(3) });
                items.Add(verse.Index);

                total += verse.ChapterNumber;
                total += verse.IndexAsNumber;
            }

            items.Insert(0, total.ToString());
            items.Insert(1, new div(MarginLeftRight(3)) { "=" });

            return new FlexRow(FlexWrap)
            {
                items
            };
        }
    }

    void OnClick()
    {
        state.ShowResults = false;
        state.ErrorText   = null;

        if (state.SearchScript.HasNoValue())
        {
            state.ErrorText = "Ayet seçmelisiniz. Tüm Kuran boyunca arama yapmak için * yazabilirsiniz.";
            return;
        }

        var verseList = VerseFilter.GetVerseList(state.SearchScript);
        if (verseList.HasError)
        {
            state.ErrorText = verseList.Error.Message;
            return;
        }

        if (state.Letters.HasNoValue())
        {
            state.ErrorText = "En az bir tane Arapça karakter girilmelidir.";
            return;
        }

        var letters = AnalyzeText(state.Letters.Replace(" ", ""));

        if (letters.Count == 0)
        {
            state.ErrorText = "En az bir tane Arapça karakter girilmelidir.";
            return;
        }

        state.IsProcessing = true;
        Client.GotoMethod(Calculate);
    }
}