namespace QuranAnalyzer.WebUI.Components;

class ArabicKeyboard : ReactPureComponent
{
    public static Element Content => new div(DisplayFlex, FlexWrap, JustifyContentCenter, DirectionRtl)
    {
        LetterToElement(ArabicLetter.Alef, ArabicLetterTurkishPronunciation.Alef),
        LetterToElement(ArabicLetter.Beh, ArabicLetterTurkishPronunciation.Beh),
        LetterToElement(ArabicLetter.Teh, ArabicLetterTurkishPronunciation.Taa),
        LetterToElement(ArabicLetter.Theh, ArabicLetterTurkishPronunciation.Thaa),
        LetterToElement(ArabicLetter.Jeem, ArabicLetterTurkishPronunciation.Jiim),
        LetterToElement(ArabicLetter.Hah, ArabicLetterTurkishPronunciation.Haa),
        LetterToElement(ArabicLetter.Khah, ArabicLetterTurkishPronunciation.Khaa),
        LetterToElement(ArabicLetter.Dal, ArabicLetterTurkishPronunciation.Daal),
        LetterToElement(ArabicLetter.Thal, ArabicLetterTurkishPronunciation.Dhaal),
        LetterToElement(ArabicLetter.Reh, ArabicLetterTurkishPronunciation.Raa),
        LetterToElement(ArabicLetter.Zain, ArabicLetterTurkishPronunciation.Zay),
        LetterToElement(ArabicLetter.Seen, ArabicLetterTurkishPronunciation.Siin),
        LetterToElement(ArabicLetter.Sheen, ArabicLetterTurkishPronunciation.Shiin),
        LetterToElement(ArabicLetter.Sad, ArabicLetterTurkishPronunciation.Saad),
        LetterToElement(ArabicLetter.Dad, ArabicLetterTurkishPronunciation.Daad),
        LetterToElement(ArabicLetter.Tah, ArabicLetterTurkishPronunciation.Taa_),
        LetterToElement(ArabicLetter.Zah, ArabicLetterTurkishPronunciation.Zaa),
        LetterToElement(ArabicLetter.Ain, ArabicLetterTurkishPronunciation.Ayn),
        LetterToElement(ArabicLetter.Ghain, ArabicLetterTurkishPronunciation.Ghayn),
        LetterToElement(ArabicLetter.Feh, ArabicLetterTurkishPronunciation.Faa),
        LetterToElement(ArabicLetter.Qaf, ArabicLetterTurkishPronunciation.Qaaf),
        LetterToElement(ArabicLetter.Kaf, ArabicLetterTurkishPronunciation.Kaaf),
        LetterToElement(ArabicLetter.Lam, ArabicLetterTurkishPronunciation.Laam),
        LetterToElement(ArabicLetter.Meem, ArabicLetterTurkishPronunciation.Miim),
        LetterToElement(ArabicLetter.Noon, ArabicLetterTurkishPronunciation.Nun),
        LetterToElement(ArabicLetter.Heh, ArabicLetterTurkishPronunciation.Haa_),
        LetterToElement(ArabicLetter.Waw, ArabicLetterTurkishPronunciation.Waaw),
        LetterToElement(ArabicLetter.Yeh, ArabicLetterTurkishPronunciation.Yaa)
    };

    protected override Element render()
    {
        return Content;
    }

    static Element LetterToElement(char arabicLetter, string englishText)
    {
        return new ArabicKeyboardLetterView { ArabicLetter = arabicLetter.ToString(), English = englishText };
    }
}

static class ArabicLetterTurkishPronunciation
{
    // @formatter:off
    public const string Alef = "elif";
    public const string Beh = "be";
    public const string Taa = "te";
    public const string Thaa = "se";
    public const string Jiim = "cim";
    public const string Haa = "hâ";
    public const string Khaa = "hı";
    public const string Daal = "dal";
    public const string Dhaal = "zel";
    public const string Raa = "ra";
    public const string Zay = "ze";
    public const string Siin = "sin";
    public const string Shiin = "şın";
    public const string Saad = "sad";
    public const string Daad = "dad";
    public const string Taa_ = "tı";
    public const string Zaa = "zı";
    public const string Ayn = "ayn";
    public const string Ghayn = "ghayn";
    public const string Faa = "fe";
    public const string Qaaf = "kaf";
    public const string Kaaf = "kef";
    public const string Laam = "lam";
    public const string Miim = "mim";
    public const string Nun = "nun";
    public const string Haa_ = "he";
    public const string Waaw = "vav";
    public const string Yaa = "yâ";
    // @formatter:on
}

class ArabicKeyboardLetterView : ReactComponent
{
    public string ArabicLetter { get; set; }
    public string English { get; set; }

    protected override Element render()
    {
        return new div
        {
            style =
            {
                DisplayFlex,
                FlexDirectionColumn,
                AlignItemsCenter,
                Margin(5),
                Border(Solid(1, ColorForBorder)),
                BorderRadius(5),
                Background(rgb(248, 249, 251)),
                CursorPointer,
                Hover(Border("1px solid #7daee7"))
            },
            children =
            {
                new div(PaddingLeftRight(5), FontSize(35), FontFamily_Lateef, Hover(Color("#7daee7")))
                {
                    text = ArabicLetter
                },
                new div(MarginLeftRight(2), FontSize("0.8rem"))
                {
                    text = English
                }
            },

            onClick = OnArabicKeyboardLetterClicked
        };
    }

    [StopPropagation]
    Task OnArabicKeyboardLetterClicked(MouseEvent e)
    {
        Client.ArabicKeyboardPressed(ArabicLetter);
        
        return Task.CompletedTask;
    }
}

static class ArabicKeyboardEvents
{
    public static Task ArabicKeyboardPressed(this Client client, string arabicLetter)
    {
        client.DispatchEvent(nameof(ArabicKeyboardPressed), [arabicLetter]);
        
        return Task.CompletedTask;
    }

    public static void OnArabicKeyboardPressed(this Client client, Func<string,Task> handlerAction)
    {
        client.ListenEvent(nameof(ArabicKeyboardPressed), handlerAction);
    }
}