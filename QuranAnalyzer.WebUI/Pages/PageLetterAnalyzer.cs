using ReactWithDotNet.ThirdPartyLibraries.MUI.Material;

namespace QuranAnalyzer.WebUI.Pages;

class PageLetterAnalyzerModel
{
    public string InputText { get; set; }

    public bool IsShowingResults { get; set; }

    public string Value { get; set; }
}


[Route(Routes.PageLetterAnalyzer)]
class PageLetterAnalyzer : ReactComponent<PageLetterAnalyzerModel>
{
   


    class DownloadQuranLink : ReactComponent
    { 
        protected override Element render()
        {
            const string href = nameof(PageQuranArabicVersion);

            return new a
            {
                "Download Quran", Href(href), TargetBlank, FontWeightMedium, FontSize12, TextDecorationUnderline, CursorPointer
            };
        }
    }
    
    protected override Element render()
    {
        var inputText = state.InputText?? "";
        
        var analyzedLetters = Analyzer.AnalyzeText(inputText);

        return new FlexColumn(Background(Theme.PanelBackgroundColor), HeightAuto, AlignItemsCenter)
        {
            // new MainContentContainer
            new div( PaddingLeftRight("5%"))
            {
                DisplayFlexColumn,
                PaddingTopBottom(50), Gap(40),

                Width(95 * percent),
                
                new FlexColumn(Gap(5), WidthFull)
                {
                    new FlexRow(JustifyContentSpaceBetween)
                    {
                        new span { "Arabic Text", FontWeightBold, FontSize12 },

                        new DownloadQuranLink(),
                    },
                    When(state.IsShowingResults, () => new FlexColumn(Height(400), Background(White), FontFamily("lateef"), FontSize24, OverflowScroll)
                    {
                        inputText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(line => new LineLetterColorizer
                        {
                            ArabicText         = line,
                            LettersForColorize = state.Value
                        })
                    }),
                    !state.IsShowingResults ? new textarea(Height(400), Background(White), FontFamily("lateef"))
                    {
                        rows        = 5,
                        placeholder = "Paste arabic text here",
                        valueBind   = () => state.InputText,
                        style =
                        {
                            OutlineNone,
                            BorderNone,
                            FontSize24
                        }
                    }:null
                },
                
                new FlexColumn(Gap(10))
                {
                    WhenMediaMinWidth(600, DisplayFlexRow, JustifyContentSpaceBetween, AlignItemsFlexEnd),

                    new FlexColumn(Gap(5), WidthFull, WhenMediaMinWidth(600, MaxWidth(400)))
                    {
                        new span { "Select special letters", FontWeightBold, FontSize12 },

                        new TextField
                        {
                            valueBind = ()=>state.Value
                        }
                    },
                    new ActionButton
                    {
                        Label = "Analyze Letters", OnClick = StartAnalyze
                    } + WidthFull + WhenMediaMinWidth(600, MaxWidth(200))
                },

                When(state.IsShowingResults, () => new FlexColumn(Gap(30))
                {
                    new FlexRow(FlexWrap, JustifyContentCenter, FlexGrow(2), Gap(10))
                    {
                        calculateCounts
                    },
                    new FlexRow(FlexWrap, JustifyContentCenter, FlexGrow(2), Gap(10))
                    {
                        calculateSpecialValues
                    }
                })
            }
        };

        Element calculateCounts()
        {
            if (string.IsNullOrWhiteSpace(state.Value))
            {
                return null;
            }

            var specialLetters = Analyzer.AnalyzeText(state.Value).Where(x => x.OrderValue > 0).ToList();
            if (specialLetters.Count == 0)
            {
                return null;
            }

            return new FlexColumn(Gap(5), AlignItemsCenter)
            {
                new span { "Count Results", FontWeightBold, FontSize12 },
                new FlexRow(FlexWrap, JustifyContentFlexStart, WidthFull, Gap(10), AlignItemsCenter)
                {
                    specialLetters.Select(x => new FlexColumnCentered(Gap(3), Width(50), Height(40))
                    {
                        Border(Solid(0.5, "#5a84ad")), BorderRadius(3), Padding(5),
                        new div(FontWeightBold)
                        {
                            x.Letter.ToString()
                        },

                        new div
                        {
                            analyzedLetters.Count(l => l.OrderValue == x.OrderValue).ToString()
                        }
                    })
                }
            };
        }

        Element calculateSpecialValues()
        {
            if (string.IsNullOrWhiteSpace(state.Value))
            {
                return null;
            }

            var specialLetters = Analyzer.AnalyzeText(state.Value).Where(x => x.OrderValue > 0).ToList();
            if (specialLetters.Count == 0)
            {
                return null;
            }

            var totalSum = 0;

            foreach (var specialLetter in specialLetters)
            {
                totalSum += analyzedLetters.Count(x => x.OrderValue == specialLetter.OrderValue);
            }

            Element extraInfo = null;

            if (totalSum > 0 && totalSum % 667 == 0)
            {
                extraInfo = new FlexRowCentered { $"(667 x {totalSum / 667})" };
            }
            else if (totalSum > 0 && totalSum % 109 == 0)
            {
                extraInfo = new FlexRowCentered { $"(109 x {totalSum / 109})" };
            }
            else if (totalSum > 0 && totalSum % 19 == 0)
            {
                extraInfo = new FlexRowCentered { $"(19 x {totalSum / 19})" };
            }

            return new FlexColumn(Gap(5), AlignItemsCenter)
            {
                new span { "Total Sum", FontWeightBold, FontSize12 },
                new FlexColumnCentered(Gap(3), Height(40), AlignItemsCenter)
                {
                    Border(Solid(0.5, "#5a84ad")), BorderRadius(3), Padding(5, 10),
                    new div(FontWeightBold)
                    {
                        totalSum.ToString()
                    },

                    extraInfo
                }
            };
        }
    }

   

    Task StartAnalyze()
    {
        state.IsShowingResults = true;
        
        return Task.CompletedTask;
    }
}