using QuranAnalyzer.WebUI.Pages.Shared;

namespace QuranAnalyzer.WebUI.Pages.PageCharacterCounting;

class CharacterCountingOptionView : ReactComponent
{
    public MushafOption MushafOption { get; set; } = new();

    [ReactCustomEvent]
    public Action<MushafOption> MushafOptionChanged { get; set; }

    protected override Element render()
    {
        var key = Key("content");
        
        return new FlexColumn(Gap(10))
        {
            new CollapseContainer
            {
                ContentOnOpened = arabicKeyBoard(true),
                ContentOnClosed = arabicKeyBoard(false)
            },
            new HelpComponent { ShowHelpMessageForLetterSearch = true },
            new CollapseContainer
            {
                ContentOnOpened = mushafOption(isOpen: true),
                ContentOnClosed = mushafOption(isOpen: false)
            }
        };
        
        Element arabicKeyBoard(bool isOpen)
        {
            return new Fragment(key)
            {
                new FlexRow(JustifyContentFlexStart)
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
        }
        Element mushafOption(bool isOpen)
        {
            return new Fragment(key)
            {
                new FlexRow(JustifyContentFlexStart)
                {
                    new div { "Mushaf Ayarları", CursorDefault },
                    new ArrowUpDownIcon { IsArrowUp = isOpen }
                },
                new FlexColumn(JustifyContentSpaceEvenly, PaddingLeft(10))
                {
                    AnimateHeightAndOpacity(isOpen),
                    new MushafOptionsView { Model = MushafOption, MushafOptionChanged = OnMushafOptionChanged }
                }
            };
        }
    }

    void OnMushafOptionChanged(MushafOption mushafOption)
    {
        MushafOption = mushafOption;
        DispatchEvent(() => MushafOptionChanged, mushafOption);
    }
    
}