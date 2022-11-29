using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourVenue_Final.Controllers
{
    public class Venue : Controller
    {
        [HttpGet]
        public ActionResult ListVenue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ListVenue(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {
            string VenueName = formColl["asdfg"];
            string VenuePhone = formColl["asdfg"];
            string VenueAddress = formColl["asdfg"];
            string VenueCity = formColl["asdfg"];
            string VenueState = formColl["asdfg"];

            Venue NewVenue = new Venue();

            if (string.IsNullOrEmpty(VenueName))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter venue name" };
            }
            else
            if (string.IsNullOrEmpty(VenuePhone))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter venue phone" };
            }
            else
            if (string.IsNullOrEmpty(VenueAddress))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter venue address" };
            }
            else
            if (string.IsNullOrEmpty(VenueCity))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter venue city" };
            }
            else
            if (string.IsNullOrEmpty(VenueState))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter venue state" };
            }
            else
            {
                //Ill figure this out IDK whats wrong
                NewVenue = new Venue();
                NewVenue.VenueName = VenueName;

                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddCustomer(MyCustomer);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateCustomer(MyCustomer);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteCustomer(MyCustomer);
                }
            }
            return View();
        }
    }
}
