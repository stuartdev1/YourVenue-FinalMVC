using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourVenue_Final.Models;

namespace YourVenue_Final.Controllers
{
    [Authorize]
    public class VenueController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {

            string VenueName = formColl["VenueName"];
            string VenuePhone = formColl["VenuePhone"];


            DemoContext demoContext = new DemoContext();
            List<Venue> searchVenues = new List<Venue>();

            if (!string.IsNullOrEmpty(VenueName))
            {
                searchVenues = demoContext.Venues.Where(x => x.VenueName.ToString() == VenueName).ToList();
            }
            else
            if (!string.IsNullOrEmpty(VenuePhone))
            {
                searchVenues = demoContext.Venues.Where(x => x.VenuePhone.ToString() == VenuePhone).ToList();
            }
   
            else
            {
                ViewData["ErrorMessage"] = new List<string> { "showing the list of all venues, no search criteria was selected" };
                searchVenues = demoContext.Venues.ToList();
            }
            return View(searchVenues);
        }

        [HttpGet]
        public ActionResult ListVenue(string ID)
        {
            DemoContext demoContext = new DemoContext();
            Venue searchVenue = new Venue();

            if (!string.IsNullOrEmpty(ID))
            {
                searchVenue = demoContext.Venues.Where(x => x.VenueID.ToString() == ID).FirstOrDefault();
            }
            if (searchVenue == null)
            {
                ViewData["ErrorMessage"] = new List<string> { "Venue ID not found" };
                searchVenue = new Venue();
            }
            return View(searchVenue);
        }
        [HttpPost]
        public ActionResult ListVenue(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {
            string VenueName = formColl["VenueName"];
            string VenuePhone = formColl["VenuePhone"];
            string VenueAddress = formColl["VenueAddress"];
            string VenueCity = formColl["VenueCity"];
            string VenueState = formColl["VenueState"];

            string AddButton = formColl["AddButton"];
            string UpdateButton = formColl["UpdateButton"];
            string DeleteButton = formColl["DeleteButton"];

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
                NewVenue.VenueName = VenueName;
                NewVenue.VenuePhone = long.Parse(VenuePhone);
                NewVenue.VenueAddress = VenueAddress;
                NewVenue.VenueName = VenueCity;
                NewVenue.VenueName = VenueState;




                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddVenue(NewVenue);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateVenue(NewVenue);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteVenue(NewVenue);
                }
            }
            return View();
        }
        public Venue AddVenue(Venue NewVenue)
        {
            NewVenue.VenueID = 0;
            DemoContext demoContext = new DemoContext();
            demoContext.Venues.Add(NewVenue);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Venue added successfully" };
            return NewVenue;
        }

        public Venue UpdateVenue(Venue NewVenue)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Venues.Update(NewVenue);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Venue updated successfully" };
            return NewVenue;
        }

        public Venue DeleteVenue(Venue NewVenue)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Venues.Remove(NewVenue);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Venue deleted successfully" };
            return NewVenue;
        }
    }
}
