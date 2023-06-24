namespace QuranAnalyzer.WebUI.Pages;

public class PageWhoIsRashadKhalifa : ReactPureComponent
{
    protected override Element render()
    {
        return new Article
        {
            new LargeTitle("Reşad Halife Kimdir? Ne söylüyor?"),

            new p
            {
                @"
Bu 19 meselesini incelerken fark ettim ki meselenin odağındaki isim bu sistemi ilk bulan kişi Reşad Halife ismi.
 Daha doğrusu onun fikirleri. Zaten fikirleri yüzünden de öldürüldü.
 Kısaca bu kişi kimdir? Derdi neymiş?
 Özetle ne söylemiş? İşte bu bilgileri kısa kısa olacak şekilde özetlemeye çalıştım. 
 Tekrarlamakta fayda görüyorum. Bu fikirler doğrudur yanlıştır gibi bir iddiam yok. 
 Daha doğrusu benim doğru veya yanlış demem herhangi bir şey ifade etmez. Ben sadece bu adamın ne demeye çalıştığını özetlemeye çalıştım. 
 Umarım faydalı olur."
            },

            (h4)"İlk Yıllar ve Kariyer",
            new p
            {
                new img { Src(FileAtImgFolder("rh.png")), Alt("Reşad Halife"), Width(200), HeightAuto, FloatLeft, MarginRight(20) },

                "1935 yılında Mısırda doğmuş. Babası tarikat şeyhi olan biridir. " +
                "Bunu özellikle belirttim. Ehli sünnet bir tarikat ortamında, dindar bir ailede doğup büyümüş birinden bahsediyoruz. " +
                "Mısırda üniversite kimya bölümünde okuyor. Onur derecesi alıyor. 25'li yaşlarda Amerika'ya doktora için gidiyor ve biyokimya alanında yüksek lisans " +
                "ve doktorasını tamamlıyor. Kendi alanında konferanslar falan veriyor. Birleşmiş milletler kalkınma örgütünde kimyager olarak çalışıyor. ",
                "Kısaca kariyer olarak oldukça iyi giden bir hayatı olmuş diyebiliriz."
            },
            new p
            {
                "30'lu yaşlarda Amerika'ya gelince bir yandan doktorasını tamamlarken bir yandan da İngilizce yazılmış Kuran meallerinin çoğunu okuyor. ",
                "Eski tefsirleri zaten Mısırdayken inceleyen biri. Anadili zaten Arapça. ",
                "Yazılan İngilizce Kuran çevirilerini inceledikten sonra fark ediyor ki bu çevirilerdeki eksik gördüğü ve tevhide uymayan fikirler olduğunu gözlemliyor. ",
                "En azından kendi evlatlarımın okuyabileceği Tevhidi merkez alan bir çeviri yapma niyeti ile çeviriye başladığını kendisi söylüyor. ",
                "Bir ayetin manasını tam anlamadan ötekine  geçmeyeceğine dair kendine de şart koşuyor. ",
                "1. sureyi çevirdikten sonra 2. sureye geliyor ve sure başındaki elif-lam-mim harflerine gelince takılıyor. ",
                "Çalıştığı şirket zamanında çalışanlarını yazılım kursuna göndermiş. Kendisi de bu sayede yazılım öğrenmiş. ",
                "Acaba Kuranda bu başlangıç harfleri ile ilgili bazı veriler olabilir mi diye düşünüp bilgisayar yazılımı ile incelemek istiyor. ",
                "Ardından farklı kuran mushaflarını inceleyerek Arapçadaki her bir harfe karşılık İngilizce bir harf ile Kuranı bilgisayara aktarıyor.",
                " Açıkçası oldukça zahmetli bir iş olsa gerek :) "
            },

            new p
            {
                "İlk fark ettiği şeylerden biri Kaf harfi ile başlayan surelerde Kaf harfinin biraz daha yoğun kullanıldığını görüyor. ",
                "Bu veriyi 1973 tarihinde makale olarak yayınlıyor. ",
                "Daha sonra 1974 de ise fark ediyor ki bu başlangıç harflerinin olduğu surelerin başındaki harfler bulundukları surelerde hep 19 un katları şeklinde geçiyor. ",
                "Sonrası çorap söküğü gibi geliyor ve tüm surelerdeki bu başlangıç harfleri ile ilgili sayımları kitap haline getirip yayınlıyor. ",
                "Hatta kitabının ismini de 'Muhammedin Ebedi Mucizesi' şeklinde yayınlıyor. Sonrasında bu ismi Kuranın Ebedi Mucizesi olarak güncelliyor. "
            },

            new p
            {
                "Bu buluştan sonra bir anda İslam dünyasında popüler oluyor. Öyle ki Libya-İran gibi ülkelerden devlet başkanları seviyesinde özel davetler alıyor. ",
                "Hatta Türkiye'de bile yankı buluyor. Öte yandan Reşad başka kitaplar yazılar makaleler de yayınlıyor. ",
                "İşte Reşad'ın fikirleri de bu yayınlar sayesinde duyulmaya başlayınca eskiden el üstünde tutulan bu insan artık ismi duyulunca geri adım atılan biri haline dönüşüyor. ",
                "Peki nedir bu adamın savunduğu fikirler? Bu fikirlerden bazılarını çok kısa şekilde belirtmeye çalıştım. Yazıda ben kendi anladıklarımı ifade etmeye çalıştım bu sebeple üslubuma pek takılmamanızı rica ediyorum. "
            },

            new ul
            {
                new li
                {
                    (b)"Ey İslam dünyası! ",
                    "Sizler Muhammed peygamberi putlaştırıyorsunuz. Allah'ın yanında sürekli Muhammed peygamberimizi ekliyorsunuz. ",
                    "Tek Olan'ı tek olarak anamıyorsunuz sürekli yanına Muhammed kelimesini yerleştiriyorsunuz. ",
                    "Hatta Kuranda mescitlerde Allah'ın adı tek olarak anılsın diye açık emir varken siz Allah yazılarının yanına sürekli Muhammed yazıları ekliyorsunuz. ",
                    "Allah'tan diler gibi Muhammed peygamberden şefaat dileniyorsunuz. ",
                    "Tüm bunları yaparak Kurandaki şu ilkeleri çiğnemiş oluyorsunuz. ",

                    new FlexColumn(MarginLeft(30), MarginTopBottom(10), Gap(10))
                    {
                        new FlexRow
                        {
                            "- Mescitlerde Allah'ın adı tek olarak anılmalıdır."
                        },
                        new FlexRow
                        {
                            "- Peygamberler arasında ayrım yapılmamalıdır."
                        }
                    },

                    "Özetle şeytan aynen Hristiyanlara yaptığı gibi sizi de tam da sevdiğiniz damarınızdan yani Muhammed peygambere olan sevginiz-saygınız üzerinden yakalamış durumda ve maalesef farkında değilsiniz. ",
                    "Hatta bu putlaştırma olayı sadece peygamber ile de sınırlı değil. Tarikat şeyhlerini cemaat liderlerini putlaştırmaya kadar gidiyor."
                }
            },
            new ul
            {
                new li
                {
                    (b)"Ey İslam dünyası! ",
                    "Kuranda zekat zamanı olarak hasat zamanı ifadesi geçer. Artık çoğumuz şehirlerde maaşla çalışan insanlarız. ",
                    "Eğer aylık maaş ile çalışıyorsanız sizin hasadınız maaşınızı aldığınız gündür ve zekatınızı da maaşınızı aldığınız zaman vermelisiniz.",
                    br,
                    "Not: Reşad bu zekat konusunda özellikle duruyor. Hem ihtiyaç sahiplerinin 1 yıl beklememesi ve zekatın her ay sonunda sürekli gündemimizde olması sayesinde 'En Yüce Olan' a daha çok yaklaşmamız için fırsat olduğu vesaire detaylı olarak açıklıyor."
                }
            },
            new ul
            {
                new li
                {
                    (b)"Tüm dünya insanları! ",
                    " Tevrat-İncil-Kuran bu kitapların Allah'tan geldiğine dair şüpheleriniz var. Musa denizi yardığında hiç birimiz orada değildik.",
                    " İsa ölüyü dirilttiğinde hiç birimiz yanında değildik.",
                    " Bu kitapların Allah'tan mı olduğuna dair şüphelerinizi giderecek ", (b)" fiziksel ", "bir kanıt gelmiş durumdadır.",
                    " Bu kitaplardan sonuncusu olan Kuran'ın Allah'tan geldiğine dair fiziksel delil (19 mucizesi) bilgisayar yardımı ile ortaya çıkmıştır.",
                    " Kurandaki en önemli mesele olan Tevhid-Şirk meselesine kulak verin İsa'yı, Meryem'i, Muhammed'i putlaştırmaktan vazgeçin.",
                    " Yaratıcı'nın'nın varlığı üzerine ve son kutsal kitapta (Kuran) yazılanların doğru olup olmadığı hakkında artık bir bahaneniz kalmamış durumdadır."
                }
            },

            new ul
            {
                new li
                {
                    (b)"Niçin buradayız?",
                    " (Bu kısmı kendi anladığım kadarı ile anlatmaya çalışacağım.)",
                    br,
                    br,
                    " Hayatın anlamı ne? Niye buradayız? gibi sorular insanlık tarihi kadar eski sorulardır. Felsefe de bile bu soruya net bir cevap verilememiştir.",
                    br,
                    br,
                    " - Ben mi istedim bu dünyaya gelmeyi?",
                    br,
                    br,
                    "- Neden Allah sürekli olarak bizlere namaz kılmamızı tembihliyor? Ödül olarak da cenneti vaat ediyor? Madem bu kadar zengin direk verse ya.",
                    br,
                    br,
                    "- Bizler Tanrının oyuncakları mıyız? Ne yani önünde eğilenleri cennete koyan eğilmeyenleri cehenneme atan bir Tanrı figürü pek de hoş değil gibi",
                    " sürekli biz insanoğlunu iyilik için yarıştırıyor.",
                    br,
                    br,
                    "- Türkiye'de doğan Mehmet Müslüman olduğu için eninde sonunda cennete gidecek fakat Almanya'da doğup büyüyen Hans, Müslüman olmadığı için cehenneme gidecek. ",
                    "Hans Ortadoğu’da bir yerde doğsaydı o da muhtemelen Müslüman olacaktı. ",
                    "Burada bir adaletsizlik yok mu?",
                    br,
                    br,
                    "- Madem Tanrı bu kadar güçlü neden bunca kötülüğe izin veriyor? ",
                    "Biz insanoğluna iyi-kötü arasında seçim yaptıracağına iyi-daha iyi arasında bir seçim yapsaydık da hepimiz cennete gitsek daha iyi olmaz mı?",
                    " Daha çok puan alan cennette daha üst konuma gitseydi",
                    br,
                    br,
                    "- Kutsal yazılarda bahsedildiğine göre Koskoca Tanrı ne diye şeytan gibi  yarattığı birini kendine rakipmiş gibi  görüp de biz insanoğluna ",
                    " ya şeytanı seçersiniz ya beni seçersiniz gibi bir seçim ile karşı karşıya bırakıyor? Tanrı neden şeytanı kendine muhatap kabul etsin ki?",
                    br,
                    br,
                    " - Ortalama 70 yıl yaşıyorum. 20 li yaşlara kadar zaten çocukluk - ergenlik - eğitim vesaire ile geçiyor. ",
                    " 60-70 den sonrasını zaten sayma istesen de günaha giremiyorsun. Zihnen de geriliyorsun. Özetle bu kadar kısacık bir yaşam için sonsuz bir cehennem ne kadar adaletli?",
                    " Hani Tanrı en merhametliydi?",
                    br,
                    br,
                    "-Uzay neden bu kadar büyük? Ne malum başka yerlerde yaşamın olmadığı?",
                    br,
                    br,
                    "-Yaşamın anlamı nedir? Yapmam gereken en önemli şey nedir? Amacım ne olmalı?",
                    br,
                    br,
                    "Benim gibi Bağcılarda doğup büyüyen ortalama birinin aklına bunlar geliyor ise kim bilir daha başka zihinlerde ne sorular dolaşıyordur. :)",
                    br,
                    "Bu saydığım soruları daha derinleştirebiliriz. Klasik dini literatürde bu sorulara verilen cevap şudur.",
                    br,
                    "Bizler bu dünyaya imtihan için gönderildik.",
                    br,
                    "İyi de niye? Niye durup dururken imtihan oluyoruz?", br,
                    "İşte tam da burada Reşad Halife bu sorunun cevabını yine Kurandan veriyor. ",
                    "Kurandan verdiği referanslar ile niçin burada olduğumuz ile ilgili, yaratılış ile ilgili çok güzel bir açıklama yapıyor.",
                    br,
                    "Bu açıklamayı kasti olarak burada vermiyorum. Çünkü verilen ayetleri tek tek inceleyip o kurguyu kendi zihninizde yapmanız gerekiyor.",
                    " Zaten  yaratılış kurgusunu zihninizde iyice oturttuğunuz durumda Kurandaki bazı noktaları da daha iyi anlamış olacaksınız. " +
                    " Yukarıda verilen ve benim  yıllarımı yiyen bu sorular artık çıtır çerez gibi gelebilir.",
                    " Aşağıda Reşad Halife tarafından yapılan çevirinin linkini ekliyorum dileyen kitabın başında detaylı olarak anlatılan bu konuyu inceleyebilir.",
                    br,
                    new a { href = "http://teslimolan.org/pdf/kuran-son-ahit---birinci-baski.pdf", text = "Yetkilendirilmiş Çeviri" }
                }
            },

            new ul
            {
                new li
                {
                    (b)"Yalnız Kuran!",
                    br,
                    "Ey İslam dünyası! Sizler Allah'ın yüce kelamı dururken Muhammed peygambere ait olup olmadığı belli olmayan rivayetlere sarılıyorsunuz. ",
                    "Dinin tek bir hüküm kaynağı vardır o da Kurandır. ",
                    "Eğer bir şey Kuranda belirtilmiş ise o bizim için bağlayıcıdır eğer detayı verilmemiş ise demek ki 'En Bilge Olan' o kadarını uygun görmüştür. ",
                    " Çünkü Kuranda üzerine basa basa şu ifadeler vardır. ",
                    br,
                    "Kuran tamdır. Detaylıdır. Bu kitaptan hesaba çekileceksiniz. ",
                    br,
                    "Eğer siz Kurandan başka bir öğreti takip ederseniz Kuran'ın tam ve eksiksiz olduğu gerçeğini göz ardı etmiş olursunuz. ",
                    br,
                    br,
                    "Not: Genel gözlemim burada karıştırılan bir durum vardır. Bu Yalnız Kuran fikrini savunan insanlara 'Hadis İnkarcısı' etiketi yapıştırılıyor. ",
                    "Hadisleri o dönemin şartlarını gözlemleyebilmek adına tarihi birer veri olarak değerlendirebilirsiniz ama dinde hüküm koyucu yapamazsınız. ",
                    "Bir örnek ile açıklayayım. Kuranda abdest 4 aşamada anlatılmıştır. ",
                    "İşte Reşad şunu söylüyor; Kuranda abdest 4 aşama diyor ise 4 aşamadır. ",
                    "Fazladan ensemi yıkayayım, burnuma su çekeyim dersen, sen Kuran'ın öğretisini değil başka bir öğretiyi takip etmiş olursun. ",
                    "Özetle Kuranda bir şeyin hükmü anlatılıyor ise o şekilde yapılmalıdır.",
                    " Yukarıdaki örnekte olduğu gibi abdest için 4 yerinizi yıkamanız gerekiyor ise 4 yerinizi yıkayın. Bu kadar basit.",
                    " Çünkü detayın peşine düşersen bu Kuran eksiksizdir, detaylıdır, tamdır cümlelerini boşa çıkarmış, dikkate almamış olursun demektir.",
                    br,
                    br,
                    "- Madem dine dair herşey Kuranda var o zaman bana öğlen namazının nasıl kılınacağını göster?",
                    br,
                    "Bu soru klasik bir soru olduğu için buna da değinmek istiyorum.",
                    br,
                    "Bu soruyu soran kişilere genelde şöyle cevap veriyorum. ",
                    br, br,
                    "- Velevki Kuranda namaz anlatılmış olsaydı yine de detay sormayacağına emin misin?",
                    " Kuranı yetiremeyen bir kişi muhtemelen yine şu soruları soracak. Oturuşta işaret parmağı kaldırılacak mı? kaldırılmayacak mı? kaldırılacak ise kaç saniye kaldırılacak? ",
                    " 4 rekatlı namazda ilk oturuşta mı yoksa ikinci oturuşda mı kaldırılacak? gibi gibi.. Yaradana içten yakarmak yerine şekilde takılı kalınıyor.",
                    br,
                    br,
                    "-Namaz ibrahim peygamber aracılığı ile gelen ibadet pratiklerindendir. ",
                    " Hatta yahudilerin namaz kılma şeklini inceleyin. Müslümanlarınkine çok benzerdir.",
                    br, br,
                    "- Benzetmek biraz garip olcak ama şöyle hayal edin.",
                    " Mahalledeki çocukların önüne top atıp 'maç oynayın' dediğinizde size şöyle soru soran bir çocuğa hiç denk geldiniz mi?",
                    " Maç kaç kişilik oynanır? Kale nedir? topa elimizle mi vuracağız ayağımızla mı?",
                    br,
                    "Bu örnek size komik gelebilir ama namaz hakkında oruç hakkında sorulan soruların çoğu bu şekildedir.",
                    br, br,
                    "Nasıl ki çocuklar ‘gol nedir’, ‘korner nedir’ sormuyorsa insanlar da İbrahim’e öğretilen ve o zamandan bu yana binlerce yıldır devam eden namazın şekli hakkında soru sormadılar.",
                    " İlk inen namaz ayeti namaz hakkında hiçbir bilgi vermediği gibi insanların bu ayete verdikleri tepki de ‘namaz nedir’ gibi  sorular olmadı. Çünkü biliniyordu.",

                    br, br,
                    " Bakara suresindeki meşhur olayı hatırlayın. Musa halkına bir buzağı kesmesini söylüyor, İsrailoğulları sürekli detaya iniyor.",
                    " Buzağının rengi ne? Allah cevap veriyor ardından İsrailoğulları tekrar soruyor buzağı genç mi? yaşlı mı?",
                    " Allah bu olayları hikaye olsun diye anlatmıyor. Tam da biz müslümanlara öğüt veriyor.",

                    br,
                    br,
                    "-'Madem Haidisleri inkar ediyorsunuz ama",
                    " Kuran da aynı kişiler tarafından aktarıldı o halde Kuran'ı da inkar etmelisiniz',",
                    " 'Nakilde sorunu olmayan ama Kurana ters mantığa ters hadisleri ne yapacağız?' gibi bir çok tartışmalı konu var.",
                    br,
                    "Özetle şunun tekrar altını çizmek istiyorum; Yalnız Kuran fikri hadisleri inkar etmiyor, dinin tek kaynağının Kuran olduğunu savunuyor.",
                    " Bu ikisi genelde karıştırılıyor.",
                    br,
                    br,
                    "Burada kendi tavsiyemi şöyle söyleyeyim;",
                    " Elinize bir kağıt kalem alıp Yalnız Kuran ve Geleneksel Anlayış diye iki başlık atın.",
                    " Geçmiş önyargılarınızı bir kenara bırakıp bu konu etrafında yapılan tartışma ve söyleşileri dinleyin referans verilen ayetleri, hadisleri not edin inceleyin.",
                    " Sürecin başından sonuna kadar en çok yapmanız gereken en önemli olan şeyi yani Allah'dan rehberlik dilemeyi unutmayın.",
                    " Unutmayınız ki Einstein'den on kat daha zeki olsanız bile Allah'ın rehberliği olmadığı sürece bir adım dahi yol alamazsınız."
                }
            },

            new ul
            {
                new li
                {
                    (b)"Zamanınızın çoğunda sizin zihninizi kim veya ne meşgul ediyor ise sizin ilahınız odur.",
                    br,
                    "Kuranda bir çok ayette Allah'ı sık sık anın, Onu gece gündüz yüceltin. Ayaktayken anın, yan yatarken anın gibi ifadeler geçer. ",
                    "Açıkçası oldum olası bu ısrarın sebebini anlamış değildim.",
                    br,
                    "Klasik cevap ise şöyleydi. Allah'ın ihtiyacı yok senin ihtiyacın var.",
                    br,
                    "İşte Reşad buradaki mekanizmayı şöyle açıklıyor; Bizler bu dünyaya ruhlarımızı kurtarmak-büyütmek için gönderildik. ",
                    " Baskın zihin durumumuz Allah ile ilişkili olur ise ve doğru(şirk içermeyen) namaz -oruç gibi ibadetler ile ruhlarımız beslenir ve büyür.",
                    " Böylelikle ahirette Allah bizlere tekrar secde etmemizi söyleyecek eğer ruhlarımızı Allah'ın yakınlığına -enerjisine alıştıramaz iseniz o gün geldiğinde",
                    " o secdeyi yapamazsınız ve Allah'ın varlığına dayanamayıp geriye(cehenneme) doğru kaçmaya çalışacaksınız.",
                    " Baskın zihin durumunu bir örnek ile açıklayalım.",
                    br,
                    "Bir elmayı ısırdığınızda zihninizi o elmaya verin.",
                    " 'En Merhametli Olan', milyon kilometre öteye adına güneş dediğimiz bir gezegen koymuş.",
                    " Bu elma için milyon km öteden ısı göndermiş ışık göndermiş.",
                    " Toprağın altında milyarlarca bakteri topraktaki besinleri ayrıştırmış.",
                    " Ağaç ise bu vitaminleri gözle görülmeyecek kadar küçük borular ile  milim milim, damla damla bu meyveye doldurmuş.",
                    " Elmanın suyu ağzınızda akarken verdiği o lezzeti fark edebilmemiz için dilimizde bir sürü farklı hücre yerleştirmiş.",
                    " İşte bütün bu şartları sağlayan 'En Lutufkar Olan'a şükürler olsun.",

                    br,
                    "Özetle; bizler Allah'a zarar veremeyiz. Yarar da veremeyiz.",
                    " Yaratıcı ile bağlantılı zihin durumu  ve ibadetler ile ancak kendimize fayda sağlamış oluruz.",
                    " Elbette bu zihin durumuna geçmek zaman alacak bir süreç. Ama madalyonun diğer yüzünde şu var.",
                    " Bizler Allaha inanınca cennete gideceğimizi sanıyoruz. Fakat Kuran bunu garanti etmiyor.",
                    " Çünkü Kuranda kesin olarak belirtiliyor ki her ne iyilik yaparsan yap, her ne kadar ibadet edersen et eğer şirk içinde bir ömür yaşadı isen ",
                    " 'Azabı En Şiddetli Olan' şirki asla affetmeyeceğini belirtiyor.",
                    " Ayrıca iman edenlerin çoğunun, bunu şirk suçunu işlemeden yapmayacağı Kuranda belirtiyor."
                }
            },

            new p
            {
                (b)"Sonuç olarak;",
                br,
                "Bu yukarıdaki belirtilen fikirler size doğru veya yanlış gelebilir.",
                " Reşad Halife yaratılış, nefs, evrenin büyüklüğü ve daha başka bir çok konuda açıklamalar yapıyor ama burada hepsine yer vermem mümkün değil.",
                " Israrla şunu da söylüyor;",
                br,
                (b)"'Eğer benden Kuranda referansı olmayan dini bir söz duyarsanız onu çöpe atabilirsiniz'.",
                br,
                " Reşad 80'li yıllarda sanki bu zamandaki youtube-sosyal medya olaylarını tahmin etmiş gibi:)",
                " bu fikirlerin bir kısmını cuma hutbelerinde bir kısmını kamera karşısına geçerek tek tek anlatmış.",
                " Doğru namazın nasıl kılınacağı için video çekmiş.",
                " Bilim adamı kimliği ile evrim hakkında video çekmiş. (Biyokimya doktorası olduğunu hatırlayın.)",
                " Toplamda 10-15 tane videosu var. Ayrıca kendi yapmış olduğu Kuran çevirisi var.",
                " Bu yazıdan ancak bir kısmını bahsettiğim fikirleri onun ağzından dinleyebilirsiniz.",
                " Açıkçası bu fikirler kadar olmasa da beni etkileyen şu kısma da değinerek yazıyı tamamlamış olayım.",
                " Reşad Halife de gördüğüm durumlar şunlar.",

                " Bu adamın çok baskın bir tevhid anlayışı var. Allah'ı çok farklı ve güzel ve Kurandan referanslar ile anlatıyor.",
                " Sıradan bir yurdum insanıyım. Allah hakkında bir sürü hikaye dinledim. Kuran okudukça fark ediyorum ki bu hikayelerin çoğu Kurandan değilmiş.",
                (b)" Zihninizdeki Allah ile gerçekteki Allah farklı olabilir. Dolayısı ile Allah'ı Kuran üzerinden tanımak mecburiyetindeyiz. ",
                " Bu konuda Reşad oldukça iyi bir eğitmen. Tevhid mesajını en yüksek tonda seslendirmeye çalışan biri.",

                " Dinden kazanç sağlamıyor olması benim için önemli. Kazanç sadece para ile olmaz. Bazen şöhret ile de olur. ",
                " 19 sistemini ilk bulduğunda popülaritesi varken istese bu fikirlerini pek duyurmayıp o popülaritenin kaymağını yiyebilirdi.",
                " Fakat o tam tersini yapıyor. Emeklilik parası ile gidip mescit kuruyor. ",
                " Hadisleri dinin kaynağı olarak görmediğini ve dinin tek kaynağının Kuran olduğunu üzerine basa basa tekrarlıyor.",
                " Bu uğurda şöhreti elden gidiyor. Ölüm tehditleri aldığı halde geri adım atmıyor. Hatta bir videoda kamera yanlışlıkla kayıyor arkasında toplamda 10 kişilik bir saf bile yok.",
                " Zaten bu fikirleri yüzünden de 55 yaşında sabah namazında öldürülüyor.",

                br,
                br,
                "Elimden geldiğince bu adamın ne söylediğini anlatmaya çalıştım. Belki benim bakışımda hata vardır, Belki yanlış anlamışımdır. " +
                " Fırsatınız var ise bu bilgileri lütfen kendiniz teyit ediniz."
            }
        };
    }
}