namespace IBKSTicketTrackingSystemDAL.Models;

/// <summary>
/// Imported class as replica of "Priority" table
/// </summary>
public partial class Priority
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? ColorCode { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
