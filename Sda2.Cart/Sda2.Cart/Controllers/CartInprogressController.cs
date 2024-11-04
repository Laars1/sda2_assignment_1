using Microsoft.AspNetCore.Mvc;
using Sda2.Cart.Abstractions;
using Sda2.Cart.Persistance.Entites;

namespace Sda2.Cart.Controllers;

[ApiController]
[Route("cart/[controller]")]
public class CartInprogressController : ControllerBase
{
    private readonly ICartInProgressRepository _cartInprogressRepository;

    public CartInprogressController(ICartInProgressRepository cartInprogressRepository)
    {
        _cartInprogressRepository = cartInprogressRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<CartInprogress>))]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _cartInprogressRepository.GetAsync());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(CartInprogress cartInprogress)
    {
        bool success = await _cartInprogressRepository.AddAsync(cartInprogress);


        return success ? NoContent() : Problem();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateAsync(CartInprogress cartInprogress)
    {
        bool exists = await _cartInprogressRepository.ExistAsync(cartInprogress.CID);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _cartInprogressRepository.UpdateAsync(cartInprogress);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool exists = await _cartInprogressRepository.ExistAsync(id);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _cartInprogressRepository.DeleteAsync(id);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("deletebycustomerid/{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteByCustomerIdAsync(int customerId)
    {
        bool exists = await _cartInprogressRepository.CustomerHasEntries(customerId);

        if (!exists)
        {
            return NotFound();
        }

        bool success = await _cartInprogressRepository.DeleteByCustomerIdAsync(customerId);

        return success ? NoContent() : Problem();
    }

    [HttpPost("{cid}/cart/{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddCartAsync(int cid, int productId)
    {
        bool success = await _cartInprogressRepository.AddCart(cid, productId);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{cid}/cart/{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCartAsync(int cid, int productId)
    {
        bool success = await _cartInprogressRepository.RemoveCart(cid, productId);

        return success ? NoContent() : Problem();
    }

    [HttpPost("{cid}/itemlist/{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddItemListAsync(int cid, int productId)
    {
        bool success = await _cartInprogressRepository.AddCart(cid, productId);

        return success ? NoContent() : Problem();
    }

    [HttpDelete("{cid}/itemlist/{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteItemListAsync(int cid, int productId)
    {
        bool success = await _cartInprogressRepository.RemoveCart(cid, productId);

        return success ? NoContent() : Problem();
    }
}