using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IRoomTypeService
{
    Task<(IEnumerable<RoomTypeDto> roomTypes, MetaData metaData)> GetAllRoomTypesAsync(RoomTypeParameters roomTypeParameters);
    Task<RoomTypeDto> GetRoomTypeAsync(Guid id);
    Task<RoomTypeDto> CreateRoomTypeAsync(RoomTypeForCreationDto roomType);
    Task<RoomTypeDto> UpdateRoomTypeAsync(Guid id, RoomTypeForUpdateDto roomType);
    Task<(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)> GetRoomTypeForPatchAsync(Guid id);
    Task<RoomTypeDto> SaveChangesForPatchAsync(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity);
    Task DeleteRoomTypeAsync(Guid id);
}