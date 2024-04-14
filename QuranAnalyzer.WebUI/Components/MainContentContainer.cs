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

            MarginLeftRight("5%"),
            MD(MarginLeftRight("10%")),
            LG(MarginLeftRight("15%"))
        };
    }
}