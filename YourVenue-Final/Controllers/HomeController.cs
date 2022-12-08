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

        [HttpPost]

        public ActionResult ListRegistration(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {
            string Email = formColl["Email"];
            string Firstname = formColl["Firstname"];
            string Lastname = formColl["Lastname"];
            string DOB = formColl["DOB"];
            string Addressline1 = formColl["Addressline1"];
            string Addressline2 = formColl["Addressline2"];
            string City = formColl["City"];
            string State = formColl["State"];
            string Zip = formColl["Zip"];
            string Phone = formColl["Phone"];
            string Psw = formColl["Pws"];
            string Psw_repeat = formColl["Psw_repeat"];

            string AddButton = formColl["AddButton"];
            string UpdateButton = formColl["UpdateButton"];
            string DeleteButton = formColl["DeleteButton"];

            Customer NewUser = new Customer();

            if (string.IsNullOrEmpty(Email))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your email:" };
            }
            else
            if (string.IsNullOrEmpty(Firstname))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your first name:" };
            }
            else
            if (string.IsNullOrEmpty(Lastname))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your last name:" };
            }
            else
            if (string.IsNullOrEmpty(DOB))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter DOB:" };
            }
            else
            if (string.IsNullOrEmpty(Addressline1))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter address line 1:" };
            }
            else
            if (string.IsNullOrEmpty(Addressline2))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter address line 2" };
            }
            else
            if (string.IsNullOrEmpty(City))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your city:" };
            }
            else
            if (string.IsNullOrEmpty(State))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your state:" };
            }
            else
            if (string.IsNullOrEmpty(Zip))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your zip:" };
            }
            else
            if (string.IsNullOrEmpty(Phone))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your phone number:" };
            }
            else
            if (string.IsNullOrEmpty(Psw))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter your password:" };
            }
            else
            if (string.IsNullOrEmpty(Psw_repeat))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please repeat your password:" };
            }
            {
                NewUser.Email = Email;
                NewUser.CustomerFirstName= Firstname;
                NewUser.CustomerLastName= Lastname;
                NewUser.CustomerDOB = DateTime.Parse(DOB);
                NewUser.AddressLine1 = Addressline1;
                NewUser.AddressLine2 = Addressline2;
                NewUser.City = City;
                NewUser.State = State;
                NewUser.Zip = Zip;
                NewUser.Phone = Phone;
                NewUser.Password = Psw;


                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddCustomer(NewUser);
                }
            }
            return View();
        }

        public Customer AddCustomer(Customer NewCustomer)
        {
            NewCustomer.CustomerID = 0;
            DemoContext demoContext = new DemoContext();
            demoContext.Customers.Add(NewCustomer);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Event added successfully" };
            return NewCustomer;
        }
        public Event AddEvent(Event NewEvent)
        {
            NewEvent.EventID = 0;
            DemoContext demoContext = new DemoContext();
            demoContext.Events.Add(NewEvent);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Event added successfully" };
            return NewEvent;
        }

        public Event UpdateEvent(Event NewEvent)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Events.Update(NewEvent);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Event updated successfully" };
            return NewEvent;
        }

        public Event DeleteEvent(Event NewEvent)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Events.Remove(NewEvent);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Event deleted successfully" };
            return NewEvent;
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
