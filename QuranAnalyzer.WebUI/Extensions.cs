namespace QuranAnalyzer.WebUI;

static class Extensions
{
    internal static void AddOrUpdate<T>(this List<T> list, Predicate<T> predicate, Func<T> notFound, Func<T,T> found) where T: class
    {
        var index = list.FindIndex(predicate);
        if (index != -1)
        {
            list[index] = found(list[index]);
        }
        else
        {
            list.Add(notFound());
        }
    }

    public static string ColorForBorder = "#dee2e6";
    public static ReactContextKey<string> KeyForQueryString = new(nameof(KeyForQueryString));

    public static string BluePrimary => "#1976d2";

    public static StyleModifier BorderRadiusForPanels => BorderRadius(5);

    public static StyleModifier ComponentBorder => Border(Solid(1, ColorForBorder));
    public static StyleModifier FontFamily_Lateef => FontFamily("Lateef, cursive");

    public static StyleModifier AnimateHeightAndOpacity(bool isVisible)
    {
        return Transition(nameof(Style.all), 300) +
               Transition(nameof(Style.opacity), 300) +
               (isVisible
                   ? VisibilityVisible + Opacity1 + HeightAuto
                   : VisibilityCollapse + Opacity0 + Height0);
    }

    public static int AsNumber(this bool value)
    {
        return value ? 1 : 0;
    }

    public static string AsText(this IReadOnlyList<LetterInfo> letters)
    {
        return string.Join(string.Empty, letters);
    }

    public static string FileAtImgFolder(string fileName)
    {
        return "wwwroot/img/" + fileName;
    }

    public static string GetLetterCountingScript(string chapterFilter, params char[] arabicLetters)
    {
        return chapterFilter + "~" + string.Join(string.Empty, arabicLetters);
    }

    public static string GetPageLink(string pageId)
    {
        return $"/?{QueryKey.Page}=" + pageId;
    }

    public static string GetTurkishPronunciationOfArabicLetter(char arabicLetter)
    {
        if (ArabicLetter.Alef == arabicLetter) return ArabicLetterTurkishPronunciation.Alef;
        if (ArabicLetter.Beh == arabicLetter) return ArabicLetterTurkishPronunciation.Beh;
        if (ArabicLetter.Teh == arabicLetter) return ArabicLetterTurkishPronunciation.Taa;
        if (ArabicLetter.Theh == arabicLetter) return ArabicLetterTurkishPronunciation.Thaa;
        if (ArabicLetter.Jeem == arabicLetter) return ArabicLetterTurkishPronunciation.Jeem;
        if (ArabicLetter.Hah == arabicLetter) return ArabicLetterTurkishPronunciation.Haa;
        if (ArabicLetter.Khah == arabicLetter) return ArabicLetterTurkishPronunciation.Khaa;
        if (ArabicLetter.Dal == arabicLetter) return ArabicLetterTurkishPronunciation.Dal;
        if (ArabicLetter.Thal == arabicLetter) return ArabicLetterTurkishPronunciation.Dhaal;
        if (ArabicLetter.Reh == arabicLetter) return ArabicLetterTurkishPronunciation.Raa;
        if (ArabicLetter.Zain == arabicLetter) return ArabicLetterTurkishPronunciation.Zay;
        if (ArabicLetter.Seen == arabicLetter) return ArabicLetterTurkishPronunciation.Siin;
        if (ArabicLetter.Sheen == arabicLetter) return ArabicLetterTurkishPronunciation.Shiin;
        if (ArabicLetter.Sad == arabicLetter) return ArabicLetterTurkishPronunciation.Saad;
        if (ArabicLetter.Dad == arabicLetter) return ArabicLetterTurkishPronunciation.Daad;
        if (ArabicLetter.Tah == arabicLetter) return ArabicLetterTurkishPronunciation.Taa_;
        if (ArabicLetter.Zah == arabicLetter) return ArabicLetterTurkishPronunciation.Zaa;
        if (ArabicLetter.Ain == arabicLetter) return ArabicLetterTurkishPronunciation.Ayn;
        if (ArabicLetter.Ghain == arabicLetter) return ArabicLetterTurkishPronunciation.Ghayn;
        if (ArabicLetter.Feh == arabicLetter) return ArabicLetterTurkishPronunciation.Faa;
        if (ArabicLetter.Qaf == arabicLetter) return ArabicLetterTurkishPronunciation.Qaaf;
        if (ArabicLetter.Kaf == arabicLetter) return ArabicLetterTurkishPronunciation.Kaaf;
        if (ArabicLetter.Lam == arabicLetter) return ArabicLetterTurkishPronunciation.Laam;
        if (ArabicLetter.Meem == arabicLetter) return ArabicLetterTurkishPronunciation.Miim;
        if (ArabicLetter.Noon == arabicLetter) return ArabicLetterTurkishPronunciation.Nun;
        if (ArabicLetter.Heh == arabicLetter) return ArabicLetterTurkishPronunciation.Haa_;
        if (ArabicLetter.Waw == arabicLetter) return ArabicLetterTurkishPronunciation.Waaw;
        if (ArabicLetter.Yeh == arabicLetter) return ArabicLetterTurkishPronunciation.Yaa;

        return arabicLetter.ToString();
    }

    public static (string reading, string trMean)? GetTurkishPronunciationOfArabicWord(string arabicWord)
    {
        if (arabicWord == "ايام")
        {
            return ("eyyam", "günler");
        }

        if (arabicWord == "يومين")
        {
            return ("yevmeyn", "2 gün");
        }

        if (arabicWord == "الايام")
        {
            return ("el-eyyam", "günler");
        }

        if (arabicWord == "اياما")
        {
            return ("eyyamen", "günler");
        }

        if (arabicWord == "واياما")
        {
            return ("ve eyyamen", "günler");
        }

        if (arabicWord == "بايىم")
        {
            return ("bi-eyyam", "günler");
        }

        // a d e m
        const string adem = "اادم";
        const string ya_adem = "يادم";
        const string li_adem = "لٔادم";
        const string veya_adem = "ويادم";

        // i s a
        const string isa = "عيسي";
        const string ve_isa = "وعيسي";
        const string ya_isa = "يعيسي";
        const string bi_isa = "بعيسي";

        return arabicWord switch
        {
            // a d e m
            adem      => ("âdem", "âdem"),
            ya_adem   => ("ya-âdem", "ya-âdem"),
            li_adem   => ("li-âdem", "li-âdem"),
            veya_adem => ("veya-âdem", "veya-âdem"),

            // i s a
            isa    => ("isa", "isa"),
            ve_isa => ("ve isa", "ve isa"),
            ya_isa => ("ya isa", "ya isa"),
            bi_isa => ("bi isa", "bi isa"),

            _ => null
        };
    }

    public static bool HasNoValue(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool HasValue(this string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public static void MainContentDivScrollChangedOverZero(this Client client, double mainDivScrollY)
    {
        client.DispatchEvent(nameof(MainContentDivScrollChangedOverZero));
    }

    public static void OnMainContentDivScrollChangedOverZero(this Client client, Func<double,Task> handlerAction)
    {
        client.ListenEvent(nameof(MainContentDivScrollChangedOverZero), handlerAction);
    }
}