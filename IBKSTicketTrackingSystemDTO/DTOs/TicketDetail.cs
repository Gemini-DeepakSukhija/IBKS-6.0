using System.ComponentModel.DataAnnotations;

namespace IBKSTicketTrackingSystemDTO.DTOs
{
    /// <summary>
    /// Data transfer class with detailed information of ticket
    /// </summary>
    public class TicketDetail
    {
        /// <summary>
        /// Id of the ticket
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Title of the ticket
        /// </summary>
        [Required(ErrorMessage = "Please enter Title")]
        [StringLength(250)]
        public string Title { get; set; }

        /// <summary>
        /// Combined ticket name
        /// </summary>
        public string TicketName => Id + Title;

        /// <summary>
        /// Module id
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// Module Name
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Description of ticket
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Latest/current reply on the ticket
        /// </summary>
        public string LatestReply { get; set; }

        /// <summary>
        /// History of all relies on ticket
        /// </summary>
        public List<string> Replies { get; set; }

        /// <summary>
        /// Id of priority
        /// </summary>
        public int PriorityId { get; set; }

        /// <summary>
        /// Name of priority
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Ticket type id
        /// </summary>
        public int TicketTypeId { get; set; }

        /// <summary>
        /// Ticket type name
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// Status id of ticket
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Name of status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Id of User
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Installed environment id
        /// </summary>
        public int InstalledEnvironmentId { get; set; }
    }
}
