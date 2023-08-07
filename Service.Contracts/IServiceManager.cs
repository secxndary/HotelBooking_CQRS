using Service.Contracts.Authentication;
using Service.Contracts.UserServices;
namespace Service.Contracts;

public interface IServiceManager
{
    IRoomTypeService RoomTypeService { get; }
    IRoomService RoomService { get; }
    IHotelService HotelService { get; }
    IReservationService ReservationService { get; }
    IFeedbackService FeedbackService { get; }
    IRoomPhotoService RoomPhotoService { get; }
    IHotelPhotoService HotelPhotoService { get; }
    IAuthenticationService AuthenticationService { get; }
}