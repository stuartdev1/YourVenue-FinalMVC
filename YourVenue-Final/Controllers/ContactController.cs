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

       
        public ActionResult Contact()
        {
            
            return View();
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
            else
            {
                NewContact.Name = Name;
                NewContact.Email = Email;
                NewContact.Subject = Subject;
                NewContact.Message = Message;
                




                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddContact(NewContact);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateContact(NewContact);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteContact(NewContact);
                }
            }
            return View();
        }

        public Contact AddContact(Contact NewContact)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Contacts.Add(NewContact);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Contact added successfully" };
            return NewContact;
        }

        public Contact UpdateContact(Contact NewContact)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Contacts.Update(NewContact);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Contact updated successfully" };
            return NewContact;
        }

        public Contact DeleteContact(Contact NewContact)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Contacts.Remove(NewContact);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Customer deleted successfully" };
            return NewContact;
        }
    }
}


