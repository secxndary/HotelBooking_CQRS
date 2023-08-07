using Contracts.Repositories.UserRepositories;
using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<Reservation>> GetReservationsAsync(Guid roomId, ReservationlParameters reservationlParameters, bool trackChanges)
    {
        var reservations = await FindByCondition(r => r.RoomId.Equals(roomId), trackChanges)
            .FilterReservationsByDateEntry(reservationlParameters.MinDateEntry, reservationlParameters.MaxDateEntry)
            .FilterReservationsByDateExit(reservationlParameters.MinDateExit, reservationlParameters.MaxDateExit)
            .Sort(reservationlParameters.OrderBy)
            .ToListAsync();

        return PagedList<Reservation>.ToPagedList(reservations, reservationlParameters.PageNumber, reservationlParameters.PageSize);
    }

    public async Task<Reservation?> GetReservationAsync(Guid roomId, Guid id, bool trackChanges) =>
        await FindByCondition(r =>
            r.RoomId.Equals(roomId) &&
            r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<Reservation?> GetReservationAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateReservationForRoom(Guid roomId, Reservation reservation)
    {
        reservation.RoomId = roomId;
        Create(reservation);
    }

    public void DeleteReservation(Reservation reservation) =>
        Delete(reservation);
}