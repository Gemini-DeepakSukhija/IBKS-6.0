namespace IBKSTicketTrackingSystemDTO.DTOs
{
    /// <summary>
    /// Data transfer class with information of ticket types
    /// </summary>
    public class TicketType
    {
        /// <summary>
        /// Id of ticket type as in DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of ticket type as in DB
        /// </summary>
        public string Title { get; set; }
    }
}
