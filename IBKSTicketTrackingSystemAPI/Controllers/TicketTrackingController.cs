using IBKSTicketTrackingSystemBAL.BAL;
using IBKSTicketTrackingSystemBAL.Interface;
using IBKSTicketTrackingSystemDAL.DAL;
using IBKSTicketTrackingSystemDTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IBKSTicketTrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTrackingController : ControllerBase
    {
        private readonly ITicketTrackingBAL _ticketTrackingBAL;
        private readonly ILogger<TicketTrackingController> _logger;

        public TicketTrackingController(ITicketTrackingBAL ticketTrackingBAL, ILogger<TicketTrackingController> logger)
        {
            _ticketTrackingBAL = ticketTrackingBAL;
            _logger = logger;
        }

        [Route("GetAllTickets")]
        [HttpGet]
        public IActionResult GetAllTickets()
        {
            try
            {
                if (_ticketTrackingBAL == null)
                {
                    return NotFound();
                }

                return Ok(_ticketTrackingBAL.GetAllTickets());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TicketTrackingController>/5
        [Route("GetTicketDetail/{id}")]
        [HttpGet]
        public IActionResult GetTicketDetail(int id)
        {
            try
            {
                var result = _ticketTrackingBAL.GetTicketDetail(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<TicketTrackingController>
        [Route("AddTicket")]
        [HttpPost]
        public IActionResult AddTicket([FromBody] TicketDetail ticket)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ticket == null)
                    {
                        return BadRequest();
                    }

                    var result = _ticketTrackingBAL.AddTicket(ticket);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex.Message}");
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<TicketTrackingController>/5
        [Route("UpdateTicket")]
        [HttpPut]
        public IActionResult UpdateTicket([FromBody] TicketDetail ticket)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ticket == null)
                    {
                        return BadRequest();
                    }

                    var result = _ticketTrackingBAL.UpdateTicket(ticket);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex.Message}");
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("GetInitialDropDownDataToAddTicket")]
        [HttpGet]
        public IActionResult GetInitialDropDownDataToAddTicket()
        {
            try
            {
                var result = _ticketTrackingBAL.GetInitialDropDownDataToAddTicket();

                if (result == null)
                {
                    return UnprocessableEntity();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
