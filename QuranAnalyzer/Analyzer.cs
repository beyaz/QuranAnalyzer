﻿namespace QuranAnalyzer;

public static class Analyzer
{
    public const string Hamza = "ء";
    public const string HamzaAbove = "ٔ";

    static readonly AlternativeForm[] AlternativeForms =
    {
        new() { ArabicLetterIndex = ArabicLetterIndex.Alif, Forms = new[] { "ٱ", "إ", "أ", "ﺍ" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Zay, Forms  = new[] { "ز" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Jiim, Forms = new[] { "ج" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Haa_, Forms = new[] { "ة" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Yaa, Forms  = new[] { "ى", "ئ" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Waaw, Forms = new[] { "ٯ", "ؤ" } }
    };

    static readonly AlternativeForm[] AlternativeFormsWithHamza =
    {
        new() { ArabicLetterIndex = ArabicLetterIndex.Alif, Forms = new[] { "ٱ", "إ", "أ", "ﺍ", Hamza, HamzaAbove } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Zay, Forms  = new[] { "ز" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Jiim, Forms = new[] { "ج" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Haa_, Forms = new[] { "ة" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Yaa, Forms  = new[] { "ى", "ئ" } },
        new() { ArabicLetterIndex = ArabicLetterIndex.Waaw, Forms = new[] { "ٯ", "ؤ" } }
    };

    public static IReadOnlyList<LetterInfo> AnalyzeText(string line, bool isHemzeActive = true)
    {
        var items = new List<LetterInfo>();

        var cursor = 0;

        while (cursor < line.Length)
        {
            var item = TryRead(line, cursor, isHemzeActive);
            if (item != null)
            {
                items.Add(item);
                // cursor += ArabicLetter.AllArabicLetters[item.ArabicLetterIndex].Length;
                cursor += item.MatchedLetter.Length;
                continue;
            }

            items.Add(new LetterInfo { ArabicLetterIndex = -1, StartIndex = cursor, MatchedLetter = line[cursor].ToString() });

            cursor++;
        }

        return items;
    }

    public static bool HasValueAndSameAs(this LetterInfo a, LetterInfo b)
    {
        if (a is null || b is null)
        {
            return false;
        }

        if (a.ArabicLetterIndex >= 0 && a.ArabicLetterIndex == b.ArabicLetterIndex)
        {
            return true;
        }

        return false;
    }

    public static bool IsArabicLetter(LetterInfo info)
    {
        return info.ArabicLetterIndex >= 0;
    }

    static LetterInfo TryMatch(string line, int startIndex, string searchLetter, int arabicLetterIndex)
    {
        if (startIndex + searchLetter.Length > line.Length)
        {
            return null;
        }

        var value = line.Substring(startIndex, searchLetter.Length);

        var isMatch = value == searchLetter;
        if (isMatch)
        {
            return new LetterInfo
            {
                ArabicLetterIndex = arabicLetterIndex,
                MatchedLetter     = value,
                StartIndex        = startIndex
            };
        }

        return null;
    }

    static LetterInfo TryRead(string line, int startIndex, bool isHemzeActive)
    {
        var alternativeForms = getAlternativeForms(isHemzeActive);

        for (var arabicLetterIndex = 0; arabicLetterIndex < ArabicLetter.AllArabicLetters.Length; arabicLetterIndex++)
        {
            foreach (var alternativeForm in alternativeForms)
            {
                if (alternativeForm.ArabicLetterIndex == arabicLetterIndex)
                {
                    foreach (var form in alternativeForm.Forms)
                    {
                        var matchInfo = tryMatch(form, arabicLetterIndex);
                        if (matchInfo != null)
                        {
                            return matchInfo;
                        }
                    }
                }
            }

            // normal match
            {
                var matchInfo = tryMatch(ArabicLetter.AllArabicLetters[arabicLetterIndex], arabicLetterIndex);
                if (matchInfo != null)
                {
                    return matchInfo;
                }
            }
        }

        return null;

        LetterInfo tryMatch(string searchCharacter, int arabicCharacterIndex) => TryMatch(line, startIndex, searchCharacter, arabicCharacterIndex);
        static AlternativeForm[] getAlternativeForms(bool isHemzeActive) => isHemzeActive ? AlternativeFormsWithHamza : AlternativeForms;
    }

    class AlternativeForm
    {
        public int ArabicLetterIndex { get; init; }
        public string[] Forms { get; init; }
    }
}