﻿namespace IBKSTicketTrackingSystemDal.Models;

/// <summary>
/// Imported class as replica of "TicketType" table
/// </summary>
public partial class TicketType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
