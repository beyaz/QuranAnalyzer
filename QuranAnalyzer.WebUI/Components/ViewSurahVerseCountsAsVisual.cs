namespace QuranAnalyzer.WebUI.Components;

class ViewSurahVerseCountsAsVisual: ReactComponent
{
    protected override Element render()
    {

        var items = new List<Element>();
        
        foreach (var chapter in DataAccess.AllChapters)
        {
            items.Add(new FlexColumn
            {
                //new FlexRowCentered(BorderRadius(2), Border(2,solid,Gray200))
                //{
                //    $"{chapter.Index+1}"
                //},
                new div
                {
                    Height(chapter.Verses.Count),Width(2), Background(Red600)
                }
            });
        }
        
        return new FlexRow(Gap(4), AlignItemsFlexEnd, Border(1, solid, Green400), FontSize10, FlexDirectionRowReverse)
        {
            items
        };
    }
}