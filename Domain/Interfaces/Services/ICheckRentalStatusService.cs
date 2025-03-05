using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface ICheckRentalStatusService
{
    bool CheckRentalStatusIsAvailable(Rental rental);
}