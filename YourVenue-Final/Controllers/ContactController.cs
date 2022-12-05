using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourVenue_Final.Models;

namespace YourVenue_Final.Controllers
{
    public class ContactController : Controller
    {

        [HttpGet]
        public ActionResult NewContact(string ID)
        {
            DemoContext demoContext = new DemoContext();
            Contact searchContacts = new Contact();

            if (!string.IsNullOrEmpty(ID))
            {
                searchContacts = demoContext.Contacts.Where(x => x.Email.ToString() == ID).FirstOrDefault();
            }
            if (searchContacts == null)
            {
                ViewData["ErrorMessage"] = new List<string> { "Message can not be sent, please try again later" };
                searchContacts = new Contact();
            }
            return View(searchContacts);
        }

        [HttpPost]
        public ActionResult NewContact(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {
            string Name = formColl["Name"];
            string Email = formColl["Email"];
            string Subject = formColl["Subject"];
            string Message = formColl["Message"];
            

            string AddButton = formColl["AddButton"];
            string UpdateButton = formColl["UpdateButton"];
            string DeleteButton = formColl["DeleteButton"];

            Contact NewContact = new Contact();

            if (string.IsNullOrEmpty(Name))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter valid name" };
            }
            else
            if (string.IsNullOrEmpty(Email))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter an email address" };
            }
            else
            if (string.IsNullOrEmpty(Subject))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter message subject" };
            }
            else
            if (string.IsNullOrEmpty(Message))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter message in the box" };
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
