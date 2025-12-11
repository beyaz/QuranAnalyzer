namespace QuranAnalyzer.WebUI;

sealed record PageRouteInfo(string Url, Type page);

static class Routes
{
    // H o m e
    public  const string Home = "/";

    public const string PageChapterNameContainsSAD = "/" + nameof(PageChapterNameContainsSAD);
    
    public const string PageCountInRange = "/" + nameof(PageCountInRange);
    
    public const string PageLetterAnalyzer = "/" + nameof(PageLetterAnalyzer);
    
    public const string PageVerseFilter = "/" + nameof(PageVerseFilter);
    
    public const string PageQuranArabicVersion = "/" + nameof(PageQuranArabicVersion);
}