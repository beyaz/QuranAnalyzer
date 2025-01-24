namespace QuranAnalyzer.WebUI.Pages.Shared;

class ArrowUpDownIcon : ReactPureComponent
{
    public bool IsArrowUp { get; init; }

    protected override Element render()
    {
        var rotationStyle = new style
        {
            """
            .transform_rotate_negative_180deg
            {
               transform: rotate(-180deg);
            }

            .transform_rotate_90deg
            {
               transform: rotate(0deg);
            }
            """
        };

        var arrowDown = new svg(svg.ViewBox(0, 0, 24, 24), svg.Size(24), Transition("all", 400))
        {
            new path { d = "M8.12 9.29 12 13.17l3.88-3.88c.39-.39 1.02-.39 1.41 0 .39.39.39 1.02 0 1.41l-4.59 4.59c-.39.39-1.02.39-1.41 0L6.7 10.7a.9959.9959 0 0 1 0-1.41c.39-.38 1.03-.39 1.42 0z" }
        };

        if (IsArrowUp)
        {
            return new Fragment
            {
                rotationStyle,
                arrowDown + ClassName("transform_rotate_negative_180deg")
            };
        }

        return new Fragment
        {
            rotationStyle,
            arrowDown + ClassName("transform_rotate_90deg")
        };
    }
}