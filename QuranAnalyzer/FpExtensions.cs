namespace QuranAnalyzer;

public static class FpExtensions
{
    extension<T>(Result<T> result)
    {
        public bool HasError => result.Error is not null;
    }
    
    public static T Unwrap<T>(this Result<T> result)
    {
        if (result.HasError)
        {
            throw new InvalidOperationException(result.Error.Message);
        }

        return result.Value;
    }
    
    public static Result<TC> Apply<TA, TB, TC>(Func<TA, TB, Result<TC>> fn, Result<TA> resultA, Result<TB> resultB)
    {
        if (resultA.HasError)
        {
            return resultA.Error;
        }

        if (resultB.HasError)
        {
            return resultB.Error;
        }

        return fn(resultA.Value, resultB.Value);
    }

    public static Result<IReadOnlyList<TTarget>> AsListOf<TSource, TTarget>(this IEnumerable<TSource> source, Func<TSource, Result<TTarget>> convertFunc)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (convertFunc == null)
        {
            throw new ArgumentNullException(nameof(convertFunc));
        }

        var result = new List<TTarget>();

        foreach (var item in source)
        {
            var response = convertFunc(item);
            if (response.HasError)
            {
                return response.Error;
            }

            result.Add(response.Value);
        }

        return result;
    }

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