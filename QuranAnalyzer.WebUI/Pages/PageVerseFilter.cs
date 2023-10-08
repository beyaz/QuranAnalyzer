using System.Threading.Tasks;
using static QuranAnalyzer.QuranArabicVersionWithNoBismillah;

namespace QuranAnalyzer.WebUI.Pages;

public class PageVerseFilter : ReactComponent
{
    const string Blue100 = "#0099FF";

    const string Grey1 = "#cdcdcd";

    public bool CalculateClicked { get; set; }

    public string InputVerseListAsString { get; set; }
    public string SearchLetters { get; set; }
    public string SliceNumber { get; set; }

    protected override Task constructor()
    {
        var arabicText = AllQuranAsString;

        SearchLetters          = "ب ر ك  ي و ج (brk yvc)";
        SliceNumber            = "19";
        InputVerseListAsString = string.Join("\n", arabicText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(TryParseVerseNumbers).Select(x => ToTextLine(x.grandVerseNumber, x.chapterNumber, x.verseNumber, x.verseText)).Take(7));

        return base.constructor();
    }

    protected override Element render()
    {
        var inputStyle = new Style
        {
            Padding(6), BorderRadius(7), Border(Solid(0.5, Grey1)), Color(rgba(0, 0, 0, 0.87))
        };

        return new FlexColumnCentered(WidthMaximized, BackgroundColor("#d2d2ce"))
        {
            new FlexColumnCentered(MarginLeftRight("10%") + WidthHeightMaximized, Gap(50), PaddingTopBottom(50))
            {
                new FlexColumn(BackgroundWhite, BorderRadius(5), BoxShadow(1, 1, 3, 1, "#333"), Height(840), Padding(50), Width(60 * vw))
                {
                    new FlexRow(FlexWrap, Gap(7), AlignItemsFlexEnd)
                    {
                        "Aşağıda verilen ayetlerden hangilerinde ", new input
                        {
                            type      = "text",
                            valueBind = () => SearchLetters,
                            style     = { Width(250), inputStyle }
                        },
                        " harfleri ",
                        new input
                        {
                            type      = "text",
                            valueBind = () => SliceNumber,
                            style     = { Width(70), inputStyle }
                        },
                        " sayısının katları şeklinde geçer?"
                    },
                    SpaceY(16),

                    new FlexColumn
                    {
                        new div(FontWeight600, FontSize13) { "Verse List" },
                        new textarea
                        {
                            valueBind = () => InputVerseListAsString,
                            style     = { Height(300), inputStyle }
                        }
                    },

                    new FlexRowCentered(MarginTop(30))
                    {
                        new CalculateButton
                        {
                            Clicked      = OnCalculateClicked,
                            IsProcessing = false
                        }
                    },

                    SpaceY(30),

                    When(CalculateClicked, Filter)
                }
            }
        };
    }

    Element Filter()
    {
        var (hasFail, matchedRecords) = FilterMatchedRecords(SearchLetters, int.Parse(SliceNumber));
        if (hasFail)
        {
            return new div { "Verse List read error." };
        }

        var table = new table
        {
            new thead
            {
                new th
                {
                    "Count"
                },
                new th { "Verse" }
            },
            new tbody
            {
                matchedRecords.Select(x => new tr(Border(Solid(1, Grey1)))
                {
                    new td(Border(Solid(1, Grey1))) { x.count }, new td(Border(Solid(1, Grey1))) { x.verseAsText }
                })
            }
        };

        return new FlexColumn(WidthMaximized, Height(500), Border(Solid(1, Grey1)), OverflowYScroll, Padding(10))
        {
            dangerouslySetInnerHTML = new FlexColumn
            {
                $"Toplam {matchedRecords.Count} adet kayıt bulundu",
                table
            }.ToHtml()
        };
    }

    (bool hasFail, IReadOnlyList<(string count, string verseAsText)> matchedRecords) FilterMatchedRecords(string searchLetters, int slicer)
    {
        var arabicText = InputVerseListAsString;

        var lines = arabicText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(TryParseVerseNumbers).ToList();

        var searchLetterList = Analyzer.AnalyzeText(searchLetters).Where(l => l.OrderValue > 0).ToList();

        int calculateCount(string line)
        {
            var letters = Analyzer.AnalyzeText(line).ToList();

            var sum = 0;

            foreach (var letterInfo in searchLetterList)
            {
                sum += letters.Count(x => x.OrderValue == letterInfo.OrderValue);
            }

            return sum;
        }

        var resultList = new List<(string count, string verseAsText)>();

        foreach (var (isParsedSuccessfully, grandVerseNumber, chapterNumber, verseNumber, verseText) in lines)
        {
            if (isParsedSuccessfully is false)
            {
                return (hasFail: true, default);
            }

            var count = calculateCount(verseText);
            if (count > 0 && count % slicer == 0)
            {
                resultList.Add((count: $"{slicer}x{count / slicer}", verseAsText: ToTextLine(grandVerseNumber, chapterNumber, verseNumber, verseText)));
            }
        }

        return (default, matchedRecords: resultList);
    }

    void OnCalculateClicked(MouseEvent e)
    {
        CalculateClicked = true;
    }

    class CalculateButton : ReactComponent
    {
        public Action<MouseEvent> Clicked { get; set; }

        public bool IsProcessing { get; set; }

        protected override Element render()
        {
            return new FlexRowCentered
            {
                IsProcessing ? "Hesaplanıyor..." : "Hesapla",
                OnClick(Clicked),
                When(IsProcessing, new LoadingIcon { Color = Blue100 } + WidthHeight(10) + MarginLeft(5)),
                OnClickPreview(() => IsProcessing = true),

                Height(40),
                Width(150),
                CursorPointer,
                Border(Solid(0.5, Blue100)), BorderRadius(5),
                Color(Blue100),
                FontFamily("SF Pro Text"),
                FontSize14,
                FontWeight500,
                LineHeight16,
                TextAlignCenter,
                WordWrapBreakWord
            };
        }
    }
}