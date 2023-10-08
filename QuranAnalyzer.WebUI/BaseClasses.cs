using System.Collections.Specialized;
using System.Web;

namespace QuranAnalyzer.WebUI;

public abstract class ReactComponent : ReactWithDotNet.Component
{
    protected IEnumerable<Element> AsLetter(char arabicLetter)
    {
        var pronunciation = GetPronunciationOfArabicLetter(arabicLetter);

        return new Element[] { (strong)pronunciation, "(", (strong)arabicLetter.ToString(), ")" };
    }

    protected string GetPronunciationOfArabicLetter(char arabicLetter)
    {
        return GetTurkishPronunciationOfArabicLetter(arabicLetter);
    }

    protected (string reading, string trMean)? GetPronunciationOfArabicWord(string arabicWord)
    {
        return GetTurkishPronunciationOfArabicWord(arabicWord);
    }
}

public abstract class ReactPureComponent : ReactWithDotNet.PureComponent
{
    protected NameValueCollection Query => HttpUtility.ParseQueryString(KeyForQueryString[Context]);

    protected IEnumerable<Element> AsLetter(char arabicLetter)
    {
        var pronunciation = GetPronunciationOfArabicLetter(arabicLetter);

        return new Element[] { (strong)pronunciation, "(", (strong)arabicLetter.ToString(), ")" };
    }

    protected string GetPronunciationOfArabicLetter(char arabicLetter)
    {
        return GetTurkishPronunciationOfArabicLetter(arabicLetter);
    }

    protected (string reading, string trMean)? GetPronunciationOfArabicWord(string arabicWord)
    {
        return GetTurkishPronunciationOfArabicWord(arabicWord);
    }
}

public abstract class ReactComponent<TState> : ReactWithDotNet.Component<TState> where TState : class, new()
{
    protected NameValueCollection Query => HttpUtility.ParseQueryString(KeyForQueryString[Context]);

    protected string GetPronunciationOfArabicLetter(char arabicLetter)
    {
        return GetTurkishPronunciationOfArabicLetter(arabicLetter);
    }
}