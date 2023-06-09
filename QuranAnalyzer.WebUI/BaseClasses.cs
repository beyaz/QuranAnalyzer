﻿namespace QuranAnalyzer.WebUI;

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

public abstract class ReactComponent<TState> : ReactWithDotNet.ReactComponent<TState> where TState : new()
{
    protected string GetPronunciationOfArabicLetter(char arabicLetter)
    {
        return GetTurkishPronunciationOfArabicLetter(arabicLetter);
    }
}