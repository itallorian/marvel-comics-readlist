using MARVEL.COMICS.BUSINESSLOGIC.Interfaces.Models;
using MARVEL.COMICS.BUSINESSLOGIC.Utils;
using MARVEL.COMICS.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MARVEL.COMICS.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserModel _userModel;

        public HomeController(IUserModel userModel)
        {
            _userModel = userModel;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/comics");
            }

            return View();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel viewModel)
        {
            try
            {
                var user = await _userModel.Login(viewModel.UserName, viewModel.Password.ToEncryptedPassword());

                if (user.Success == true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.User.Id.ToString()),
                        new Claim(ClaimTypes.Sid, user.User.Name),
                        new Claim(ClaimTypes.Actor, user.User.UserName),
                        new Claim(ClaimTypes.Role, "User")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "User");

                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync("User", new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ErrorMessage = user.Message;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("User");

            return RedirectToAction(nameof(Login));
        }
    }
}
