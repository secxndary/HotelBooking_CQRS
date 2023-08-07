using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelRepository
{
    Task<PagedList<Hotel>> GetAllHotelsAsync(HotelParameters hotelParameters, bool trackChanges);
    Task<IEnumerable<Hotel>> GetAllHotelsAsync(bool trackChanges);
    Task<IEnumerable<Hotel>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<Hotel?> GetHotelAsync(Guid id, bool trackChanges);
    void CreateHotel(Hotel hotel);
    void DeleteHotel(Hotel hotel);
}