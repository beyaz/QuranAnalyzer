namespace QuranAnalyzer.WebUI.Pages.PageMainWindow;

class FixedTopPanelContainerModel
{
    public bool IsMenuVisible { get; set; }
    public double MainDivScrollY { get; set; }
}

class FixedTopPanelContainer : ReactComponent<FixedTopPanelContainerModel>
{
    protected override void constructor()
    {
        state = new FixedTopPanelContainerModel();

        Client.OnMainContentDivScrollChangedOverZero(mainDivScrollY => state.MainDivScrollY = mainDivScrollY);
    }

    bool IsMenuVisible => Context.Query[QueryKey.Page] == PageId.MobileMenu;

    protected override Element render()
    {
        var top = new FlexColumn(JustifyContentCenter)
        {
            style =
            {
                PositionSticky,
                Top(0),
                WidthMaximized,
                Height(50),
                Zindex(2),
                BorderBottom("1px solid #dadce0"),
                Background("white")
            },
            children =
            {
                new nav(DisplayFlex, FlexDirectionRow, JustifyContentSpaceBetween, AlignItemsCenter)
                {
                    new SiteTitle() + MarginLeft(20),

                    new div(DisplayNone, MediaQueryOnMobile(new Style { DisplayBlock }), MarginRight(15))
                    {
                        HamburgerMenuLink
                    }
                }
            }
        };

        if (state.MainDivScrollY > 0)
        {
            top.style.borderBottom = "";
            top.style.boxShadow    = "0px 0px 8px rgb(0 0 0 / 20%)";
        }

        return top;
    }

    Element HamburgerMenuLink()
    {
        if (IsMenuVisible)
        {
            return new a { new MenuCloseIcon(), Href("#"), OnClick(_ => Client.HistoryGo(-2)) };
        }

        return new a { new SvgHamburgerIcon(), Href(GetPageLink(PageId.MobileMenu)) };
    }
}