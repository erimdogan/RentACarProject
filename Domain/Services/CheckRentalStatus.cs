//using Domain.Entities;
//using Domain.Interfaces;
//using Domain.Interfaces.Services;

//namespace Domain.Services;

//public class CheckRentalStatus : ICheckRentalStatusService
//{
//    private readonly IRentalRepository _rentalRepository;

//    public CheckRentalStatus(IRentalRepository rentalRepository)
//    {
//        _rentalRepository = rentalRepository;
//    }

//    public bool CheckRentalStatusIsAvailable(Rental rental)
//    {
//        var _rental= _rentalRepository.GetByRentalId(rental.RentId);

//        return _rental.RentStatus == RentalStatus.Available;
//    }
//}