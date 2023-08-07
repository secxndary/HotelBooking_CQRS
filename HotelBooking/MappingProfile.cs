using AutoMapper;
using Entities.Models;
using Entities.Models.UserModels;
using Shared.DataTransferObjects.AuthenticationDtos;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<RoomType, RoomTypeDto>();
        CreateMap<Room, RoomDto>();
        CreateMap<Hotel, HotelDto>();
        CreateMap<Reservation, ReservationDto>();
        CreateMap<Feedback, FeedbackDto>();
        CreateMap<RoomPhoto, RoomPhotoDto>();
        CreateMap<HotelPhoto,  HotelPhotoDto>();

        CreateMap<RoomTypeForCreationDto, RoomType>();
        CreateMap<RoomForCreationDto, Room>();
        CreateMap<HotelForCreationDto, Hotel>();
        CreateMap<ReservationForCreationDto, Reservation>();
        CreateMap<FeedbackForCreationDto, Feedback>();
        CreateMap<RoomPhotoForCreationDto, RoomPhoto>();
        CreateMap<HotelPhotoForCreationDto, HotelPhoto>();

        CreateMap<RoomTypeForUpdateDto, RoomType>().ReverseMap();
        CreateMap<RoomForUpdateDto, Room>().ReverseMap();
        CreateMap<HotelForUpdateDto, Hotel>().ReverseMap();
        CreateMap<ReservationForUpdateDto, Reservation>().ReverseMap();
        CreateMap<FeedbackForUpdateDto, Feedback>().ReverseMap();
        CreateMap<RoomPhotoForUpdateDto, RoomPhoto>().ReverseMap();
        CreateMap<HotelPhotoForUpdateDto, HotelPhoto>().ReverseMap();

        CreateMap<UserForRegistrationDto, UserIdentity>();

        // TODO: delete everything above
        CreateMap<Hotel, HotelDto>();
    }
}