Projemizde ilk olarak wep api .net core olarak oluşturuldu.
Dosyalama sistemi gerçekleştirildi.
-Model
-Services
-Controler
Db modellemede tablo oluşturuldu.
gerekli nuget paketler yuklendi.
Microsoft.EntityFrameworkCore ve Microsoft.EntityFrameworkCore.Tools
Daha sonra gerekli olacak DTO hazırlandı.
Context' de Db set edildi.
UserServices oluşturulup email ve şifre ile login olunarak jwt token oluşturuldu.
Bunun için Nuget jose-jwt yülendi. 
Auto mapper yapıldı bunun için ise AutoMapper.Extensions.Microsoft.DependecyIncejection
yüklendi.
Yapılan Servicesların Controller yazıldı.
Atributtes SkipAuth yakıpısı kullanıdı.
Authorization için bir filtreleme yazıldı.
Dto' lar için mappinProfile yapılarak user modeline bağlandılar.
Startup ayarları yapıldı.
Swager için Swashbucle.AspNetCore yüklendi.
UserServices addScoped edildi.
db için Usemysql bağlantısı yazıldı.
appsetting mysql bağlantıları eklendi ilk başta mssql düzeninde eklemiştim, daha sonra hata alınca onu düzeltim.
Oluşturulan modellemeler sql oluşturulması için Database EnsureCreated yapıldı.
Db bağlantısı için bu arada Pomelo.EntityFramwork.Mysql kullanıldı.
Çalıştırıldığında ilk çalışacağı yer swager olmadığı için Propertiesden düzeltildi.
İlk çalıştırmada login oluyor fakat ChangePassword çalışmıyordu.
_cloadBeryContext null veriliyordu. debuglayıp sorunun UserServicesde _cloadBeryContext context eşitlemediğim anlaşıldı.
ve sorun çözülmüş oldu.
