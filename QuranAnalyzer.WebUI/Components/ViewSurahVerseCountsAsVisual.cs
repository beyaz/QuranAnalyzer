using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer.WebUI.Components;

class ViewSurahVerseCountsAsVisual: ReactComponent
{
    static int getCount(Verse verse, params int[] arabicLetterOrderValues)
    {
        var option = new MushafOption();
        return arabicLetterOrderValues
            .Select(orderValueOfLetter => GetCountOfLetterInVerse(verse, orderValueOfLetter, option, true)).Sum();
    }
    
    static int getCountInChapter(Chapter chapter, params int[] arabicLetterOrderValues)
    {
        return chapter.Verses.Sum(v => getCount(v, arabicLetterOrderValues));
    }
    
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
                    Height( getCountInChapter(chapter,[ArabicLetterOrder.Qaaf])),Width(2), Background(Red600)
                }
            });
        }
        
        return new FlexRow(Gap(4), AlignItemsFlexEnd, Border(1, solid, Green400), FontSize10, FlexDirectionRowReverse)
        {
            items
        };
    }
}