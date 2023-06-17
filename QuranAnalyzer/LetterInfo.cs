namespace QuranAnalyzer;

public sealed class LetterInfo
{
    public int ArabicLetterIndex { get; init; }
    public string MatchedLetter { get; init; }
    public int StartIndex { get; init; }
    
    public char Letter { get; init; }

    public override string ToString()
    {
        return MatchedLetter;
    }
}