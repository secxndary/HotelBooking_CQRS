using Application.Queries;
using AutoMapper;
using Contracts.Repository;
using MediatR;
using Shared.DataTransferObjects.OutputDtos;
namespace Application.Handlers;

public sealed class GetHotelsHandler : IRequestHandler<GetHotelsQuery, IEnumerable<HotelDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHotelsHandler(IRepositoryManager repository, IMapper mapper) 
    {
        _repository = repository;
        _mapper = mapper;
    }
    

    public async Task<IEnumerable<HotelDto>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _repository.Hotel.GetAllHotelsAsync(request.TrackChanges);
        var hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotels);
        return hotelsDto;
    }
}