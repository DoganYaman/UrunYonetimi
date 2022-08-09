Proje temelde iki adet ana uç kısımdan oluşuyor. 
Bunlardan bir tanesi Kategori ve Ürün yönetimini gerçekleştirdiğimiz 'Admin' panel. 
Bir diğeri ise Admin panel üzerinden girilen ürün bilgilerini görüntüleyen 'Web' arayüzü oluyor. 
İki proje de ASP.NET MVC Framework ile geliştirildi. 
Bunların dışında sollution içerisinde 'Data' ve 'Core' adında iki katman daha bulunuyor. 
Bu katmanlar üzerinden gerekli soyutlama işemlerini de yaparak katmanlı bir mimari tasarlanmış olundu ve projenin altyapısı bu şekilde hazırlanmış oldu.

Yönetim panelinde ürün ile ilgili işlemler, ayarlamalar yapıldı. 
Ön yüzde ise oluşturulmuş ürünler görüntülendi. Böylece yönetilebilir bir içerik sistemi oluşturuldu. 
Ürünler MSSQL SERVER üzerinde barındırılıp, veriye Entity Framework teknolojisi kullanarak erişildi. 
Ayrıca bu tarz projelerde genelde tercih edilen bir yöntem olan Katmanlı Mimari uyglandı ve proje bu prensip doğrultusunda gerçekleştirildi.
