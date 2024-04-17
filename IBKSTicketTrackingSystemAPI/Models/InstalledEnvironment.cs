using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemAPI.Models
{
    public partial class InstalledEnvironment
    {
        public InstalledEnvironment()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
