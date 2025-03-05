using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalController:ControllerBase
{
    IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpGet("GetAllRental")]
    public async Task<IActionResult> GetAllRentals()
    {
        var rentals = await _rentalService.GetAllRentalsAsync();
        return Ok(rentals);
    }

    [HttpGet("GetAvailableRental")]
    public async Task<IActionResult> GetAvailableRentals()
    {
        var rentals = await _rentalService.GetAvailableRentalsAsync();
        return Ok(rentals);
    }

    [HttpGet("GetRentedRentals")]
    public async Task<IActionResult> GetRentedRentals()
    {
        var result = await _rentalService.GetRentedRentalsAsync();
        return Ok(result);
    }

    [HttpGet("GetRentalbyRentalId")]
    public async Task<IActionResult> GetRentalByRentalId(Guid rentalId)
    {
        var reuslt = await _rentalService.GetByRentalIdAsync(rentalId);
        return Ok(reuslt);
    }

    [HttpPost("AddRental")]
    public async Task<IActionResult> CreateRental([FromBody]RentalDTO rental)
    {
        await _rentalService.AddRentalAsync(rental);
        return Ok();
    }

    [HttpPut("UpdateRental")]
    public async Task<IActionResult> UpdateRental([FromBody]RentalDTO rental)
    {
        await _rentalService.UpdateRentalAsync(rental);
        return Ok();
    }

    [HttpPut("EndRental")]
    public async Task<IActionResult> EndRental([FromBody] RentalDTO rental)
    { 
        await _rentalService.EndRentalAsync(rental);
        return Ok();
    }

    [HttpDelete("DeleteRental")]
    public async Task<IActionResult> DeleteRental(Guid rentalId)
    {
        await _rentalService.DeleteRentalAsync(rentalId);
        return Ok();
    }
}