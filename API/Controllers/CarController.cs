using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController:ControllerBase
{
    ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("GetAllCars")]
    public async Task<IActionResult> GetAllCars()
    {
        var result = await _carService.GetAllCarsAsync();
        if (result!=null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("GetCarByID")]
    public async Task<IActionResult> GetCarById(Guid carId)
    {
        var result = await _carService.GetCarByIdAsync(carId);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    //[HttpGet("GetCarByBrandID")]
    //public IActionResult GetCarByBrandId(Guid brandId)
    //{
    //    var result = _carService.GetCarsWithBrand(brandId);
    //    if (result != null)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}

    [HttpPost("AddNewCar")]
    public async Task<IActionResult> AddCar([FromBody]CarDTO car)
    {
        await _carService.AddCarAsync(car);
        return Ok();
    }

    [HttpPut("UpdateCar")]
    public async Task<IActionResult> UpdateCar([FromBody] CarDTO car)
    {
        var carId = await _carService.GetCarByIdAsync(car.CarId);
        if (carId.CarId == null)
        {
            return BadRequest("Given Id doesnt match with CarId");
        }
        else
        {
            await _carService.UpdateCarAsync(car);
            return Ok();
        }
    }

    [HttpDelete("DeleteCar")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        _carService.DeleteCarAsync(id);
        return Ok();
    }
}