using Application.Commands;
using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models.UserModels;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;

namespace Application.Handlers;

public class UpdateHotelHandler : IRequestHandler<UpdateHotelCommand, HotelDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateHotelHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<HotelDto> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotelEntity = await _repository.Hotel.GetHotelAsync(request.Id, request.TrackChanges);
        if (hotelEntity is null)
            throw new HotelNotFoundException(request.Id);

        _mapper.Map(request.Hotel, hotelEntity);
        await _repository.SaveAsync();

        var hotelToReturn = _mapper.Map<HotelDto>(hotelEntity);
        return hotelToReturn;
    }
}