using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Car
{
    [Key]
    public Guid CarId { get; set; }
    public Guid BrandId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CarName { get; set; }

    [Required]
    [MaxLength(50)]
    public int ModelYear { get; set; }

    [Required]
    [MaxLength(50)]
    public decimal DailyPrice { get; set; }

    [Required]
    [MaxLength(150)]
    public string Description { get; set; }

    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }

    public List<Rental> Rentals { get; set; }
}