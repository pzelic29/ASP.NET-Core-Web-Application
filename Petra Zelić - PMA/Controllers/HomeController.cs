using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Petra_Zelić___PMA.Models;

namespace Petra_Zelić___PMA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // za logiranje i registraciju
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly SignInManager<IdentityUser> _signInManager;  


        public HomeController(ILogger<HomeController> logger,
                UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // login
        public IActionResult Login() // ovo prikazuje samo stranicu(view za logiranje)
        {
            return View();
        }


        [HttpPost]  // ovo se odnosi na samo logiranje
        public async Task<IActionResult> Login(string email, string password) 
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var SignInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (SignInResult.Succeeded)
                {
                    return RedirectToAction("Film", "Film", new { area = "" });
                }
            }

            //ako ne postoji taj korisnik onda ga odvedi na page za registraciju
            return RedirectToAction("Register");
        }


        // register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string username, string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var SignInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (SignInResult.Succeeded)
                {
                    return RedirectToAction("Film", "Film", new { area = "" });
                    //return RedirectToAction("Film");
                }
            }

            return RedirectToAction("Register");
        }


        // logout
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
