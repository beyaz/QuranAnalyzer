using System.Numerics;

namespace QuranAnalyzer;

public static class Calculator
{
    public static BigInteger GetNumericValue(string str)
    {
        BigInteger total = 0;

        var len = str.Length;

        for (var i = 0; i < len; i++)
        {
            total += GetNumericValue(str[i]);
        }

        return total;
    }

    public static int GetNumericValue(char c)
    {
        if (c == 'ا')
        {
            return 1;
        }

        if (c == 'ب')
        {
            return 2;
        }

        if (c == 'ت')
        {
            return 400;
        }

        if (c == 'ث')
        {
            return 500;
        }

        if (c == 'ج')
        {
            return 3;
        }

        if (c == 'ح')
        {
            return 8;
        }

        if (c == 'خ')
        {
            return 600;
        }

        if (c == 'د')
        {
            return 4;
        }

        if (c == 'ذ')
        {
            return 700;
        }

        if (c == 'ر')
        {
            return 200;
        }

        if (c == 'ز')
        {
            return 7;
        }

        if (c == 'س')
        {
            return 60;
        }

        if (c == 'ش')
        {
            return 300;
        }

        if (c == 'ص')
        {
            return 90;
        }

        if (c == 'ض')
        {
            return 800;
        }

        if (c == 'ط')
        {
            return 9;
        }

        if (c == 'ظ')
        {
            return 900;
        }

        if (c == 'ع')
        {
            return 70;
        }

        if (c == 'غ')
        {
            return 1000;
        }

        if (c == 'ف')
        {
            return 80;
        }

        if (c == 'ق')
        {
            return 100;
        }

        if (c == 'ك')
        {
            return 20;
        }

        if (c == 'ل')
        {
            return 30;
        }

        if (c == 'م')
        {
            return 40;
        }

        if (c == 'ن')
        {
            return 50;
        }

        if (c == 'ه')
        {
            return 5;
        }

        if (c == 'و')
        {
            return 6;
        }

        if (c == 'ي')
        {
            return 10;
        }

        throw new Exception($"Not recognized Arabic Letter:'{c}'");
    }

    public static BigInteger GetOrderValue(string str)
    {
        BigInteger total = 0;

        var len = str.Length;

        for (var i = 0; i < len; i++)
        {
            total += GetOrderNumber(str[i]);
        }

        return total;
    }

    static int GetOrderNumber(char c)
    {
        if (c == 'ا')
        {
            return 1;
        }

        if (c == 'ب')
        {
            return 2;
        }

        if (c == 'ت')
        {
            return 3;
        }

        if (c == 'ث')
        {
            return 4;
        }

        if (c == 'ج')
        {
            return 5;
        }

        if (c == 'ح')
        {
            return 6;
        }

        if (c == 'خ')
        {
            return 7;
        }

        if (c == 'د')
        {
            return 8;
        }

        if (c == 'ذ')
        {
            return 9;
        }

        if (c == 'ر')
        {
            return 10;
        }

        if (c == 'ز')
        {
            return 11;
        }

        if (c == 'س')
        {
            return 12;
        }

        if (c == 'ش')
        {
            return 13;
        }

        if (c == 'ص')
        {
            return 14;
        }

        if (c == 'ض')
        {
            return 15;
        }

        if (c == 'ط')
        {
            return 16;
        }

        if (c == 'ظ')
        {
            return 17;
        }

        if (c == 'ع')
        {
            return 18;
        }

        if (c == 'غ')
        {
            return 19;
        }

        if (c == 'ف')
        {
            return 20;
        }

        if (c == 'ق')
        {
            return 21;
        }

        if (c == 'ك')
        {
            return 22;
        }

        if (c == 'ل')
        {
            return 23;
        }

        if (c == 'م')
        {
            return 24;
        }

        if (c == 'ن')
        {
            return 25;
        }

        if (c == 'ه')
        {
            return 26;
        }

        if (c == 'و')
        {
            return 27;
        }

        if (c == 'ي')
        {
            return 28;
        }

        throw new Exception($"Not recognized Arabic Letter:'{c}'");
    }
    
    public static int GetOrderValueByNumericValue(int c)
    {
        if (c == 1)
        {
            return 1;
        }

        if (c == 2)
        {
            return 2;
        }

        if (c == 400)
        {
            return 3;
        }

        if (c == 500)
        {
            return 4;
        }

        if (c == 3)
        {
            return 5;
        }

        if (c == 8)
        {
            return 6;
        }

        if (c == 600)
        {
            return 7;
        }

        if (c == 4)
        {
            return 8;
        }

        if (c == 700)
        {
            return 9;
        }

        if (c == 200)
        {
            return 10;
        }

        if (c == 7)
        {
            return 11;
        }

        if (c == 60)
        {
            return 12;
        }

        if (c == 300)
        {
            return 13;
        }

        if (c == 90)
        {
            return 14;
        }

        if (c == 800)
        {
            return 15;
        }

        if (c == 9)
        {
            return 16;
        }

        if (c == 900)
        {
            return 17;
        }

        if (c == 70)
        {
            return 18;
        }

        if (c == 1000)
        {
            return 19;
        }

        if (c == 80)
        {
            return 20;
        }

        if (c == 100)
        {
            return 21;
        }

        if (c == 20)
        {
            return 22;
        }

        if (c == 30)
        {
            return 23;
        }

        if (c == 40)
        {
            return 24;
        }

        if (c == 50)
        {
            return 25;
        }

        if (c == 5)
        {
            return 26;
        }

        if (c == 6)
        {
            return 27;
        }

        if (c == 10)
        {
            return 28;
        }

        throw new Exception($"Not recognized Arabic Letter:'{c}'");
    }
    
    
    
    
    public static LetterInfo2 GetLetterInfo(char c, int startIndex, bool isHemzeActive)
    {
        if (c == 'ا' || c == 'ٱ' || c == 'إ' || c == 'أ' || c == 'ﺍ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 0,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (isHemzeActive)
        {
            const char Hamza = 'ء';
            const char HamzaAbove = 'ٔ';
            
            if (c == Hamza || c == HamzaAbove)
            {
                return new LetterInfo2
                {
                    ArabicLetterIndex = 0,
                    MatchedLetter     = c,
                    StartIndex        = startIndex
                };
            }
        }

        if (c == 'ب')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 1,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ت')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 2,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ث')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 3,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ج' || c == 'ج')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 4,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ح')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 5,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'خ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 6,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'د')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 7,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ذ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 8,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ر')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 9,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ز' || c == 'ز')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 10,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'س')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 11,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ش')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 12,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ص')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 13,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ض')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 14,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ط')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 15,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ظ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 16,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ع')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 17,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'غ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 18,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ف')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 19,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ق')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 20,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ك')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 21,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ل')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 22,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'م')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 23,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ن')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 24,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ه' || c == 'ة')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 25,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'و' || c == 'ٯ' || c ==  'ؤ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 26,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c == 'ي' || c == 'ى' || c == 'ئ')
        {
            return new LetterInfo2
            {
                ArabicLetterIndex = 27,
                MatchedLetter     = c,
                StartIndex        = startIndex
            };
        }

        if (c != ' ')
        {
            c.ToString();
        }
        
        return new LetterInfo2
        {
            ArabicLetterIndex = -1,
            MatchedLetter     = c,
            StartIndex        = startIndex
        };
    }
}

public sealed class LetterInfo2
{
    public int ArabicLetterIndex { get; init; }
    public char MatchedLetter { get; init; }
    public int StartIndex { get; init; }

    public override string ToString()
    {
        return MatchedLetter.ToString();
    }
}