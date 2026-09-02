namespace QuranAnalyzer;

public static class FpExtensions
{
    

    public static Result<int> ParseInt(string value)
    {
        return Result.From(() => int.Parse(value));
    }

    public static Result<TB> Then<TA, TB>(this Result<TA> result, Func<TA, Result<TB>> nextFunc)
    {
        if (result.HasError)
        {
            return result.Error;
        }

        return nextFunc(result.Value);
    }

    public static Result<TC> Then<TA, TB, TC>(this (Result<TA> a, Result<TB> b) response, Func<TA, TB, Result<TC>> nextFunc)
    {
        if (response.a.HasError)
        {
            return response.a.Error;
        }

        if (response.b.HasError)
        {
            return response.b.Error;
        }

        return nextFunc(response.a.Value, response.b.Value);
    }

    public static Result<TB> Then<TA, TB>(this Result<TA> result, Func<TA, TB> nextFunc)
    {
        if (result.HasError)
        {
            return result.Error;
        }

        return nextFunc(result.Value);
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

    public static Result<IReadOnlyList<TA>> ToReadOnlyList<TA>(this Result<TA> result)
    {
        if (result.HasError)
        {
            return result.Error;
        }

        return new List<TA> { result.Value };
    }
}