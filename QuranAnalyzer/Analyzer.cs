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
                StartIndex        = startIndex
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
                    StartIndex        = startIndex
                };
            }
        }

        if (c == 'ب')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 1,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ت')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 2,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ث')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 3,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ج' || c == 'ج')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 4,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ح')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 5,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'خ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 6,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'د')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 7,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ذ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 8,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ر')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 9,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ز' || c == 'ز')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 10,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'س')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 11,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ش')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 12,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ص')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 13,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ض')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 14,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ط')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 15,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ظ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 16,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ع')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 17,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'غ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 18,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ف')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 19,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ق')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 20,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ك')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 21,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ل')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 22,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'م')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 23,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ن')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 24,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ه' || c == 'ة')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 25,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'و' || c == 'ٯ' || c == 'ؤ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 26,
                Letter            = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ي' || c == 'ى' || c == 'ئ')
        {
            return new LetterInfo
            {
                ArabicLetterIndex = 27,
                Letter            = c,
                StartIndex        = startIndex
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