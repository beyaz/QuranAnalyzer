namespace QuranAnalyzer.WebUI.Pages.PageAllInitialLettersCombined;

public class InitialLetterCountInfo
{
    public string Count { get; set; }

    public IReadOnlyList<CountInfo> Details { get; init; }
    
    public char Text { get; init; }
    
    public string Label { get; init; }
}

public class CountInfo
{
    public int ChapterNumber { get; set; }
    public string Count { get; set; }
}