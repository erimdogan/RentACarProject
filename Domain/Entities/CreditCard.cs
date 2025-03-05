using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class CreditCard
{
    [Key]
    public Guid CardId { get; set; }
    
    public Guid CustomerId { get; set; }

    [Required]
    [MaxLength(100)]
    public required string CardUser { get; set; }

    [Required]
    [MaxLength(20)]
    public required string CardNumber { get; set; }

    [Required]
    [MaxLength(15)]
    public required string ValidDate { get; set; }

    [Required]
    [MaxLength(4)]
    public required string Cvv { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}