namespace QuranAnalyzer.WebUI.Pages.PageMainWindow;

class MainPageContent : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Bu sitede ne var?"),

            new p
            {
                "Yasin suresi, Taha suresi, Kaf suresi gibi sure isimlerini muhtemelen daha önce duymuşsunuzdur.",
                " Kuranda bazı surelerin başında ya-sin gibi, ta-ha gibi  harfler var. Elbette bu başlangıç harfleri hakkında bir çok yorum var.",
                " Bu konu ile ilgili olarak bir kaç yıl önce Kuran hakkında 19 Sistemi - 19 Mucizesi benzeri isimlerle duyduğum bir konu üzerine vakit buldukça araştırma yapma fırsatım oldu."
            },
            new p
            {
                "Elimden geldiğince aklımın yettiği ölçüde nedir ne değildir incelemeye çalıştım.",
                " Bu konu etrafında doğru yanlış bir çok şey duydum ve okudum.",
                " Konuyu incelemek ve konu etrafında dönen doğru yanlış şeylere kendimce verdiğim cevapları ve yazdığım programları paylaşmak istedim.",
                " Böylelikle konuyu araştıran kişiler için tarafsız bir gözlem sunmak niyetindeyim.",
            },
            (p)"Bu siteyi hazırlarken aşağıdaki konulara özellikle dikkat ettim;",

            new ul
            {
                new li
                {
                    new p
                    {
                        "Özellikle Kuran'dan bir ayetin Türkçe mealini paylaşmadım. ",
                        "Çünkü insanlar genelde önce kendi fikirlerini peşinen doğru kabul ediyorlar ardından Kuran ayetlerine de o bakış açısı ile mana veriyorlar. ",
                        "Farkında olmadan Kuranı kendi fikirlerine uyduruyorlar.",
                        " Yahut çevirilerde moderniteye uymak için kelimelerin ikinci üçüncü anlamları tercih edilebiliyor."
                    }
                },

                new li
                {
                    new p
                    {
                        "Düşünebilen her insanın bir beyni olduğuna inanıyorum. ",
                        "Bu sebeple doğru şudur veya şu yanlıştır gibi ifadelerden uzak durmaya çalıştım. ",
                        "Konu etrafında dönen zıt fikirleri elimden geldiğince tarafsız bir biçimde aktarmaya çalıştım. ",
                        "Karar verme yorum yapma işini ise elimden geldiğince okuyucuya bırakmaya çalıştım.",
                    }
                },

                new li
                {
                    new p
                    {
                        "Bu sitede bazı matematiksel veriler bulunmaktadır. Hesaplama araçları bulunmaktadır. ",
                        "Bu veriler gerçek zamanlı olarak çalışmaktadır. Giriş değerlerini değiştirdiğinizde sonuçlar da otomatik olarak değişecektir."
                    }
                },

                new li
                {
                    new p
                    {
                        "Hesaplamasını yapıp göstermediğim herhangi bir veriyi paylaşmadım."
                    }
                }
            },

            (p)"Lütfen konunun anlaşılması için menüyü sırası ile takip ediniz."
        };
    }
}