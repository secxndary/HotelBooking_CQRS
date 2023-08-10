using Application.Commands;
using AutoMapper;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using MediatR;
namespace Application.Handlers;

public class DeleteHotelHandler : IRequestHandler<DeleteHotelCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public DeleteHotelHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
    }


    public async Task<Unit> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(request.Id, request.TrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(request.Id);

        _repository.Hotel.DeleteHotel(hotel);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}