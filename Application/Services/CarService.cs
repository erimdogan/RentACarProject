using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.DomainEvents;
using Domain.DomainEvents.CarEvents;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CarService:ICarService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventHandler<CarCreated> _carCreatedEventHandler;
    private readonly IEventHandler<CarUpdated> _carUpdatedEventHandler;
    private readonly IEventHandler<CarDeleted> _carDeletedEventHandler;

    public CarService(
            IUnitOfWork unitOfWork,
            IEventHandler<CarCreated> carCreatedEventHandler,
            IEventHandler<CarUpdated> carUpdatedEventHandler,
            IEventHandler<CarDeleted> carDeletedEventHandler)
    {
        _unitOfWork = unitOfWork;
        _carCreatedEventHandler = carCreatedEventHandler;
        _carUpdatedEventHandler = carUpdatedEventHandler;
        _carDeletedEventHandler = carDeletedEventHandler;
    }


    public async Task<CarDTO> GetCarByIdAsync(Guid carId)
    {
        var car = await _unitOfWork.Cars.GetCarByIdAsync(carId);
        return _mapper.Map<CarDTO>(car);
    }

    public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
    {
        var cars = await _unitOfWork.Cars.GetAllCarsAsync();
        return _mapper.Map<IEnumerable<CarDTO>>(cars);
    }

    public async Task AddCarAsync(CarDTO carDTO)
    {
        var car = _mapper.Map<Car>(carDTO);
        await _unitOfWork.Cars.AddCarAsync(car);
        await _unitOfWork.SaveChangesAsync();

        var eventCreated = new CarCreated(car);
        _carCreatedEventHandler.Handle(eventCreated);
    }

    public async Task UpdateCarAsync(CarDTO carDTO)
    {
        var toUpdated = await _unitOfWork.Cars.GetCarByIdAsync(carDTO.CarId);
        _mapper.Map(carDTO,toUpdated);
        await _unitOfWork.Cars.UpdateCarAsync(toUpdated);
        await _unitOfWork.SaveChangesAsync();

        var updateEvent = new CarUpdated(toUpdated);
        _carUpdatedEventHandler.Handle(updateEvent);
    }

    public async Task DeleteCarAsync(Guid carId)
    {
        _unitOfWork.Cars.DeleteCarAsync(carId);
        await _unitOfWork.SaveChangesAsync();
    }
}