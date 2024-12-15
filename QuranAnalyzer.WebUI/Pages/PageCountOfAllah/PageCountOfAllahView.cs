namespace QuranAnalyzer.WebUI.Pages.CountOfAllahPage;

class PageCountOfAllahView : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("9. 128-129 üzerine ufak bir inceleme"),

            new p
            {
                "Acaba Kuranda geçen her bir 'Allah' kelimesinin geçiş yerleri ile ilgili bir şey olabilir mi?",
                br,
                "İşte bu yazıda aşağıdaki programlar yardımı ile bu bilgi incelenecektir."
            },

            separation,

            "Aşağıdaki program verilen kelimeleri arar. Bulunan kelimelerin geçtiği sure ve ayetlerin toplamını ve kaç adet olduğunu gösterir. ",
            br,
            "Önce basit bir arama yapalım ve programın nasıl çalıştığını gözlemleyelim.",
            br,
            "Mesela 2. surenin 60 ila 62. ayetleri arasında geçen 'Allah' kelimelerini aratalım.",

            raisePanel(new Calculator
            {
                Word         = "الله,والله,بالله,لله,ولله,تالله,فالله,فلله,ءالله,ابالله,وتالله",
                SearchScript = "2:60 --> 2:62",
                ShowDetails  = true
            }),
            SpaceY(10),
            "Böylece programın neyi hesapladığını kısa bir veri üzerinde görmüş olduk. İsterseniz değerleri değiştirip daha detaylı öğrenebilirsiniz.",

            new p
            {
                "Peki tüm mushaf boyunca bu aramayı yapalım."
            },
            raisePanel(new Calculator
            {
                Word         = "الله,والله,بالله,لله,ولله,تالله,فالله,فلله,ءالله,ابالله,وتالله",
                SearchScript = "*"
            }),

            "Sonuçlardan da görüldüğü üzere bu toplamlarda herhangi bir ilginçlik yok.",

            separation,

            "Şimdi ise üzerinde tartışmanın döndüğü konu olan 9. surenin 128 ve 129 nolu cümleleri çıkarıp sayalım.",
            SpaceY(10),

            raisePanel(new Calculator
            {
                Word         = "الله,والله,بالله,لله,ولله,تالله,فالله,فلله,ءالله,ابالله,وتالله",
                SearchScript = "*, -9:128, -9:129"
            }),

            "Sanırım çok fazla söze gerek yok.",
            br,
            "Burada dikkat edilmesi gereken nokta şu;",
            br,
            "Herhangi bir surenin herhangi bir cümlesini  çıkarsanız veya herhangi bir sureye fazladan bir 'Allah' kelimesi ekleseniz bu tablo bozulurdu.",
            " İşte 19 sisteminin Kuranı koruması böyle oluyor.",
            " Herhangi iki ayet değil özellikle bu bahsi geçen üzerinde bazı şüphelerin tartışmaların olduğu iki cümle çıkarılınca bu tablonun oluşması çok ilginç.",
            " Özetle Kurandaki her bir 'Allah' kelimesinin geçiş yerleri dahi bir öneme sahiptir.",

            br,
            br,
            "İşte 'sırf 19 rakamına uymuyor diye Kurandan ayet atılıyor' iddiasının aslı budur.",
            " Tabii şunu da belirtmem gerekiyor. Reşad bunun gibi 70 den fazla matematiksel veri de sunuyor.",

            new p
            {
                "Burada kendi fikrimi şöyle ifade etmek istiyorum. ",
                "Ben bu yazıda konunun ne olduğunun anlaşılması için sunulan verilerden sadece 1 tanesini örnek olarak inceledim. ",
                "Bu şekilde 70 den fazla veri var. ",
                "Başlangıç harfleri'nin bu Tevbe suresi üzerindeki tartışma ile pek ilgisi olmadığı için bu konuya dair bu yazı dışında herhangi bir yazı sunmadım. "
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