using MediatR;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Application.Commands;

public sealed record CreateHotelCommand(HotelForCreationDto Hotel)
    : IRequest<HotelDto>;