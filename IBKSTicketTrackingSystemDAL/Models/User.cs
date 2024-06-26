﻿using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemDal.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Oid { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public DateTime? LastScannedUtc { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
