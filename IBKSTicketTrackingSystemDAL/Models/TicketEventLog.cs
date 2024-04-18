namespace IBKSTicketTrackingSystemDal.Models;

/// <summary>
/// Imported class as replica of "TicketEventLog" table
/// </summary>
public partial class TicketEventLog
{
    public long Id { get; set; }

    public int LogTypeId { get; set; }

    public long TicketId { get; set; }

    public int UserId { get; set; }

    public DateTime EventDt { get; set; }

    public string? Message { get; set; }

    public virtual LogType LogType { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
