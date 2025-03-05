using Application.DTO;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    ICreditCardService _creditCardService;

    public CreditCardController(ICreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    [HttpGet("GetAllCreditCards")]
    public async Task<IActionResult> GetAllCreditCards()
    {
        var results = await _creditCardService.GetAllCreditCardsAsync();
        if (results != null)
        {
            return Ok(results);
        }
        return BadRequest(results);
    }

    [HttpGet("GetCreditCardById")]
    public async Task<IActionResult> GetCreditCardById(Guid id)
    {
        var result = await _creditCardService.GetByCardIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("GetCreditCardByUser")]
    public async Task<IActionResult> GetCreditCardByUser(string cardUser)
    {
        var result = await _creditCardService.GetByCardUserAsync(cardUser);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("GetByCardNumber")]
    public async Task<IActionResult> GetCreditCardByNumber(string cardNumber)
    {
        var result = await _creditCardService.GetByCardNumberAsync(cardNumber);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("AddCreditCard")]
    public async Task<IActionResult> CreateCreditCard(CreditCardDTO creditCard)
    {
        await _creditCardService.AddCreditCardAsync(creditCard);
        return Ok();
    }

    [HttpPut("UpdateCreditCard")]
    public async Task<IActionResult> UpdateCreditCard(CreditCardDTO creditCard)
    {
        await _creditCardService.UpdateCreditCardAsync(creditCard);
        return Ok();
    }

    [HttpDelete("DeleteCreditCard")]
    public async Task<IActionResult> DeleteCreditCard(Guid creditCardId)
    {
        await _creditCardService.DeleteCreditCardAsync(creditCardId);
        return Ok();
    }
}