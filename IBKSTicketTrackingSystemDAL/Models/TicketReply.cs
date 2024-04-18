﻿using System;
using System.Collections.Generic;

namespace IBKSTicketTrackingSystemDal.Models
{
    public partial class TicketReply
    {
        public int ReplyId { get; set; }
        public long Tid { get; set; }
        public string? Reply { get; set; }
        public DateTime ReplyDate { get; set; }
    }
}
