namespace QuranAnalyzer.WebUI.Pages;

public class PageAlternativeSystems : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Alternatif 19 Sistemleri"),

            new p
            {
                @"
Kuran üzerinde 19 ile ilgili bilgiler duyulmaya başladıkça başka insanlar da 19 üzerine çalışma yapmaya başladılar. 
Bu kişiler de günümüz bilgisayar yazılımlarını kullanarak bazı sayımlar yapıyorlar ve 19'un katı olan bazı sayılar elde ediyorlar. 
Duruma göre bu kişilerin çalışmalarını da inceleyebilirsiniz. İmran Akdemir, Gökmen Altay, İki Sayının Sahibi gibi isimler de çalışma yapıyorlar. 
Bu isimlerin ortaya attıkları iddiaları incelerken muhtemelen ilk duyacağınız cümle şu olacaktır. 'Uyduruk 19 sistemi', 'Sahte 19 sistemi' benzeri kelimeler söyledikten sonra 19 ile ilgili kendi buldukları verilerin gerçek 19 sistemi olduğunu ileri sürüyorlar. 
Bu kişilerin ortaya attıkları iddialara karşı cevaplar da var onları da dinlemenizi öneririm."
            },

            new p
            {
                "Mesela ikiz kod(7-19) sistemi diye bir sistem daha var olduğunu iddia edildi.",
                " Youtube ' da bu konu ile ilgili yapılan eleştiri videosunu incelemenizi tavsiye ederim."
            },
            new a { href = "https://www.youtube.com/watch?v=ZBweugCUuyk", text = "Gürkan Engin İkiz Kod 7 & 19" },

            new p
            {
                @"Hatta sinema filmlerinin bir sahnesinde geçen bir arabaların plaka numaralarını toplayıp çarparak Kurandan 19 ve 238 sayıları ile ilgili veriler bulan bile var.
Şaka değil konuyu araştırırken gerçekten böyle videolara denk geldim. 
Hatta Mustafa Kemal Atatürk'ün hayatındaki olayların tarihleri ile  19 rakamı arasında ilişkiler kurmaya çalışanlara bile denk gelebilirsiniz."
            },
            
            new p
            {
                "Özetle bu konuyu araştırırken o da 19'un katı bu da 19 un katı şeklinde bir çok videoya - yazıya denk gelebilirsiniz." ,
                " Tahminim o ki burada şeytanın bir oyunu olabilir.",
                " 19 meselesini sulandırarak, alakasız konularla ilişkilendirerek 19 gibi basit anlaşılır bir meseleyi anlaşılmaz işin içinden çıkılmaz ve şüpheli bir hale getirmeye çalışıyor olabilir."
            },

            new p
            {
                "Bu saydığım isimlerin ortak takıldıkları meseleler özetle aşağıdaki iki konudur."
            },
            
            new ul
            {
                (li)"Reşad Halife'nin elçilik meselesine takılmış durumdalar.",
                (li)"Tartışma konusu olan Tevbe suresindeki 128-129 ile ilgili kısımdır.",
                " 19 veya başka rakamlar kullanarak bu iki sözün Kurandan olduğunu ispatlama çabası içerisindeler."
            },

            new p
            {
                "Bu ortaya atılan alternatif iddiaları incelerken şunu hatırınızda tutmanız gerekir." ,
                " 19 kodunun başka fonksiyonlarını da göz önünde bulundurmalısınız.",
                " 19 sistemi Kuranda harf bazında düzeltme yapar. Koruyucu bir özelliği vardır.",
                " Olay sadece kuru kuruya güzel bir matematiksel örüntü değildir.",
                " Mesela isteseniz de Meryem suresine bir ekleme yapamazsınız. Bir ekleme yaptığınızda sistem alarm verir."
            },
            new p
            {
                @"Elbette madalyonun diğer yüzünde 19 olayını daha tarafsız inceleyen KuranMucizeler.com, Gürkan Engin gibi isimler de var.

Bu saydığım isimler sadece Türkiye'de olan resim. Elbette başka ülkelerde de buna benzer ayrışmalar var.
"
            },

            new p
            {
                (b)"Not: ", "Bu sitede sadece Reşad Halife tarafından keşfedilen 19 sisteminin ", (b)"en majör noktası", " olan başlangıç harfleri üzerindeki veriler incelenmiştir.",
                " Dilerseniz bu sitede kullanılan sayım programlarını kullanabilir ve alternatif iddiaları inceleyebilirsiniz.",
                " Açıkçası Kuran ile ilgili hangi rakamı duydu isem ekledim.",
                " Başka verileri de incelenebilsin diye sonuç kısmı 1230, 505, 7, 238 gibi  rakamların katları olan bir rakam olur ise onu özellikle belirtmeye çalıştım. "
            },

            new p
            {
                "Ayrıca bu alternatif incelemelerden bağımsız olarak şunu da belirtmem gerekiyor.",
                " Bazen bir şeyin ne olmadığını bilmek onun ne olduğunu bilmemize yardımcı olur.",
                " Kuran'daki bazı ayetler ve onların sayısal değerleri kullanılarak tarihdeki olmuş olan olaylar arasında bağlantı kurulması meselesi var.",
                " Bazı verileri çarpıp bölüp İstanbulun fethi 1453 rakamını bulmak gibi.",
                " 19 meselesinin böyle bir şey ", (span)"olmadığını" + TextDecorationUnderline, " sanırım anlatmama gerek yok."
            },

            new p
            {
                (b)"Sonuç olarak: ",
                "Elbette ileriki yıllarda Kuranda daha başka matematiksel veriler - örüntüler bulunabilir.",
                " Burada dikkat edilmesi gereken mesele şu olmalı; yeni bulunan örüntünün başlangıç harflerindeki 19 rakamı ile ",(b)"çelişmiyor"," olmasıdır.",
                " Ortaya konulan yeni iddia 19 ile ya örtüşüyor dolayısı ile destekleyici olacaktır veya çelişiyor olacaktır."
            }
        };
    }
}