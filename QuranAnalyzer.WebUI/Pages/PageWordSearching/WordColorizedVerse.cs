using System.Text;
using static QuranAnalyzer.WebUI.LetterColorPalette;

namespace QuranAnalyzer.WebUI.Pages.PageWordSearching;

sealed record WordColorizedVerseModelItem
{
    public required string Color { get; init; }

    public required int Count { get; init; }
    
    public required string Word { get; init; }
}

sealed record WordColorizedVerseModel
{
    public required int ChapterNumber { get; init; }
    
    public required int VerseNumber { get; init; }
    
    public required string ArabicTextInHtmlFormat { get; init; }

    public required IReadOnlyList<WordColorizedVerseModelItem> Words { get; init; }
}

static class WordColorizedVerse 
{
    internal static WordColorizedVerseModel Calculate(Verse Verse, IReadOnlyList<(IReadOnlyList<LetterInfo> searchWord, IReadOnlyList<(LetterInfo start, LetterInfo end)> startEndPoints)> MatchList)
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
                words.Add(new()
                {
                    Word  = string.Join(string.Empty, searchWord),
                    Color = GetColor(searchWordIndex),
                    Count = startEndPoints.Count
                });

                searchWordIndex++;
            }
        }

        return new()
        {
            ArabicTextInHtmlFormat = html.ToString(),

            Words = words,
            
            ChapterNumber = Verse.ChapterNumber,
            
            VerseNumber = Verse.Index
        };
    }

}