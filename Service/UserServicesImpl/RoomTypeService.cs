using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models.UserModels;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.UserServicesImpl;

public sealed class RoomTypeService : IRoomTypeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoomTypeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<RoomTypeDto> roomTypes, MetaData metaData)> GetAllRoomTypesAsync(RoomTypeParameters roomTypeParameters)
    {
        var roomTypesWithMetaData = await _repository.RoomType.GetAllRoomTypesAsync(roomTypeParameters, trackChanges: false);
        var roomTypesDto = _mapper.Map<IEnumerable<RoomTypeDto>>(roomTypesWithMetaData);
        return (roomTypes: roomTypesDto, metaData: roomTypesWithMetaData.MetaData);
    }

    public async Task<RoomTypeDto> GetRoomTypeAsync(Guid id)
    {
        var roomType = await GetRoomTypeAndCheckIfItExists(id, trackChanges: false);
        var roomTypeDto = _mapper.Map<RoomTypeDto>(roomType);
        return roomTypeDto;
    }

    public async Task<RoomTypeDto> CreateRoomTypeAsync(RoomTypeForCreationDto roomType)
    {
        var roomTypeEntity = _mapper.Map<RoomType>(roomType);

        _repository.RoomType.CreateRoomType(roomTypeEntity);
        await _repository.SaveAsync();

        var roomTypeToReturn = _mapper.Map<RoomTypeDto>(roomTypeEntity); 
        return roomTypeToReturn;
    }

    public async Task<RoomTypeDto> UpdateRoomTypeAsync(Guid id, RoomTypeForUpdateDto roomTypeForUpdate)
    {
        var roomTypeEntity = await GetRoomTypeAndCheckIfItExists(id, trackChanges: true);

        _mapper.Map(roomTypeForUpdate, roomTypeEntity);
        await _repository.SaveAsync();

        var roomTypeToReturn = _mapper.Map<RoomTypeDto>(roomTypeEntity);
        return roomTypeToReturn;
    }

    public async Task<(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)> GetRoomTypeForPatchAsync(Guid id)
    {
        var roomTypeEntity = await GetRoomTypeAndCheckIfItExists(id, trackChanges: true);
        var roomTypeToPatch = _mapper.Map<RoomTypeForUpdateDto>(roomTypeEntity);
        return (roomTypeToPatch, roomTypeEntity);
    }

    public async Task<RoomTypeDto> SaveChangesForPatchAsync(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)
    {
        _mapper.Map(roomTypeToPatch, roomTypeEntity);
        await _repository.SaveAsync();

        var roomTypeToReturn = _mapper.Map<RoomTypeDto>(roomTypeEntity);
        return roomTypeToReturn;
    }

    public async Task DeleteRoomTypeAsync(Guid id)
    {
        var roomType = await GetRoomTypeAndCheckIfItExists(id, trackChanges: false);
        _repository.RoomType.DeleteRoomType(roomType);
        await _repository.SaveAsync();
    }


    private async Task<RoomType> GetRoomTypeAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var roomType = await _repository.RoomType.GetRoomTypeAsync(id, trackChanges);
        if (roomType is null)
            throw new RoomTypeNotFoundException(id);
        return roomType;
    }
}