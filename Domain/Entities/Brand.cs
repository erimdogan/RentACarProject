using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Brand
{
    public List<Car> _cars { get; set; } = new List<Car>();

    [Key]
    public Guid BrandId { get; set; }


    [Required]
    [MaxLength(50)]
    public string BrandName { get; set; }

}