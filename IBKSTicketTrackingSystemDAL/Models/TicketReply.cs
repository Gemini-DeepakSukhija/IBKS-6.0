namespace IBKSTicketTrackingSystemDAL.Models;

/// <summary>
/// Imported class as replica of "TicketReply" table
/// </summary>
public partial class TicketReply
{
    public int ReplyId { get; set; }

    public long Tid { get; set; }

    public string? Reply { get; set; }

    public DateTime ReplyDate { get; set; }
}
