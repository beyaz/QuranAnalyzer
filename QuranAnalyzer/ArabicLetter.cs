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
   
    // 11
    public static readonly LetterInfo Kaf  = new (){ Letter = ArabicLetter.Kaf, OrderValue = 11, NumericValue = 20};
 
    // 12
    public static readonly LetterInfo Lam  = new (){ Letter = ArabicLetter.Lam, OrderValue = 12, NumericValue = 30};
    
    // 13
    public static readonly LetterInfo Meem  = new (){ Letter = ArabicLetter.Meem, OrderValue = 13, NumericValue = 40};
    
    // 14
    public static readonly LetterInfo Noon  = new (){ Letter = ArabicLetter.Noon, OrderValue = 14, NumericValue = 50};

    // 15
    public static readonly LetterInfo Seen  = new (){ Letter = ArabicLetter.Seen, OrderValue = 15, NumericValue = 60};
    
    // 16
    public static readonly LetterInfo Ain  = new (){ Letter = ArabicLetter.Ain, OrderValue = 16, NumericValue = 70};
    
    // 17
    public static readonly LetterInfo Feh  = new (){ Letter = ArabicLetter.Feh, OrderValue = 17, NumericValue = 80};
    
    // 18
    public static readonly LetterInfo Sad  = new (){ Letter = ArabicLetter.Sad, OrderValue = 18, NumericValue = 90};
    
    // 19
    public static readonly LetterInfo Qaf  = new (){ Letter = ArabicLetter.Qaf, OrderValue = 19, NumericValue = 100};
    
    // 20
    public static readonly LetterInfo Reh  = new (){ Letter = ArabicLetter.Reh, OrderValue = 20, NumericValue = 200};

    // 21
    public static readonly LetterInfo Sheen  = new (){ Letter = ArabicLetter.Sheen, OrderValue = 21, NumericValue = 300};
    
    // 22
    public static readonly LetterInfo Teh  = new (){ Letter = ArabicLetter.Teh, OrderValue = 22, NumericValue = 400};

    // 23
    public static readonly LetterInfo The  = new (){ Letter = ArabicLetter.The, OrderValue = 23, NumericValue = 500};

    // 24
    public static readonly LetterInfo Khah  = new (){ Letter = ArabicLetter.Khah, OrderValue = 24, NumericValue = 600};

    // 25
    public static readonly LetterInfo Thal  = new (){ Letter = ArabicLetter.Thal, OrderValue = 25, NumericValue = 700};
    
    // 26
    public static readonly LetterInfo Dad  = new (){ Letter = ArabicLetter.Dad, OrderValue = 26, NumericValue = 800};

    // 27
    public static readonly LetterInfo Zah  = new (){ Letter = ArabicLetter.Zah, OrderValue = 27, NumericValue = 900};
    
    // 28
    public static readonly LetterInfo Ghain  = new (){ Letter = ArabicLetter.Ghain, OrderValue = 28, NumericValue = 1000};
    
    // @formatter:on
}
