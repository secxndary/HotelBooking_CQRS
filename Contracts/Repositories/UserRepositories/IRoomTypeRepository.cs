using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomTypeRepository
{
    Task<PagedList<RoomType>> GetAllRoomTypesAsync(RoomTypeParameters roomTypeParameters, bool trackChanges);
    Task<RoomType?> GetRoomTypeAsync(Guid id, bool trackChanges);
    void CreateRoomType(RoomType roomType);
    void DeleteRoomType(RoomType roomType);
}