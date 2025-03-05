using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class RentalService:IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RentalService(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public async Task<IEnumerable<RentalDTO>> GetAllRentalsAsync()
    {   // Repository methodu Rental entity kullaniyor.
        // Ama bizim buradaki methodumuz DTO kullandigi icin repositoryden veriyi alip onu DTO olarak ceviriyoruz
        // Cevirdigimiz DTO'yu donduruyoruz liste olarak.

        //var rentals = _rentalRepository.GetRentals();
        //return rentals.Select(rental => new RentalDTO()
        //{
        //    RentId = rental.RentId,
        //    CarId = rental.CarId,
        //    CustomerId = rental.CustomerId,
        //    RentEndDateTime = rental.RentEndDateTime,
        //    RentStartDateTime = rental.RentStartDateTime,
        //    RentStatus = rental.RentStatus.ToString()
        //}).ToList();
        var rentals = await _unitOfWork.Rental.GetAllRentalsAsync();
        return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
    }

    public async Task<IEnumerable<RentalDTO>> GetAvailableRentalsAsync()
    {
        var rentals = await _unitOfWork.Rental.GetAvailableRentalsAsync();
        return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
    }

    public async Task<IEnumerable<RentalDTO>> GetRentedRentalsAsync()
    {
        var rentals = await _unitOfWork.Rental.GetRentedRentalsAsync();
        return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
    }

    public async Task<RentalDTO> GetByRentalIdAsync(Guid rentalId)
    {
        var rental = await _unitOfWork.Rental.GetByRentalIdAsync(rentalId);
        return _mapper.Map<RentalDTO>(rental);
    }

    public async Task<RentalDTO> GetRentalForCarAsync(Guid carId)
    {
        var rental = await _unitOfWork.Cars.GetRentalForCarAsync(carId);
        return _mapper.Map<RentalDTO>(rental);
    }


    public async Task AddRentalAsync(RentalDTO rentalDTO)
    {
        var rental = _mapper.Map<Rental>(rentalDTO);
        await _unitOfWork.Rental.AddRentalAsync(rental);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task EndRentalAsync(RentalDTO rentalDTO)
    {
        var toEnded = await _unitOfWork.Rental.GetByRentalIdAsync(rentalDTO.RentId);
        _mapper.Map(rentalDTO, toEnded);
        toEnded.RentEndDateTime = DateTime.Now;
        toEnded.RentStatus = RentalStatus.Available;

        await _unitOfWork.Rental.UpdateRentalAsync(toEnded);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateRentalAsync(RentalDTO rentalDTO)
    {
        var toUpdated = await _unitOfWork.Rental.GetByRentalIdAsync(rentalDTO.RentId);
        _mapper.Map(rentalDTO, toUpdated);
        await _unitOfWork.Rental.UpdateRentalAsync(toUpdated);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteRentalAsync(Guid rentId)
    {
        await _unitOfWork.Rental.DeleteRentalAsync(rentId);
        await _unitOfWork.SaveChangesAsync();
    }
}