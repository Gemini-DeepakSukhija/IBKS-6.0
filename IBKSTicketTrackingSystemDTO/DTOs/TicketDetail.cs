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
        [Required(ErrorMessage = "Please enter ApplicationId")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid ApplicationId")] 
        public int ApplicationId { get; set; }

        /// <summary>
        /// Module Name
        /// </summary>
        [Required(ErrorMessage = "Please enter ApplicationName")]
        [StringLength(250)] 
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
        [Required(ErrorMessage = "Please enter PriorityId")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid PriorityId")]
        public int PriorityId { get; set; }

        /// <summary>
        /// Name of priority
        /// </summary>
        [Required(ErrorMessage = "Please enter Priority")]
        [StringLength(250)] 
        public string Priority { get; set; }

        /// <summary>
        /// Ticket type id
        /// </summary>
        [Required(ErrorMessage = "Please enter TicketTypeId")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid TicketTypeId")] 
        public int TicketTypeId { get; set; }

        /// <summary>
        /// Ticket type name
        /// </summary>
        [Required(ErrorMessage = "Please enter TicketType")]
        [StringLength(250)] 
        public string TicketType { get; set; }

        /// <summary>
        /// Status id of ticket
        /// </summary>
        [Required(ErrorMessage = "Please enter StatusId")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid StatusId")] 
        public int StatusId { get; set; }

        /// <summary>
        /// Name of status
        /// </summary>
        [Required(ErrorMessage = "Please enter Status")]
        [StringLength(250)] 
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
