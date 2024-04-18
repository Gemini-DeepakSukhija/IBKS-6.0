using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemDal.Models
{
    public partial class LogType
    {
        public LogType()
        {
            TicketEventLogs = new HashSet<TicketEventLog>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<TicketEventLog> TicketEventLogs { get; set; }
    }
}
