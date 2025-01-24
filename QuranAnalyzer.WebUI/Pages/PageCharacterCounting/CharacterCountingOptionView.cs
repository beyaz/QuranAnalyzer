using QuranAnalyzer.WebUI.Pages.Shared;

namespace QuranAnalyzer.WebUI.Pages.PageCharacterCounting;

class CharacterCountingOptionView : ReactComponent<CharacterCountingOptionView.State>
{
    public MushafOption MushafOption { get; init; }

    [CustomEvent]
    public Func<MushafOption, Task> MushafOptionChanged { get; set; }

    protected override Task constructor()
    {
        state = new()
        {
            MushafOption = MushafOption ?? new()
        };

        return Task.CompletedTask;
    }

    protected override Element render()
    {
        var key = Key("content");

        return new FlexColumn(Gap(10))
        {
            () =>
            {
                var isOpen = false;

                return FC(_ =>
                {
                    return new Fragment
                    {
                        new FlexRow(JustifyContentFlexStart, OnClick(Toggle))
                        {
                            new div { "Arapça Klavye", CursorDefault },
                            new ArrowUpDownIcon { IsArrowUp = isOpen }
                        },
                        new FlexColumn(JustifyContentSpaceEvenly, PaddingLeft(10))
                        {
                            AnimateHeightAndOpacity(isOpen),
                            new ArabicKeyboard()
                        }
                    };

                    Task Toggle(MouseEvent _)
                    {
                        isOpen = !isOpen;
                        return Task.CompletedTask;
                    }
                });
            },
            new HelpComponent { ShowHelpMessageForLetterSearch = true },
            new Fragment(key)
            {
                new FlexRow(JustifyContentFlexStart, OnClick(_ =>
                {
                    state = state with
                    {
                        IsMushafOptionOpen = !state.IsMushafOptionOpen
                    };
                    return Task.CompletedTask;
                }))
                {
                    new div { "Mushaf Ayarları", CursorDefault },
                    new ArrowUpDownIcon { IsArrowUp = state.IsMushafOptionOpen }
                },
                new FlexColumn(JustifyContentSpaceEvenly, PaddingLeft(10))
                {
                    AnimateHeightAndOpacity(state.IsMushafOptionOpen),
                    new MushafOptionsView { Model = MushafOption, MushafOptionChanged = OnMushafOptionChanged }
                }
            }
        };
    }

    Task OnMushafOptionChanged(MushafOption mushafOption)
    {
        state = state with
        {
            MushafOption = mushafOption
        };

        DispatchEvent(MushafOptionChanged, [mushafOption]);

        return Task.CompletedTask;
    }

    internal record State
    {
        public bool IsMushafOptionOpen { get; init; }
        public MushafOption MushafOption { get; init; }
    }
}