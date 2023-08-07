using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.BadRequest.Collections;
using Entities.Exceptions.BadRequest.Filtering;
using Entities.Exceptions.NotFound;
using Entities.LinkModels;
using Entities.Models.UserModels;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
namespace Service.UserServicesImpl;

public sealed class RoomService : IRoomService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRoomLinks _roomLinks;

    public RoomService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IRoomLinks roomLinks)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _roomLinks = roomLinks;
    }


    public async Task<(LinkResponse linkResponse, MetaData metaData)> GetRoomsAsync(Guid hotelId, LinkParameters linkParameters)
    {
        if (!linkParameters.RoomParameters.ValidSleepingPlacesRange)
            throw new MaxSleepingPlacesRangeBadRequestException();
        if (!linkParameters.RoomParameters.ValidPriceRange)
            throw new MaxPriceRangeBadRequestException();

        await CheckIfHotelExists(hotelId);

        var roomsWithMetaData = await _repository.Room.GetRoomsAsync(hotelId, linkParameters.RoomParameters, trackChanges: false);
        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(roomsWithMetaData);

        var links = _roomLinks.TryGenerateLinks(roomsDto, linkParameters.RoomParameters.Fields!, hotelId, linkParameters.Context);
        return (linkResponse: links, metaData: roomsWithMetaData.MetaData);
    }

    public async Task<IEnumerable<RoomDto>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        await CheckIfHotelExists(hotelId);

        var rooms = await _repository.Room.GetByIdsForHotelAsync(hotelId, ids, trackChanges: false);
        if (rooms.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);
        return roomsDto;
    }

    public async Task<RoomDto> GetRoomAsync(Guid hotelId, Guid id)
    {
        await CheckIfHotelExists(hotelId);

        var room = await GetRoomForHotelAndCheckIfItExists(hotelId, id, trackChanges: false);
        var roomDto = _mapper.Map<RoomDto>(room);
        
        return roomDto;
    }

    public async Task<RoomDto> CreateRoomForHotelAsync(Guid hotelId, RoomForCreationDto room)
    {
        await CheckIfHotelExists(hotelId);
        await CheckIfRoomTypeExists(room.RoomTypeId);

        var roomEntity = _mapper.Map<Room>(room);
        _repository.Room.CreateRoomForHotel(hotelId, roomEntity);
        await _repository.SaveAsync();

        var roomToReturn = _mapper.Map<RoomDto>(roomEntity);
        return roomToReturn;
    }

    public async Task<(IEnumerable<RoomDto> rooms, string ids)> CreateRoomCollectionAsync
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection)
    {
        if (roomsCollection is null)
            throw new RoomCollectionBadRequest();

        var roomsEntities = _mapper.Map<IEnumerable<Room>>(roomsCollection);
        foreach (var room in roomsEntities)
            _repository.Room.CreateRoomForHotel(hotelId, room);
        await _repository.SaveAsync();

        var roomsCollectionToReturn = _mapper.Map<IEnumerable<RoomDto>>(roomsEntities);
        var ids = string.Join(",", roomsCollectionToReturn.Select(r => r.Id));
        return (rooms: roomsCollectionToReturn, ids);
    }

    public async Task<RoomDto> UpdateRoomForHotelAsync(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate)
    {
        await CheckIfHotelExists(hotelId);
        await CheckIfRoomTypeExists(roomForUpdate.RoomTypeId);

        var roomEntity = await GetRoomForHotelAndCheckIfItExists(hotelId, id, trackChanges: true);
        _mapper.Map(roomForUpdate, roomEntity);
        await _repository.SaveAsync();

        var roomToReturn = _mapper.Map<RoomDto>(roomEntity);
        return roomToReturn;
    }

    public async Task<(RoomForUpdateDto roomToPatch, Room roomEntity)> GetRoomForPatchAsync(Guid hotelId, Guid id)
    {
        await CheckIfHotelExists(hotelId);

        var roomEntity = await GetRoomForHotelAndCheckIfItExists(hotelId, id, trackChanges: true);
        var roomToPatch = _mapper.Map<RoomForUpdateDto>(roomEntity);
    
        return (roomToPatch, roomEntity);
    }

    public async Task<RoomDto> SaveChangesForPatchAsync(RoomForUpdateDto roomToPatch, Room roomEntity)
    {
        _mapper.Map(roomToPatch, roomEntity);
        await _repository.SaveAsync();

        var roomToReturn = _mapper.Map<RoomDto>(roomEntity);
        return roomToReturn;
    }

    public async Task DeleteRoomForHotelAsync(Guid hotelId, Guid id)
    {
        await CheckIfHotelExists(hotelId);
        
        var room = await GetRoomForHotelAndCheckIfItExists(hotelId, id, trackChanges: false);
        
        _repository.Room.DeleteRoom(room);
        await _repository.SaveAsync();
    }


    private async Task CheckIfHotelExists(Guid hotelId)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
    }

    private async Task CheckIfRoomTypeExists(Guid roomTypeId)
    {
        var roomType = await _repository.RoomType.GetRoomTypeAsync(roomTypeId, trackChanges: false);
        if (roomType is null)
            throw new RoomTypeNotFoundException(roomTypeId);
    }

    private async Task<Room> GetRoomForHotelAndCheckIfItExists(Guid hotelId, Guid id, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(hotelId, id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);
        return room;
    }
}