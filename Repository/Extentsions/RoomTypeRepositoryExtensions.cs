using System.Data;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
using Entities.Models.UserModels;

namespace Repository.Extentsions;

public static class RoomTypeRepositoryExtensions
{
    public static IQueryable<RoomType> Search(this IQueryable<RoomType> roomTypes, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return roomTypes;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var roomTypesWithSearchTermInName = roomTypes
            .Where(r => r.Name!.ToLower().Contains(lowerCaseTerm))
            .Select(r => new { RoomType = r, Priority = 1 });

        var roomTypesWithSearchTermInDescription = roomTypes
            .Where(r =>
                !r.Name!.ToLower().Contains(lowerCaseTerm) &&
                r.Description!.ToLower().Contains(lowerCaseTerm))
            .Select(r => new { RoomType = r, Priority = 2 });

        var result = roomTypesWithSearchTermInName
            .Union(roomTypesWithSearchTermInDescription)
            .OrderBy(r => r.Priority)
            .Select(r => r.RoomType);

        return result;
    }

    public static IQueryable<RoomType> Sort(this IQueryable<RoomType> roomTypes, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return roomTypes.OrderBy(r => r.Name);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<RoomType>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return roomTypes.OrderBy(r => r.Name);

        return roomTypes.OrderBy(orderQuery);
    }
}
