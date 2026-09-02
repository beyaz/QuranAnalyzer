namespace QuranAnalyzer;

public static class FpExtensions
{
    

    public static Result<int> ParseInt(string value)
    {
        return Result.From(() => int.Parse(value));
    }

    
   



}