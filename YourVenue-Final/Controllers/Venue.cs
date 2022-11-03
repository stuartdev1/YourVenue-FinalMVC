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
        // GET: Venue
        public ActionResult ListVenue()
        {
            return View();
        }
    }
}
