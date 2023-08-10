using Application.Commands;
using AutoMapper;
using Contracts.Repository;
using Entities.Models.UserModels;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;
namespace Application.Handlers;

public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, HotelDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateHotelHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotelEntity = _mapper.Map<Hotel>(request.Hotel);

        _repository.Hotel.CreateHotel(hotelEntity);
        await _repository.SaveAsync();

        var hotelToReturn = _mapper.Map<HotelDto>(hotelEntity);
        return hotelToReturn;
    }
}