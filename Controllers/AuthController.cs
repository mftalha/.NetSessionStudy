using Microsoft.AspNetCore.Mvc;
using Session.Extensions;
using Session.Models;

namespace Session.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel) 
        {
            if(loginModel.Email == "talha.satir0729@gmail.com" && loginModel.Password == "1234")
            {
                // Not: eğerki sesion dan veri'yi okuma üstüne yazma gibi bir işlem yapılmaz ise ilgili veri 20 dakika sonra sesion'dan otomatik silinir.

                // Session İşlemi
                // bu işlemden önce : program.cs de session tanımlamalarını yapmalıyım yoksa hata verir.
                //HttpContext.Session.SetString("UserSession", loginModel.Email); -- bu şekilde sesion'a verilebilir. : en temel hali ile. : ama verilecek değerin string olması gerekiyor.

                // bizim yazdığımız extension : bu sayede direk modeli veriyoruz ve => model içindeki verilerin string olmasınada gerek kalmıyor.
                HttpContext.Session.Set<LoginModel>("UserSession", loginModel);

                HttpContext.Session.Set<string>("StringTest", "string icerikdir.");
                HttpContext.Session.Set<int>("IntTest", 444);

                //Intex Home yönlendir.
                return RedirectToAction("Index", "Home");
            }
            // yanlış bilgi giriş durumu : login sayfasına tekrar dönme
            return View();
        }
    }
}
