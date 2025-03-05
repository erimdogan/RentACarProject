using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController:ControllerBase
{
    IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }


    [HttpGet("GetAllBrands")]
    public async Task<IActionResult> GetAllBrands()
    {
        var results = await _brandService.GetAllBrandsAsync();
        if (results!=null)
        {
            return Ok(results);
        }
        return BadRequest(results);
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> GetBrandByID(Guid id)
    {
        var result = await _brandService.GetBrandByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }


    [HttpGet("GetCarsByBrandId")]
    public async Task<IActionResult> GetCarsByBrandId(Guid brandId)
    {
        var cars = await _brandService.GetCarsByBrandIdAsync(brandId);
        return Ok(cars);
    }


    [HttpPost("AddNewBrand")]
    public async Task<IActionResult> AddNewBrand([FromBody] BrandDTO brand)
    {
        try
        {
            await _brandService.AddBrandAsync(brand);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPut("UpdateBrand")]
    public async Task<IActionResult> UpdateBrand([FromBody] BrandDTO brand)
    {
        await _brandService.UpdateBrandAsync(brand);
        return Ok();
    }


    [HttpDelete("DeleteBrand")]
    public async Task<IActionResult> DeleteBrand(Guid brandId)
    {
        await _brandService.DeleteBrandAsync(brandId);
        return Ok();
    }
}