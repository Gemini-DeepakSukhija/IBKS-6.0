using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemDal.Models
{
    public partial class TicketType
    {
        public TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
