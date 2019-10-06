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
using Portal.Domain.Entities;
using Portal.Services.Interfaces;
using Portal.Services.Sender;

namespace Portal.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UnitOfWork _db;
        private readonly ISender _sender;

        public AuthController(UnitOfWork db)
        {
            _sender = new EmailSender();
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

        [HttpGet]
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_db.UsersGenericRepository.Where(u => u.UserName == model.Username).Any())
                {
                    model.Username = null;
                    ModelState.AddModelError("Mobile", "چنین شماره ای وجود دارد");
                    return View(model);
                }
                Users user = new Users
                {
                    IsActive = false,
                    UserName = model.Username,
                    ActiveCode = CodeGenerator.EmailCode(),
                    PasswordHash = PasswordHash.HashWithMD5(model.Password),
                    RoleId = 2,

                };
                _db.UsersGenericRepository.Insert(user);
                _db.SaveAsync();
                string messageBody = "کد فعالسازی شما :" + user.ActiveCode;
                _sender.SendAsync(user.Email, messageBody);
                return RedirectToAction("ActivateAccount");
            }
            else
            {
                return View(model);
            }
        }
    }
}