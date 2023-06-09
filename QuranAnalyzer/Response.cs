﻿namespace QuranAnalyzer;

/// <summary>
///     The error
/// </summary>
[Serializable]
public sealed class Error
{
    /// <summary>
    ///     Gets or sets the message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Exception" /> to <see cref="Error" />.
    /// </summary>
    public static implicit operator Error(Exception exception)
    {
        return new Error
        {
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
        return Message;
    }
}

/// <summary>
///     The response
/// </summary>
[Serializable]
public class Response
{
    /// <summary>
    ///     The success
    /// </summary>
    public static readonly Response Success = new();

    /// <summary>
    ///     The errors
    /// </summary>
    protected readonly List<Error> Errors = new();

    /// <summary>
    ///     Returns as array of errors
    /// </summary>
    public Error[] ErrorsAsArray => Errors.ToArray();

    /// <summary>
    ///     Gets the fail message.
    /// </summary>
    public string FailMessage => string.Join(Environment.NewLine, Errors.Select(e => e.Message));

    /// <summary>
    ///     Gets a value indicating whether this instance is fail.
    /// </summary>
    public bool IsFail => Errors.Count > 0;

    /// <summary>
    ///     Gets a value indicating whether this instance is success.
    /// </summary>
    public bool IsSuccess => Errors.Count == 0;

    /// <summary>
    ///     Fails the specified error message.
    /// </summary>
    public static Response Fail(string errorMessage)
    {
        return new Response
        {
            Errors = { errorMessage }
        };
    }

    public static Response operator +(Response responseX, Response responseY)
    {
        var response = new Response();

        response.Errors.AddRange(responseX.ErrorsAsArray);
        response.Errors.AddRange(responseY.ErrorsAsArray);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Exception" /> to <see cref="Response" />.
    /// </summary>
    public static implicit operator Response(Exception exception)
    {
        var response = new Response();

        response.Errors.Add(exception);

        return response;
    }

    /// <summary>
    ///     Performs an implicit conversion from <see cref="Error" /> to <see cref="Response" />.
    /// </summary>
    public static implicit operator Response(Error error)
    {
        var response = new Response();

        response.Errors.Add(error);

        return response;
    }
}

/// <summary>
///     The response
/// </summary>
[Serializable]
public sealed class Response<TValue> : Response
{
    /// <summary>
    ///     Gets or sets the value.
    /// </summary>
    public TValue Value { get; set; }

    public static Response<TValue> Fail(Response response)
    {
        var newResponse = new Response<TValue>();

        newResponse.Errors.AddRange(response.ErrorsAsArray);

        return newResponse;
    }

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
    public static Response<TB> Apply<TA, TB>(Func<TA, Response<TB>> functionAToB, TA a)
    {
        return functionAToB(a);
    }

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

    public static Response<int> GetIndex<T>(this T[] array, T value)
    {
        var index = Array.IndexOf(array, value);
        if (index < 0)
        {
            return $"{value} değeri listede bulunamadı";
        }

        return index;
    }

    public static Response<T> GetValueAt<T>(this T[] array, int index)
    {
        if (array is null)
        {
            return new ArgumentNullException(nameof(array));
        }

        if (index >= 0 && index < array.Length)
        {
            return new Response<T> { Value = array[index] };
        }

        return new IndexOutOfRangeException("index:" + index);
    }

    public static Response<int> ParseInt(string value)
    {
        return Try(() => int.Parse(value));
    }

    public static Response<TB> Pipe<TA, TB>(Response<TA> responseA, Func<TA, Response<TB>> func1)
    {
        if (responseA.IsFail)
        {
            return responseA.ErrorsAsArray;
        }

        return func1(responseA.Value);
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

    public static TB Then<TA, TB>(this Response<TA> response, Func<TA, TB> successFunc, Func<string, TB> failFunc)
    {
        if (response.IsFail)
        {
            return failFunc(response.FailMessage);
        }

        return successFunc(response.Value);
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