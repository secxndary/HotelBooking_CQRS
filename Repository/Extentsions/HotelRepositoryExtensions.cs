using Entities.Models.UserModels;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
namespace Repository.Extentsions;

public static class HotelRepositoryExtensions
{
    public static IQueryable<Hotel> FilterHotelsByStars(this IQueryable<Hotel> hotels, uint minStars, uint maxStars) =>
        hotels.Where(h => h.Stars >= minStars && h.Stars <= maxStars);

    public static IQueryable<Hotel> Search(this IQueryable<Hotel> hotels, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return hotels;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var hotelsWithSearchTermInName = hotels
            .Where(h => h.Name!.ToLower().Contains(lowerCaseTerm))
            .Select(h => new { Hotel = h, Priority = 1 });

        var hotelsWithSearchTermInDescription = hotels
            .Where(h => 
                !h.Name!.ToLower().Contains(lowerCaseTerm) && 
                h.Description!.ToLower().Contains(lowerCaseTerm))
            .Select(h => new { Hotel = h, Priority = 2 });

        var result = hotelsWithSearchTermInName
            .Union(hotelsWithSearchTermInDescription)
            .OrderBy(h => h.Priority)
            .Select(h => h.Hotel);

        return result;
    }

    public static IQueryable<Hotel> Sort(this IQueryable<Hotel> hotels, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return hotels.OrderByDescending(h => h.Stars);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Hotel>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return hotels.OrderByDescending(h => h.Stars);

        return hotels.OrderBy(orderQuery);
    }
}
