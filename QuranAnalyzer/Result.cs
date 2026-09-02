namespace QuranAnalyzer;

/// <summary>
///     The error
/// </summary>
[Serializable]
public sealed record Error
{
    public string Code { get; init; }

    public string Message { get; init; }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "Exception" /> to <see cref = "Error" />.
    /// </summary>
    public static implicit operator Error(Exception exception)
    {
        return new Error
        {
            Code = exception.HResult.ToString(),

            Message = exception.ToString()
        };
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "System.String" /> to <see cref = "Error" />.
    /// </summary>
    public static implicit operator Error(string errorMessage)
    {
        return new Error
        {
            Message = errorMessage
        };
    }

    /// <summary>
    ///     Returns a string representation of the error.
    /// </summary>
    public override string ToString()
    {
        if (Code is null)
        {
            return Message;
        }

        return Code + " " + Message;
    }
}

public static class Result
{
    public static Result<T> Fail<T>(Exception exception)
    {
        var result =  new Result<T>();
        result.Errors.Add(exception);
        return result;
    }
}
/// <summary>
///     The response
/// </summary>
[Serializable]
public sealed class Result<TValue>
{
    internal readonly List<Error> Errors = [];

    /// <summary>
    ///     Returns as array of errors
    /// </summary>
    public Error[] Error => [.. Errors];

    /// <summary>
    ///     Gets the fail message.
    /// </summary>
    public string FailMessage => string.Join(Environment.NewLine, from e in Errors select e.ToString());

    
    public bool HasError => Errors.Count > 0;


    /// <summary>
    ///     Gets or sets the value.
    /// </summary>
    public TValue Value { get; set; }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "Exception" /> to <see cref = "Result{TValue}" />.
    /// </summary>
    public static implicit operator Result<TValue>(Exception exception)
    {
        var response = new Result<TValue>();

        response.Errors.Add(exception);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "QuranAnalyzer.Error" /> to <see cref = "Result{TValue}" />.
    /// </summary>
    public static implicit operator Result<TValue>(Error error)
    {
        var response = new Result<TValue>();

        response.Errors.Add(error);

        return response;
    }

    

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "QuranAnalyzer.Error" /> to <see cref = "Result{TValue}" />.
    /// </summary>
    public static implicit operator Result<TValue>(Error[] errors)
    {
        var response = new Result<TValue>();

        response.Errors.AddRange(errors);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "TValue" /> to <see cref = "Result{TValue}" />.
    /// </summary>
    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue> { Value = value };
    }

    public TValue Unwrap()
    {
        if (HasError)
        {
            throw new Exception(FailMessage);
        }

        return Value;
    }
}

public static class FpExtensions
{
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
        return Try(() => int.Parse(value));
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
            return failFunc(result.FailMessage);
        }

        return successFunc(result.Value.Item1, result.Value.Item2);
    }

    public static TD Then<TA, TB, TC, TD>(this Result<(TA, TB, TC)> result, Func<TA, TB, TC, TD> successFunc, Func<string, TD> failFunc)
    {
        if (result.HasError)
        {
            return failFunc(result.FailMessage);
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

    static Result<T> Try<T>(Func<T> func)
    {
        try
        {
            return func();
        }
        catch (Exception exception)
        {
            return exception;
        }
    }
}