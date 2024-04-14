namespace QuranAnalyzer.WebUI.Components;

class MainContentContainer : ReactPureComponent
{
    protected override Element render()
    {
        return new FlexRow
        {
            JustifyContentCenter,

            children,

            WidthFull,
            Height("100%"),

            WhenMediaSizeLessThan(MD,MarginLeftRight("5%")),
            MediaQueryOnTablet(MarginLeftRight("10%")),
            LG(MarginLeftRight("15%"))
        };
    }
}