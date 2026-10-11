namespace QuranAnalyzer;

public static class ArabicLetter
{
    // @formatter:off
    public const char Alef  = 'ا';
    public const char Beh   = 'ب';
    public const char Jeem  = 'ج';
    public const char Dal  = 'د';
    public const char Heh  = 'ه';
    public const char Waw  = 'و';
    public const char Zain   = 'ز';
    public const char Hah   = 'ح';
    public const char Tah  = 'ط';
    public const char Yeh   = 'ي';
    public const char Kaf  = 'ك';
    public const char Lam  = 'ل';
    public const char Meem  = 'م';
    public const char Noon   = 'ن';
    public const char Seen  = 'س';
    public const char Ain   = 'ع';
    public const char Feh   = 'ف';
    public const char Sad  = 'ص';
    public const char Qaf  = 'ق';
    public const char Reh   = 'ر';
    public const char Sheen = 'ش';
    public const char Teh   = 'ت';
    public const char The  = 'ث';
    public const char Khah  = 'خ';
    public const char Thal = 'ذ';
    public const char Dad  = 'ض';
    public const char Zah   = 'ظ';
    public const char Ghain = 'غ';
    // @formatter:on
}

public static class ArabicLetterOrder
{
    // @formatter:off
    public const int Alef  = 1;
    public const int Beh   = 2;
    public const int Jeem  = 3;
    public const int Dal  = 4;
    public const int Heh  = 5;
    public const int Waw  = 6;
    public const int Zain   = 7;
    public const int Hah   = 8;
    public const int Tah  = 9;
    public const int Yeh   = 10;
    public const int Kaf  = 11;
    public const int Lam  = 12;
    public const int Meem  = 13;
    public const int Noon   = 14;
    public const int Seen  = 15;
    public const int Ain   = 16;
    public const int Feh   = 17;
    public const int Sad  = 18;
    public const int Qaf  = 19;
    public const int Reh   = 20;
    public const int Sheen = 21;
    public const int Teh   = 22;
    public const int The  = 23;
    public const int Khah  = 24;
    public const int Thal = 25;
    public const int Dad  = 26;
    public const int Zah   = 27;
    public const int Ghain = 28;
    // @formatter:on
}

public static class Letter
{
   
    // @formatter:off
    
    public static IReadOnlyList<LetterInfo> All
    {
        get
        {
            return field ??= 
            [
                Beh
            ];
        }
    }
    
    public const char Alef  = 'ا';
    public static readonly LetterInfo Beh  = new (){ Letter = ArabicLetter.Beh, OrderValue = 2, NumericValue = 2};
    public static readonly LetterInfo Jeem  = new (){ Letter = ArabicLetter.Jeem, OrderValue = 3, NumericValue = 3};
    public static readonly LetterInfo Dal  = new (){ Letter = ArabicLetter.Dal, OrderValue = 4, NumericValue = 4};
    
    public static readonly LetterInfo Heh  = new (){ Letter = ArabicLetter.Heh, OrderValue = 5, NumericValue = 5};
    public static readonly LetterInfo HehMarbuta  = new (){ Letter = 'ة', OrderValue = 5, NumericValue = 5};
    
    public static readonly LetterInfo Waw  = new (){ Letter = ArabicLetter.Waw, OrderValue = 6, NumericValue = 6};
    public static readonly LetterInfo Gaf  = new (){ Letter = 'ٯ', OrderValue = 6, NumericValue = 6};
    public static readonly LetterInfo WawWithHamzaAbove  = new (){ Letter = 'ؤ', OrderValue = 6, NumericValue = 6};
   
    public static readonly LetterInfo Zain  = new (){ Letter = ArabicLetter.Zain, OrderValue = 7, NumericValue = 7};
    public static readonly LetterInfo Hah  = new (){ Letter = ArabicLetter.Hah, OrderValue = 8, NumericValue = 8};
 
    public static readonly LetterInfo Tah  = new (){ Letter = ArabicLetter.Tah, OrderValue = 9, NumericValue = 9};
    
    
    public static readonly LetterInfo Yeh  = new (){ Letter = ArabicLetter.Yeh, OrderValue = 10, NumericValue = 10};
    public static readonly LetterInfo AlefMaksura  = new (){ Letter = 'ى', OrderValue = 10, NumericValue = 10};
    public static readonly LetterInfo YehWithHamzaAbove  = new (){ Letter = 'ئ', OrderValue = 10, NumericValue = 10};
   
 
    public const char Kaf  = 'ك';
    public const char Lam  = 'ل';
    public const char Meem  = 'م';
    public const char Noon   = 'ن';
    public const char Seen  = 'س';
    public const char Ain   = 'ع';
    public const char Feh   = 'ف';
    public const char Sad  = 'ص';
    public const char Qaf  = 'ق';
    public const char Reh   = 'ر';
    public const char Sheen = 'ش';
    public const char Teh   = 'ت';
    public const char The  = 'ث';
    public const char Khah  = 'خ';
    public const char Thal = 'ذ';
    public const char Dad  = 'ض';
    public const char Zah   = 'ظ';
    public const char Ghain = 'غ';
    // @formatter:on
}
