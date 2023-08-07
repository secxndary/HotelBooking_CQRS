using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IReservationRepository
{
    Task<PagedList<Reservation>> GetReservationsAsync(Guid roomId, ReservationlParameters reservationlParameters, bool trackChanges);
    Task<Reservation?> GetReservationAsync(Guid roomId, Guid id, bool trackChanges);
    Task<Reservation?> GetReservationAsync(Guid id, bool trackChanges);
    void CreateReservationForRoom(Guid roomId,  Reservation reservation);
    void DeleteReservation(Reservation reservation);
}