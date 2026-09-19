using System.Text;
using static QuranAnalyzer.WebUI.LetterColorPalette;

namespace QuranAnalyzer.WebUI.Pages.PageWordSearching;

sealed record WordColorizedVerseModelItem
{
    public required string Word { get; init; }
    
    public required string Color { get; init; }

    public required int Count { get; init; }

}
sealed record WordColorizedVerseModel
{
    public required string HtmlString { get; init; }
    
    public required IReadOnlyList<WordColorizedVerseModelItem> Words { get; init; }
}
sealed class WordColorizedVerse : ReactPureComponent
{
    public required IReadOnlyList<(IReadOnlyList<LetterInfo> searchWord, IReadOnlyList<(LetterInfo start, LetterInfo end)> startEndPoints)> MatchList { get; set; }
    
    public required Verse Verse { get; init; }

    internal static WordColorizedVerseModel Calculate( Verse Verse, IReadOnlyList<(IReadOnlyList<LetterInfo> searchWord, IReadOnlyList<(LetterInfo start, LetterInfo end)> startEndPoints)> MatchList )
    {
        List<WordColorizedVerseModelItem> words = [];
            
        var verseLetters = Verse.TextAnalyzed.ToList();

        var cursor = 0;

        var html = new StringBuilder();

        while (cursor < verseLetters.Count)
        {
            var letterInfo = verseLetters[cursor];

            var hasAnyMatch = false;

            var searchWordIndex = 0;
            foreach (var (_, startEndPoints) in MatchList)
            {
                foreach (var startEndPoint in startEndPoints)
                {
                    if (startEndPoint.start == letterInfo)
                    {
                        var endIndex = verseLetters.IndexOf(startEndPoint.end, cursor);

                        var span = new span
                        {
                            innerText = verseLetters.GetRange(cursor, endIndex - cursor + 1).AsText(),
                            style =
                            {
                                FontWeightBold,
                                BorderRadiusForPanels,
                                Border("1px dashed rgb(218, 220, 224)"),
                                Color(GetColor(searchWordIndex))
                            }
                        };

                        html.Append(span.ToHtml());

                        cursor = endIndex + 1;

                        hasAnyMatch = true;
                        break;
                    }
                }

                if (hasAnyMatch)
                {
                    break;
                }

                searchWordIndex++;
            }

            if (hasAnyMatch)
            {
                continue;
            }

            html.Append(letterInfo.Letter);

            cursor++;
        }


        {
            var searchWordIndex = 0;

            foreach (var (searchWord, startEndPoints) in MatchList)
            {
                words.Add(new ()
                {
                    Word = string.Join(string.Empty, searchWord),
                    Color = GetColor(searchWordIndex),
                    Count = startEndPoints.Count
                });
                
               

                searchWordIndex++;
            }
        }
        

       

        return new()
        {
            HtmlString = html.ToString(),
            
            Words = words
        };
    }

    protected override Element render()
    {
        var verseLetters = Verse.TextAnalyzed.ToList();

        var cursor = 0;

        var html = new StringBuilder();

        while (cursor < verseLetters.Count)
        {
            var letterInfo = verseLetters[cursor];

            var hasAnyMatch = false;

            var searchWordIndex = 0;
            foreach (var (_, startEndPoints) in MatchList)
            {
                foreach (var startEndPoint in startEndPoints)
                {
                    if (startEndPoint.start == letterInfo)
                    {
                        var endIndex = verseLetters.IndexOf(startEndPoint.end, cursor);

                        var span = new span
                        {
                            innerText = verseLetters.GetRange(cursor, endIndex - cursor + 1).AsText(),
                            style =
                            {
                                FontWeightBold,
                                BorderRadiusForPanels,
                                Border("1px dashed rgb(218, 220, 224)"),
                                Color(GetColor(searchWordIndex))
                            }
                        };

                        html.Append(span.ToHtml());

                        cursor = endIndex + 1;

                        hasAnyMatch = true;
                        break;
                    }
                }

                if (hasAnyMatch)
                {
                    break;
                }

                searchWordIndex++;
            }

            if (hasAnyMatch)
            {
                continue;
            }

            html.Append(letterInfo.Letter);

            cursor++;
        }

        var countsView = new FlexRow(FlexWrap, JustifyContentCenter, Padding(5), Gap(13));

        {
            var searchWordIndex = 0;

            foreach (var (searchWord, startEndPoints) in MatchList)
            {
                var countView = new FlexRow(AlignItemsCenter)
                {
                    new div { string.Join(string.Empty, searchWord), FontWeightBold, Color(GetColor(searchWordIndex)) },

                    new div { ":", MarginLeftRight(4) },

                    new div { startEndPoints.Count.ToString(), FontSize12 }
                };

                countsView.children.Add(countView);

                searchWordIndex++;
            }
        }
        var textView = new div(FontFamily_Lateef)
        {
            innerHTML = html.ToString(),
            style =
            {
                FontSize(38),
                Padding(5),
                DirectionRtl
            }
        };

        var verseId = new div(FontWeightBold, MarginLeft(2), FontSize13)
        {
            $"{Verse.Id}"
        };

        var topLegend = new legend(DisplayFlex, FlexDirectionRow, AlignItemsCenter, Gap(5), UserSelect(none))
        {
            verseId,
            countsView
        };

        return new fieldset
        {
            children = { topLegend, textView },
            style =
            {
                DisplayFlex,
                FlexDirectionColumn,
                AlignItemsFlexEnd,

                Border("1px dashed rgb(218, 220, 224)"),
                BorderRadiusForPanels
            }
        };
    }
}