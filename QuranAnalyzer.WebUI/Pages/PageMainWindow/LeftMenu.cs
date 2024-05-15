namespace QuranAnalyzer.WebUI.Pages.PageMainWindow;

class LeftMenuButtonForMobile : ReactPureComponent
{
    public string Href { get; set; }
    public bool IsSelected { get; set; }
    public string Text { get; set; }

    protected override Element render()
    {
        var textColor = IsSelected ? "rgb(30 167 253)" : "rgb(77 65 79)";
        return new a(Href(Href))
        {
            DisplayFlex, FlexDirectionRow, JustifyContentCenter, Gap(10), Padding(10),
            ComponentBorder,
            BorderRadiusForPanels,
            TextDecorationNone,
            Background("linear-gradient(180deg, white 0%, #eff2f7 100%)"),
            Text(Text),
            Color(textColor)
        };
    }
}

class LeftMenu : ReactPureComponent
{
    static readonly List<(string text, IReadOnlyList<string> pageIdList)> MenuItems = new()
    {
        ("Anasayfa", new[] { PageId.MainWindow }),
        ("Teknolojide Veri İletimi", new[] { PageId.SecuringDataWithCurrentTechnology }),
        ("Ön Bilgiler", new[] { PageId.PreInformation }),
        ("Tanım", new[] { PageId.SimpleDefinition }),
        ("Başlangıç Harfleri", new[] { PageId.InitialLetters }),
        ("Soru - Cevap", new[]
        {
            PageId.QuestionAnswer,
            PageId.AlternativeSystems,
            PageId.WhoIsRashadKhalifaPage,
            PageId.AboutEdipYuksel,
            PageId.WhyFamousPeopleAreSilent,
            PageId.AdditionalVerses,
            PageId.WhereIsTheProblem,
            PageId.CountOfAllah,
            PageId.IsHeMessenger,
            PageId.IsThereAnyCommunity
        }),
        ("İletişim", new[] { PageId.Contact }),
        ("Harf Sayım Programı", new[] { PageId.CharacterCounting }),
        ("Kelime Sayım Programı", new[] { PageId.WordSearching })
    };

    public string SelectedPageId { get; set; }

    int? SelectedIndex => MenuItems.FindIndex(x => x.pageIdList.Contains(SelectedPageId));

    protected override Element render()
    {
        if (SelectedPageId == PageId.MobileMenu)
        {
            SelectedPageId = Query[QueryKey.SenderPage] ?? SelectedPageId;
        }

        return new Fragment
        {
            // wide screen menu
            new FlexColumn(Gap(40), WhenMediaSizeLessThan(MD,DisplayNone))
            {
                MenuItems.Select((_, i) => createText(i, i == SelectedIndex))
            },

            // small screen
            new FlexColumn(Height100vh, JustifyContentSpaceEvenly, MD(DisplayNone))
            {
                MenuItems.Select((_, i) => createTextForMobile(i, i == SelectedIndex))
            }
        };

        static Element createTextForMobile(int index, bool isSelected)
        {
            var text = MenuItems[index].text;

            return new LeftMenuButtonForMobile
            {
                Text       = text,
                Href       = GetPageLink(MenuItems[index].pageIdList[0]),
                IsSelected = isSelected
            };
        }

        static Element createText(int index, bool isSelected)
        {
            var text = MenuItems[index].text;

            var textColor = isSelected ? "rgb(30 167 253)" : "rgb(173 164 164)";

            return new a(Href(GetPageLink(MenuItems[index].pageIdList[0])))
            {
                DisplayFlex, FlexDirectionRow, AlignItemsCenter, Gap(10),
                PositionRelative,
                TextDecorationNone,

                // C i r c l e
                new div
                {
                    Size(8),
                    Background(isSelected ? "rgb(30 167 253)" : "rgb(221 221 221)"),
                    BorderRadius("1em"),
                    Zindex(1)
                },

                // T e x t
                new FlexRowCentered
                {
                    Text(text),
                    Color(textColor),
                    When(!isSelected, Hover(Color("rgb(51 51 51)")))
                },

                // V e r t i c l e   L i n e
                new div
                {
                    PositionAbsolute,
                    MarginTop(-55),
                    Height(60),
                    Left(3.5),
                    When(index > 0, BorderLeft("1px solid rgb(238, 238, 238)"))
                }
            };
        }
    }
}