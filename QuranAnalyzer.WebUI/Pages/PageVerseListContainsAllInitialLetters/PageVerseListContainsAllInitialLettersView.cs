﻿using static QuranAnalyzer.ArabicLetter;

namespace QuranAnalyzer.WebUI.Pages.PageVerseListContainsAllInitialLetters;

class PageVerseListContainsAllInitialLettersView : ReactComponent
{
    public int? SelectedIndex { get; set; }

    protected override Element render()
    {
        static Element raisePanel(Element element)
        {
            return new div
            {
                BoxShadow("rgb(0 0 0 / 34%) 0px 2px 5px 0px"), Padding(15), BorderRadiusForPanels, MarginTopBottom(10),
                element
            };
        }

        return new Article
        {
            new LargeTitle("Bütün Başlangıç Harflerini İçeren Ayetler"),

            new p
            {
                "Toplamda 14 tane başlangıç harfi vardır. ",
                "Kur’an’ın 29 suresinin 30 ayetinde bu başlangıç harfleri farklı kombinasyonlar oluşturacak şekilde surelerin başlarında bulunmaktadır.",
                br,
                br,
                "Peki bu 14 başlangıç harfinin hepsini birden içeren ayetlerde bir ilginçlik olabilir mi?",
                br,
                "İşte bu yazıda aşağıdaki programlar yardımı ile bu bilgi incelenecektir."
            },
            new FlexRow(Gap(3))
            {
                (b)"Not:", "Komut satırları gerçek zamanlı olarak çalışmaktadır. İsterseniz komut satırlarında değişiklik yaparak farklı aramalar yapabilirsiniz."
            },

            separation,

            "Aşağıdaki program verilen harflerin sayısal değerini (aynen Roma rakamlarında olduğu gibi Arap harflerinin sayısal karşılığını) verir.",
            raisePanel(new NumericValueCalculator
            {
                Letters = string.Join(" ", Alif, Laam, Miim, Saad, Raa, Kaaf, Haa, Yaa, Ayn, Taa_, Siin, Haa_, Qaaf, Nun)
            }),
            SpaceY(10),
            "Eğer 693 sayısını görüyor iseniz hesaplamalarımız doğru gidiyor demektir. ",
            "İlk bakışta bu rakam pek bir şey ifade etmiyor gibi gelebilir ama şimdilik aklınızın bir köşesinde tutun.",

            separation,

            "Peki bu 14 başlangıç harfinin tamamını içeren ayet sayısı acaba kaçtır? Aşağıdaki program yardımı ile hesaplayalım.",
            SpaceY(10),

            raisePanel(new Calculator
            {
                ShowVerseList = true,
                SearchScript  = "*",
                Letters       = string.Join(" ", Alif, Laam, Miim, Saad, Raa, Kaaf, Haa, Yaa, Ayn, Taa_, Siin, Haa_, Qaaf, Nun)
            }),

            "Eğer 114 adet buldu iseniz işte burada ilginçlik başlıyor. ",
            "114 Kuran'daki toplam sure sayısıdır. ",
            "Bulunan ilk ayet ise 2. surenin 19. ayeti olması gibi  başka detaylar da var ama detayda boğulmamak için derine girmiyorum.",

            separation,

            "Gelelim son hesaplamaya. Bu geçişlerin sure ve ayet numaralarını topladığımızda karşımıza hangi sayı çıkıyor.",

            raisePanel(new Calculator
            {
                ShowNumbers  = true,
                SearchScript = "*",
                Letters      = string.Join(" ", Alif, Laam, Miim, Saad, Raa, Kaaf, Haa, Yaa, Ayn, Taa_, Siin, Haa_, Qaaf, Nun)
            }),

            "Eğer sonuç olarak 9702 rakamını görüyor iseniz. Bu rakamı biraz inceleyelim. Bu rakam şu iki sayının çarpımından oluşmaktadır.",
            br,
            new FlexRowCentered { "14 x 693 = 9702" },
            br,
            "Toplam 14 tane başlangıç harfi vardır ve bu 14 harfin sayısal toplamının 693 olduğunu yazının ilk başında zaten hesaplamıştık. ",
            "Bu harflerin tamamını barındıran ayetlerin sure ve ayet numaraları toplamının da bu iki rakamın çarpımını(9702) vermesi oldukça ilginç.",

            SpaceY(40),
            (b)"Sonuç: ",
            "Açıkçası herhangi bir kitapta buna benzer bir hesaplama ile önümüze böyle rakamlar koyulsa haklı olarak pek dikkate almayabilirdik. ",
            "Sırf işine gelen rakamı bulmak için zorlamışsın diyebilirdik.",
            br,
            "Elbette ki eleştirmek isteyen her türlü bir yol bulabilir. Mesela niye rakamları çarpmak yerine topladın? ",
            "Neden harfin sayısal karşılığını aldın da sırasını almadın? ",
            "Benimde önüme bir kitap ver bende bazı şeyleri çarpar böler sana istediğin rakamı veriririm. Buna benzer şeyler söyleyebilirdik. ",
            "Yahut tam tersi", br,
            "Evet burada bir gariplik var  toplamda 114 sure olması ve bu başlangıç harflerini içeren toplamda 114 tane ayet olması vesaire vesaire...",
            br,
            br,
            "Burada önemli olan olay şu: Eğer bir kitapta buna benzer 1-2 tane değil, ",
            "düzinelerce ilginç ve hep aynı rakama yani 19 rakamına işaret eden verilerin olmasıdır. ",
            "Üstelik bu başlangıç harflerinden hemen sonraki cümlelerin şöyle başladığını hatırlayın.",
            (b)"'Bu harfler kitabın kanıtlarıdır...'",
            br,
            br,
            "Özetle burada bir ilginçlik var mı? yok mu? Artık bu soru ile başbaşa olan sizsiniz. :)"
        };

        static Element separation()
        {
            return new FlexRowCentered(MarginTopBottom(10)) { "* * *" };
        }
    }
}