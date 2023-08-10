using MediatR;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Application.Commands;

public sealed record UpdateHotelCommand(Guid Id, HotelForUpdateDto Hotel, bool TrackChanges)
    : IRequest<HotelDto>;