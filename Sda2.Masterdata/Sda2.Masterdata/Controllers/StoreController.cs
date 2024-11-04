using Microsoft.AspNetCore.Mvc;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Controllers;

[ApiController]
[Route("masterdata/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;

    public StoreController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<Store>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _storeRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(Store store)
    {
        bool success = await _storeRepository.AddAsync(store);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(Store store)
    {
        bool exists = await _storeRepository.ExistAsync(store.SID);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _storeRepository.UpdateAsync(store);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(int id)
    {
        bool exists = await _storeRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _storeRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }

    [HttpPost("{storeId}/addemployee/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> AddEmployee(int storeId, int employeeId)
    {
        bool success = await _storeRepository.AddEmployee(storeId, employeeId);

        return success ? NoContent() : Problem();
    }

    [HttpPost("{storeId}/removeemployee/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> RemoveEmployee(int storeId, int employeeId)
    {
        bool success = await _storeRepository.RemoveEmployee(storeId, employeeId);

        return success ? NoContent() : Problem();
    }
}
