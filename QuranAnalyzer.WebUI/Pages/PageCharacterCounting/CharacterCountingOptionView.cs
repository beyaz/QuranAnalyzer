﻿using QuranAnalyzer.WebUI.Pages.Shared;

namespace QuranAnalyzer.WebUI.Pages.PageCharacterCounting;

class CharacterCountingOptionView : ReactComponent
{
    public MushafOption MushafOption { get; set; } = new();

    [CustomEvent]
    public Func<MushafOption,Task> MushafOptionChanged { get; set; }

    protected override Element render()
    {
        var key = Key("content");

        return new FlexColumn(Gap(10))
        {
            new Accordion
            {
                arabicKeyBoard(false),
                arabicKeyBoard(true)
            },
            new HelpComponent { ShowHelpMessageForLetterSearch = true },
            new Accordion
            {
                mushafOption(false),
                mushafOption(true)
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

    Task OnMushafOptionChanged(MushafOption mushafOption)
    {
        MushafOption = mushafOption;
        DispatchEvent(MushafOptionChanged, [mushafOption]);
        
        return Task.CompletedTask;
    }
}