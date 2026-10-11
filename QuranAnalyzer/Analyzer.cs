namespace QuranAnalyzer;

public static class Analyzer
{
    public const char Hamza = 'ء';
    public const char HamzaAbove = 'ٔ';
    
    static readonly LetterInfo LetterHamza = new()
    {
        Letter = Hamza,
        NumericValue = 1,
        OrderValue = 1
    };
    
    static readonly LetterInfo LetterHamzaAbove = new()
    {
        Letter = HamzaAbove,
        NumericValue = 1,
        OrderValue = 1
    };

    public static IReadOnlyList<LetterInfo> AnalyzeText(string line, bool isHamzaActive = true)
    {
        return [.. line.Select((c, i) => GetLetterInfo(c, isHamzaActive) with { StartIndex = i })];
    }

    public static LetterInfo GetLetterInfo(char c, bool isHamzaActive)
    {
        foreach (var letter in Letter.All)
        {
            if (letter.Letter == c)
            {
                return letter;
            }
        }

        // elif
        if (isHamzaActive)
        {
            if (c == LetterHamza.Letter || c == LetterHamzaAbove.Letter)
            {
                return new()
                {
                    Letter       = c,
                    NumericValue = 1,
                    OrderValue   = 1
                };
            }
        }

        return new()
        {
            Letter     = c
        };
    }

    public static bool HasValueAndSameAs(this LetterInfo a, LetterInfo b)
    {
        if (a is null || b is null)
        {
            return false;
        }

        if (a.NumericValue > 0 && a.NumericValue == b.NumericValue)
        {
            return true;
        }

        return false;
    }

    
   public const string LatinCharToArabicCharMap =
        """

        a : ا  ,  b : ب  ,  c : ج  ,  d : د  ,
        f : ف  ,  ç : ج  ,  g : ك  ,  h : ح  ,
        i : ي  ,  j : ج  ,  k : ك  ,  l : ل  ,
        m : م  ,  n : ن  ,  o : و  ,  p : پ  ,
        q : ق  ,  r : ر  ,  s : س  ,  t : ت  ,
        u : ع  ,  v : ڤ  ,  w : و  ,  ö : و  ,
        ü : و  ,  x : خ  ,  y : ي  ,  z : ز  ,

        """;
    
    public static IReadOnlyDictionary<char, LetterInfo> GetLatinCharToArabicCharMap(string latinCharToArabicCharMap)
    {
        Dictionary<char, LetterInfo> map = [];
            
        foreach (var pairText in latinCharToArabicCharMap.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var pair = pairText.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (pair.Length == 2)
            {
                var latinChar = pair[0][0];
                    
                var arabicChar = pair[1][0];
                    
                map.Add(latinChar, GetLetterInfo(arabicChar, true));
            }
        }
            
        return map;
    }
}