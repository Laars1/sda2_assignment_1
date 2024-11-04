using Microsoft.AspNetCore.Mvc;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Controllers;

[ApiController]
[Route("masterdata/[controller]")]
public class EmployeeInfoController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeInfoController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<EmployeeInfo>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _employeeRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(EmployeeInfo employeeInfo)
    {
        bool success = await _employeeRepository.AddAsync(employeeInfo);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(EmployeeInfo employeeInfo)
    {
        bool exists = await _employeeRepository.ExistAsync(employeeInfo.EmployeeId);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _employeeRepository.UpdateAsync(employeeInfo);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool exists = await _employeeRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _employeeRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }
}
