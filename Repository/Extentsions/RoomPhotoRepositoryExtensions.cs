using Entities.Models.UserModels;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
namespace Repository.Extentsions;

public static class RoomPhotoRepositoryExtensions
{
    public static IQueryable<RoomPhoto> Search(this IQueryable<RoomPhoto> roomPhotos, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return roomPhotos;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return roomPhotos.Where(p => p.Path!.ToLower().Contains(lowerCaseTerm));
    }


    public static IQueryable<RoomPhoto> Sort(this IQueryable<RoomPhoto> roomPhotos, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return roomPhotos.OrderBy(p => p.Path);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<RoomPhoto>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return roomPhotos.OrderBy(p => p.Path);

        return roomPhotos.OrderBy(orderQuery);
    }
}
