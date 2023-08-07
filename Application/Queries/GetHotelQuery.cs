using MediatR;
using Shared.DataTransferObjects.OutputDtos;
namespace Application.Queries;

public sealed record GetHotelQuery(Guid Id, bool TrackChanges) 
    : IRequest<HotelDto>;