using Application.Queries;
using AutoMapper;
using Contracts.Repository;
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
        var hotelDto = _mapper.Map<HotelDto>(hotel);
        return hotelDto;
    }
}