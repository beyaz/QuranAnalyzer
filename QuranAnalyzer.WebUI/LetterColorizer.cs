using System.Text;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.WebUI.LetterColorPalette;
using static QuranAnalyzer.QuranAnalyzerMixin;

namespace QuranAnalyzer.WebUI;

public class LetterColorizer : ReactPureComponent
{
    public string ChapterNumber { get; set; }
    public string LettersForColorize { get; set; }
    public IReadOnlyList<LetterInfo> LettersForColorizeNodes { get; set; }
    public MushafOption MushafOption { get; set; }

    public Verse Verse { get; set; }
    public string VerseNumber { get; set; }
    public string VerseText { get; set; }
    public IReadOnlyList<LetterInfo> VerseTextNodes { get; set; }

    protected override Element render()
    {
        var verseText = VerseTextNodes ??= Analyzer.AnalyzeText(VerseText).Where(Analyzer.IsArabicLetter).ToList();

        var lettersForColorize = LettersForColorizeNodes ??= Analyzer.AnalyzeText(LettersForColorize).Where(Analyzer.IsArabicLetter).ToList();

        var cursor = 0;

        var counts = new int[lettersForColorize.Count];

        var html = new StringBuilder();

        foreach (var letterInfo in verseText)
        {
            for (var j = 0; j < lettersForColorize.Count; j++)
            {
                if (letterInfo.NumericValue == lettersForColorize[j].NumericValue)
                {
                    html.Append(VerseText.Substring(cursor, letterInfo.StartIndex - cursor));

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

        if (cursor < VerseText.Length - 1)
        {
            html.Append(VerseText.Substring(cursor));
        }

        var countsView = new FlexRow(FlexWrap, JustifyContentCenter, Padding(5), Gap(13));

        for (var j = 0; j < lettersForColorize.Count; j++)
        {
            var countView = new FlexRow(AlignItemsCenter)
            {
                new div { lettersForColorize[j].Letter.ToString(), FontWeightBold, Color(GetColor(j)) },

                new div { ":", MarginLeftRight(4) },

                new div { counts[j].ToString(), FontSize12 },

                GetExtra(lettersForColorize[j].OrderValue)
            };

            countsView.children.Add(countView);
        }

        var textView = new div(FontFamily_Lateef)
        {
            html,
            FontSize(32),
            Padding(5),
            DirectionRtl
        };

        var verseId = new div(FontWeightBold, MarginLeft(2), FontSize13)
        {
            $"{ChapterNumber}:{VerseNumber}"
        };

        var topLegend = new legend(DisplayFlex, FlexDirectionRow, AlignItemsCenter, Gap(5), UserSelect(none))
        {
            verseId,
            countsView
        };

        return new fieldset
        {
            children = { topLegend, textView },
            style =
            {
                DisplayFlex,
                FlexDirectionColumn,
                AlignItemsFlexEnd,

                Border(1, "dashed", rgb(218, 220, 224)),
                BorderRadiusForPanels
            }
        };
    }

    Element GetExtra(int arabicLetterOrder)
    {
        if (Verse == null)
        {
            return null;
        }

        if (MushafOption == null)
        {
            return null;
        }

        if (arabicLetterOrder == Alif)
        {
            if (MushafOption.UseElifReferencesFromTanzil == false)
            {
                if (MushafTotalCountPerVerseDifference[Alif].TryGetValue(GetDifferencesKeyForRK(Verse.Id), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Alif].TryGetValue(GetDifferencesKeyForTanzil(Verse.Id), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return new div { text = "+" + (count - countAccordingToTanzil) };
                        }

                        return new div { text = "-" + (countAccordingToTanzil - count) };
                    }
                }
            }
        }

        if (arabicLetterOrder == Laam)
        {
            if (MushafOption.Use_Laam_SpecifiedByTanzil == false)
            {
                if (MushafTotalCountPerVerseDifference[Laam].TryGetValue(GetDifferencesKeyForRK(Verse.Id), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Laam].TryGetValue(GetDifferencesKeyForTanzil(Verse.Id), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return new div { text = "+" + (count - countAccordingToTanzil) };
                        }

                        return new div { text = "-" + (countAccordingToTanzil - count) };
                    }
                }
            }
        }

        if (arabicLetterOrder == Saad)
        {
            if (MushafOption.Use_Sad_in_Surah_7_Verse_69_in_word_bestaten == false)
            {
                if (MushafTotalCountPerVerseDifference[Saad].TryGetValue(GetDifferencesKeyForRK(Verse.Id), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Saad].TryGetValue(GetDifferencesKeyForTanzil(Verse.Id), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return new div { text = "+" + (count - countAccordingToTanzil) };
                        }

                        return new div { text = "-" + (countAccordingToTanzil - count) };
                    }
                }
            }
        }

        if (arabicLetterOrder == Siin)
        {
            if (MushafOption.Use_Sad_in_Surah_7_Verse_69_in_word_bestaten == false)
            {
                if (MushafTotalCountPerVerseDifference[Siin].TryGetValue(GetDifferencesKeyForRK(Verse.Id), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Siin].TryGetValue(GetDifferencesKeyForTanzil(Verse.Id), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return new div { text = "+" + (count - countAccordingToTanzil) };
                        }

                        return new div { text = "-" + (countAccordingToTanzil - count) };
                    }
                }
            }
        }

        if (arabicLetterOrder == Nun)
        {
            if (MushafOption.Chapter_68_Should_Single_Nun == false)
            {
                if (MushafTotalCountPerVerseDifference[Nun].TryGetValue(GetDifferencesKeyForRK(Verse.Id), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Nun].TryGetValue(GetDifferencesKeyForTanzil(Verse.Id), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return new div { text = "+" + (count - countAccordingToTanzil) };
                        }

                        return new div { text = "-" + (countAccordingToTanzil - count) };
                    }
                }
            }
        }

        if (arabicLetterOrder == Waaw)
        {
            if (MushafOption.Chapter_68_Should_Single_Nun == false)
            {
                if (MushafTotalCountPerVerseDifference[Waaw].TryGetValue(GetDifferencesKeyForRK(Verse.Id), out var count))
                {
                    if (MushafTotalCountPerVerseDifference[Waaw].TryGetValue(GetDifferencesKeyForTanzil(Verse.Id), out var countAccordingToTanzil))
                    {
                        if (count > countAccordingToTanzil)
                        {
                            return new div { text = "+" + (count - countAccordingToTanzil) };
                        }

                        return new div { text = "-" + (countAccordingToTanzil - count) };
                    }
                }
            }

            if (!MushafOption.Enba_u_Should_Contains_one_waw)
            {
                // [enba'u] Tanzil.net counts extra waw char in these verses
                if (Verse.Id == "6:5")
                {
                    return new div { text = "-1" };
                }

                if (Verse.Id == "26:6")
                {
                    return new div { text = "-1" };
                }
            }

            if (!MushafOption._75_13_yunebbeu_Should_Contains_1_waw)
            {
                if (Verse.Id == "75:13")
                {
                    return new div { text = "-1" };
                }
            }
        }

        if (arabicLetterOrder == Yaa)
        {
            // Tanzil.net has a bug here. There mush be extra ye here according to utmaine mushaf
            if (!MushafOption.Ya_sahibeyi_Should_Contains_2_ya)
            {
                // [ ya sahibeyi ] - [يَا صَاحِبَيِ]
                if (Verse.Id == "12:39")
                {
                    return new div { text = "+1" };
                }

                if (Verse.Id == "12:41")
                {
                    return new div { text = "+1" };
                }
            }
        }

        return null;
    }
}