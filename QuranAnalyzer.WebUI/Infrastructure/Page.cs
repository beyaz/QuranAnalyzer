using QuranAnalyzer.WebUI.Pages;
using QuranAnalyzer.WebUI.Pages.PageMainWindow;

namespace QuranAnalyzer.WebUI;

sealed record PageRouteInfo(string Url, Type page);

static class Page
{
    public static readonly PageRouteInfo Home = new("/", typeof(PageMainWindowView));
    public static readonly PageRouteInfo PageChapterNameContainsSAD = new("/" + nameof(PageChapterNameContainsSAD), typeof(PageChapterNameContainsSAD));
    public static readonly PageRouteInfo PageCountInRange = new("/" + nameof(PageCountInRange), typeof(PageCountInRange));
    public static readonly PageRouteInfo PageVerseFilter = new("/" + nameof(PageVerseFilter), typeof(PageVerseFilter));
    
    public static readonly PageRouteInfo LetterAnalyzer = new($"/{nameof(PageLetterAnalyzer)}", typeof(PageLetterAnalyzer));
    public static readonly PageRouteInfo QuranArabicVersion = new($"/{nameof(PageQuranArabicVersion)}", typeof(PageQuranArabicVersion));
}