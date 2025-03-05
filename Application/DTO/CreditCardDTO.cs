namespace Application.DTO;

public class CreditCardDTO
{
    public Guid CardId { get; set; }
    public Guid CustomerId { get; set; }
    public string CardUser { get; set; }
    public string CardNumber { get; set; }
    public required string ValidDate { get; set; }
    public required string Cvv { get; set; }
}