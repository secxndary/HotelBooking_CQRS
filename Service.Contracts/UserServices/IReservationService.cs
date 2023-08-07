using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    Task<(IEnumerable<ReservationDto> reservations, MetaData metaData)> GetReservationsAsync
        (Guid roomId, ReservationlParameters reservationlParameters);
    Task<ReservationDto> GetReservationAsync(Guid roomId, Guid id);
    Task<ReservationDto> CreateReservationForRoomAsync(Guid roomId, ReservationForCreationDto reservation);
    Task<ReservationDto> UpdateReservationForRoomAsync(Guid roomId, Guid id, ReservationForUpdateDto reservation);
    Task<(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)> GetReservationForPatchAsync
        (Guid roomId, Guid id);
    Task<ReservationDto> SaveChangesForPatchAsync(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity);
    Task DeleteReservationForRoomAsync(Guid roomId, Guid id);
}