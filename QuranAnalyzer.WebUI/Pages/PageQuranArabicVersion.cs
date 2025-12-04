namespace QuranAnalyzer.WebUI.Pages;

partial class PageQuranArabicVersion : ReactPureComponent
{
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
                        defaultValue = AllQuran,
                        readOnly = true,
                        style =
                        {
                            Width(60 * vw),
                            BorderNone,
                            Height("70vh"),
                            WhenMediaMaxWidth(MD,WidthFull),
                            FontFamily("Lateef"),
                            FontSize24
                            
                        }
                    }
                }
            }
        };
    }
}