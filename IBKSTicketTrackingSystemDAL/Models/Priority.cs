using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemDal.Models
{
    public partial class Priority
    {
        public Priority()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ColorCode { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
