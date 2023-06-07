namespace QuranAnalyzer.WebUI.Pages;

public class PageContact : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("İletişim"),

            new p
            {
                "İsmim ", (b)"Abdullah Beyaztaş"
            },
            new p
            {
                (b)"Yazılım", ", ", (b)"Felsefe", " ve ", (b)"Kuran",
                " olmak üzere bu üç konu üzerine ",
                "öğrenmeyi, düşünmeyi seviyorum. ",
                "Vaktim olduğu sürece bu üç konu üzerine istediğiniz kadar fikir alışverişine açığım. ",
                "Aşağıdaki mail adresinden bana ulaşabilirsiniz",
                br,
                br,
                new Link
                {
                    href = "mailto:beyaz1404@gmail.com",
                    text = "gmail",
                    imageSrc = "https://upload.wikimedia.org/wikipedia/commons/archive/7/7e/20221017173629%21Gmail_icon_%282020%29.svg"
                },
                
                br,
                new Link
                {
                    href     = "https://twitter.com/Abdullah__Beyaz",
                    text     = "twitter",
                    imageSrc = "https://upload.wikimedia.org/wikipedia/commons/6/6f/Logo_of_Twitter.svg"
                }
            },
            new span(DisplayFlexRowCentered)
            {
                "* * *"
            },
            new p
            {
                "Bu sitede kullanılan tüm kaynak kodları aşağıda belirttiğim linkten inceleyebilirsiniz. ",
                "Eğer programlama biliyorsanız bu kodları kullanarak kendi analizlerinizi yapabilirsiniz.",
                br,
                br,

                new Link
                {
                    href     = "https://github.com/beyaz/QuranAnalyzer",
                    text     = "QuranAnalyzer",
                    imageSrc = "https://upload.wikimedia.org/wikipedia/commons/9/91/Octicons-mark-github.svg"
                }
            },
            new span(DisplayFlexRowCentered)
            {
                "* * *"
            },
            new p
            {
                "Gördüğüm resmi mümkün olduğunca kendi düşüncelerim minimum olacak şekilde aktarmaya çalıştım. ",
                "Umarım bu konular üzerine düşünen araştıran insanlara bir nebze de olsa faydalı bir çalışma olmuştur."
            }
        };

        
    }

    class Link : ReactPureComponent
    {
        public string href, text, imageSrc;
        
        protected override Element render()
        {
            return new a(DisplayFlexRowCentered, Aria("label", text))
            {
                new img(WidthHeight(26), PaddingRight(5))
                {
                    Src(imageSrc),
                    Title(text)
                },
                Href(href),
                text
            };
        }
    }
}