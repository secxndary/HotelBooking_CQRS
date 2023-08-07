using Entities.Models.UserModels;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
namespace Repository.Extentsions;

public static class RoomRepositoryExtensions
{
    public static IQueryable<Room> FilterRoomsBySleepingPlaces(this IQueryable<Room> rooms, uint minSleepingPlaces, uint maxSleepingPlaces) =>
        rooms.Where(r => r.SleepingPlaces >= minSleepingPlaces && r.SleepingPlaces <= maxSleepingPlaces);

    public static IQueryable<Room> FilterRoomsByPrice(this IQueryable<Room> rooms, uint minPrice, uint maxPrice) =>
        rooms.Where(r => r.Price >= minPrice && r.Price <= maxPrice);

    public static IQueryable<Room> Sort(this IQueryable<Room> rooms, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return rooms.OrderBy(r => r.Price);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Room>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return rooms.OrderBy(r => r.Price);

        return rooms.OrderBy(orderQuery);
    }
}
