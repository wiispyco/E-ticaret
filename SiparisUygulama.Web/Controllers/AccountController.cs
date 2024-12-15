using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiparisUygulama.Contract.DataContract.Dto;
using SiparisUygulama.Contract.DataContract.Model;
using SiparisUygulama.Data.Entity;
using SiparisUygulama.Web.Models.Login;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SiparisUygulama.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly Business.IAuthenticationService _authenticationService;
        public AccountController(Business.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private int GetUserId()
        {
            var userId = User.Identity.IsAuthenticated && User.Claims.Any(m => m.Type == "UserId") ? int.Parse(User.Claims.FirstOrDefault(m => m.Type == "UserId").Value) : 0;
            return userId;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
             SignUpViewModel model = new SignUpViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Signup(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto()
                {
                    Name = model.Name,
                    Email = model.Mail,
                    Password = model.Password,
                    Adress = model.Adress,
                    RoleId = model.RoleId.Value,
                };

                var userCreated = _authenticationService.CreateUser(userDto);
                if (!userCreated.hasError)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    model.ErrorMessages = new List<string>() { userCreated.message };
                }
            }
            else
            {
                model.ErrorMessages = new List<string>() { "Lütfen bilgilerinizi kontrol edin!" };
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            // Google reCAPTCHA doğrulaması
            var recaptchaResponse = Request.Form["g-recaptcha-response"];
            var isCaptchaValid = await IsCaptchaValid(recaptchaResponse);

            if (!isCaptchaValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen reCAPTCHA doğrulamasını tamamlayınız.");
                return View(loginViewModel);
            }


            var authenticationRequestModel = new AuthenticationRequest()
            {
                Email = loginViewModel.Mail,
                Password = loginViewModel.Password,
            };
            var loginResponse = _authenticationService.AuthenticateUser(authenticationRequestModel);
            if (loginResponse.IsAuthenticated)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,loginResponse.Username),
                    new Claim("UserId",loginResponse.UserId.ToString()),
                    new Claim("UserFullName",loginResponse.FullName),
                    new Claim(ClaimTypes.Role,loginResponse.RoleName),
                    new Claim("RestaurantId",loginResponse.RestaurantId?.ToString()??"0"),
                };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                if (loginResponse.RoleName == "RestaurantOwner")
                {
                    return RedirectToAction("Index", "Restaurant");
                }
                else
                {
                    return RedirectToAction("Index", "RestaurantFood");
                }

            }

            loginViewModel.ErrorMessages = new List<string>() { "Girdiğiniz bilgileri kontrol ediniz!" };

            return View(loginViewModel);
        }

        private async Task<bool> IsCaptchaValid(string recaptchaResponse)
        {
            var secretKey = "6LcxriUqAAAAAEUfYqt5Lj4wfzScg8CK0pemKDJT";
            var client = new HttpClient();

            var result = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaResponse}");

            var captchaResult = JsonConvert.DeserializeObject<ReCaptchaResponse>(result);

            return captchaResult.Success;
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult IsAuthenticated()
        {
            return Json(User.Identity.IsAuthenticated);
        }
    }
}
