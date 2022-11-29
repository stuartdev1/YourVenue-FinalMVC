using System;
using System.Collections.Generic;

#nullable disable

namespace YourVenue_Final.Models
{
    public partial class Host
    {
        public Host()
        {
            Messages = new HashSet<Message>();
            Venues = new HashSet<Venue>();
        }

        public long HostID { get; set; }
        public string HostFirstName { get; set; }
        public string HostLastName { get; set; }
        public long? HostPhone { get; set; }
        public string HostAddressLine1 { get; set; }
        public string HostCity { get; set; }
        public string HostState { get; set; }
        public string HostEmail { get; set; }
        public string HostZip { get; set; }
        public DateTime? LastActivity { get; set; }
        public string LastActivityUserID { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Venue> Venues { get; set; }
    }
}
