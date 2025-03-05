using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Rental
{
    [Key]
    public Guid RentId { get; set; }
    
    public Guid CarId { get; set; }
    
    public Guid CustomerId { get; set; }
    public DateTime RentStartDateTime { get; set; }
    public DateTime? RentEndDateTime { get; set; }
    public RentalStatus RentStatus { get; set; }

    [ForeignKey("CarId")]
    public Car Car { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }

}