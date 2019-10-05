using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Portal.Common.Generators;
using Portal.Common.ViewModels.Account;
using Portal.Data.UOW;

namespace Portal.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UnitOfWork _db;
        public AuthController(UnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Profile");
            }
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _db.UsersGenericRepository
                    .Where(u => u.PasswordHash == PasswordHash.HashWithMD5(model.Password)
                    & u.UserName == model.UserName).FirstOrDefault();
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim(ClaimTypes.Name,user.UserName),
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = model.IsRemember
                        };
                        HttpContext.SignInAsync(principal, properties);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "اکانت شما فعال نیست");
                    }
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Username", "اطلاعات وارد شده صحیح نمی باشد");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}