using System;
using System.Collections.Generic;

#nullable disable

namespace YourVenue_Final.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Messages = new HashSet<Message>();
        }

        public long CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime? CustomerDOB { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public DateTime? LastActivity { get; set; }
        public string LastActivityUserID { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
