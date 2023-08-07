using Application.Queries;
using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;
namespace Application.Handlers;

public class GetHotelHandler : IRequestHandler<GetHotelQuery, HotelDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHotelHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<HotelDto> Handle(GetHotelQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(request.Id, request.TrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(request.Id);

        var hotelDto = _mapper.Map<HotelDto>(hotel);
        return hotelDto;
    }
}