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
    public class EventController : Controller
    {
        [HttpGet]
        public ActionResult ListEvent(string ID)
        {
            DemoContext demoContext = new DemoContext();
            Event searchEvent = new Event();

            if (!string.IsNullOrEmpty(ID))
            {
                searchEvent = demoContext.Events.Where(x => x.EventID.ToString() == ID).FirstOrDefault();
            }
            if (searchEvent == null)
            {
                ViewData["ErrorMessage"] = new List<string> { "Event ID not found" };
                searchEvent = new Event();
            }
            return View(searchEvent);
        }
        [HttpPost]
        public ActionResult ListEvent(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {
            string EventName = formColl["EventName"];
            string EventDate = formColl["EventDate"];
            string EventID = formColl["EventID"];
            string CustomerID = formColl["CustomerID"];
            string VenueID = formColl["VenueID"];

            string AddButton = formColl["AddButton"];
            string UpdateButton = formColl["UpdateButton"];
            string DeleteButton = formColl["DeleteButton"];

            Event NewEvent = new Event();

            if (string.IsNullOrEmpty(EventName))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter event name" };
            }
            else
            if (string.IsNullOrEmpty(EventDate))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter event date" };
            }
            else
            if (string.IsNullOrEmpty(EventID))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter event ID" };
            }
            else
            if (string.IsNullOrEmpty(CustomerID))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer ID" };
            }
            else
            if (string.IsNullOrEmpty(VenueID))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter venue ID" };
            }
            else
            {
                NewEvent.EventName = EventName;
                NewEvent.EventDate = DateTime.Parse(EventDate);
                NewEvent.EventID = long.Parse(EventID);
                NewEvent.CustomerID = long.Parse(CustomerID);
                NewEvent.VenueID = long.Parse(VenueID);




                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddEvent(NewEvent);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateEvent(NewEvent);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteEvent(NewEvent);
                }
            }
            return View();
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
    }
}

