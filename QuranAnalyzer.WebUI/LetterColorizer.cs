using System.Text;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.WebUI.LetterColorPalette;

namespace QuranAnalyzer.WebUI;

sealed record LetterColorizerModel
{
    public required string ArabicTextInHtmlFormat { get; init; }

    public required int ChapterNumber { get; init; }

    public required IReadOnlyList<LetterColorizerLetterModel> ColorizedLetters { get; init; }

    public required int VerseNumber { get; init; }
}

sealed record LetterColorizerLetterModel
{
    public required int Count { get; init; }

    public required string ExtraCount { get; init; }

    public required string Letter { get; init; }

    public required string LetterColor { get; init; }
}

public sealed record LetterColorizerInput
{
    public required int ChapterNumber { get; init; }

    public required IReadOnlyList<LetterInfo> LettersForColorizeNodes { get; init; }

    public required MushafOption MushafOption { get; init; }

    public required int VerseNumber { get; init; }

    public required string VerseText { get; init; }

    public required IReadOnlyList<LetterInfo> VerseTextNodes { get; init; }
}

static class LetterColorizer
{
    internal static LetterColorizerModel Calculate(LetterColorizerInput input)
    {
        var lettersForColorize = input.LettersForColorizeNodes;

        var cursor = 0;

        var counts = new int[lettersForColorize.Count];

        var html = new StringBuilder();

        foreach (var letterInfo in input.VerseTextNodes)
        {
            for (var j = 0; j < lettersForColorize.Count; j++)
            {
                if (letterInfo.NumericValue == lettersForColorize[j].NumericValue)
                {
                    html.Append(input.VerseText.Substring(cursor, letterInfo.StartIndex - cursor));

                    var span = new span
                    {
                        innerText = letterInfo.Letter.ToString(),
                        style =
                        {
                            FontWeightBold,
                            BorderRadiusForPanels,
                            Border("1px dashed rgb(218, 220, 224)"),
                            Color(GetColor(j))
                        }
                    };

                    html.Append(span.ToHtml());

                    cursor = letterInfo.StartIndex + 1;

                    counts[j]++;

                    break;
                }
            }
        }

        if (cursor < input.VerseText.Length - 1)
        {
            html.Append(input.VerseText[cursor..]);
        }

        List<LetterColorizerLetterModel> letterModels = [];
        for (var j = 0; j < lettersForColorize.Count; j++)
        {
            letterModels.Add(new()
            {
                Letter      = lettersForColorize[j].Letter.ToString(),
                LetterColor = GetColor(j),
                Count       = counts[j],
                ExtraCount  = GetExtraModel(input.MushafOption, input.ChapterNumber, input.VerseNumber, lettersForColorize[j].OrderValue)
            });
        }

        return new()
        {
            ChapterNumber          = input.ChapterNumber,
            VerseNumber            = input.VerseNumber,
            ColorizedLetters       = letterModels,
            ArabicTextInHtmlFormat = html.ToString()
        };
    }

    static string GetExtraModel(MushafOption mushafOption, int ChapterNumber, int VerseNumber, int arabicLetterOrder)
    {
        if (mushafOption == null)
        {
            return null;
        }

        var verseId = $"{ChapterNumber}:{VerseNumber}";

        if (arabicLetterOrder == Alif)
        {
            if (!mushafOption.UseElifReferencesFromTanzil)
            {
                if (MushafTotalCountPerVerseDifference[Alif].TryGetValue(GetDifferencesKeyForRK(verseId), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Alif].TryGetValue(GetDifferencesKeyForTanzil(verseId), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return "+" + (count - countAccordingToTanzil);
                        }

                        return "-" + (countAccordingToTanzil - count);
                    }
                }
            }
        }

        if (arabicLetterOrder == Laam)
        {
            if (!mushafOption.Use_Laam_SpecifiedByTanzil)
            {
                if (MushafTotalCountPerVerseDifference[Laam].TryGetValue(GetDifferencesKeyForRK(verseId), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Laam].TryGetValue(GetDifferencesKeyForTanzil(verseId), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return "+" + (count - countAccordingToTanzil);
                        }

                        return "-" + (countAccordingToTanzil - count);
                    }
                }
            }
        }

        if (arabicLetterOrder == Saad)
        {
            if (!mushafOption.Use_Sad_in_Surah_7_Verse_69_in_word_bestaten)
            {
                if (MushafTotalCountPerVerseDifference[Saad].TryGetValue(GetDifferencesKeyForRK(verseId), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Saad].TryGetValue(GetDifferencesKeyForTanzil(verseId), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return "+" + (count - countAccordingToTanzil);
                        }

                        return "-" + (countAccordingToTanzil - count);
                    }
                }
            }
        }

        if (arabicLetterOrder == Siin)
        {
            if (!mushafOption.Use_Sad_in_Surah_7_Verse_69_in_word_bestaten)
            {
                if (MushafTotalCountPerVerseDifference[Siin].TryGetValue(GetDifferencesKeyForRK(verseId), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Siin].TryGetValue(GetDifferencesKeyForTanzil(verseId), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return "+" + (count - countAccordingToTanzil);
                        }

                        return "-" + (countAccordingToTanzil - count);
                    }
                }
            }
        }

        if (arabicLetterOrder == Nun)
        {
            if (!mushafOption.Chapter_68_Should_Single_Nun)
            {
                if (MushafTotalCountPerVerseDifference[Nun].TryGetValue(GetDifferencesKeyForRK(verseId), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Nun].TryGetValue(GetDifferencesKeyForTanzil(verseId), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return "+" + (count - countAccordingToTanzil);
                        }

                        return "-" + (countAccordingToTanzil - count);
                    }
                }
            }
        }

        if (arabicLetterOrder == Waaw)
        {
            if (!mushafOption.Chapter_68_Should_Single_Nun)
            {
                if (MushafTotalCountPerVerseDifference[Waaw].TryGetValue(GetDifferencesKeyForRK(verseId), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Waaw].TryGetValue(GetDifferencesKeyForTanzil(verseId), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return "+" + (count - countAccordingToTanzil);
                        }

                        return "-" + (countAccordingToTanzil - count);
                    }
                }
            }

            if (!mushafOption.Enba_u_Should_Contains_one_waw)
            {
                // [enba'u] Tanzil.net counts extra waw char in these verses
                if (verseId == "6:5")
                {
                    return "-1";
                }

                if (verseId == "26:6")
                {
                    return "-1";
                }
            }

            if (!mushafOption._75_13_yunebbeu_Should_Contains_1_waw)
            {
                if (verseId == "75:13")
                {
                    return "-1";
                }
            }
        }

        if (arabicLetterOrder == Yaa)
        {
            // Tanzil.net has a bug here. There mush be extra ye here according to utmaine mushaf
            if (!mushafOption.Ya_sahibeyi_Should_Contains_2_ya)
            {
                // [ ya sahibeyi ] - [يَا صَاحِبَيِ]
                if (verseId == "12:39")
                {
                    return "+1";
                }

                if (verseId == "12:41")
                {
                    return "+1";
                }
            }
        }

        return null;
    }
}