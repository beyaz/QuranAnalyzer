namespace QuranAnalyzer;

public static class Mixin
{
    public static Result<int> ParseInt(string value)
    {
        return Result.From(() => int.Parse(value));
    }
}