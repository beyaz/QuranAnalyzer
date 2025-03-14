﻿namespace QuranAnalyzer.WebUI.Pages;

public class PageAdditionalVerses : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Tevbe Suresi 128. ve 129. Meselesi"),

            new p
            {
                "19 sisteminin olması için Kurandan iki ayet atılması gerekiyormuş. Yoksa sistem çöküyormuş. ",
                br,
                "Konuyu pek araştırmayan insanlar üzerinde etki bırakan bir söz. ",
                "Çünkü insanlar bu sözü duyunca otomatikman şöyle düşünürler, ",
                (b)" isterse dünyanın en süper bilgisi olsun bana ayeti dolayısıyla Kuranı reddettirecek bir şey ise benim için mesele başlamadan bitmiş demektir. Peşinen reddederim.",
                br,
                "Peki nedir bu meselenin aslı?"
            },
            new p
            {
                "Önce net bir şekilde cevabı verelim.",
                (b)"19 sisteminin en majör bileşeni başlangıç harfleri üzerine olan sistemdir. ",
                "Bu en majör bileşen olan başlangıç harflerinin, Tevbe suresinin toplamda 127 ayet mi yoksa 129 ayet mi olması ile doğrudan bir ilgisi yoktur.",
                br,
                "Hatta böyle bir kafa karışıklığına mahal vermemesi için ben bu sitede yaptığım tüm sayımları  ",
                "klasik elinize aldığınız bir kuran mushafı ile aynı olan Tanzil.net den aldığım mushaf ile yaptım."
            },
            new p
            {
                "Önce meselenin tarihi yönünü ele alalım. ",
                " Rivayetlerde şöyle nakledilir, Ebubekir zamanında Kuran mushaf haline getirilmesi için 5 kişilik bir ekip kurulur.",
                " İnsanlar elinde ne kadar deriye yazılmış kuran var ise ortaya koyarlar. Her bir ayet için en az 3 kişinin şahitliği şart koşulur.",
                " Süveybe adında bir sahabe de, tevbe suresinin 128. ve 129. ayetlerini söyler.",
                " Fakat onun dışında hiç kimse bu iki sözün ayet olduğuna şahit olmaz.",
                " Süveybe ise taa mekke döneminde bir kişinin peygamberin deve satın alması konusunda problem yaşadığını görür ve peygamber ile ticaret yapan kişinin ilk anlaşması esnasında olmadığı halde  peygamberin doğru söylediğine şahitlik eder.",
                " Hatta olaydan sonra peygamberimize gelerek şunu söyler ben senin Allah'ın resulü olduğuna şahitlik ediyorum buradaki şu ufak ticaretine neden şahit olmayayım der.",
                " Bunun üzerine de peygamberimiz 'Süveybenin şahitliği iki kişinin şahitliği gibidir' der.",
                " Hasılı bu sözü de delil getirerek Süveybenin şahitliği iki kişi gibi sayılır ve bu iki söz Kurana eklenir.",
                " Üstelik Tevbe suresindeki tüm ayetler Medine dönemine aitken sadece bu sonraki iki ayet Mekke dönemine aittir.",

                br,
                br,
                "Tarihi rivayet olarak durum böyle. Elbette ki bu sözü şöyle yorumlayanlar da var. ",
                "Aslında oradaki herkes bu iki sözün Kurandan olduğunu biliyordu fakat yazılı olarak ellerinde yoktu. ",
                "Burada rivayet tenkidi-yorumlaması yapmayacağım ben sadece böyle bir rivayeti aktardım.",

                " Hatta başka bir rivayette Ali'nin evinden belli bir süre çıkmadığı bunun sebebini soranlara da Kurana söz eklendi diye durumu boykot ettiğine dair rivayetler var.",
                " Dileyen bu rivayetleri daha derinlemesine araştırabilir. ", br,
                " İşine gelince rivayetlere sarılıyorsun gibi haklı bir eleştiri yapabilirsiniz ama benim burada aktarmak istediğim şey şu; ",
                " burada bir duman tütüyor.",
                " İlk toplanan muashafın yakılması vesaire ister istemez konu üzerinde soru işaretleri bırakmış olabilir.",
                " Hatta herkim ki tevbe suresi 128. 129 uncu ayetleri şu vakitlerde okur ise ona şöyle sevap yazılır şeklinde rivayetlerin olması da bir garip.",
                " Özellikle 128-129 un seçilmiş olması biraz garip.",
                br,
                "Rahman Rahim gibi sıfatlar Allah için kullanılırken burada Muhammed peygamber için kullanılmış.",
                br,
                "Hasılı iki kapak arasına girdikten sonra mesele kapanıyor."
            },

            separation,

            "Peki konunun 19 sistemi ile ne ilgisi var?",
            new p
            {
                "19 sistemini ilk keşfeden kişi Reşad yaptığı ilk sayımlarda tevbe suresine 128-129 dahil ederek sayımları yapıyor.",
                " Ama bilgisayar Allah kelimesi sayımlarını bir fazla vermesi gerekirken bir eksik veriyor.",
                " Hatta ilk kitabın ilk baskısında bu haliyle çıkıyor.",
                " Daha sonrasında Cebrail aracılığı ile bu bilgi kendisine veriliyor.",
                " Özetle Tevbe suresindeki 128. 129'uncu sözler Kurana ait değildir bilgisini alıyor.",
                " Aynı zamanda sayımları tekrar gözden geçiriyor ve normalde bir fazla vermesi gereken Allah kelimesinin bilgisayar tarafından bir eksik verildiğini görüyor. Kendisi de şaşırıyor.",
                " Bunun üzerine bu iki sözün Kurandan olmadığına dair matemaiksel veriler de ortaya çıkıyor.",
                " Ben sadece bu örneklerden bir tanesini aşağıdaki link üzerinde gösterdim. Dileyen var ise inceleyebilir. Aşağıdaki örnek gibi 70 den fazla örnek var."
            },
            new FlexRowCentered
            {
                new a { href = GetPageLink(PageId.CountOfAllah), text = "9. 128-129 üzerine ufak bir inceleme" }
            },
            new p
            {
                "Özetlemek gerekir ise ", (b)" Bu bilgi Cebrail aracılığı ile geliyor. Ardından matematikle destekleniyor.",
                br,
                "Dünyada hiç bir kimse kendi kutsal saydığı kitaptan matematiğe uymuyor diye ayet atmaz.",
                " Reşad o kadar da aptal biri değil. Kuran çevirisi üzerine 20 yıla yakın uğraşan birinden bahsediyoruz.",
                " Burasını maalesef karıştırıyorlar."
            },

            separation,
            new p
            {
                "Reşad Halife'nin elçilik meselesini zihninizde bir yere oturtmadıysanız bu meseleyi de bir yere oturtmanız oldukça zor.",
                " Ben burada meseleyi özetlemeye çalıştım. Karar vermek size kalan bir mesele."
            },
            separation,

            new p
            {
                "Kuranda bu kitabın Allah tarfından korunduğuna dair net ifadeler var. Bu durumda haklı olarak şu soruyu sormalıyız.",
                " Hani Allah Kuranı korumuştu? Eğer Tevbe 128-129 Kurandan değil ise nasıl oldu da Kuran mushafları arasına girebildi?",
                " Demek ki mantık olarak çöküyor.",

                br,
                br,
                "İşte bu fikre karşı arguman olarak da şu söyleniyor. Aslında halihazırda ayet gerçekleşmiş durumda.",
                " Allah koruyacağını söyledi ve 19 kodu ile bunu koruduğunu bizzat gösterdi.",
                " Hayalen şöyle düşünün; bir odada 10 kişi olalım ve elimizde şöyle bir bilgi olsun 'Bu odaya giren olur ise dayak yer'.",
                " Eğer hiç kimse girmez ise kimse dayak yemez ve 'odaya giren dayak yer' bilgisi sadece kuru - emin olmadığımız bir bilgi olarak kalır.",
                " Ne zamanki biri odaya girer ve dayağı yer ancak bu durumda bu bilgi netlik kazanır.",
                br,
                "Durum biraz buna benziyor. Allah bu kitabı koruyacağını söylüyor? Bu bilginin kaynağı ne ? Kim söylüyor? Cevap: Bu kitap",
                br,
                "Bu da mantık hatasına yol açıyor.",
                " Üstelik madem koruma olayını biz elimizdeki mushaf olarak görüyor isek, dünyada farklı farklı bir çok mushaf var. Her bir mushafda yazım farklılıkları var.",
                " Bu durumda Allah  Kuranı harf bazında koruyamadı gibi bir sonuca da gitmeliyiz. Kuran ve mushaf kavramları birbirine karıştırılıyor."
            },
            separation,
            new p
            {
                "Ben gene de Kurandan iki ayeti red etmeyeyim diye düşünebilirsiniz. ",
                "Ama meseleyi tersden ele alır iseniz Kuranda olmayan iki cümleye Allah sözü muamelesi yapmış da olabilirsiniz. ",
                "Bu konu ile ilgili olarak Kuranın mushaf haline getirilme süreçlerini araştırabilirsiniz."
            },
            separation,
            new p
            {
                "Kuranda bütün surelerin başında besmele vardır. Sadece bir tek surenin başında besmele yoktur.",
                " Sanki kitabın yazarı özellikle buraya dikkat çekiyor.",
                " Bunun sebebini araştırdığınızda ise 'çünkü bu surede inanmayanlara ültimatom veriliyor ondan dolayı başında besmele yok' şeklinde cevaplar bulabilirsiniz.",
                " Yahut neden bir tek bu surenin başında besmele yok diye sorduğunuzda cevap olarak 'çünkü yok' deniliyor.",
                " Bu veilen cevaplar sizi ne kadar tatmin eder orasını size kalmış. 19 sistemi işte burada şu açıklamayı yapar;",
                " Çünkü 'Her Şeyde Tam Kontrol Durumunda Olan' bu surenin içine fazladan iki söz eklenmesine müsade etmiştir. Müsada etmiş ki ",
                "bu Kuranın bizzat kendisi tarafından korunduğunu insanlara göstermek istemiş.",
                " Bu sebeple bu sureye dikkat çekmek için ve Allah kelamı olmayan iki söz olduğu için başına besmele koymamıştır."
            },
            separation,
            new p
            {
                "Mesele etrafında dönen tartışmayı aktarmaya çalıştım. Umarım faydalı olmuştur.",
                br,
                "Ufak da olsa kendi anlayışımı ifade etmek istiyorum. ",
                "Açıkçası hayatında Kuran olmayan birinin Tevbe 128-129 Kuran'dandır veya değildir demesinin bence bir anlamı yok. ",
                "Yılan adamı yarı beline kadar yutmuş fakat adam az önce ensesinden ısıran sivri sineğin derdine düşmüş. ",
                br,
                "Örnek biraz saçma gelebilir ama malesef durum böyle.  "
            }
        };

        static Element separation()
        {
            return new FlexRowCentered(MarginTopBottom(10)) { "* * *" };
        }
    }
}