using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomPhotoRepository
{
    Task<PagedList<RoomPhoto>> GetRoomPhotosAsync(Guid roomId, RoomPhotoParameters roomPhotoParameters, bool trackChanges);
    Task<IEnumerable<RoomPhoto>> GetByIdsAsync(Guid roomId, IEnumerable<Guid> ids, bool trackChanges);
    Task<RoomPhoto?> GetRoomPhotoAsync(Guid roomId, Guid id, bool trackChanges);
    void CreateRoomPhoto(Guid roomId, RoomPhoto roomPhoto);
    void DeleteRoomPhoto(RoomPhoto photo);
}