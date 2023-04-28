using Newtonsoft.Json;

namespace Session.Extensions;

    // extension yapabilmek için statik yapıyorum class'ı
    public static class SessionExtension
    {
        // session'ları almak için bu methot.
        // this ISession session : HttpContext.Session.SetString("","") : işleminde Session'un tipi : ISession
        // string key == bir string key alacaz
        // T value => T tipinde bir value alacaz
        public static void Set<T> (this ISession session, string key, T value)
        {
            // session'a sadece string veri atabiliyoruz anladığım kadarıyla ondan string'e çeviriyoruz.
            // JsonConvert.SerializeObject(value) == kendisine ne değer verirsek verelim string json'a dönüştürür.
            // {"email": "emailbilgisi", "password":"1234"} => gibi bir sonuç alacağız. => email(key), emailbilisi:(value) ==> şeklinde sessio'a kayıt yapacak otomatik.
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //session'dan verileri çekmek için.
        //T? => T değeri null dönebilir => default dan dolayı bunu yapmaz isek altını çiziyor. => nullable tipli oluyor : null dönebilir.
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            // eğerki verilen isimde bir sesion yoksa ? verilen türün default değerini döndür. : eğerki var ise girilen değerin type'ı neyse o type'ı döndürerek geri döndür veriyi. => model verdiysek modeli döndürecek.
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }

