# Ürün Yönetimi
Projede iki adet ana uç bulunuyor. 
Bunlardan bir tanesi Kategori ve Ürün yönetimini gerçekleştirdiğimiz Admin Panel. 
Bir diğeri ise Admin Panel üzerinden girilen ürün bilgilerini görüntüleyen Web arayüzü. 
İki proje de ASP.NET MVC Framework ile geliştirildi. 
Bunların dışında Solution içerisinde Data ve Core adında iki katman daha bulunuyor. 
Bu katmanlar üzerinden gerekli soyutlama işemlerini de yaparak katmanlı bir mimari tasarlandı. 
Projenin altyapısı bu şekilde hazırlanmış oldu.

Yönetim panelinden ürün ile ilgili işlemler, ayarlamalar yapılıyor. 
Ön yüzden ise oluşturulmuş ürünler görüntüleniyor. 
Böylece yönetilebilir bir içerik sistemi oluşturduk. 
Ürünlerimizi MSSQL SERVER üzerinde barındırıp,
veriye Entity Framework teknolojisini kullanarak eriştik. 
Ayrıca bu tarz projelerde genelde tercih edilen bir yöntem olan katmanlı mimari ile geliştirildi 
ve proje bu prensip doğrultusunda gerçekleştirildi.
