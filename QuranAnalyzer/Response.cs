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
    ///     Performs an implicit conversion from <see cref="Exception" /> to <see cref="Error" />.
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
    ///     Performs an implicit conversion from <see cref="System.String" /> to <see cref="Error" />.
    /// </summary>
    public static implicit operator Error(string errorMessage)
    {
        return new Error
        {
            Message = errorMessage
        };
    }

    public override string ToString()
    {
        if (Code is null)
        {
            return Message;
        }
        
        return Code + " " + Message;
    }
}



/// <summary>
///     The response
/// </summary>
[Serializable]
public sealed class Response<TValue> 
{
    readonly List<Error> Errors = [];
    
    /// <summary>
    ///     Returns as array of errors
    /// </summary>
    public Error[] ErrorsAsArray => [.. Errors];

    /// <summary>
    ///     Gets the fail message.
    /// </summary>
    public string FailMessage => string.Join(Environment.NewLine, from e in Errors select e.ToString());


    
    /// <summary>
    ///     Gets a value indicating whether this instance is fail.
    /// </summary>
    public bool IsFail => Errors.Count > 0;

    /// <summary>
    ///     Gets a value indicating whether this instance is success.
    /// </summary>
    public bool IsSuccess => Errors.Count == 0;
    
    
    /// <summary>
    ///     Gets or sets the value.
    /// </summary>
    public TValue Value { get; set; }

   

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Exception" /> to <see cref="Response{TValue}" />.
    /// </summary>
    public static implicit operator Response<TValue>(Exception exception)
    {
        var response = new Response<TValue>();

        response.Errors.Add(exception);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Error" /> to <see cref="Response{TValue}" />.
    /// </summary>
    public static implicit operator Response<TValue>(Error error)
    {
        var response = new Response<TValue>();

        response.Errors.Add(error);

        return response;
    }

    public static implicit operator Response<TValue>(string error)
    {
        var response = new Response<TValue>();

        response.Errors.Add(error);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Error" /> to <see cref="Response{TValue}" />.
    /// </summary>
    public static implicit operator Response<TValue>(Error[] errors)
    {
        var response = new Response<TValue>();

        response.Errors.AddRange(errors);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="TValue" /> to <see cref="Response{TValue}" />.
    /// </summary>
    public static implicit operator Response<TValue>(TValue value)
    {
        return new Response<TValue> { Value = value };
    }

    public TValue Unwrap()
    {
        if (IsFail)
        {
            throw new Exception(FailMessage);
        }

        return Value;
    }
}

public static class FpExtensions
{
    

    public static Response<TC> Apply<TA, TB, TC>(Func<TA, TB, Response<TC>> fn, Response<TA> responseA, Response<TB> responseB)
    {
        if (responseA.IsFail)
        {
            return responseA.ErrorsAsArray;
        }

        if (responseB.IsFail)
        {
            return responseB.ErrorsAsArray;
        }

        return fn(responseA.Value, responseB.Value);
    }

    public static Response<IReadOnlyList<TTarget>> AsListOf<TSource, TTarget>(this IEnumerable<TSource> source, Func<TSource, Response<TTarget>> convertFunc)
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
            if (response.IsFail)
            {
                return response.ErrorsAsArray;
            }

            result.Add(response.Value);
        }

        return result;
    }

    

   

    public static Response<int> ParseInt(string value)
    {
        return Try(() => int.Parse(value));
    }

  

    public static Response<TB> Then<TA, TB>(this Response<TA> response, Func<TA, Response<TB>> nextFunc)
    {
        if (response.IsFail)
        {
            return response.ErrorsAsArray;
        }

        return nextFunc(response.Value);
    }

    public static Response<TC> Then<TA, TB, TC>(this (Response<TA> a, Response<TB> b) response, Func<TA, TB, Response<TC>> nextFunc)
    {
        if (response.a.IsFail)
        {
            return response.a.ErrorsAsArray;
        }

        if (response.b.IsFail)
        {
            return response.b.ErrorsAsArray;
        }

        return nextFunc(response.a.Value, response.b.Value);
    }

    public static Response<TB> Then<TA, TB>(this Response<TA> response, Func<TA, TB> nextFunc)
    {
        if (response.IsFail)
        {
            return response.ErrorsAsArray;
        }

        return nextFunc(response.Value);
    }

    

    public static TC Then<TA, TB, TC>(this Response<(TA, TB)> response, Func<TA, TB, TC> successFunc, Func<string, TC> failFunc)
    {
        if (response.IsFail)
        {
            return failFunc(response.FailMessage);
        }

        return successFunc(response.Value.Item1, response.Value.Item2);
    }

    public static TD Then<TA, TB, TC, TD>(this Response<(TA, TB, TC)> response, Func<TA, TB, TC, TD> successFunc, Func<string, TD> failFunc)
    {
        if (response.IsFail)
        {
            return failFunc(response.FailMessage);
        }

        return successFunc(response.Value.Item1, response.Value.Item2, response.Value.Item3);
    }

    public static Response<IReadOnlyList<TA>> ToReadOnlyList<TA>(this Response<TA> response)
    {
        if (response.IsFail)
        {
            return response.ErrorsAsArray;
        }

        return new List<TA> { response.Value };
    }

    static Response<T> Try<T>(Func<T> func)
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