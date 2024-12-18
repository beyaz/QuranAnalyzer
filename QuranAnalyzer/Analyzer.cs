﻿namespace QuranAnalyzer;

public static class Analyzer
{
    public const char Hamza = 'ء';
    public const char HamzaAbove = 'ٔ';

    public static IReadOnlyList<LetterInfo> AnalyzeText(string line, bool isHemzeActive = true)
    {
        return line.Select((c, i) => GetLetterInfo(c, i, isHemzeActive)).ToList();
    }

    public static LetterInfo GetLetterInfo(char c, int startIndex, bool isHemzeActive)
    {
        // elif
        if (c is 'ا' or 'ٱ' or 'إ' or 'أ' or 'ﺍ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 1,
                OrderValue   = 1
            };
        }

        // elif
        if (isHemzeActive)
        {
            if (c is Hamza or HamzaAbove)
            {
                return new()
                {
                    Letter       = c,
                    StartIndex   = startIndex,
                    NumericValue = 1,
                    OrderValue   = 1
                };
            }
        }

        // be
        if (c == 'ب')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 2,
                OrderValue   = 2
            };
        }

        // cim
        if (c == 'ج' || c == 'ج')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 3,
                OrderValue   = 3
            };
        }

        // dal
        if (c == 'د')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 4,
                OrderValue   = 4
            };
        }

        // he
        if (c == 'ه' || c == 'ة')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 5,
                OrderValue   = 5
            };
        }

        // vav
        if (c == 'و' || c == 'ٯ' || c == 'ؤ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 6,
                OrderValue   = 6
            };
        }

        // ze
        if (c == 'ز' || c == 'ز')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 7,
                OrderValue   = 7
            };
        }

        // ha
        if (c == 'ح')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 8,
                OrderValue   = 8
            };
        }

        // tı
        if (c == 'ط')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 9,
                OrderValue   = 9
            };
        }

        // ye
        if (c is 'ي' or 'ى' or 'ئ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 10,
                OrderValue   = 10
            };
        }

        // kef
        if (c == 'ك')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 20,
                OrderValue   = 11
            };
        }

        // lam
        if (c == 'ل')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 30,
                OrderValue   = 12
            };
        }

        // mim
        if (c == 'م')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 40,
                OrderValue   = 13
            };
        }

        // nun
        if (c == 'ن')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 50,
                OrderValue   = 14
            };
        }

        // sin
        if (c == 'س')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 60,
                OrderValue   = 15
            };
        }

        // ayn
        if (c == 'ع')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 70,
                OrderValue   = 16
            };
        }

        // fe
        if (c == 'ف')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 80,
                OrderValue   = 17
            };
        }

        // sad
        if (c == 'ص')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 90,
                OrderValue   = 18
            };
        }

        // kaf
        if (c == 'ق')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 100,
                OrderValue   = 19
            };
        }

        // re
        if (c == 'ر')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 200,
                OrderValue   = 20
            };
        }

        //şin
        if (c == 'ش')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 300,
                OrderValue   = 21
            };
        }

        // te
        if (c == 'ت')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 400,
                OrderValue   = 22
            };
        }

        // se
        if (c == 'ث')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 500,
                OrderValue   = 23
            };
        }

        // hı
        if (c == 'خ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 600,
                OrderValue   = 24
            };
        }

        // zel
        if (c == 'ذ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 700,
                OrderValue   = 25
            };
        }

        // dad
        if (c == 'ض')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 800,
                OrderValue   = 26
            };
        }

        // zı
        if (c == 'ظ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 900,
                OrderValue   = 27
            };
        }

        // ğayn
        if (c == 'غ')
        {
            return new()
            {
                Letter       = c,
                StartIndex   = startIndex,
                NumericValue = 1000,
                OrderValue   = 28
            };
        }

        return new()
        {
            Letter     = c,
            StartIndex = startIndex
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

    public static bool IsArabicLetter(LetterInfo info)
    {
        return info.NumericValue > 0;
    }
}