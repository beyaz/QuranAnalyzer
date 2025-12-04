using System.Text;

namespace QuranAnalyzer.WebUI.Components;

class LineLetterColorizer : ReactPureComponent
{
    public string ArabicText { get; set; }

    public string LettersForColorize { get; set; }

    protected override Element render()
    {
        return new FlexRow(DirectionRtl, FlexWrap, JustifyContentFlexEnd)
        {
            innerHTML = CalculateHtml()
        };
    }

    string CalculateHtml()
    {
        if (string.IsNullOrWhiteSpace(ArabicText))
        {
            return string.Empty;
        }

        if (string.IsNullOrWhiteSpace(LettersForColorize))
        {
            return ArabicText;
        }

        var arabicText = ArabicText;

        var (isParsedSuccessfully, grandVerseNumber, chapterNumber, verseNumber, verseText) = QuranArabicVersionWithNoBismillah.TryParseVerseNumbers(arabicText);
        if (isParsedSuccessfully)
        {
            arabicText = verseText;
        }

        var arabicTextLetters = Analyzer.AnalyzeText(arabicText).Where(Analyzer.IsArabicLetter).ToList();

        var lettersForColorize = Analyzer.AnalyzeText(LettersForColorize).Where(Analyzer.IsArabicLetter).ToList();

        var cursor = 0;

        var counts = new int[lettersForColorize.Count];

        var html = new StringBuilder();

        foreach (var letterInfo in arabicTextLetters)
        {
            for (var j = 0; j < lettersForColorize.Count; j++)
            {
                if (letterInfo.NumericValue == lettersForColorize[j].NumericValue)
                {
                    html.Append(arabicText.Substring(cursor, letterInfo.StartIndex - cursor));

                    var span = new span
                    {
                        innerText = letterInfo.Letter.ToString(),
                        style =
                        {
                            //FontWeightBold,
                            BorderRadius(5),
                            Border("0.5px dashed rgb(218, 220, 224)"),
                            Color(LetterColorPalette.GetColor(j))
                        }
                    };
                    html.Append(span.ToHtml());

                    cursor = letterInfo.StartIndex + 1;

                    counts[j]++;

                    break;
                }
            }
        }

        if (cursor < arabicText.Length - 1)
        {
            html.Append(arabicText.Substring(cursor));
        }

        if (isParsedSuccessfully)
        {
            return html + $"|{verseNumber}|{chapterNumber}|{grandVerseNumber}";
        }

        return html.ToString();
    }

    static class LetterColorPalette
    {
        static readonly string[] Colors =
        {
            "blue", "red", "#9900CC", "#00FF00", "#33CC00"
        };

        public static string GetColor(int index)
        {
            if (index >= 0 && index < Colors.Length)
            {
                return Colors[index];
            }

            return "red";
        }
    }
}