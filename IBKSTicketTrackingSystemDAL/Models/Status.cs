using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemDal.Models
{
    public partial class Status
    {
        public Status()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
