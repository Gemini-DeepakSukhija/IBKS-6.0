namespace IBKSTicketTrackingSystemDTO.DTOs
{

    /// <summary>
    /// Created generic class to get all the dropdown values of ticket related data
    /// </summary>
    public class TicketDropDownData
    {
        public IList<Module> Modules { get; set; }
        public IList<TicketPriority> Priorities { get; set; }
        public IList<TicketStatus> Statuses { get; set; }
        public IList<TicketType> Types { get; set; }
    }
}
