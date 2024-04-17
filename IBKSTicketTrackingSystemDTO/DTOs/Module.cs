namespace IBKSTicketTrackingSystemDTO.DTOs
{
    /// <summary>
    /// Data transfer class for modules, data fetching from "Ticket" table
    /// </summary>
    public class Module
    {
        /// <summary>
        /// Id as in DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title as in DB
        /// </summary>
        public string Title { get; set; }
    }
}
