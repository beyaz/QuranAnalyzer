
namespace QuranAnalyzer.WebUI.Pages;

class PageChapterNameContainsSAD : ReactComponent<PageChapterNameContainsSAD.State>
{
    internal class State
    {
        public string SearchWords { get; set; }
        public string CharachterMap { get; set; }
        public bool IsProcessing { get; set; }
        public bool CanShowCalculationResults { get; set; }
    }

    protected override Task constructor()
    {
        state = new()
        {
            CharachterMap = "b:ب , c:ج , d:د , h:ه , v:و , z:ز , y:ي , k:ك , l:ل , m:م , n:ن , f:ف , s:ص , r:ر , t:ت  , ö:و , ü:و , g:ك , ç:ج  "
        };
        
        return Task.CompletedTask;
    }

    static (bool success, Dictionary<char, char> map, string errorMessage) ParseCharachterMap(string map)
    {
        if (map.HasNoValue())
        {
            return (default, default, "map is empty");
        }


        var arr = map.Split(',', StringSplitOptions.RemoveEmptyEntries);

        if (!arr.Any())
        {
            return (default, default, "map is empty");
        }
        
        var dictionary = new Dictionary<char, char>();
        
        foreach (var item in arr)
        {
            var pair = item.Split(':', StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToArray();
            if (pair.Length is not 2)
            {
                return (default, default, "invalid map");
            }
            
            dictionary.Add(pair[0][0], pair[1][0]);
        }

        return (true, dictionary, default);
    }
    

    protected override Element render()
    {
        return new FlexColumn
        {
            
            new FlexColumn
            {
                new label{"Charachter Map", FontSize14},
                new input
                {
                    valueBind = ()=>state.CharachterMap,
                    style =
                    {
                        Width(600),
                        Padding(5)
                    }
                }
            },
            
            new FlexColumn
            {
                new label{"Any word or any name", FontSize14},
                new input
                {
                    valueBind = ()=>state.SearchWords,
                    style =
                    {
                        Width(300),
                        Padding(5)
                    }
                }
            },
            
            new FlexRow(JustifyContentFlexEnd)
            {
                
                new ActionButton { Label = "Hesapla", OnClick = StartCalculate, IsProcessing = state.IsProcessing },
            },
            
            ResultView,
            
            new []
            {
                AlignContentCenter,
                PaddingLeftRight("5%"), LG(PaddingLeftRight("10%")), 
                PaddingTopBottom(50), 
                FontFamily("Calibri, sans-serif"), 
                FontSize24, 
                FontWeight400
            }
        };
    }

    Element ResultView()
    {
        if (state.CanShowCalculationResults is false)
        {
            return null;
        }

        
        var arabicVersionOfSearchWords = new List<char>();
        
        var (success, map, errorMessage) = ParseCharachterMap(state.CharachterMap);
        if (!success)
        {
            return errorMessage;
        }
        
        
        
        foreach (char c in state.SearchWords)
        {
            if (map.ContainsKey(c))
            {
                arabicVersionOfSearchWords.Add(map[c]);
            }
        }
        

        var arabic = new string(arabicVersionOfSearchWords.ToArray());

        var results = AnalyzeText(arabic);
        
        return new FlexColumn
        {
            $"Sayısal değeri: {results.Where(l=>l.OrderValue > 0).Sum(x=>x.NumericValue)}",
            br,
          $"Sıra değeri: {results.Where(l=>l.OrderValue > 0).Sum(x=>x.OrderValue)}",
          br,
          CrateTable
          
        };
        

        //return CrateTable();
    }
    
    Task StartCalculate()
    {
        state.IsProcessing = true;

        state.CanShowCalculationResults = false;
        
        
        Client.GotoMethod(10, Calculate);
        
        return Task.CompletedTask;
    }

    Task Calculate()
    {
        state.IsProcessing = false;

        state.CanShowCalculationResults = true;
        
        return Task.CompletedTask;
    }
    class NumberViewer : PureComponent
    {
        public int Count { get; set; }
        public bool DisableColorize { get; set; }
        
        protected override Element render()
        {
            if (Count <= 0 || DisableColorize)
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
        var searchLettersAsString = "ص";
        var chapterNumbers = new[] { 28, 37, 38, 41, 61, 103, 110, 112 };
        var searchLetters = AnalyzeText(searchLettersAsString).Select(letter => letter.OrderValue).ToArray();

        //var chapterNumbers = new[] { 42, 50 };
        //var searchLetters = new[] { ArabicLetterOrder.Qaaf };

        var sharedStyle = Border(Solid(1, "black")) + BorderCollapseCollapse+ TextAlignCenter + Padding(5);

        static int CalculateCount(string verseFilter, int[] arabicLetterOrders)
        {
            return VerseFilter.GetVerseList(verseFilter).Then(verses => arabicLetterOrders.Sum(arabicLetterOrder => QuranAnalyzerMixin.GetCountOfLetter(verses, arabicLetterOrder))).Value;
        }

        var dataList = chapterNumbers.Select(chapterNumber => new
        {
            ChapterNumber = chapterNumber,
            NumberOfVerseInChapter=VerseFilter.GetVerseList(chapterNumber + ":*").Value.Count,
            NumberOfSearchLetters = CalculateCount(chapterNumber+":*",searchLetters)
        }).ToList();
        
        return new table(sharedStyle, Background(White))
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
                
                dataList.Select(data =>new tr
                {
                    new td(sharedStyle)
                    {
                        "ص\u02dc"
                    },
                    new td(sharedStyle, PaddingTopBottom(10))
                    {
                        string.Join(", ", searchLetters)
                    },
                    new td(sharedStyle)
                    {
                        new NumberViewer{Count = data.ChapterNumber, DisableColorize = true}
                    },
                    new td(sharedStyle)
                    {
                        new NumberViewer{Count = data.NumberOfSearchLetters, DisableColorize = true}
                    },
                    new td(sharedStyle)
                    {
                        new NumberViewer{Count = data.NumberOfVerseInChapter}
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
                        "AYET TOPLAMI",
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

/*
 *
 
 ا
   ,b:ب
   ,c:ج
   ,d:د
   ,h:ه
   ,v:و
   ,z:ز
   , ح
   , ط
   ,y:ي
   ,k:ك
   ,l:ل
   ,m:م
   ,n:ن
   , س
   , ع
   ,f:ف
   ,s:ص
   , ق
   ,r:ر
   , ش
   ,t:ت
   , ث
   , خ
   , ذ
   , ض
   , ظ
   , غ
 
 
 * 
 */