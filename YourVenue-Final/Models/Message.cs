using System;
using System.Collections.Generic;

#nullable disable

namespace YourVenue_Final.Models
{
    public partial class Message
    {
        public long MessageID { get; set; }
        public long SenderID { get; set; }
        public long ReceiverID { get; set; }
        public string MessageBody { get; set; }
        public DateTime TimeSent { get; set; }

        public virtual Host Receiver { get; set; }
        public virtual Customer Sender { get; set; }
    }
}
