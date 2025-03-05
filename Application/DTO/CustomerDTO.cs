using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class CustomerDTO
{
    public Guid CustomerId { get; set; }

    [Required(ErrorMessage = "Customer Name Can Not Be Blank")]
    [MaxLength(50, ErrorMessage = "Customer Name Can Not Exceed 50 characters")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Customer Email Can Not Be Blank")]
    [MaxLength(50,ErrorMessage = "Customer Email Can Not Exceed 50 characters")]
    public string CustomerEmail { get; set; }
}