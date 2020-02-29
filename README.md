# A-Star-Algorimasi-8-Bulmacasi
C# ile A* (Star) Algoritması kullanarak 8 Taş Bulmacasını çözmek

<!-- wp:paragraph -->
<p>A star algoritması sezgisel bilgileri kullanarak bir durumdan bir amaca ulaşmaktır. Bu amaç duruma ulaşmak için minimum yolun bulunmasında daha az tarama yapmaya olanak tanımalıdır.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>İyi seçilmiş bir sezgisel fonksiyon ile çok az dallanma yaparak hedefe yaklaşabiliriz.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":269,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak1.jpg" alt="" class="wp-image-269"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Bu görselde yeşil kutudan kırmızı kutuya gitmeye çalışalım. Ancak kutuların ortasında bir duvar olsun. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Öncelikle yeşil kutudan başlayarak çevre alanları taramaya başlayacağız. Daha sonra taradığımız alanları açık bir listeye ekleyeceğiz. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Eğer karenin çevresinde duvar var ise bunu listeye eklemeyeceğiz.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Daha sonra ise başlangıç karesini kapalı bir listeye ekleyeceğiz.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":271,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak2-1.jpg" alt="" class="wp-image-271"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Yukarıdaki görsel gibi çevresini tarayacağız.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Daha sonra açık listeye eklediğimiz kareleri her birisini <strong>F = G + H</strong> denklemi ile en küçük F değerini seçeceğiz. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>G = Başlangıç noktasına göre yoldur.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>H = Amacımıza ulaşmak için tahmini bir değerdir. (Heuristic) Tahmin</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>F değerinin en küçüğünü seçeceğiz çünkü o yol bizi kısadan amacımıza ulaştıracaktır.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Her kare hareketi için 10'ar puan diyelim. Köşegen üzerinde yapılan çaprak hareket 14 puandır (10*kök(2))</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":272,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak3.jpg" alt="" class="wp-image-272"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Yani ilk kutumuzu ele alırsak üstteki gibi bir sonuç çıkacaktır. Sol üst F değeri Sol alt G değeri sağ alt H değeridir.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":273,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak4.jpg" alt="" class="wp-image-273"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Bu değerlere baktığımızda F değerinin en küçüğüne gideceği için kutumuz sağa gitmelidir.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":274,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak5.jpg" alt="" class="wp-image-274"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Daha sonra aşağı aşağı gidecektir. Fakat bir kısa yolumuz daha vardır. Direk F 40 olan yere gitmek yerine çaprazdaki 54 değerine sahip olan kutuya gitmek bizi daha kısadan götürecektir.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":275,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak6.jpg" alt="" class="wp-image-275"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Şu şekilde bir soru olabilir. Öncelikle F 54'e gidiyoruz daha sonra aşağı 74 gidiyoruz ama çapraz gitsek daha kısa olabilir denilebilir fakat duvar buna engel olacaktır. Kutu şeklinde hareket edeceği için önce aşağı sonra sağa gitmeliyiz.</p>
<!-- /wp:paragraph -->

<!-- wp:heading -->
<h2>A Star Algoritması Mantığı Özeti</h2>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>Başlangıç karesini açık listeye ekle.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Çevresini dolaş en küçük F değerli kareyi bul. Seçilen kareyi kapalıya ekle.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Seçili kare için aynı şekilde yap. Duvar gibi engellere bakma.</p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Eğer amacımız gerçekleşirse yol bulunmuştur. </p>
<!-- /wp:paragraph -->

<!-- wp:heading -->
<h2>8 Taş Bulmacası</h2>
<!-- /wp:heading -->

<!-- wp:paragraph -->
<p>8 Taş bulmacasını da A* algoritması ile çözebiliriz. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Buradaki maliyetimiz her hareket için 1'dir.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":277,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak7.jpg" alt="" class="wp-image-277"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Üstteki gibi bir başlangıcımız var ve bir amacımız var. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Boş olan kareyi hareket ettirmemiz gerekiyor. </p>
<!-- /wp:paragraph -->

<!-- wp:paragraph -->
<p>Sadece yukarı, aşağı, sağa , sola hareket ettirebiliriz.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":278,"align":"center"} -->
<div class="wp-block-image"><figure class="aligncenter"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak8.jpg" alt="" class="wp-image-278"/></figure></div>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Üstteki fotoğraftaki gibi hareketler yaparak sonuca ulaşabiliriz.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":279} -->
<figure class="wp-block-image"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak9.jpg" alt="" class="wp-image-279"/></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>C# ile yapmış olduğum programda başlangıç durumu ve amaç durumu 2 tane kullanıcının girmesi için beklenen yer vardır ve ',' ile ayrılmalıdır.</p>
<!-- /wp:paragraph -->

<!-- wp:image {"id":280} -->
<figure class="wp-block-image"><img src="http://eraykisabacak.com/wp-content/uploads/2020/02/astaralgoritmaAliErayKısabacak10.jpg" alt="" class="wp-image-280"/></figure>
<!-- /wp:image -->

<!-- wp:paragraph -->
<p>Çöz denildiğinde çözdükten sonra animasyonlu olarak '0' yer değiştirecektir. Yer değiştirmeler sağda gösterilir. Yaptığı işlemler en altta yazmaktadır.</p>
<!-- /wp:paragraph -->

<!-- wp:heading {"level":3} -->
<h3>Kodlar:  <a href="https://github.com/eraykisabacak/A-Star-Algorimasi-8-Bulmacasi">https://github.com/eraykisabacak/A-Star-Algorimasi-8-Bulmacasi</a> </h3>
<!-- /wp:heading -->