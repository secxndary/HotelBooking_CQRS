using Contracts.Repositories.UserRepositories;
namespace Contracts.Repository;

public interface IRepositoryManager
{
    IRoomTypeRepository RoomType { get; }
    IRoomRepository Room { get; }
    IHotelRepository Hotel { get; }
    IReservationRepository Reservation { get; }
    IFeedbackRepository Feedback { get; }
    IRoomPhotoRepository RoomPhoto { get; }
    IHotelPhotoRepository HotelPhoto { get; }
    Task SaveAsync();
}