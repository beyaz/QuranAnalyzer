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
}