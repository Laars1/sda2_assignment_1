using Microsoft.AspNetCore.Mvc;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Models;

namespace Sda.Ticketing.Controllers;

[ApiController]
[Route("ticketing/[controller]")]
public class TaxController : ControllerBase
{
    private readonly ITaxHttpService _taxHttpService;

    public TaxController(ITaxHttpService taxHttpService)
    {
        _taxHttpService = taxHttpService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(int year, float price)
    {
        Tax? tax = await _taxHttpService.GetTaxFromFaas(year, price);

        return Ok(tax);
    }
}
