using MediatR;
namespace Application.Commands;

public sealed record DeleteHotelCommand(Guid Id, bool TrackChanges)
    : IRequest;