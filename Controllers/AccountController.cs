using BoniboNews.Data.Repositories;
using BoniboNews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BoniboNews.DateTime;

namespace BoniboNews.Controllers
{
    public class AccountController : Controller
    {
        #region Context
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userRepository.IsExistUserByUserName(register.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده قبلا در سایت ثبت نام کرده است");
                return View(register);
            }

            Users users = new Users()
            {
                UserName = register.UserName,
                Password = register.Password,
                IsAdmin = false,
                RegisterDate = PersianDate.Persian()
            };
            _userRepository.AddUser(users);

            return View("SuccessRegister", register);
        }
        #endregion

        #region Login
        public IActionResult login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userRepository.GetUserForLogin(login.UserName.ToLower(), login.Password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "اطلاعات وارد شده صحیح نیست");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principa = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principa, properties);

            return Redirect("/");
        }
        #endregion

        #region LougOut
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        #endregion
    }
}
