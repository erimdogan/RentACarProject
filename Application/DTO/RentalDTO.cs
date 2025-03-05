namespace Application.DTO;

public class RentalDTO
{
    public Guid RentId { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime RentStartDateTime { get; set; }
    public DateTime? RentEndDateTime { get; set; }
    public string RentStatus { get; set; }
}