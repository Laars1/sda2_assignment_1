using Microsoft.AspNetCore.Mvc;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Controllers;

    [ApiController]
    [Route("ticketing/[controller]")]
public class TicketSystemController : ControllerBase
{
    private readonly ITicketSystemRepository _ticketSystemRepository;

    public TicketSystemController(ITicketSystemRepository ticketSystemRepository)
    {
        _ticketSystemRepository = ticketSystemRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<TicketSystem>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _ticketSystemRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(TicketSystem registerTable)
    {
        bool success = await _ticketSystemRepository.AddAsync(registerTable);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(TicketSystem ticketSystem)
    {
        bool exists = await _ticketSystemRepository.ExistAsync(ticketSystem.TicketId);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _ticketSystemRepository.UpdateAsync(ticketSystem);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool exists = await _ticketSystemRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _ticketSystemRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("deletebycustomerid/{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteByCustomerIdAsync(int customerId)
    {
        bool exists = await _ticketSystemRepository.CustomerHasEntriesAsync(customerId);

        if (!exists)
        {
            return NoContent();
        }

        bool success = await _ticketSystemRepository.DeleteByCustomerIdAsync(customerId);

        return success ? NoContent() : Problem();
    }
}
