namespace QuranAnalyzer.WebUI.Pages.Shared;

class ArrowUpDownIcon : ReactPureComponent
{
    public bool IsArrowUp { get; init; }

    protected override Element render()
    {
        var arrowDown = new svg(svg.ViewBox(0, 0, 24, 24), svg.Size(24))
        {
            new path { d = "M8.12 9.29 12 13.17l3.88-3.88c.39-.39 1.02-.39 1.41 0 .39.39.39 1.02 0 1.41l-4.59 4.59c-.39.39-1.02.39-1.41 0L6.7 10.7a.9959.9959 0 0 1 0-1.41c.39-.38 1.03-.39 1.42 0z" }
        };

        return arrowDown + Transition("all", 400) + Transform(IsArrowUp ? "rotate(-180deg)" : "rotate(0deg)");
    }
}