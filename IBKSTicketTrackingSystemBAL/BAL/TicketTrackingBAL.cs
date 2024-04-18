using IBKSTicketTrackingSystemBal.Interface;
using IBKSTicketTrackingSystemDal.Dal;
using IBKSTicketTrackingSystemDal.Interface;
using IBKSTicketTrackingSystemDTO.DTOs;
using Microsoft.Extensions.Logging;
using System.Runtime.ExceptionServices;

namespace IBKSTicketTrackingSystemBal.Bal
{
    /// <summary>
    /// Class to handle all the business related operations for Ticket tracking
    /// </summary>
    public class TicketTrackingBal: ITicketTrackingBal
    {
        /// <summary>
        /// Object for TicketTrackingRepository
        /// </summary>
        private readonly ITicketTrackingDal _ticketTrackingDal;
        private readonly ILogger<TicketTrackingBal> _logger;

        /// <summary>
        /// Constuctor to initiate members 
        /// </summary>
        public TicketTrackingBal(ITicketTrackingDal ticketTrackingDal, ILogger<TicketTrackingBal> logger)
        {
            _ticketTrackingDal = ticketTrackingDal;
            _logger = logger;
        }

        /// <summary>
        /// Method to get all the tickets
        /// </summary>
        /// <returns>List of tickets with selected columns</returns>
        public IList<TicketData> GetAllTickets()
        {
            IList<TicketData> tickets = new List<TicketData>();
            try
            {

                tickets = _ticketTrackingDal.GetAllTickets();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return tickets;
        }
      
        /// <summary>
        /// Method to add new ticket from DB
        /// </summary>
        /// <returns>Newly added ticket with TicketId</returns>
        public TicketDetail AddTicket(TicketDetail ticketDetail)
        {
            TicketDetail ticket = new TicketDetail();
            try
            {

                ticket = _ticketTrackingDal.AddTicket(ticketDetail);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return ticket;
        }
        
        /// <summary>
        /// Method to update existing ticket on basis of ticketid from DB
        /// </summary>>
        public TicketDetail UpdateTicket(TicketDetail ticketDetail)
        {
            TicketDetail ticket = new TicketDetail();
            try
            {

                _ticketTrackingDal.UpdateTicket(ticketDetail);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return ticket;
        }

        /// <summary>
        /// Method to get the selected ticket
        /// </summary>
        /// <returns>Selected ticket with selected columns</returns>
        public TicketDetail GetTicketDetail(int id)
        {
            TicketDetail ticket = new TicketDetail();
            try
            {

                ticket = _ticketTrackingDal.GetTicketDetail(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return ticket;
        }

        /// <summary>
        /// Method to get all the intital values of drop down
        /// </summary>
        /// <returns>All the values in list format</returns>
        public TicketDropDownData GetInitialDropDownDataToAddTicket()
        {
            TicketDropDownData ticketDropDownData = new TicketDropDownData();
            try
            {

                ticketDropDownData.Modules = _ticketTrackingDal.GetAllModules();
                ticketDropDownData.Statuses = _ticketTrackingDal.GetAllStatuses();
                ticketDropDownData.Types = _ticketTrackingDal.GetAllTicketTypes();
                ticketDropDownData.Priorities = _ticketTrackingDal.GetAllPriorities();


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return ticketDropDownData;
        }
    }
}
