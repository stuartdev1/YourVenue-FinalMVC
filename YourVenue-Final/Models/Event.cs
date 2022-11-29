using System;
using System.Collections.Generic;

#nullable disable

namespace YourVenue_Final.Models
{
    public partial class Event
    {
        public long? EventID { get; set; }
        public long? CustomerID { get; set; }
        public long? VenueID { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
