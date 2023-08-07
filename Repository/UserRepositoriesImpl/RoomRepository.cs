using Contracts.Repositories.UserRepositories;
using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<Room>> GetRoomsAsync(Guid hotelId, RoomParameters roomParameters, bool trackChanges)
    {
        var rooms = await FindByCondition(r => r.HotelId.Equals(hotelId), trackChanges)
            .FilterRoomsBySleepingPlaces(roomParameters.MinSleepingPlaces, roomParameters.MaxSleepingPlaces)
            .FilterRoomsByPrice(roomParameters.MinPrice, roomParameters.MaxPrice)
            .Sort(roomParameters.OrderBy)
            .ToListAsync();

        return PagedList<Room>.ToPagedList(rooms, roomParameters.PageNumber, roomParameters.PageSize);
    }

    public async Task<IEnumerable<Room>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(r =>
            r.HotelId.Equals(hotelId) &&
            ids.Contains(r.Id), trackChanges)
        .OrderBy(r => r.Price)
        .ToListAsync();

    public async Task<Room?> GetRoomAsync(Guid hotelId, Guid id, bool trackChanges) =>
        await FindByCondition(r => 
            r.HotelId.Equals(hotelId) && 
            r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<Room?> GetRoomAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRoomForHotel(Guid hotelId, Room room)
    {
        room.HotelId = hotelId;
        Create(room);
    }

    public void DeleteRoom(Room room) =>
        Delete(room);
}