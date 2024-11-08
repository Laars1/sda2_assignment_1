using Microsoft.AspNetCore.Mvc;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Controllers;

[ApiController]
[Route("ticketing/[controller]")]
public class ReturnTableController : ControllerBase
{
    private readonly IReturnTableRepository _returnTableRepository;

    public ReturnTableController(IReturnTableRepository returnTableRepository)
    {
        _returnTableRepository = returnTableRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReturnTable>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _returnTableRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(ReturnTable returnTable)
    {
        bool success = await _returnTableRepository.AddAsync(returnTable);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(ReturnTable returnTable)
    {
        bool exists = await _returnTableRepository.ExistAsync(returnTable.RTID);
        if (!exists)
        {
            return NotFound();
        }

        bool success = await _returnTableRepository.UpdateAsync(returnTable);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool exists = await _returnTableRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _returnTableRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }
}
