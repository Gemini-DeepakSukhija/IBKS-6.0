﻿using IBKSTicketTrackingSystemBAL.Interface;
using IBKSTicketTrackingSystemDAL.DAL;
using IBKSTicketTrackingSystemDAL.Interface;
using IBKSTicketTrackingSystemDTO.DTOs;
using Microsoft.Extensions.Logging;
using System.Runtime.ExceptionServices;

namespace IBKSTicketTrackingSystemBAL.BAL
{
    /// <summary>
    /// Class to handle all the business related operations for Ticket tracking
    /// </summary>
    public class TicketTrackingBal: ITicketTrackingBal
    {
        /// <summary>
        /// Object for TicketTrackingRepository
        /// </summary>
        private readonly ITicketTrackingDAL _ticketTrackingDAL;
        private readonly ILogger<TicketTrackingBal> _logger;

        /// <summary>
        /// Constuctor to initiate members 
        /// </summary>
        public TicketTrackingBal(ITicketTrackingDAL ticketTrackingDAL, ILogger<TicketTrackingBal> logger)
        {
            _ticketTrackingDAL = ticketTrackingDAL;
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
                tickets = _ticketTrackingDAL.GetAllTickets();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Rethrow", ex);
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

                ticket = _ticketTrackingDAL.AddTicket(ticketDetail);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Rethrow", ex);
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
                _ticketTrackingDAL.UpdateTicket(ticketDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Rethrow", ex);
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
                ticket = _ticketTrackingDAL.GetTicketDetail(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Rethrow", ex);
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
                ticketDropDownData.Modules = _ticketTrackingDAL.GetAllModules();
                ticketDropDownData.Statuses = _ticketTrackingDAL.GetAllStatuses();
                ticketDropDownData.Types = _ticketTrackingDAL.GetAllTicketTypes();
                ticketDropDownData.Priorities = _ticketTrackingDAL.GetAllPriorities();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Rethrow", ex);
            }

            return ticketDropDownData;
        }
    }
}
