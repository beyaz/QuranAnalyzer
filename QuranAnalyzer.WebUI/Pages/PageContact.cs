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
                new span(DisplayFlexRowCentered){ "beyaz1404@gmail.com" }
            },
            new span(DisplayFlexRowCentered)
            {
                "* * *"
            },
            new p
            {
                "Bu sitede kullanılan tüm kodları aşağıda belirttiğim linkten inceleyebilirsiniz. ",
                "Eğer programlama biliyorsanız bu kodları kullanarak kendi analizlerinizi yapabilirsiniz.",
                br,
                br,
                new a(DisplayFlexRowCentered) { href = "https://github.com/beyaz/QuranAnalyzer", text = "https://github.com/beyaz/QuranAnalyzer" }
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
}