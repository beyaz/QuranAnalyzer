
using System.Threading.Tasks;

namespace QuranAnalyzer.WebUI.Pages;

public class PageCountInRange : ReactComponent
{
    static readonly StyleModifier Container = MarginLeftRight("10%") + WidthHeightMaximized;

    public bool CalculateClicked { get; set; }
    public string SearchLetters { get; set; }
    public string SliceNumber { get; set; }

    protected override Task constructor()
    {
        SearchLetters = "ب ر ك ر ي و ر ك و ج (brkr yvrkvc)";
        SliceNumber   = "667";

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
            new FlexColumnCentered(Container, Gap(50), PaddingTopBottom(50))
            {
                new FlexColumn(BackgroundWhite, BorderRadius(5), BoxShadow(1, 1, 3, 1, "#333"), Height(840), Padding(50), Width(60 * vw))
                {
                    new FlexRow(FlexWrap, Gap(7), AlignItemsFlexEnd)
                    {
                        "Tüm Kuran", "'da ", new input
                        {
                            type      = "text",
                            valueBind = () => SearchLetters,
                            style     = { Width(250), inputStyle }
                        },
                        " harfleri ile oluşabilecek adeti ",
                        new input
                        {
                            type      = "text",
                            valueBind = () => SliceNumber,
                            style     = { Width(70), inputStyle  }
                        },
                        " sayısının katları şeklinde olan ayet aralıklarının listesi nedir?"
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

                    When(CalculateClicked, () => new FlexColumn(WidthMaximized, Height(500), Border(Solid(1, "#d7d5d5")), OverflowYScroll, Padding(10))
                    {
                        dangerouslySetInnerHTML = new table
                        {
                            new thead
                            {
                                new th { "From" },
                                new th { "To" },
                                new th { "Count" }
                            },
                            new tbody
                            {
                                GetAllSubRanges(SearchLetters, int.Parse(SliceNumber)).Select(x => new tr(Border(Solid(1, "#d7d5d5")))
                                {
                                    new td(Border(Solid(1, "#d7d5d5")))
                                    {
                                        x.from
                                    },

                                    new td(Border(Solid(1, "#d7d5d5")))
                                    {
                                        x.to
                                    },

                                    new td(Border(Solid(1, "#d7d5d5")))
                                    {
                                        x.count
                                    }
                                })
                            }
                        }.ToHtml()
                    })
                }
            }
        };
    }

    static List<(string from, string to, string count)> GetAllSubRanges(string searchLetters, int slicer)
    {
        var arabicText = QuranArabicVersionWithNoBismillah.AllQuranAsString;

        var lines = arabicText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(QuranArabicVersionWithNoBismillah.TryParseVerseNumbers).ToList();

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

        var allLines = lines.Select(x => (x.chapterNumber, x.verseNumber, Count: calculateCount(x.verseText))).ToList();

        var resultList = new List<(string from, string to, string count)>();

        for (var i = 0; i < allLines.Count; i++)
        {
            var total = 0;
            for (var j = i; j < allLines.Count; j++)
            {
                total += allLines[j].Count;

                if (total > 0 && total % slicer == 0)
                {
                    resultList.Add((from: $"{allLines[i].chapterNumber}:{allLines[i].verseNumber}", to: $"{allLines[j].chapterNumber}:{allLines[j].verseNumber}", count: $"{slicer}x{total / slicer}"));
                }
            }
        }

        return resultList;
    }

    void OnCalculateClicked(MouseEvent e)
    {
        CalculateClicked = true;
    }

    const string Blue100 = "#0099FF";
    
    const string Grey1 = "#cdcdcd";
    
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
                When(IsProcessing, new LoadingIcon{Color = Blue100} + WidthHeight(10) + MarginLeft(5)),
                OnClickPreview(()=>IsProcessing = true),
                
                Height(40), 
                Width(150),
                CursorPointer, 
                Border(Solid(0.5,Blue100)), BorderRadius(5),
                Color(Blue100),
                FontFamily("SF Pro Text"),
                FontSize14, 
                FontWeight500,
                LineHeight16,
                TextAlignCenter, 
                WordWrapBreakWord,
                
            };
        }
    }
}