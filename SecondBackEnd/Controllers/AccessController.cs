using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SecondBackEnd.Models;
using SecondBackEnd.Data;

namespace SecondBackEnd.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccessController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Test modelLogin)
        {
            var status = _db.Tests.Where(m => m.Email == modelLogin.Email && m.Password == modelLogin.Password).FirstOrDefault();
            if (status == null)
            {

                ViewData["ValidateMessage"] = "This Email has not been registerd or the password is incorrect";
                return View();
            }
            else
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")

                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }  
        }
    }
}
