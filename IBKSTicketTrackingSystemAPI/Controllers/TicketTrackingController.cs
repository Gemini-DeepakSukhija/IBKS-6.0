using IBKSTicketTrackingSystemBAL.Interface;
using IBKSTicketTrackingSystemDTO.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace IBKSTicketTrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTrackingController : ControllerBase
    {
        private readonly ITicketTrackingBAL _ticketTrackingBAL;

        public TicketTrackingController(ITicketTrackingBAL ticketTrackingBAL)
        {
            _ticketTrackingBAL = ticketTrackingBAL;
        }

        [Route("GetAllTickets")]
        [HttpGet]
        public IList<TicketData> GetAllTickets()
        {
            if (_ticketTrackingBAL == null)
            {
                return (IList<TicketData>)NoContent();
                //return NotFound();
            }
            return _ticketTrackingBAL.GetAllTickets();
        }

        // GET api/<TicketTrackingController>/5
        [Route("GetTicketDetail/{id}")]
        [HttpGet]
        public TicketDetail GetTicketDetail(int id)
        {
            return _ticketTrackingBAL.GetTicketDetail(id);
        }

        // POST api/<TicketTrackingController>
        [Route("AddTicket")]
        [HttpPost]
        public void AddTicket([FromBody] TicketDetail ticket)
        {
            _ticketTrackingBAL.AddTicket(ticket);
        }

        // PUT api/<TicketTrackingController>/5
        [Route("UpdateTicket")]
        [HttpPut]
        public void UpdateTicket([FromBody] TicketDetail ticket)
        {
            _ticketTrackingBAL.UpdateTicket(ticket);
        }

        [Route("GetInitialDropDownDataToAddTicket")]
        [HttpGet]
        public TicketDropDownData GetInitialDropDownDataToAddTicket()
        {
            return _ticketTrackingBAL.GetInitialDropDownDataToAddTicket();
        }
    }
}
