namespace IBKSTicketTrackingSystemDTO.DTOs
{
    /// <summary>
    /// Data transfer class with only relevent information for tickets 
    /// </summary>
    public class TicketData
    {
        /// <summary>
        /// ID of ticket
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Title of ticket
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Module name 
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Type of ticket
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// Status type
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Type of priority
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Color code for priority
        /// </summary>
        public string PriorityColorCode { get; set; }
    }
}
