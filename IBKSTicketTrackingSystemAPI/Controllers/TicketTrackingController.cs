using IBKSTicketTrackingSystemBal.Bal;
using IBKSTicketTrackingSystemBal.Interface;
using IBKSTicketTrackingSystemDal.Dal;
using IBKSTicketTrackingSystemDTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IBKSTicketTrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTrackingController : ControllerBase
    {
        private readonly ITicketTrackingBal _ticketTrackingBal;
        private readonly ILogger<TicketTrackingController> _logger;

        public TicketTrackingController(ITicketTrackingBal ticketTrackingBal, ILogger<TicketTrackingController> logger)
        {
            _ticketTrackingBal = ticketTrackingBal;
            _logger = logger;
        }

        [Route("GetAllTickets")]
        [HttpGet]
        public IActionResult GetAllTickets()
        {
            try
            {
                if (_ticketTrackingBal == null)
                {
                    return NotFound();
                }

                return Ok(_ticketTrackingBal.GetAllTickets());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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
                var result = _ticketTrackingBal.GetTicketDetail(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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

                    var result = _ticketTrackingBal.AddTicket(ticket);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
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

                    var result = _ticketTrackingBal.UpdateTicket(ticket);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
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
                var result = _ticketTrackingBal.GetInitialDropDownDataToAddTicket();

                if (result == null)
                {
                    return UnprocessableEntity();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }
    }
}
