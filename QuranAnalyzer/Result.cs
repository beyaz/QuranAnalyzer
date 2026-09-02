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
        return new() { Error = exception };
    }

    public static Result<T> From<T>(Func<T> value)
    {
        try
        {
            return Success(value());
        }
        catch (Exception exception)
        {
            return Fail<T>(exception);
        }
    }

    public static Result<T> Success<T>(T value)
    {
        return new() { Value = value };
    }
}

/// <summary>
///     The response
/// </summary>
[Serializable]
public sealed class Result<TValue>
{
    public bool HasError => Error is null;

    public Error Error { get; init; }

    /// <summary>
    ///     Gets or sets the value.
    /// </summary>
    public TValue Value { get; set; }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "Exception" /> to <see cref = "Result{TValue}" />.
    /// </summary>
    public static implicit operator Result<TValue>(Exception exception)
    {
        return new() { Error = exception };
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref = "QuranAnalyzer.Error" /> to <see cref = "Result{TValue}" />.
    /// </summary>
    public static implicit operator Result<TValue>(Error error)
    {
        return new() { Error = error };
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
            throw new Exception(Error.Message);
        }

        return Value;
    }
}