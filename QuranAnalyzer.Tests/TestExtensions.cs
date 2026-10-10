using System.Collections.Generic;
using System.Linq;

namespace QuranAnalyzer;

static class TestExtensions
{
    public static void ShouldBe(this Result<int> actual, int expected)
    {
        actual.Value.ShouldBe(expected);
    }

    public static int CountOf<T>(this IEnumerable<T> source) => source.Count();
}