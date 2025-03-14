using static QuranAnalyzer.WebUI.PageId;

namespace QuranAnalyzer.WebUI.Pages.PageCharacterCounting;

sealed class MushafOptionsView : ReactComponent<MushafOption>
{
    public required MushafOption Model { get; init; }

    [CustomEvent]
    public Func<MushafOption, Task> MushafOptionChanged { get; init; }

    protected override Task constructor()
    {
        state = Model;

        return Task.CompletedTask;
    }

    protected override Element render()
    {
        return new FlexColumn(JustifyContentCenter, Gap(20))
        {
            new SwitchWithLabel
            {
                Label         = "Elif sayımları için Tanzil.net'i referans al",
                LabelMaxWidth = 250,
                Value         = state.UseElifReferencesFromTanzil,
                ValueChange = changeEvent =>
                {
                    state.UseElifReferencesFromTanzil = Convert.ToBoolean(changeEvent.target.value);
                    FireMushafOptionChanged();

                    return Task.CompletedTask;
                }
            },

            new SwitchWithLabel
            {
                Label         = "7:69 ve 2:245 daki bestaten ve yebsutu kelimelerindeki sad-sin yazım farklılığında Sad harfini tercih et",
                LabelMaxWidth = 250,
                Value         = state.Use_Sad_in_Surah_7_Verse_69_in_word_bestaten,
                ValueChange = changeEvent =>
                {
                    state.Use_Sad_in_Surah_7_Verse_69_in_word_bestaten = Convert.ToBoolean(changeEvent.target.value);
                    FireMushafOptionChanged();

                    return Task.CompletedTask;
                }
            },

            new SwitchWithLabel
            {
                Label         = "68:1 tek nun olarak say",
                LabelMaxWidth = 250,
                Value         = state.Chapter_68_Should_Single_Nun,
                ValueChange = changeEvent =>
                {
                    state.Chapter_68_Should_Single_Nun = Convert.ToBoolean(changeEvent.target.value);
                    FireMushafOptionChanged();
                    return Task.CompletedTask;
                }
            },

            new SwitchWithLabel
            {
                Label         = "11:70 ve 30:21 surelerdeki Lam harf farklılığında Tanzil.neti tercih et",
                LabelMaxWidth = 250,
                Value         = state.Use_Laam_SpecifiedByTanzil,
                ValueChange = changeEvent =>
                {
                    state.Use_Laam_SpecifiedByTanzil = Convert.ToBoolean(changeEvent.target.value);
                    FireMushafOptionChanged();
                    return Task.CompletedTask;
                }
            },

            new SwitchWithLabel
            {
                Label         = "6:5 ve 26:6 surelerdeki [enba'u] kelimesindeki Vav harf farklılığında Tanzil.neti tercih et",
                LabelMaxWidth = 250,
                Value         = state.Enba_u_Should_Contains_one_waw,
                ValueChange = changeEvent =>
                {
                    state.Enba_u_Should_Contains_one_waw = Convert.ToBoolean(changeEvent.target.value);
                    FireMushafOptionChanged();
                    return Task.CompletedTask;
                }
            },

            new SwitchWithLabel
            {
                Label         = "75:13 nolu ayetteki [yunebbeu](يُنَبَّؤُ) kelimesindeki 'vav' harf farklılığında vav harfi olan versiyonu seç.",
                LabelMaxWidth = 250,
                Value         = state._75_13_yunebbeu_Should_Contains_1_waw,
                ValueChange = changeEvent =>
                {
                    state._75_13_yunebbeu_Should_Contains_1_waw = Convert.ToBoolean(changeEvent.target.value);
                    FireMushafOptionChanged();
                    return Task.CompletedTask;
                }
            },

            new a { Text("Mushaf ayarları hakkında detaylı bilgi"), Href(GetPageLink(MushafOptionsDetail)), MarginTop(10) }
        };
    }

    void FireMushafOptionChanged()
    {
        DispatchEvent(MushafOptionChanged, [state]);
    }
}