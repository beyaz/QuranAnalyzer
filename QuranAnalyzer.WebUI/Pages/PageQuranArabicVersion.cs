namespace QuranAnalyzer.WebUI.Pages;

abstract class PageQuranArabicVersionBase : ReactPureComponent
{
    protected abstract string GetQuranText();

    protected override Element render()
    {
        return new div(Background(Theme.PanelBackgroundColor), HeightFull)
        {
            new FlexRow(DisplayFlex, JustifyContentCenter)
            {
                new MainContentContainer
                {
                    PaddingTopBottom(50),

                    new textarea
                    {
                        defaultValue = GetQuranText(),
                        readOnly     = true,
                        style =
                        {
                            Width(60 * vw),
                            BorderNone,
                            Height("70vh"),
                            WhenMediaMaxWidth(MD, WidthFull),
                            FontFamily("Lateef"),
                            FontSize24
                        }
                    }
                }
            }
        };
    }
}

[Route(Routes.PageQuranArabicVersion)]
sealed class PageQuranArabicVersion : PageQuranArabicVersionBase
{
    protected override string GetQuranText()
    {
        return QuranArabicVersionWithNoBismillah.AllQuranAsString;
    }
}

[Route(Routes.PageQuranArabicVersionWithBismillah)]
sealed class PageQuranArabicVersionWithBismillah : PageQuranArabicVersionBase
{
    static string QuranText => field ??= string.Join("\n", from x in QuranArabicVersionWithNoBismillah.AllQuranVersesWithBismillah select x.ToTextLine());

    protected override string GetQuranText()
    {
        return QuranText;
    }
}