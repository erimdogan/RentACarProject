using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class CarDTO
{
    public Guid CarId { get; set; }

    [Required(ErrorMessage = "Car has to be have a brandId")]
    public Guid BrandId { get; set; }
    [Required(ErrorMessage = "Car has to have a name")]
    [MaxLength(50, ErrorMessage = "Car name cant exceeds 50 characters")]
    public string CarName { get; set; }
    [Required]
    public int ModelYear { get; set; }
    [Required(ErrorMessage = "A car must have daily price")]
    public decimal DailyPrice { get; set; }
    [Required]
    [MaxLength(225, ErrorMessage = "Description cant exceeds 225 characters")]
    public string Description { get; set; }
}