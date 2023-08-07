using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IHotelPhotoService
{
    Task<(IEnumerable<HotelPhotoDto> hotelPhotos, MetaData metaData)> GetHotelPhotosAsync
        (Guid hotelId, HotelPhotoParameters hotelPhotoParameters);
    Task<IEnumerable<HotelPhotoDto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids);
    Task<HotelPhotoDto> GetHotelPhotoAsync(Guid hotelId, Guid id);
    Task<HotelPhotoDto> CreateHotelPhotoAsync(Guid hotelId, HotelPhotoForCreationDto hotelPhoto);
    Task<(IEnumerable<HotelPhotoDto> hotelPhotos, string ids)> CreateHotelPhotoCollectionAsync
        (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection);
    Task<HotelPhotoDto> UpdateHotelPhotoAsync(Guid hotelId, Guid id, HotelPhotoForUpdateDto hotelPhoto);
    Task<(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity)> GetHotelPhotoForPatchAsync
        (Guid hotelId, Guid id);
    Task<HotelPhotoDto> SaveChangesForPatchAsync(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity);
    Task DeleteHotelPhotoAsync(Guid hotelId, Guid id);
}