namespace QuranAnalyzer.WebUI.Pages.Shared;

class HelpComponent : ReactComponent<HelpComponent.State>
{
    public bool ShowHelpMessageForLetterSearch { get; init; }

    protected override Element render()
    {
        return new FlexColumn
        {
            new FlexRow(AlignItemsCenter, PaddingBottom(10), OnClick(Toggle))
            {
                new span { "Örnek arama komutları", CursorDefault },
                new ArrowUpDownIcon { IsArrowUp = state.IsExpanded }
            },
            new FlexColumn(JustifyContentSpaceEvenly, PaddingLeft(10))
            {
                AnimateHeightAndOpacity(state.IsExpanded),
                new HelpComponentDetail { ShowHelpMessageForLetterSearch = ShowHelpMessageForLetterSearch }
            }
        };
    }

    Task Toggle(MouseEvent e)
    {
        state = state with { IsExpanded = !state.IsExpanded };

        return Task.CompletedTask;
    }

    internal record State
    {
        public bool IsExpanded { get; init; }
    }
}

class HelpComponentDetail : ReactPureComponent
{
    public bool ShowHelpMessageForLetterSearch { get; set; }

    string DescriptionPart
    {
        get
        {
            if (ShowHelpMessageForLetterSearch)
            {
                return "harflerini";
            }

            return "kelimesini";
        }
    }

    string SearchItem
    {
        get
        {
            if (ShowHelpMessageForLetterSearch)
            {
                return ArabicLetter.Qaaf.ToString();
            }

            return "الله";
        }
    }

    protected override Element render()
    {
        return new table(TextAlignCenter)
        {
            new tbody
            {
                new tr
                {
                    new th { "Komut" } + FontWeight500, new th { "Açıklama" } + FontWeight500
                },
                new tr { Height(15) },
                new tr
                {
                    commandText($"* | {SearchItem}"),
                    description("(Tüm mushaf boyunca geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                },
                new tr { Height(10) },
                new tr
                {
                    commandText($"2:* | {SearchItem}"),
                    description("(2. surenin tamamında geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                },
                new tr { Height(10) },
                new tr
                {
                    commandText($"2:*, 3:*, 7:5-40 | {SearchItem}"),
                    description("(2. surenin tamamında, 3. surenin tamamında ve 7. surenin 5 ila 40. ayetler arasında geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                },
                new tr { Height(10) },
                new tr
                {
                    commandText($"2:*, -2:4, -2:8 | {SearchItem}"),
                    description("(2. surenin tamamında(4. ve 8. ayetler hariç), geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                },
                new tr { Height(10) },
                new tr
                {
                    commandText($"*, -9:128, -9:129 | {SearchItem}"),
                    description("(Tüm mushaf boyunca (9:128 ve 9:129 hariç), geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                },
                new tr { Height(10) },
                new tr
                {
                    commandText($"2:17 --> 5:4 | {SearchItem}"),
                    description("(2. surenin 17. ayeti ile 5. surenin 4. ayeti arasında geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                },
                new tr { Height(10) },
                new tr
                {
                    commandText($"2:17[4..] --> 5:4[..6] | {SearchItem}"),
                    description("(2. surenin 17. ayetinin 4. harfi ile 5. surenin 4. ayetinin 6. harfi arasında geçen ", (b)SearchItem, $" {DescriptionPart} aratır)")
                }
            }
        };

        static Element commandText(string text)
        {
            return new td { (b)text } + Width(200) + ComponentBorder + BorderRadiusForPanels;
        }

        static Element description(params Element[] children)
        {
            return new td { children } + Width(400);
        }
    }
}