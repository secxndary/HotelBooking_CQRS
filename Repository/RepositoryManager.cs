using Contracts.Repositories.UserRepositories;
using Contracts.Repository;
using Repository.UserRepositoriesImpl;
namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;

    private readonly Lazy<IRoomTypeRepository> _roomTypeRepository;
    private readonly Lazy<IRoomRepository> _roomRepository;
    private readonly Lazy<IHotelRepository> _hotelRepository;
    private readonly Lazy<IReservationRepository> _reservationRepository;
    private readonly Lazy<IFeedbackRepository> _feedbackRepository;
    private readonly Lazy<IRoomPhotoRepository> _roomPhotoRepository;
    private readonly Lazy<IHotelPhotoRepository> _hotelPhotoRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _roomTypeRepository = new Lazy<IRoomTypeRepository>(() => new RoomTypeRepository(repositoryContext));
        _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(repositoryContext));
        _hotelRepository = new Lazy<IHotelRepository>(() => new HotelRepository(repositoryContext));
        _reservationRepository = new Lazy<IReservationRepository>(() => new ReservationRepository(repositoryContext));
        _feedbackRepository = new Lazy<IFeedbackRepository>(()=> new FeedbackRepository(repositoryContext));
        _roomPhotoRepository = new Lazy<IRoomPhotoRepository>(() => new RoomPhotoRepository(repositoryContext));
        _hotelPhotoRepository = new Lazy<IHotelPhotoRepository>(() => new HotelPhotoRepository(repositoryContext));
    }

    public IRoomTypeRepository RoomType => _roomTypeRepository.Value;
    public IRoomRepository Room => _roomRepository.Value;
    public IHotelRepository Hotel => _hotelRepository.Value;
    public IReservationRepository Reservation => _reservationRepository.Value;
    public IFeedbackRepository Feedback => _feedbackRepository.Value;
    public IRoomPhotoRepository RoomPhoto => _roomPhotoRepository.Value;
    public IHotelPhotoRepository HotelPhoto => _hotelPhotoRepository.Value;
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}