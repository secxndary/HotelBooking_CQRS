using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IRoomPhotoService
{
    Task<(IEnumerable<RoomPhotoDto> roomPhotos, MetaData metaData)> GetRoomPhotosAsync
        (Guid roomId, RoomPhotoParameters roomPhotoParameters);
    Task<IEnumerable<RoomPhotoDto>> GetByIdsAsync(Guid roomId, IEnumerable<Guid> ids);
    Task<RoomPhotoDto> GetRoomPhotoAsync(Guid roomId, Guid id);
    Task<RoomPhotoDto> CreateRoomPhotoAsync(Guid roomId, RoomPhotoForCreationDto roomPhoto);
    Task<(IEnumerable<RoomPhotoDto> roomPhotos, string ids)> CreateRoomPhotoCollectionAsync
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection);
    Task<RoomPhotoDto> UpdateRoomPhotoAsync(Guid roomId, Guid id, RoomPhotoForUpdateDto roomPhoto);
    Task<(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity)> GetRoomPhotoForPatchAsync
        (Guid roomId, Guid id);
    Task<RoomPhotoDto> SaveChangesForPatchAsync(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity);
    Task DeleteRoomPhotoAsync(Guid roomId, Guid id);
}