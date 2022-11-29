using System;
using System.Collections.Generic;

#nullable disable

namespace YourVenue_Final.Models
{
    public partial class Venue
    {
        public long VenueID { get; set; }
        public long? VenueHostID { get; set; }
        public string VenueName { get; set; }
        public long? VenuePhone { get; set; }
        public string VenueAddress { get; set; }
        public string VenueCity { get; set; }
        public string VenueState { get; set; }

        public virtual Host VenueHost { get; set; }
    }
}
