using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;

namespace Railroad.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReadDTO>>> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllAsync();
            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        // GET: api/tickets/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TicketReadDTO>>> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // PUT: api/tickets
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TicketWriteDTO value)
        {
            await _ticketService.AddAsync(value);
            return Ok();
        }

        // PUT: api/tickets/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, [FromBody] TicketWriteDTO value)
        {
            await _ticketService.UpdateAsync(Id, value);
            var updatedTicket = await _ticketService.GetByIdAsync(Id);
            return Ok(updatedTicket);
        }

        // DELETE: api/tickets/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ticketService.DeleteAsync(id);
            return Ok();
        }
    }
}
