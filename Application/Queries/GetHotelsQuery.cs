using MediatR;
using Shared.DataTransferObjects.OutputDtos;
namespace Application.Queries;

public sealed record GetHotelsQuery(bool TrackChanges)
    : IRequest<IEnumerable<HotelDto>>;