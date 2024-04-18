using IBKSTicketTrackingSystemDal.Interface;
using IBKSTicketTrackingSystemDal.Models;
using IBKSTicketTrackingSystemDTO.DTOs;
using Microsoft.Extensions.Logging;
using TicketType = IBKSTicketTrackingSystemDTO.DTOs.TicketType;

namespace IBKSTicketTrackingSystemDal.Dal
{
    /// <summary>
    /// Creating class to manage all the database related operations 
    /// </summary>
    public class TicketTrackingDal : ITicketTrackingDal
    {
        /// <summary>
        /// Data context object handle all the tables related queries
        /// </summary>
        private readonly SupportContext _supportContext;

        /// <summary>
        /// Instance for logging
        /// </summary>
        private readonly ILogger<TicketTrackingDal> _logger;
        /// <summary>
        /// Constuctor to initiate members 
        /// </summary>
        public TicketTrackingDal(SupportContext supportContext, ILogger<TicketTrackingDal> logger)
        {
            _supportContext = supportContext;
            _logger = logger;
        }

        /// <summary>
        /// Method to get all the tickets from DB
        /// </summary>
        /// <returns>List of tickets with selected columns</returns>
        public IList<TicketData> GetAllTickets()
        {
            _logger.LogInformation("Inside method GetAllTickets");
            List<TicketData> tickets = new List<TicketData>();

            try
            {
                var allTickets = from ticket in _supportContext.Tickets
                                 join ticketType in _supportContext.TicketTypes
                                 on ticket.TicketTypeId equals ticketType.Id
                                 join urgency in _supportContext.Priorities
                                 on ticket.PriorityId equals urgency.Id
                                 join state in _supportContext.Statuses
                                 on ticket.StatusId equals state.Id
                                 select new
                                 {
                                     Id = ticket.Id,
                                     Title = ticket.Title,
                                     ApplicationName = ticket.ApplicationName,
                                     TicketType = ticketType.Title,
                                     Status = state.Title,
                                     Priority = urgency.Title,
                                     PriorityColorCode = urgency.ColorCode,
                                 };

                foreach (var ticket in allTickets)
                {
                    TicketData ticketData = new TicketData()
                    {
                        Id = ticket.Id,
                        Title = ticket.Title,
                        ApplicationName = ticket.ApplicationName,
                        TicketType = ticket.TicketType,
                        Status = ticket.Status,
                        Priority = ticket.Priority
                    };
                    tickets.Add(ticketData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }
            return tickets;
        }

        /// <summary>
        /// Method to get the selected ticket from DB
        /// </summary>
        /// <returns>Selected ticket with selected columns</returns>
        public TicketDetail GetTicketDetail(int id)
        {
            _logger.LogInformation("Inside method GetTicketDetail");
            TicketDetail ticketDetail = new TicketDetail();
            try
            {
                var repliesOnTicket = from ticketReply in _supportContext.TicketReplies
                                      join ticket in _supportContext.Tickets
                                      on ticketReply.Tid equals ticket.Id
                                      where ticket.Id == id
                                      select new
                                      {
                                          Id = ticket.Id,
                                          Reply = ticketReply.Reply,
                                      };

                var requiredTicket = (from ticket in _supportContext.Tickets
                                      join ticketType in _supportContext.TicketTypes
                                      on ticket.TicketTypeId equals ticketType.Id
                                      join urgency in _supportContext.Priorities
                                      on ticket.PriorityId equals urgency.Id
                                      join state in _supportContext.Statuses
                                      on ticket.StatusId equals state.Id
                                      where ticket.Id == id
                                      select new
                                      {
                                          Id = ticket.Id,
                                          Title = ticket.Title,
                                          ApplicationId = ticket.ApplicationId,
                                          ApplicationName = ticket.ApplicationName,
                                          Description = ticket.Description,
                                          TicketTypeId = ticketType.Id,
                                          StatusId = state.Id,
                                          PriorityId = urgency.Id,
                                          TicketType = ticketType.Title,
                                          Status = state.Title,
                                          Priority = urgency.Title,
                                          PriorityColorCode = urgency.ColorCode,
                                          InstalledEnvironmentId = ticket.InstalledEnvironmentId
                                      }).AsEnumerable().FirstOrDefault();

                if (requiredTicket != null)
                {
                    ticketDetail.Id = requiredTicket.Id;
                    ticketDetail.Title = requiredTicket.Title;
                    ticketDetail.ApplicationId = requiredTicket.ApplicationId;
                    ticketDetail.ApplicationName = requiredTicket.ApplicationName;
                    ticketDetail.Description = requiredTicket.Description;
                    ticketDetail.TicketType = requiredTicket.TicketType;
                    ticketDetail.TicketTypeId = requiredTicket.TicketTypeId;
                    ticketDetail.StatusId = requiredTicket.StatusId;
                    ticketDetail.Status = requiredTicket.Status;
                    ticketDetail.PriorityId = requiredTicket.PriorityId;
                    ticketDetail.Priority = requiredTicket.Priority;
                    ticketDetail.InstalledEnvironmentId = requiredTicket.InstalledEnvironmentId;

                    ticketDetail.Replies = repliesOnTicket.Select(x => x.Reply).ToList();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }

            return ticketDetail;

        }

        /// <summary>
        /// Method to add new ticket from DB
        /// </summary>
        /// <returns>Newly added ticket with TicketId</returns>
        public TicketDetail AddTicket(TicketDetail ticket)
        {
            _logger.LogInformation("Inside method AddTicket");

            try
            {
                Ticket requiredTicket = new Ticket()
                {
                    Title = ticket.Title,
                    ApplicationId = ticket.ApplicationId,
                    ApplicationName = ticket.ApplicationName,
                    Description = ticket.Description,
                    TicketTypeId = ticket.TicketTypeId,
                    StatusId = ticket.StatusId,
                    PriorityId = ticket.PriorityId,
                    InstalledEnvironmentId = 1, //Making it default to every insertion
                    Date = DateTime.UtcNow, // Current time will be inserted for every new record
                    LastModified = DateTime.UtcNow, // Current time will be inserted for every new record

                };

                _supportContext.Tickets.Add(requiredTicket);
                _supportContext.SaveChanges();
                ticket.Id = requiredTicket.Id;

                TicketReply ticketReply = new TicketReply()
                {
                    Tid = ticket.Id,
                    Reply = ticket.LatestReply,
                    ReplyDate = DateTime.UtcNow// Current time will be inserted for every new record
                };

                _supportContext.TicketReplies.Add(ticketReply);
                _supportContext.SaveChanges();

                return GetTicketDetail((int)ticket.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Method to update existing ticket on basis of ticketid from DB
        /// </summary>>
        public void UpdateTicket(TicketDetail ticket)
        {
            _logger.LogInformation("Inside method UpdateTicket");
            try
            {
                Ticket requiredTicket = new Ticket()
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    ApplicationId = ticket.ApplicationId,
                    ApplicationName = _supportContext.Applications.Where(x=>x.Id==ticket.ApplicationId).Select(x=>x.Title).FirstOrDefault(),
                    Description = ticket.Description,
                    TicketTypeId = ticket.TicketTypeId,
                    StatusId = ticket.StatusId,
                    PriorityId = ticket.PriorityId,
                    LastModified = DateTime.UtcNow, // Current time will be inserted for every new record
                    InstalledEnvironmentId = ticket.InstalledEnvironmentId,
                };

                _supportContext.Tickets.Update(requiredTicket);

                if (!string.IsNullOrWhiteSpace(ticket.LatestReply))
                {
                    TicketReply ticketReply = new TicketReply()
                    {
                        Tid = ticket.Id,
                        Reply = ticket.LatestReply,
                        ReplyDate = DateTime.UtcNow// Current time will be inserted for every new record
                    };
                    _supportContext.TicketReplies.Add(ticketReply);
                }

                _supportContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Method to get all the modules from DB
        /// </summary>
        /// <returns>List of modules</returns>
        public IList<Module> GetAllModules()
        {
            _logger.LogInformation("Inside method GetAllModules");
            List<Module> modules = new List<Module>();

            try
            {
                var allModules = from module in _supportContext.Applications
                                    select new
                                    {
                                        Id = module.Id,
                                        Title = module.Title,
                                    };

                foreach (var type in allModules)
                {
                    Module status = new Module()
                    {
                        Id = type.Id,
                        Title = type.Title
                    };
                    modules.Add(status);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }
            return modules;
        }

        /// <summary>
        /// Method to get all the Priorities from DB
        /// </summary>
        /// <returns>List of Priorities</returns>
        public IList<TicketPriority> GetAllPriorities()
        {
            _logger.LogInformation("Inside method GetAllPriorities");
            List<TicketPriority> ticketPriorities = new List<TicketPriority>();

            try
            {
                var allPriorities = from priority in _supportContext.Priorities
                                    select new
                                    {
                                        Id = priority.Id,
                                        Title = priority.Title,
                                    };

                foreach (var type in allPriorities)
                {
                    TicketPriority status = new TicketPriority()
                    {
                        Id = type.Id,
                        Title = type.Title
                    };
                    ticketPriorities.Add(status);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }
            return ticketPriorities;
        }

        /// <summary>
        /// Method to get all the tickets types from DB
        /// </summary>
        /// <returns>List of tickets types</returns>
        public IList<TicketType> GetAllTicketTypes()
        {
            _logger.LogInformation("Inside method GetAllTicketTypes");
            List<TicketType> ticketTypes = new List<TicketType>();

            try
            {
                var allTypes = from type in _supportContext.TicketTypes
                               select new
                               {
                                   Id = type.Id,
                                   Title = type.Title,
                               };

                foreach (var type in allTypes)
                {
                    TicketType status = new TicketType()
                    {
                        Id = type.Id,
                        Title = type.Title
                    };
                    ticketTypes.Add(status);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }
            return ticketTypes;
        }

        /// <summary>
        /// Method to get all the Statuses from DB
        /// </summary>
        /// <returns>List of "Statuses"</returns>
        public IList<TicketStatus> GetAllStatuses()
        {
            _logger.LogInformation("Inside method GetAllStatuses");

            List<TicketStatus> ticketStatuses = new List<TicketStatus>();

            try
            {
                var allStates = from state in _supportContext.Statuses
                                select new
                                {
                                    Id = state.Id,
                                    Title = state.Title,
                                };

                foreach (var state in allStates)
                {
                    TicketStatus status = new TicketStatus()
                    {
                        Id = state.Id,
                        Title = state.Title
                    };
                    ticketStatuses.Add(status);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                throw;
            }
            return ticketStatuses;
        }
    }
}
