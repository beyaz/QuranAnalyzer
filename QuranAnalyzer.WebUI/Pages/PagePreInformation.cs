﻿namespace QuranAnalyzer.WebUI.Pages;

public class PagePreInformation : ReactPureComponent
{
    static string PageUrlOfAdem => GetPageLink(PageId.WordSearching) +
                                   "&" + QueryKey.SearchQuery + "=" + "*~اادم;*~يادم;*~لٔادم;*~ويادم" +
                                   "&" + QueryKey.SearchOption + "=" + WordSearchOption.Same;

    static string PageUrlOfDays30 => GetPageLink(PageId.WordSearching) +
                                     "&" + QueryKey.SearchQuery + "=" + "*~ايام;*~يومين;*~الايام;*~اياما;*~واياما;*~بايىم" +
                                     "&" + QueryKey.SearchOption + "=" + WordSearchOption.Same;

    static string PageUrlOfDays365 => GetPageLink(PageId.WordSearching) +
                                      "&" + QueryKey.SearchQuery + "=" + "*~يوم;*~ويوم;*~اليوم;*~واليوم;*~يوما;*~ليوم;*~فاليوم;*~بيوم;*~باليوم;*~وباليوم" +
                                      "&" + QueryKey.SearchOption + "=" + WordSearchOption.Same;

    static string PageUrlOfIsa => GetPageLink(PageId.WordSearching) +
                                  "&" + QueryKey.SearchQuery + "=" + "*~عيسي;*~وعيسي;*~يعيسي;*~بعيسي" +
                                  "&" + QueryKey.SearchOption + "=" + WordSearchOption.Same;

    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Kuran Hakkında Bazı Bilgiler"),

            (p)"Bu bölümde Kuran hakkında dikkat çeken bazı bilgiler verilecektir.",

            new ul
            {
                new li
                {
                    (p)"Kuran toplamda 114 tane sure adı verilen bölümden oluşur. Mesela 1. sure Fatiha suresidir."
                },

                new li
                {
                    (p)"Her bölümün(surenin) başında besmele vardır. Sadece 9. surenin başında besmele yoktur."
                },

                new li { (p)"Sureler vahyedilirken karışık sırada geliyor. Mesela  bazen 2. surenin bir kısmı geliyor sonra başka bir surenin başka bir kısmı geliyor. " },

                new li
                {
                    (p)@"Genel kabule göre Kuranın kitaplaşması halife Ebubekir, çoğaltılması ise halife Osman zamanında yapılıyor. 
Rivayetlere göre halife Osman zamanında, o zamanki insanların kendi kuran notları, sakladıkları kuran parçaları başka karmaşaya sebep olmasın diye Ebubekir zamanındaki orijinal mushaf dahil yakılmıştır."
                },

                new li
                {
                    (p)@"Kuran farklı mushaflar üzerinden bugüne gelmiştir. 
Yani klasik herkesin öyle tahmin ettiği gibi yeryüzündeki bütün kuranlar harfi harfine aynı değildir. 
İran'dan ve Türkiye'den ve Afrika'dan Kuran mushaflarını önünüze açtığınızda elif harflerinde farklılıklar göreceksiniz. 
İsterseniz farklı mushafları aşağıdaki linkten inceleyebilirsiniz.",
                    new a { href = "https://www.quranflash.com/home?en", text = "Kuran mushafları" }
                },

                new li
                {
                    (p)"Kurandaki bazı kelimeler ilginç bir şekilde farklı yazılmıştır. Bir kaç örnek aşağıda verilmiştir.",

                    "Mekke şehri Kuranda bir cümlede Bekke diye ifade edilir.",
                    br,
                    "Nuh'un yaşı için bin yıldan elli eksik ibaresi kullanılır.",
                    br,
                    "Ashabı-Kehf in mağarada kaldıkları süre için üç yüz yıl ilave dokuz yıl ibaresi kullanılır."
                },

                new li
                {
                    (p)@"Kuranda bazı bölümlerin başında harfler vardır. En çok bilinen Yasin suresinin başında Ya(ي) ve Sin(س) harfleri vardır.
Bazı bölümlerin başında bir tane harf olurken mesela 50. surenin başındaki Kaf(ق) harfi gibi. Bazı bölümlerde sure başında iki tane harf vardır. 
Mesela 40. ve 46. arası 7 tane surenin başlarında sadece Ha(ح) ve Mim(م) olmak üzere iki harf vardır.",

                    (p)@"En çok ise 19. surede beş tane başlangıç harfi vardır. Kaf(ق) - Ha(ه) - Ya(ي) - Ayn(ع) - Sad(ص). 
Toplamda 29 surenin başında böyle harfler vardır. Başlangıç harfleri-Kesik harfler-hurufu mukatta gibi isimlerle anılmaktadır.
Tarih boyu bu başlangıç harfleri ile ilgili bir çok farklı yorum yapılmıştır.
Yine bu harflerin geçtiği surelerin bir kısmında ilk cümleler şöyledir. Bunlar kitabın ayetleridir-kanıtlarıdır-işaretleridir."
                },

                new li
                {
                    (p)@"Kurandaki bazı kelimelerin geçişleri anlamları/olayları ile ilgili olarak çok ilginç sayıda geçmektedir. 
Mesela gün kelimesinin 365 defa geçmesi buna bir örnek olarak verilebilir.
Adem ve İsanın durumu aynıdır denmesi ve Adem / İsa kelimeleri 25'er defa geçmesi bunlara örnek olarak verilebilir. 
Dilerseniz aşağıdaki linklerden bu sayımları kendiniz yapabilirsiniz.",
                    new p { new a { href = PageUrlOfDays365, text = "Gün Sayısının 365 kez geçmesi" } },

                    new p { new a { href = PageUrlOfDays30, text = "Günler kelimesinin 30 defa geçmesi" } },

                    new p
                    {
                        new a
                        {
                            href = GetPageLink(PageId.WordSearching) +
                                   "&" + QueryKey.SearchQuery + "=" + "*~الدنيا" +
                                   "&" + QueryKey.SearchOption + "=" + WordSearchOption.Same,
                            text = "dünya"
                        },

                        " ve ",

                        new a
                        {
                            href = GetPageLink(PageId.WordSearching) +
                                   "&" + QueryKey.SearchQuery + "=" + "*~الاخرة;*~بالاخرة;*~والاخرة;*~وللاخرة;*~وبالاخرة;*~للاخرة" +
                                   "&" + QueryKey.SearchOption + "=" + WordSearchOption.Same,
                            text = "ahiret"
                        },
                        " kelimelerinin 115'er defa geçmesi"
                    },
                    new p
                    {
                        new a { href = PageUrlOfAdem, text = "Adem" }, " ve ",
                        new a { href = PageUrlOfIsa, text  = "İsa" }, "'nın yaratılması aynıdır ifadesinin kullanılması ve ikisinin de 25'er defa geçmesi"
                    }
                }
            }
        };
    }
}