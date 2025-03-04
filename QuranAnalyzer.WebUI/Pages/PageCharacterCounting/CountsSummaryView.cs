﻿namespace QuranAnalyzer.WebUI.Pages.PageCharacterCounting;

public class SummaryInfo
{
    public int Count { get; set; }
    public string Name { get; set; }
}

[Serializable]
class CountsSummaryView : ReactPureComponent
{
    static readonly int[] SpecialNumbers = [19, 1230, 505, 667, 109, 7, 238];

    public IReadOnlyList<SummaryInfo> Counts { get; set; } = new List<SummaryInfo>();

    protected override Element render()
    {
        var counts = Counts ?? new List<SummaryInfo>();

        var returnDiv = new fieldset
        {
            style =
            {
                marginTop    = "5px",
                border       = "2px solid rgb(218, 220, 224)",
                borderRadius = "4px",

                display       = "flex",
                flexDirection = "column",
                alignItems    = "flex-start"
            }
        };

        var total = counts.Select(x => x.Count).Sum();

        var specialNumber = TryFindSpecialNumber(total);
        if (specialNumber.HasValue)
        {
            returnDiv.children.Add(MultipleOf(total, specialNumber.Value));
        }
        else
        {
            returnDiv.children.Add(new legend(DisplayFlex, FlexDirectionRow, Gap(4))
            {
                new div { text = "Toplam:" },

                new strong { text = total.ToString(), id = "GrandTotal" }
            });
        }

        var countsView = new FlexRow(Gap(20))
        {
            style =
            {
                padding        = "5px",
                justifyContent = "space-between",
                fontSize       = "0.9rem",
                flexWrap       = "wrap",
                marginTop      = "20px"
            }
        };

        for (var j = 0; j < counts.Count; j++)
        {
            var name = counts[j].Name;

            countsView.children.Add(CountAsElement(name, LetterColorPalette.GetColor(j), GetPronunciation(name), counts[j].Count, "subTotal-" + j));

            returnDiv.children.Add(new Xarrow
            {
                start       = "GrandTotal",
                end         = "subTotal-" + j,
                path        = "smooth",
                color       = "rgb(218, 220, 224)",
                strokeWidth = 1,
                startAnchor = "bottom",
                dashness    = true,
                endAnchor   = "top"
            });
        }

        returnDiv.children.Add(countsView);

        return returnDiv;
    }

    static Element CountAsElement(string text, string color, string pronunciation, int count, string id)
    {
        return new FlexRow(AlignItemsCenter)
        {
            new FlexColumn(AlignItemsCenter)
            {
                new div { text, Color(color), FontSize30 },
                pronunciation is null ? null : new div { Text(pronunciation), FontSize12, FontWeight700 }
            },

            new div { ":", MarginLeftRight(4) },

            new div { text = count.ToString(), id = id }
        };
    }

    static Element MultipleOf(int total, int specialNumber)
    {
        var parsedVersion = new List<Element>
        {
            new div{specialNumber.ToString()},
            (small)"x"
        };

        if (total / specialNumber % 19 == 0)
        {
            parsedVersion.Add((small)"19");
            parsedVersion.Add((small)"x");
            parsedVersion.Add((small)(total / specialNumber / 19).ToString());
        }
        else
        {
            parsedVersion.Add((small)(total / specialNumber).ToString());
        }

        return new legend(DisplayFlex, FlexDirectionRow, Id("GrandTotal"))
        {
            new div { innerHTML = $"Toplam: <strong>{total}</strong> (" },
            new FlexRow(MarginLeftRight(5), AlignItemsCenter, Color("red"), Gap(3))
            {
                parsedVersion
            },
            new div { innerText = ")" }
        };
    }

    static int? TryFindSpecialNumber(int value)
    {
        if (value == 0)
        {
            return null;
        }

        foreach (var specialNumber in SpecialNumbers)
        {
            if (value % specialNumber == 0)
            {
                return specialNumber;
            }
        }

        return null;
    }

    string GetPronunciation(string name)
    {
        if (name == null)
        {
            return null;
        }

        if (name.Length == 1)
        {
            var pronunciation = GetPronunciationOfArabicLetter(name[0]);
            if (pronunciation is not null && pronunciation != name)
            {
                return  "(" + pronunciation + ")";
            }
        }
        
        return GetPronunciationOfArabicWord(name)?.trMean;
    }
}