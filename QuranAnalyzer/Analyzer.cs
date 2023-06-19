namespace QuranAnalyzer;

public static class Analyzer
{
    public const char Hamza = 'ء';
    public const char HamzaAbove = 'ٔ';
    

    public static IReadOnlyList<LetterInfo> AnalyzeText(string line, bool isHemzeActive = true)
    {
        return line.Select((c, i) => GetLetterInfo(c, i, isHemzeActive)).ToList();
    }

    public static bool HasValueAndSameAs(this LetterInfo a, LetterInfo b)
    {
        if (a is null || b is null)
        {
            return false;
        }

        if (a.ArabicLetterIndex >= 0 && a.ArabicLetterIndex == b.ArabicLetterIndex)
        {
            return true;
        }

        return false;
    }

    public static bool IsArabicLetter(LetterInfo info)
    {
        return info.ArabicLetterIndex >= 0;
    }

    static LetterInfo GetLetterInfo(char c, int startIndex, bool isHemzeActive)
    {
        if (c == 'ا' || c == 'ٱ' || c == 'إ' || c == 'أ' || c == 'ﺍ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 0,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 1
            };
        }

        if (isHemzeActive)
        {
            if (c == Hamza || c == HamzaAbove)
            {
                return new LetterInfo
                {
                    ArabicLetterIndex = 0,
                    Letter            = c,
                    StartIndex        = startIndex,
                    NumericValue      = 1
                };
            }
        }

        if (c == 'ب')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 1,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 2
            };
        }

        if (c == 'ت')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 2,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 400
            };
        }

        if (c == 'ث')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 3,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 500
            };
        }

        if (c == 'ج' || c == 'ج')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 4,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 3
            };
        }

        if (c == 'ح')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 5,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 8
            };
        }

        if (c == 'خ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 6,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 600
            };
        }

        if (c == 'د')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 7,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 4
            };
        }

        if (c == 'ذ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 8,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 700
            };
        }

        if (c == 'ر')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 9,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 200
            };
        }

        if (c == 'ز' || c == 'ز')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 10,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 7
            };
        }

        if (c == 'س')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 11,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 60
            };
        }

        if (c == 'ش')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 12,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 300
            };
        }

        if (c == 'ص')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 13,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 90
            };
        }

        if (c == 'ض')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 14,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 800
            };
        }

        if (c == 'ط')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 15,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 9
            };
        }

        if (c == 'ظ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 16,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 900
            };
        }

        if (c == 'ع')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 17,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 70
            };
        }

        if (c == 'غ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 18,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 1000
            };
        }

        if (c == 'ف')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 19,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 80
            };
        }

        if (c == 'ق')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 20,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 100
            };
        }

        if (c == 'ك')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 21,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 20
            };
        }

        if (c == 'ل')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 22,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 30
            };
        }

        if (c == 'م')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 23,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 40
            };
        }

        if (c == 'ن')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 24,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 50
            };
        }

        if (c == 'ه' || c == 'ة')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 25,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 5
            };
        }

        if (c == 'و' || c == 'ٯ' || c == 'ؤ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 26,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 6
            };
        }

        if (c == 'ي' || c == 'ى' || c == 'ئ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 27,
                Letter            = c,
                StartIndex        = startIndex,
                NumericValue      = 10
            };
        }
        
        return new LetterInfo
        {
            ArabicLetterIndex = -1,
            Letter            = c,
            StartIndex        = startIndex
        };
    }
    
}