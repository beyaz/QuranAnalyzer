using System.Collections.Specialized;
using System.Web;

namespace QuranAnalyzer.WebUI;

public abstract class ReactComponent : ReactWithDotNet.ReactComponent
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

public abstract class ReactPureComponent : ReactWithDotNet.ReactPureComponent
{


    protected NameValueCollection Query=> HttpUtility.ParseQueryString(KeyForQueryString[Context]);
    
    
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

public abstract class ReactComponent<TState> : ReactWithDotNet.ReactComponent<TState> where TState : class, new()
{
    protected NameValueCollection Query=> HttpUtility.ParseQueryString(KeyForQueryString[Context]);
    
    protected string GetPronunciationOfArabicLetter(char arabicLetter)
    {
        return GetTurkishPronunciationOfArabicLetter(arabicLetter);
    }
}