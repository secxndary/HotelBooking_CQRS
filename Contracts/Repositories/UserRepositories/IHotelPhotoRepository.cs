using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelPhotoRepository
{
    Task<PagedList<HotelPhoto>> GetHotelPhotosAsync(Guid hotelId, HotelPhotoParameters hotelPhotoParameters, bool trackChanges);
    Task<IEnumerable<HotelPhoto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    Task<HotelPhoto?> GetHotelPhotoAsync(Guid hotelId, Guid id, bool trackChanges);
    void CreateHotelPhoto(Guid hotelId, HotelPhoto hotelPhoto);
    void DeleteHotelPhoto(HotelPhoto photo);
}