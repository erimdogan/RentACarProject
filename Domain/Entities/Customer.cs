using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Customer
{
    [Key]
    public Guid CustomerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CustomerName { get; set; }

    [Required]
    [MaxLength(50)]
    public string CustomerEmail { get; set; }

    public List<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

    public List<Rental> Rentals { get; set; } = new List<Rental>();
}