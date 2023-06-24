namespace QuranAnalyzer.WebUI.Pages.PageAllInitialLettersCombined;

class PageAllInitialLettersCombinedView : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Başlangıç harflerinin yan yana yazılması ile oluşan büyük sayılar"),

            new p
            {
                "Başlangıç harflerinin içinde bulunduğu sure ile ilişkili olduğunu 'Başlangıç Harfleri' sayfasında detaylı olarak incelenmişti.",
                br,
                "Peki bu geçiş adetlerini yan yana yazsak acaba önümüze nasıl bir rakam çıkar?"
            },

            separation,

            "Mesela Kaf harfi iki surede olmak üzere toplamda 114 defa geçer.",
            br,
            "Başlangıç harflerinin ait oldukları surelerdeki toplam geçiş adetlerini yan yana yazınca oluşan büyük rakam 19'un tam katıdır.",
            br,
            raisePanel(new TotalCounts()),

            br,
            "Yukarıdaki geçiş adetlerinden herhangi birini değiştirmeyi deneyebilirsiniz. Hesaplama gerçek zamanlı olarak çalışmaktadır.",
            separation,

            "2. olarak bu geçiş adetlerini daha detaylı olarak yazalım. ",
            "Mesela Mim harfi toplamda 17 surede olmak üzere 8659 defa geçer. ",
            "Bu 17 suredeki geçiş adetlerini de bu toplamın önüne ekleyelim ve oluşan sayıyı inceleyelim. ",
            "Aşağıda bulunan paneldeki hesapla düğmesine basarak bu işlemi hesaplayabilirsiniz.",
            raisePanel(new TotalCountsWithDetail()),
            br,
            "Yukarıdaki geçiş adetlerinden herhangi birini değiştirmeyi deneyebilirsiniz.",
            separation,

            "Son olarak olayı daha da zorlaştıralım. İlaveten sure numaraları da dahil edelim. ",
            "Mesela Mim harfi toplamda 17 surede olmak üzere 8659 defa geçer. ",
            "Bu 17 suredeki ", (strong)"sure no, o suredeki toplam geçiş adeti ", " şeklinde yan yana yazalım. Aşağıda bu işlemi hesaplayabilirsiniz.",
            raisePanel(new TotalCountsWithDetail { IncludeChapterNumbers = true }),
            br,
            "Yukarıdaki geçiş adetlerinden herhangi birini değiştirmeyi deneyebilirsiniz. Hesaplama gerçek zamanlı olarak çalışmaktadır.",
            separation,

            new SubTitle("Sonuç"),
            new p
            {
                "Elbette ki herhangi bir sayının 19'a bölünme ihtimali 19 da 1 dir. ",
                "Sayının ne kadar büyük olduğunun bir önemi yoktur.",
                br,
                "Burada insanı hayrete düşüren olayı bir örnek ile açıklayalım.",
                br,
                "Sadece ", AsLetter(ArabicLetter.Miim), " harfini ele alalım. Bu başlangıç harfi ile başlayan 17 surelerde toplamda 8659 adet geçer. ",

                "Eğer 46. suredeki ", AsLetter(ArabicLetter.Miim), " harfi bir fazla veya eksik olsaydı  hem bu yukarıda hesaplanan  büyük rakamlar 19'un katı olmazdı. ",
                "Hem 'Başlangıç Harfleri' kısmında gözlemlediğimiz Ha-Mim ile ilgili veriler olmazdı.",
                " Sadece bir yerden değil bir çok yerden kitlenen iç içe geçmeli bir yapı gibi düşünülebilir."
            },

            new p
            {
                "Kuranda özellikle ", (strong)"bu kitabın bir benzerinin oluşturulamayacağı", " vurgulanır. ",
                "19 sistemi keşfedilinceye kadar olay sadece edebi açıdan ele alınıyordu. Edebi mucize olarak ele alınıyordu. ",
                "Bu edebi açıdan mucize olduğu yorumu ise bazı insanları tam tatmin etmiyordu. Çünkü edebiyat görecelidir. ",
                "Kimine göre Necip Fazıl daha iyi şairdir kimine göre de Nazım Hikmet. ",
                "Ama matematik yoruma daha kapalıdır. 2 + 2 Bağcılarda da 4 eder Berlin'de de 4 eder. ",
                "Tüm denizlerdeki kum tanelerinin adetini kesin olarak bilen bir yaratıcı Kuranın içine de böyle bir örüntüyü eklemiş. ",
                "Böylelikle Kuranın korunacağı ve Kuranın bir benzerinin getirilemeyeceği iddiaları 19 sistemi ile daha anlamlı hale gelmiş oluyor. "
            },

            new div { "Neden 19?", TextAlignCenter },
            br,
            "Elbette her şeyin sayısını bilen Allah istese bunu 19 değil 29 rakamı ile de yapabilirdi. Eğer bu örüntü 29 üzerine olsaydı neden 29 diye sorulacaktı. ",
            br,
            new ul
            {
                (li)"Kuranın kapağını açtığınızda karşınıza çıkan ilk çümle yani Besmele 19 harftir.",
                (li)"Kuranda toplam 114 (19x4) adet sure vardır.",
                (li)"İlk vahyedilen Alak suresi 19 ayettir.",
                (li)"Vahid(tek) kelimesinin sayısal karşılığı 19 dur.",
                (li)"Kuranda bahsi geçen tüm rakamların toplamı 19'un katıdır.",
                " Nuh'un yaşı ifade edilirken neden 1000 yıldan 50 eksik gibi bir ifade kullanıldığını sanırım şimdi daha iyi anlamışsınızdır.",
                (li)"Başlangıç harfli surelerde o harfler 19'un katı şeklinde geçer."
            },
            new p
            {
                "Hatta 74. surede bizzat 19 diye bir konudan bahsediliyor, imanlıların imanını artıracağını söylüyor.",
                " Artık 19 meselesini öğrendiğinize göre 74. sureyi bu gözle tekrar incelemenizi öneririm.",
                br,
                " Bunlara benzer daha bir çok örnek verilebilir. ",
                " Mühim olan buradaki tasarımı görebilmektir. ",
                " Böylelikle Allah var mı? yok mu? Kuran Allah kelamı mı değil mi? gibi şüpheler giderilmiş olacak.",
                " Kuran'ın Allah'tan geldiğine olan inancımızı sağlam bir zemine oturmuş olacağız. ",
                " Artık bir sonraki aşamaya yani Kuranı anlama ve hayatımıza uygulama aşamasına geçebiliriz."
            }
        };

        static Element separation()
        {
            return new FlexRowCentered(MarginTopBottom(10)) { "* * *" };
        }

        static Element raisePanel(Element element)
        {
            return new div
            {
                BoxShadow("rgb(0 0 0 / 34%) 0px 2px 5px 0px"), Padding(15), BorderRadiusForPanels, MarginTopBottom(10),
                element
            };
        }
    }
}