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
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult ListCustomer(string ID)
        {
            DemoContext demoContext = new DemoContext();
            Customer searchCustomer = new Customer();

            if (!string.IsNullOrEmpty(ID))
            {
                searchCustomer = demoContext.Customers.Where(x => x.CustomerID.ToString() == ID).FirstOrDefault();
            }
            if (searchCustomer == null)
            {
                ViewData["ErrorMessage"] = new List<string> { "Customer ID not found" };
                searchCustomer = new Customer();
            }
            return View(searchCustomer);
        }
        [HttpPost]
        public ActionResult ListCustomer(Microsoft.AspNetCore.Http.IFormCollection formColl)
        {
            string CustomerFirstName = formColl["Customer First Name"];
            string CustomerLastName = formColl["Customer Last Name"];
            string CustomerDOB = formColl["Customer Date of Birth"];
            string CustomerAddressLine1 = formColl["Customer Address Line 1"];
            string CustomerAddressLine2 = formColl["Customer Address Line 2"];
            string CustomerCity = formColl["Customer City"];
            string CustomerState = formColl["Customer State"];
            string CustomerZip = formColl["Customer Zip"];
            string CustomerPhone = formColl["Customer Phone"];
            string CustomerLastActivity = formColl["Customer Last Activity"];
            string CustomerEmail = formColl["Customer Email"];


            string AddButton = formColl["AddButton"];
            string UpdateButton = formColl["UpdateButton"];
            string DeleteButton = formColl["DeleteButton"];

            Customer NewCustomer = new Customer();

            if (string.IsNullOrEmpty(CustomerFirstName))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer first name" };
            }
            else
            if (string.IsNullOrEmpty(CustomerLastName))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer last name" };
            }
            else
            if (string.IsNullOrEmpty(CustomerDOB))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer date of birth" };
            }
            else
            if (string.IsNullOrEmpty(CustomerAddressLine1))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer address line 1" };
            }
            else
            if (string.IsNullOrEmpty(CustomerAddressLine2))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer address line 2" };
            }
            else
            if (string.IsNullOrEmpty(CustomerCity))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer city" };
            }
            else
            if (string.IsNullOrEmpty(CustomerState))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer state" };
            }
            else
            if (string.IsNullOrEmpty(CustomerZip))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer zip" };
            }
            else
            if (string.IsNullOrEmpty(CustomerPhone))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer phone number" };
            }
            else
            if (string.IsNullOrEmpty(CustomerLastActivity))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer last activity" };
            }
            else
            if (string.IsNullOrEmpty(CustomerEmail))
            {
                ViewData["ErrorMessage"] = new List<string> { "Please enter customer email" };
            }
            else
            {
            
                NewCustomer.CustomerFirstName = CustomerFirstName;
                NewCustomer.CustomerLastName = CustomerLastName;
                NewCustomer.AddressLine1 = CustomerAddressLine1;
                NewCustomer.AddressLine2 = CustomerAddressLine2;
                NewCustomer.City = CustomerCity;
                NewCustomer.State = CustomerState;
                NewCustomer.Zip = CustomerZip;
                //NewCustomer.Phone = long.Parse(CustomerPhone);
                NewCustomer.Email = CustomerEmail;
               




                if (!string.IsNullOrEmpty(AddButton))
                {
                    AddCustomer(NewCustomer);
                }
                else
                if (!string.IsNullOrEmpty(UpdateButton))
                {
                    UpdateCustomer(NewCustomer);
                }
                else
                if (!string.IsNullOrEmpty(DeleteButton))
                {
                    DeleteCustomer(NewCustomer);
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
            ViewData["SuccessMessage"] = new List<string> { "Customer added successfully" };
            return NewCustomer;
        }

        public Customer UpdateCustomer(Customer NewCustomer)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Customers.Update(NewCustomer);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Customer updated successfully" };
            return NewCustomer;
        }

        public Customer DeleteCustomer(Customer NewCustomer)
        {
            DemoContext demoContext = new DemoContext();
            demoContext.Customers.Remove(NewCustomer);
            demoContext.SaveChanges();
            ViewData["SuccessMessage"] = new List<string> { "Customer deleted successfully" };
            return NewCustomer;
        }
    }
}


        
