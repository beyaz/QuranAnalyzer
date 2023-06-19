namespace QuranAnalyzer;

public sealed class LetterInfo
{
    public int ArabicLetterIndex { get; init; }

    public char Letter { get; init; }

    public int NumericValue { get; init; }

    public int OrderValue { get; init; }

    public int StartIndex { get; init; }

    public override string ToString()
    {
        return Letter.ToString();
    }
}