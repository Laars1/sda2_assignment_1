using Microsoft.AspNetCore.Mvc;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Controllers;

[ApiController]
[Route("masterdata/[controller]")]
public class CustomerInfoController : ControllerBase
{
    private readonly ICustomerInfoRepository _customerRepository;

    private readonly ICartHttpService _cartHttpService;

    private readonly ITicketingHttpService _ticketingHttpService;

    public CustomerInfoController(ICustomerInfoRepository customerRepository, ICartHttpService cartHttpService, ITicketingHttpService ticketingHttpService)
    {
        _customerRepository = customerRepository;
        _cartHttpService = cartHttpService;
        _ticketingHttpService = ticketingHttpService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<EmployeeInfo>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _customerRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(CustomerInfo customerInfo)
    {
        bool success = await _customerRepository.AddAsync(customerInfo);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(CustomerInfo customerInfo)
    {
        bool exists = await _customerRepository.ExistAsync(customerInfo.CustomerId);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _customerRepository.UpdateAsync(customerInfo);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool exists = await _customerRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _customerRepository.DeleteAsync(id);

        bool deletedResultsOnCartMicroservice = true;
        bool deletedResultsOnTicketingMicroservice = true;
        if (success)
        {
            deletedResultsOnCartMicroservice = await _cartHttpService.DeleteCartInprogressAsync(id);
            deletedResultsOnTicketingMicroservice = await _ticketingHttpService.DeleteTicketsAsync(id);
        }

        return success && deletedResultsOnCartMicroservice && deletedResultsOnTicketingMicroservice ? NoContent() : Problem();
    }
}