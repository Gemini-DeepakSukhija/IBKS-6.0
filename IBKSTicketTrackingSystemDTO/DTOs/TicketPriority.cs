namespace IBKSTicketTrackingSystemDTO.DTOs
{
    /// <summary>
    /// Data transfer class to set priority of tickets
    /// </summary>
    public class TicketPriority
    {
        /// <summary>
        /// Id as in DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title as in DB
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ColorCode as in DB
        /// </summary>
        public string? ColorCode { get; set; }
    }
}
