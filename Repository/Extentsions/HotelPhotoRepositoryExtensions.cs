using Entities.Models.UserModels;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
namespace Repository.Extentsions;

public static class HotelPhotoRepositoryExtensions
{
    public static IQueryable<HotelPhoto> Search(this IQueryable<HotelPhoto> hotelPhotos, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return hotelPhotos;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return hotelPhotos.Where(p => p.Path!.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<HotelPhoto> Sort(this IQueryable<HotelPhoto> hotelPhotos, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return hotelPhotos.OrderBy(p => p.Path);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelPhoto>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return hotelPhotos.OrderBy(p => p.Path);

        return hotelPhotos.OrderBy(orderQuery);
    }
}
