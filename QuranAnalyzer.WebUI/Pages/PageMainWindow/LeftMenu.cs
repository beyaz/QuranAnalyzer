﻿namespace QuranAnalyzer.WebUI.Pages.PageMainWindow;

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
        ("Kelime Sayım Programı", new[] { PageId.WordSearching }),
    };

    public string SelectedPageId { get; set; }

    int? SelectedIndex => MenuItems.FindIndex(x => x.pageIdList.Contains(SelectedPageId));

    protected override Element render()
    {
        return new FlexColumn(Gap(40))
        {
            MenuItems.Select((_, i) => createText(i, i == SelectedIndex))
        };

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
                    wh(8),
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