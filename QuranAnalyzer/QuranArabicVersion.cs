namespace QuranAnalyzer;


public record VerseWithSequence
{
    public int SequenceNumber { get; init; }

    public Verse Verse { get; init; }
    
    public int ChapterNumber => Verse.ChapterNumber;
    
    public int VerseNumber => Verse.VerseNumber;
    
    public string Text => Verse.Text;

    public  string ToTextLine()
    {
        return $"{SequenceNumber}|{Verse.ChapterNumber}|{Verse.VerseNumber}|{Verse.Text}";
    }
}


partial class QuranArabicVersionWithNoBismillah 
{

    public  static IReadOnlyList<VerseWithSequence> AllQuranVerses
    {
        get
        {
            return field ??= AllQuranAsString.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(TryParseVerseLine).Traverse().Unwrap();
        }
    }
    
    public static Result<VerseWithSequence> TryParseVerseLine(string line)
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

        return new VerseWithSequence
        {
            SequenceNumber = grandVerseNumber,
            Verse = new()
            {
                ChapterNumber = chapterNumber,
                VerseNumber   = verseNumber,
                Text          = arr[3]
            }
        };
    }
   
    
   
    

}