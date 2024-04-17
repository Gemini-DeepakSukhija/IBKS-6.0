namespace IBKSTicketTrackingSystemDAL.Models;

/// <summary>
/// Imported class as replica of "LogType" table
/// </summary>
public partial class LogType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<TicketEventLog> TicketEventLogs { get; set; } = new List<TicketEventLog>();
}
