namespace QuranAnalyzer.WebUI.Components;

class ArabicKeyboard : ReactPureComponent
{
    public static Element Content => new div(DisplayFlex, FlexWrap, JustifyContentCenter, DirectionRtl)
    {
        LetterToElement(ArabicLetter.Alef, ArabicLetterTurkishPronunciation.Alef),
        LetterToElement(ArabicLetter.Beh, ArabicLetterTurkishPronunciation.Beh),
        LetterToElement(ArabicLetter.Teh, ArabicLetterTurkishPronunciation.Teh),
        LetterToElement(ArabicLetter.Theh, ArabicLetterTurkishPronunciation.Thaa),
        LetterToElement(ArabicLetter.Jeem, ArabicLetterTurkishPronunciation.Jeem),
        LetterToElement(ArabicLetter.Hah, ArabicLetterTurkishPronunciation.Hah),
        LetterToElement(ArabicLetter.Khah, ArabicLetterTurkishPronunciation.Khah),
        LetterToElement(ArabicLetter.Dal, ArabicLetterTurkishPronunciation.Dal),
        LetterToElement(ArabicLetter.Thal, ArabicLetterTurkishPronunciation.Thal),
        LetterToElement(ArabicLetter.Reh, ArabicLetterTurkishPronunciation.Reh),
        LetterToElement(ArabicLetter.Zain, ArabicLetterTurkishPronunciation.Zain),
        LetterToElement(ArabicLetter.Seen, ArabicLetterTurkishPronunciation.Seen),
        LetterToElement(ArabicLetter.Sheen, ArabicLetterTurkishPronunciation.Sheen),
        LetterToElement(ArabicLetter.Sad, ArabicLetterTurkishPronunciation.Sad),
        LetterToElement(ArabicLetter.Dad, ArabicLetterTurkishPronunciation.Dad),
        LetterToElement(ArabicLetter.Tah, ArabicLetterTurkishPronunciation.Tah),
        LetterToElement(ArabicLetter.Zah, ArabicLetterTurkishPronunciation.Zah),
        LetterToElement(ArabicLetter.Ain, ArabicLetterTurkishPronunciation.Ain),
        LetterToElement(ArabicLetter.Ghain, ArabicLetterTurkishPronunciation.Ghain),
        LetterToElement(ArabicLetter.Feh, ArabicLetterTurkishPronunciation.Feh),
        LetterToElement(ArabicLetter.Qaf, ArabicLetterTurkishPronunciation.Qaf),
        LetterToElement(ArabicLetter.Kaf, ArabicLetterTurkishPronunciation.Kaf),
        LetterToElement(ArabicLetter.Lam, ArabicLetterTurkishPronunciation.Lam),
        LetterToElement(ArabicLetter.Meem, ArabicLetterTurkishPronunciation.Meem),
        LetterToElement(ArabicLetter.Noon, ArabicLetterTurkishPronunciation.Noon),
        LetterToElement(ArabicLetter.Heh, ArabicLetterTurkishPronunciation.Heh),
        LetterToElement(ArabicLetter.Waw, ArabicLetterTurkishPronunciation.Waw),
        LetterToElement(ArabicLetter.Yeh, ArabicLetterTurkishPronunciation.Yeh)
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
    public const string Teh = "te";
    public const string Thaa = "se";
    public const string Jeem = "cim";
    public const string Hah = "hâ";
    public const string Khah = "hı";
    public const string Dal = "dal";
    public const string Thal = "zel";
    public const string Reh = "ra";
    public const string Zain = "ze";
    public const string Seen = "sin";
    public const string Sheen = "şın";
    public const string Sad = "sad";
    public const string Dad = "dad";
    public const string Tah = "tı";
    public const string Zah = "zı";
    public const string Ain = "ayn";
    public const string Ghain = "ghayn";
    public const string Feh = "fe";
    public const string Qaf = "kaf";
    public const string Kaf = "kef";
    public const string Lam = "lam";
    public const string Meem = "mim";
    public const string Noon = "nun";
    public const string Heh = "he";
    public const string Waw = "vav";
    public const string Yeh = "yâ";
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