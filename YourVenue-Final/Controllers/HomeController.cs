using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourVenue_Final.Models;

namespace YourVenue_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your username!" };
            }
            else
             if (string.IsNullOrEmpty(password))
            {
                ViewData["ErrorList"] = new List<string> { "Please enter your password!" };
            }
            else
            {
                DemoContext demoContext = new DemoContext();

                Customer searchcustomers = demoContext.Customers.Where(x => x.Email == username && x.Password == password).FirstOrDefault();

                if (searchcustomers != null)
                {
                    var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, searchcustomers.Role)
                };
                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principle, props).Wait();
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewData["ErrorList"] = new List<string> { "User not found" };
                    return View();
                }
            }
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
