using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Authentication;
using Service.Contracts;
using Service.Contracts.Authentication;
using Service.Contracts.UserServices;
using Service.UserServicesImpl;
namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IRoomTypeService> _roomTypeService;
    private readonly Lazy<IRoomService> _roomService;
    private readonly Lazy<IHotelService> _hotelService;
    private readonly Lazy<IReservationService> _reservationService;
    private readonly Lazy<IFeedbackService> _feedbackService;
    private readonly Lazy<IRoomPhotoService> _roomPhotoService;
    private readonly Lazy<IHotelPhotoService> _hotelPhotoService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IRoomLinks roomLinks, 
        UserManager<UserIdentity> userManager, RoleManager<IdentityRole> roleManager, IOptionsSnapshot<JwtConfiguration> config)
    {
        _roomTypeService = new Lazy<IRoomTypeService>(() => new RoomTypeService(repository, logger, mapper));
        _roomService = new Lazy<IRoomService>(() => new RoomService(repository, logger, mapper, roomLinks));
        _hotelService = new Lazy<IHotelService>(() => new HotelService(repository, logger, mapper));
        _reservationService = new Lazy<IReservationService>(() =>  new ReservationService(repository, logger, mapper));
        _feedbackService = new Lazy<IFeedbackService>(() => new FeedbackService(repository, logger, mapper));
        _roomPhotoService = new Lazy<IRoomPhotoService>(() => new RoomPhotoService(repository, logger, mapper));
        _hotelPhotoService = new Lazy<IHotelPhotoService>(() => new HotelPhotoService(repository, logger, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() => 
            new AuthenticationService(logger, mapper, userManager, roleManager, config));
    }

    public IRoomTypeService RoomTypeService => _roomTypeService.Value;
    public IRoomService RoomService => _roomService.Value;
    public IHotelService HotelService => _hotelService.Value;
    public IReservationService ReservationService => _reservationService.Value;
    public IFeedbackService FeedbackService => _feedbackService.Value;
    public IRoomPhotoService RoomPhotoService => _roomPhotoService.Value;
    public IHotelPhotoService HotelPhotoService => _hotelPhotoService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}