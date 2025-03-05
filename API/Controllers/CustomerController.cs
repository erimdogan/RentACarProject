using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController:ControllerBase
{
    ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        if (customers != null)
        {
            return Ok(customers);
        }
        return BadRequest(customers);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);
        if (customer != null)
        {
            return Ok(customer);
        }
        return BadRequest(customer);
    }


    [HttpGet("GetCreditCards")]
    public async Task<IActionResult> GetCreditCards(Guid customerId)
    {
        var creditCards = await _customerService.GetCreditCardsAsync(customerId);
        if (creditCards != null)
        {
            return Ok(creditCards);
        }
        return BadRequest(creditCards);
    }

    [HttpGet("GetRentals")]
    public async Task<IActionResult> GetRentals(Guid customerId)
    {
        var rentals = await _customerService.GetRentalsAsync(customerId);
        if (rentals != null)
        {
            return Ok(rentals);
        }
        return BadRequest(rentals);
    }


    [HttpPost("AddCustomer")]
    public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customer)
    {
        await _customerService.AddCustomerAsync(customer);
        return Ok();
    }


    [HttpPut("UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDTO customer)
    {
        await _customerService.UpdateCustomerAsync(customer);
        return Ok();
    }


    [HttpDelete("DeleteCustomer")]
    public async Task<IActionResult> DeleteCustomer(Guid customerId)
    {
        await _customerService.DeleteCustomerAsync(customerId);
        return Ok();
    }
}