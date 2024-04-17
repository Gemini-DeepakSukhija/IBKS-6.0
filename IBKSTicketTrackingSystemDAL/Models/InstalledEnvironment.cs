namespace IBKSTicketTrackingSystemDAL.Models;

/// <summary>
/// Imported class as replica of "InstalledEnvironment" table
/// </summary>
public partial class InstalledEnvironment
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
