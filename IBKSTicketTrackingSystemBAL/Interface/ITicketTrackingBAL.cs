using IBKSTicketTrackingSystemDTO.DTOs;

namespace IBKSTicketTrackingSystemBal.Interface
{
    /// <summary>
    /// Interface for TicketTrackingBal
    /// </summary>
    public interface ITicketTrackingBal
    {
        /// <summary>
        /// Method to get all the tickets
        /// </summary>
        /// <returns>List of tickets with selected columns</returns>
        IList<TicketData> GetAllTickets();

        /// <summary>
        /// Method to add new ticket from DB
        /// </summary>
        /// <returns>Newly added ticket with TicketId</returns>
        TicketDetail AddTicket(TicketDetail ticketDetail);

        /// <summary>
        /// Method to update existing ticket on basis of ticketid from DB
        /// </summary>>
        TicketDetail UpdateTicket(TicketDetail ticketDetail);


        /// <summary>
        /// Method to get the selected ticket
        /// </summary>
        /// <returns>Selected ticket with selected columns</returns>
        TicketDetail GetTicketDetail(int id);


        /// <summary>
        /// Method to get all the intital values of drop down
        /// </summary>
        /// <returns>All the values in list format</returns>
        TicketDropDownData GetInitialDropDownDataToAddTicket();
    }
}
