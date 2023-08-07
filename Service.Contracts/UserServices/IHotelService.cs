using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IHotelService
{
    Task<(IEnumerable<HotelDto> hotels, MetaData metaData)> GetAllHotelsAsync(HotelParameters hotelParameters);
    Task<IEnumerable<HotelDto>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<HotelDto> GetHotelAsync(Guid id);
    Task<HotelDto> CreateHotelAsync(HotelForCreationDto hotel);
    Task<(IEnumerable<HotelDto> hotels, string ids)> CreateHotelCollectionAsync 
        (IEnumerable<HotelForCreationDto> hotelCollection);
    Task<HotelDto> UpdateHotelAsync(Guid id, HotelForUpdateDto hotel);
    Task<(HotelForUpdateDto hotelToPatch, Hotel hotelEntity)> GetHotelForPatchAsync(Guid id);
    Task<HotelDto> SaveChangesForPatchAsync(HotelForUpdateDto hotelToPatch, Hotel hotelEntity);
    Task DeleteHotelAsync(Guid id);
}