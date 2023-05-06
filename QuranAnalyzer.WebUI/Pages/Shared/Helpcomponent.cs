namespace QuranAnalyzer.WebUI.Pages.Shared;

class HelpComponent : ReactComponent
{
    public bool ShowHelpMessageForLetterSearch { get; set; }

    protected override Element render()
    {
        return new CollapsiblePanel
        {
            Title = "Örnek arama komutları",
            children =
            {
                new HelpComponentDetail { ShowHelpMessageForLetterSearch = ShowHelpMessageForLetterSearch },
            }
        };
    }
}

[ReactHigherOrderComponent]
class CollapsiblePanel : ReactComponent
{
    public string Title { get; set; }
    
    protected override Element render()
    {
        var key = Key("content");
        
        return new CollapseContainer
        {
            ContentOnOpened = new Fragment(key)
            {
                new FlexRow(AlignItemsCenter, PaddingBottom(10))
                {
                    new span { Title,CursorDefault },
                    new ArrowUpDownIcon { IsArrowUp = true }
                },
                new FlexColumn(JustifyContentSpaceEvenly, PaddingLeft(10))
                {
                    AnimateHeightAndOpacity(true),
                    Children(children)
                }
            },
            ContentOnClosed = new Fragment(key)
            {
                new FlexRow(AlignItemsCenter, PaddingBottom(10))
                {
                    new span { Title,CursorDefault },
                    new ArrowUpDownIcon { IsArrowUp = false }
                },
                new FlexColumn(JustifyContentSpaceEvenly, PaddingLeft(10))
                {
                    AnimateHeightAndOpacity(false),
                    Children(children)
                }
            }
        };
    }
}

class CollapseContainer : ThirdPartyReactComponent
{
    [ReactProp]
    public Element ContentOnOpened { get; set; }

    [ReactProp]
    public Element ContentOnClosed { get; set; }
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
                return ArabicLetter.Qaaf;
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