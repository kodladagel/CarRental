using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameInValid = "Araba ismi geçersiz.";

        public static string CarAdded = "Araba eklendi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarsListed = "Arabalar listelendi.";
        
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandsListed = "Markalar listelendi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorsListed = "Renkler listelendi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomersListed = "Müşteriler listelendi.";

        public static string RentalInvalid = "Araba kirada.";

        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalsListed = "Kiralamalar listelendi.";

        public static string ImageAdded = "Resim eklendi.";
        public static string ImageUpdated = "Resim güncellendi.";
        public static string ImageDeleted = "Resim silindi.";
        public static string ImageLimitExceded = "Resim limiti aşıldı.";

        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string PasswordError = "Parola hatası";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kayıt oldu";

        public static string MaintenanceTime = "Sistem bakımda";
    }
}
