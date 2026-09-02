namespace QuranAnalyzer;

public static class ListExtensions
{
    public static Result<int> SumOf<TSource>(this IEnumerable<TSource> source, Func<TSource, Result<int>> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Aggregate(0, selector, (total, value) => total + value);
    }

    static Result<TAccumulate> Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TSource, Result<TAccumulate>> func, Func<TAccumulate, TAccumulate, TAccumulate> accumulate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (func == null)
        {
            throw new ArgumentNullException(nameof(func));
        }

        var result = seed;
        foreach (var element in source)
        {
            var response = func(element);
            if (response.HasError)
            {
                return response.Error;
            }

            result = accumulate(result, response.Value);
        }

        return result;
    }
}