using Contracts.Repositories.UserRepositories;
using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<RoomType>> GetAllRoomTypesAsync(RoomTypeParameters roomTypeParameters, bool trackChanges)
    {
        var roomTypes = await FindAll(trackChanges)
            .Search(roomTypeParameters.SearchTerm)
            .Sort(roomTypeParameters.OrderBy)
            .ToListAsync();

        return PagedList<RoomType>.ToPagedList(roomTypes, roomTypeParameters.PageNumber, roomTypeParameters.PageSize);
    }

    public async Task<RoomType?> GetRoomTypeAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRoomType(RoomType roomType) =>
        Create(roomType);

    public void DeleteRoomType(RoomType roomType) =>
        Delete(roomType);
}