using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.BadRequest.Collections;
using Entities.Exceptions.NotFound;
using Entities.Models.UserModels;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.UserServicesImpl;

public sealed class RoomPhotoService : IRoomPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoomPhotoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<RoomPhotoDto> roomPhotos, MetaData metaData)> GetRoomPhotosAsync
        (Guid roomId, RoomPhotoParameters roomPhotoParameters)
    {
        await CheckIfRoomExists(roomId);

        var roomPhotosWithMetaData = await _repository.RoomPhoto.GetRoomPhotosAsync(roomId, roomPhotoParameters, trackChanges: false);
        var roomPhotosDto = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotosWithMetaData);
        
        return (roomPhotos: roomPhotosDto, metaData: roomPhotosWithMetaData.MetaData);
    }

    public async Task<IEnumerable<RoomPhotoDto>> GetByIdsAsync(Guid roomId, IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        await CheckIfRoomExists(roomId);

        var roomPhotos = await _repository.RoomPhoto.GetByIdsAsync(roomId, ids, trackChanges: false);
        if (roomPhotos.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var roomPhotosDto = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotos);
        return roomPhotosDto;
    }

    public async Task<RoomPhotoDto> GetRoomPhotoAsync(Guid roomId, Guid id)
    {
        await CheckIfRoomExists(roomId);

        var roomPhoto = await GetRoomPhotoAndCheckIfItExists(roomId, id, trackChanges: false);
        var roomPhotoDto = _mapper.Map<RoomPhotoDto>(roomPhoto);
        
        return roomPhotoDto;
    }

    public async Task<RoomPhotoDto> CreateRoomPhotoAsync(Guid roomId, RoomPhotoForCreationDto roomPhoto)
    {
        await CheckIfRoomExists(roomId);

        var roomPhotoEntity = _mapper.Map<RoomPhoto>(roomPhoto);
        _repository.RoomPhoto.CreateRoomPhoto(roomId, roomPhotoEntity);
        await _repository.SaveAsync();

        var roomPhotoToReturn = _mapper.Map<RoomPhotoDto>(roomPhotoEntity);
        return roomPhotoToReturn;
    }

    public async Task<(IEnumerable<RoomPhotoDto> roomPhotos, string ids)> CreateRoomPhotoCollectionAsync
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection)
    {
        if (roomPhotosCollection is null)
            throw new RoomPhotoCollectionBadRequest();

        var roomPhotosEntities = _mapper.Map<IEnumerable<RoomPhoto>>(roomPhotosCollection);
        foreach (var roomPhoto in roomPhotosEntities)
            _repository.RoomPhoto.CreateRoomPhoto(roomId, roomPhoto);
        await _repository.SaveAsync();

        var roomPhotosCollectionToReturn = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotosEntities);
        var ids = string.Join(",", roomPhotosCollectionToReturn.Select(p => p.Id));
        return (roomPhotos: roomPhotosCollectionToReturn, ids);
    }

    public async Task<RoomPhotoDto> UpdateRoomPhotoAsync(Guid roomId, Guid id, RoomPhotoForUpdateDto roomPhotoForUpdate)
    {
        await CheckIfRoomExists(roomId);

        var roomPhotoEntity = await GetRoomPhotoAndCheckIfItExists(roomId, id, trackChanges: true);
        _mapper.Map(roomPhotoForUpdate, roomPhotoEntity);
        await _repository.SaveAsync();

        var roomPhotoToReturn = _mapper.Map<RoomPhotoDto>(roomPhotoEntity);
        return roomPhotoToReturn;
    }

    public async Task<(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity)> 
        GetRoomPhotoForPatchAsync(Guid roomId, Guid id)
    {
        await CheckIfRoomExists(roomId);

        var roomPhotoEntity = await GetRoomPhotoAndCheckIfItExists(roomId, id, trackChanges: true);
        var photoToPatch = _mapper.Map<RoomPhotoForUpdateDto>(roomPhotoEntity);
        
        return (photoToPatch, roomPhotoEntity);
    }

    public async Task<RoomPhotoDto> SaveChangesForPatchAsync(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity)
    {
        _mapper.Map(roomPhotoToPatch, roomPhotoEntity);
        await _repository.SaveAsync();

        var roomPhotoToReturn = _mapper.Map<RoomPhotoDto>(roomPhotoEntity);
        return roomPhotoToReturn;
    }

    public async Task DeleteRoomPhotoAsync(Guid roomId, Guid id)
    {
        await CheckIfRoomExists(roomId);

        var roomPhoto = await GetRoomPhotoAndCheckIfItExists(roomId, id, trackChanges: false);

        _repository.RoomPhoto.DeleteRoomPhoto(roomPhoto);
        await _repository.SaveAsync();
    }


    private async Task CheckIfRoomExists(Guid roomId)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges: false);
        if (room is null)
            throw new RoomNotFoundException(roomId);
    }

    private async Task<RoomPhoto> GetRoomPhotoAndCheckIfItExists(Guid roomId, Guid id, bool trackChanges)
    {
        var roomPhoto = await _repository.RoomPhoto.GetRoomPhotoAsync(roomId, id, trackChanges);
        if (roomPhoto is null)
            throw new RoomPhotoNotFoundException(id);
        return roomPhoto;
    }
}