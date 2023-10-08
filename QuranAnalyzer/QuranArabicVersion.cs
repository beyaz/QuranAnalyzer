namespace QuranAnalyzer;


partial class QuranArabicVersionWithNoBismillah 
{
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