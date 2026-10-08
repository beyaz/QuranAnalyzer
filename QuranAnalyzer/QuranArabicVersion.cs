namespace QuranAnalyzer;


public record VerseModel
{
    public int GrandVerseNumber { get; init; }
    public int ChapterNumber { get; init; }
    public int VerseNumber { get; init; }
    public string ArabicText { get; init; }
    public IReadOnlyList<LetterInfo> Letters { get; init; }
}


partial class QuranArabicVersionWithNoBismillah 
{

    public static Result<VerseModel> ParseLine(string line)
    {
        var arr = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
        if (arr.Length != 4)
        {
            return new InvalidOperationException($"Invalid line format: {line}");
        }

        if (!int.TryParse(arr[0], out var grandVerseNumber))
        {
            return new InvalidOperationException($"Invalid grand verse number: {arr[0]}");
        }

        if (!int.TryParse(arr[1], out var chapterNumber))
        {
            return new InvalidOperationException($"Invalid chapter number: {arr[1]}");
        }

        if (!int.TryParse(arr[2], out var verseNumber))
        {
            return new InvalidOperationException($"Invalid verse number: {arr[2]}");
        }

        return new VerseModel()
        {
            GrandVerseNumber = grandVerseNumber,
            ChapterNumber = chapterNumber,
            VerseNumber = verseNumber,
            ArabicText = arr[3],
            Letters = AnalyzeText(arr[3])
        };
    }
    public static (bool isParsedSuccessfully, int grandVerseNumber, int chapterNumber, int verseNumber, string verseText) TryParseVerseNumbers(string verseText)
    {
        var arr = verseText.Split('|', StringSplitOptions.RemoveEmptyEntries);
        if (arr.Length == 4)
        {
            if (int.TryParse(arr[0], out var grandVerseNumber))
            {
                if (int.TryParse(arr[1], out var chapterNumber))
                {
                    if (int.TryParse(arr[2], out var verseNumber))
                    {
                        return (isParsedSuccessfully: true, grandVerseNumber, chapterNumber, verseNumber, verseText: arr[3]);
                    }
                }
            }
        }

        return default;
    }

    public static string ToTextLine(int grandVerseNumber, int chapterNumber, int verseNumber, string verseText)
    {
        return $"{grandVerseNumber}|{chapterNumber}|{verseNumber}|{verseText}";
    }

   
    

}