using IBKSTicketTrackingSystemDTO.DTOs;

namespace IBKSTicketTrackingSystemDAL.Interface
{
    /// <summary>
    /// Interface of TicketTrackingDAL
    /// </summary>
    public interface ITicketTrackingDAL
    {
        /// <summary>
        /// Method to get all the tickets from DB
        /// </summary>
        /// <returns>List of tickets with selected columns</returns>
        IList<TicketData> GetAllTickets();

        /// <summary>
        /// Method to get the selected ticket from DB
        /// </summary>
        /// <returns>Selected ticket with selected columns</returns>
        TicketDetail GetTicketDetail(int id);

        /// <summary>
        /// Method to add new ticket from DB
        /// </summary>
        /// <returns>Newly added ticket with TicketId</returns>
        TicketDetail AddTicket(TicketDetail ticket);

        /// <summary>
        /// Method to update existing ticket on basis of ticketid from DB
        /// </summary>>
        void UpdateTicket(TicketDetail ticket);

        /// <summary>
        /// Method to get all the modules from DB
        /// </summary>
        /// <returns>List of modules</returns>
        IList<Module> GetAllModules();

        /// <summary>
        /// Method to get all the Priorities from DB
        /// </summary>
        /// <returns>List of Priorities</returns>
        IList<TicketPriority> GetAllPriorities();

        /// <summary>
        /// Method to get all the Statuses from DB
        /// </summary>
        /// <returns>List of "Statuses"</returns>
        IList<TicketStatus> GetAllStatuses();

        /// <summary>
        /// Method to get all the tickets types from DB
        /// </summary>
        /// <returns>List of tickets types</returns>
        IList<TicketType> GetAllTicketTypes();
    }
}
