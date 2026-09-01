namespace QuranAnalyzer;

static class TestExtensions
{
    public static void ShouldBe(this Result<int> actual, int expected)
    {
        actual.Value.ShouldBe(expected);
    }
}