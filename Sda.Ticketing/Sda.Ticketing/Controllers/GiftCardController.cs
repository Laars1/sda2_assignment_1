using Microsoft.AspNetCore.Mvc;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance.Entities;
using Sda.Ticketing.Repositories;

namespace Sda.Ticketing.Controllers;

[ApiController]
[Route("ticketing/[controller]")]
public class GiftCardController : ControllerBase
{
    private readonly IGiftCardRepository _giftCardRepository;

    public GiftCardController(IGiftCardRepository giftCardRepository)
    {
        _giftCardRepository = giftCardRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<GiftCard>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _giftCardRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(GiftCard giftCard)
    {
        bool success = await _giftCardRepository.AddAsync(giftCard);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(GiftCard giftCard)
    {
        bool exists = await _giftCardRepository.ExistAsync(giftCard.GiftId);
        if (!exists)
        {
            return NotFound();
        }

        bool success = await _giftCardRepository.UpdateAsync(giftCard);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool exists = await _giftCardRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _giftCardRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }
}