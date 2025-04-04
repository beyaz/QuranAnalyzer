﻿namespace QuranAnalyzer.WebUI.Pages;

public class PageQuestionAnswer : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Soru - Cevap"),

            new p
            {
                @"Bu bölümde 19 meselesi etrafında dönen tartışmalı konuları ele aldım. 
Elimden geldiğince tartışılan konuları en kısa ve tarafsız bir şekilde özetlemeye çalıştım.",
                br,
                br,
                "Tekrar hatırlatmakta fayda görüyorum.",
                br,
                br,
                @"Aşağıdaki soruların cevaplarının doğru olup olmadığı siz okuyucuya bırakılmıştır. 
İmana dair bir meselenin üzerinde düşünülüp içselleştirilmedikten sonra bir faydasının olmayacağına inanıyorum.
Tarafların özetle ne söylediğini aktarayım sonrasında üzerine düşünmek-araştırmak ve bir karara varmak size kalan bir mesele.",
                br,
                """
                Hatta şüpheciliğimizi bir adım daha öteye taşıyalım. Her ne kadar tarafsız bir şekilde anlatmaya çalışsam da anlatan kişinin de yorumumu karışmış olabilir
                şüphesini elden bırakmayınız.
                """
            },
            br,
            new FlexColumn
            {
                new QuestionLink
                {
                    Question = "19 sistemini ilk keşfeden kişi (Reşad Halife) kimdir? Ne söylüyor?",
                    Url      = GetPageLink(PageId.WhoIsRashadKhalifaPage)
                },
                new QuestionLink
                {
                    Question = "Peki bu 19 sistemi hiç mi eleştiri almıyor? Kabul etmeyenler nereleri eleştiriyor?",
                    Url      = GetPageLink(PageId.WhereIsTheProblem)
                },
                new QuestionLink
                {
                    Question = "Madem bu 19 sayısı bu kadar ilginç veriler içeriyor, neden medyadaki hiç bir alimden/hocadan duymuyoruz?",
                    Url      = GetPageLink(PageId.WhyFamousPeopleAreSilent)
                },
                new QuestionLink
                {
                    Question = "19 sistemi nin olması için Kurandan iki ayet atılması gerekiyor mu ? Yoksa sistem çöküyormuş doğru mu ?",

                    Url = GetPageLink(PageId.AdditionalVerses)
                },

                new QuestionLink { Question = "Reşad Halife kendini peygamber ilan etmiş doğru mu ?", Url = GetPageLink(PageId.IsHeMessenger) },

                new QuestionLink
                {
                    Question = "19'cular diye bir cemaat / tarikat / topluluk mu var?", Url = GetPageLink(PageId.IsThereAnyCommunity)
                },

                new QuestionLink
                {
                    Question = "Alternatif 19 sistemleri", Url = GetPageLink(PageId.AlternativeSystems)
                },

                new QuestionLink
                {
                    Question = "Edip Yüksel", Url = GetPageLink(PageId.AboutEdipYuksel)
                }
            }
        };
    }

    class QuestionLink : ReactPureComponent
    {
        public string Question { get; init; }

        public string Url { get; init; }

        protected override Element render()
        {
            // https://support.google.com/youtube/answer/9872296?hl=en-GB&ref_topic=9257501
            const string d = "M19 5v14H5V5h14m0-2H5c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm-5 14H7v-2h7v2zm3-4H7v-2h10v2zm0-4H7V7h10v2z";

            return new FlexRow(AlignItemsCenter, Gap(10))
            {
                new FlexRowCentered(Size(24))
                {
                    new svg(svg.ViewBox(0, 0, 24, 24), Size(24))
                    {
                        new path
                        {
                            d    = d,
                            fill = "#6c93d0"
                        },
                        new path
                        {
                            d    = "M0 0h24v24H0z",
                            fill = "none"
                        }
                    }
                },
                new a
                {
                    href      = Url,
                    innerText = Question,
                    style =
                    {
                        PaddingTopBottom(10),
                        Color("#575757"),
                        Hover(Color("rgb(165 107 107)"), TextDecorationUnderline),
                        CursorPointer,
                        TextDecorationNone
                    }
                }
            };
        }
    }
}