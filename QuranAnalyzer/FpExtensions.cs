namespace QuranAnalyzer;

public static class FpExtensions
{
    

    public static Result<int> ParseInt(string value)
    {
        return Result.From(() => int.Parse(value));
    }

    
   


    public static TC Then<TA, TB, TC>(this Result<(TA, TB)> result, Func<TA, TB, TC> successFunc, Func<string, TC> failFunc)
    {
        if (result.HasError)
        {
            return failFunc(result.Error.Message);
        }

        return successFunc(result.Value.Item1, result.Value.Item2);
    }

    public static TD Then<TA, TB, TC, TD>(this Result<(TA, TB, TC)> result, Func<TA, TB, TC, TD> successFunc, Func<string, TD> failFunc)
    {
        if (result.HasError)
        {
            return failFunc(result.Error.Message);
        }

        return successFunc(result.Value.Item1, result.Value.Item2, result.Value.Item3);
    }

}