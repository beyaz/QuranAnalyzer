﻿namespace QuranAnalyzer.WebUI.Pages;

public class PageAboutEdipYuksel : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Edip Yüksel hakkında"),

            new p
            {
                "Bu konuyu araştırırken bu isim çok çıktığı için özel bir yazı yazma gereğini duydum. ",

                "Bazı konuların Edip tarafından daha farklı ele alındığını gözlemledim."
            },
            new p
            {
                "Hayatını kısaca okuduğunuzu varsayıyorum. Hapis yatması, kardeşinin öldürülmesi, Amerika'ya gitmek zorunda kalması, Reşad Halife ile tanışması falan oldukça ilginç bir hayatı olmuş. ",
                "Gerçekten de cesaretine, azmine, zekasına hayran bırakıyor. ",
                "Sosyal medyada yediden yetmişe herkesle oturup konuşması vesaire gerçekten iyi.",
                br,
                br,
                "Edip'in eleştiriye maruz kaldığı noktalar ise şu şekilde;",
                separation,

                "Maalesef insanlar fikirler ile insanları özdeştiriyorlar ve insanın hatalarını veya fıtratlarını otomatikman fikirlere nispet ediyorlar.",
                " Edip de zaten kendini Sokrates misali insanları rahatsız eden bir ", (b)"at sineği", " olarak tanımlıyor.",
                " Haliyle kimine göre bu tavır itici olarak gelebiliyor ve Edip'in söylediği bazı sözlerin-fikirlerin de otomatikman kulak ardı edilmesine sebep oluyor.",

                " Yahut Edip'in yalnızca Kuran söyleminin yanlış anlaşılmasına sebep olabiliyor.",
                " Fikirler ile o fikirleri söyleyenlerin şahsi fikirleri bazen karıştırılır.",
                separation,

                "Sanki Edip, Reşad'ın bir numaralı talebesi imiş gibi, her yönü ile Reşad'ın fikirlerini aktaran biriymiş gibi anlaşılabiliyor.",
                " Halbuki iki ayrı insan iki ayrı fıtrat.",
                " Edip; Reşad'ın yanında 1-1.5 yıl kadar kalıyor.",
                separation,

                "Reşad Halife nin yaptığı ingilizce çeviriyi bir kenara koyup kendi çevirisini yapması garip gelebilir. ",
                separation,

                "Edip'in Reşad Halifenin ölümü ardından Reşad'ın tavsiyelerini uygulayanlara sizler Reşad'ı putlaştırıyorsunuz muamelesi var.",
                separation,
                "Namazın 3 vakit olduğu fikrini savunması, Atatürk ile 19 meselesi arasında bağ kurması gibi konular var.",
                separation,

                " Sonuç olarak Reşad'ın fikirlerini Edip Yüksel üzerinden anlamaya çalışmak yerine herkesi birinci ağızdan kendi sesiyle tanımanın daha doğru olduğunu düşünüyorum."
            }
        };

        static Element separation()
        {
            return new span(DisplayFlexRowCentered, MarginTopBottom(10)) { "* * *" };
        }
    }
}