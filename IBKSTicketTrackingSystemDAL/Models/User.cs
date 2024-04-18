namespace IBKSTicketTrackingSystemDal.Models;

/// <summary>
/// Imported class as replica of "User" table
/// </summary>
public partial class User
{
    public string Oid { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public DateTime? LastScannedUtc { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
