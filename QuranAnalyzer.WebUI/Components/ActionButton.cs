namespace QuranAnalyzer.WebUI.Components;

public class ActionButton : ReactComponent
{
    public bool IsProcessing { get; set; }

    public string Label { get; set; }

    [ReactCustomEvent]
    public Func<Task> OnClick { get; set; }

    protected override Element render()
    {
        return new FlexRowCentered
        {
            children =
            {
                IsProcessing ? new LoadingIcon { wh(17) } : null,
                ! IsProcessing ? new div(Label) : null
            },
            onClick = ActionButtonOnClick,
            style =
            {
                Color(BluePrimary),
                Border($"1px solid {BluePrimary}"),
                Background("transparent"),
                BorderRadiusForPanels,
                Padding(10, 30),
                CursorPointer
            }
        };
    }

    Task ActionButtonOnClick(MouseEvent _)
    {
        IsProcessing = true;

        DispatchEvent(OnClick);
        
        return Task.CompletedTask;
    }
}