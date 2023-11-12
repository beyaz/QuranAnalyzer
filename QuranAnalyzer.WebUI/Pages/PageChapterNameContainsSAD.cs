﻿using static QuranAnalyzer.QuranArabicVersionWithNoBismillah;

namespace QuranAnalyzer.WebUI.Pages;

public class PageChapterNameContainsSAD : ReactComponent
{
    

    

    protected override Element render()
    {
        return new div(FontFamily("Calibri, sans-serif"), FontSize24, FontWeight400)
        {
            CrateTable
        };
    }

    class NumberViewer : PureComponent
    {
        public int Count { get; set; }
        
        protected override Element render()
        {
            if (Count <= 0)
            {
                return new FlexRowCentered(FontFamily("Arial, sans-serif"), FontSize13)
                {
                    Count.ToString()
                };
            }

            var numbers = new[] { 667, 109, 19};

            foreach (var number in numbers)
            {
                if (Count == number)
                {
                    return new FlexRowCentered(FontFamily("Calibri, sans-serif"), Color("red"), FontWeight700)
                    {
                        Count.ToString()
                    };
                }
                
                if (Count % number == 0)
                {
                    return new FlexRowCentered(AlignItemsFlexEnd)
                    {
                        new FlexRowCentered(FontFamily("Calibri, sans-serif"), Color("red"), FontWeight700)
                        {
                            number
                        },
                        new FlexRow(FontFamily("Arial, sans-serif"), FontSize13,AlignItemsFlexEnd)
                        {
                            "x", Count / number
                        }
                    };
                }
            }
            
            return new FlexRowCentered(FontFamily("Arial, sans-serif"), FontSize13)
            {
                Count.ToString()
            };
        }
    }
    Element CrateTable()
    {
        var chapterNumbers = new[] { 28, 37,38,41,61,103,110,112 };

        var searchLetters = new[] { ArabicLetterOrder.Saad };

        var sharedStyle = Border(Solid(1, "black")) + BorderCollapseCollapse+ TextAlignCenter + Padding(5);

        static int CalculateCount(string verseFilter, int[] arabicLetterOrders)
        {
            return VerseFilter.GetVerseList(verseFilter).Then(verses => arabicLetterOrders.Sum(arabicLetterOrder => QuranAnalyzerMixin.GetCountOfLetter(verses, arabicLetterOrder))).Value;
        }
        
        return new table(sharedStyle, BackgroundWhite)
        {
            new tbody
            {
                new tr(sharedStyle)
                {
                    new td(sharedStyle, ColSpan(5))
                    {
                        new FlexRowCentered(Padding(15))
                        {
                            "İsminde ", new span(Color("red"), FontWeight700, MarginLeftRight(5) ){"SAD"}, " BULUNAN SURELER"
                        }
                    }
                },
                new tr(sharedStyle)
                {
                    new td(sharedStyle)
                    {
                        "ARAPÇA",
                        PaddingLeftRight(5),
                        FontSize15
                    },
                    new td(sharedStyle)
                    {
                        "TÜRKÇE",
                        PaddingLeftRight(20),
                        FontSize15
                    },
                    new td(sharedStyle)
                    {
                        "SURE NO",
                        FontSize15, FontWeight700
                    },
                    new td(sharedStyle)
                    {
                        "SAD SAYISI",
                        FontSize15, FontWeight700
                    },
                    new td(sharedStyle)
                    {
                        "AYET"
                    }
                },
                
                chapterNumbers.Select(chapterNumber =>new tr
                {
                    new td(sharedStyle)
                    {
                        "ص\u02dc"
                    },
                    new td(sharedStyle)
                    {
                        "S (Saad)"
                    },
                    new td(sharedStyle)
                    {
                        new NumberViewer{Count = chapterNumber}
                    },
                    new td(sharedStyle)
                    {
                        new NumberViewer{Count = CalculateCount(chapterNumber+":*",searchLetters)}
                    },
                    new td(sharedStyle)
                    {
                        new NumberViewer{Count = VerseFilter.GetVerseList(chapterNumber + ":*").Value.Count}
                    }
                }),
                
                new tr
                {
                    new td(sharedStyle)
                    {
                        "38 HArf"
                    },
                    new td(sharedStyle)
                    {
                        "SURE NO+SAD SAYISI TOPLAMI"
                    },
                    new td(sharedStyle,td.ColSpan(2))
                    {
                        new NumberViewer
                        {
                            Count = chapterNumbers.Select(chapterNumber=>chapterNumber+CalculateCount(chapterNumber+":*",searchLetters)).Sum()
                        }
                        
                    },
                    new td(sharedStyle,td.RowSpan(2))
                    {
                        "AYET TOPLAMI 109X4",
                        new NumberViewer
                        {
                            Count = chapterNumbers.Select(chapterNumber=>VerseFilter.GetVerseList(chapterNumber + ":*").Value.Count).Sum()
                        }
                    }
                },
                
                new tr
                {
                    new td(sharedStyle,td.ColSpan(2))
                    {
                        "SURE NO+SAD SAYISI RAKAM TOPLAMI\r\n\r\n2+8+3+9+3+7+3+4+3+8+2+9+4+1+1+9\r\n\r\n+6+1+9+1+0+3+5+1+1+0+1+1+1+2+1"
                    },
                    new td(sharedStyle,td.ColSpan(2))
                    {
                        new NumberViewer{Count = 109}
                    },
                },
                new tr
                {
                    new td(sharedStyle,td.ColSpan(5))
                    {
                        4
                    }
                }
            }
        };
    }
    

}