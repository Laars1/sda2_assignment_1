using Microsoft.AspNetCore.Mvc;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Controllers;

[ApiController]
[Route("masterdata/[controller]")]
public class RegisterTableController : ControllerBase
{
    private readonly IRegisterRepository _registerRepository;

    public RegisterTableController(IRegisterRepository registerRepository)
    {
        _registerRepository = registerRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<RegistersTable>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _registerRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(RegistersTable registerTable)
    {
        bool success = await _registerRepository.AddAsync(registerTable);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(RegistersTable registerTable)
    {
        bool exists = await _registerRepository.ExistAsync(registerTable.RegisterId);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _registerRepository.UpdateAsync(registerTable);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(int id)
    {
        bool exists = await _registerRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _registerRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }
}
