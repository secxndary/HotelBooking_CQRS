using Entities.Models.UserModels;
using Repository.Extentsions.Utility;
using System.Linq.Dynamic.Core;
namespace Repository.Extentsions;

public static class ReservationRepositoryExtensions
{
    public static IQueryable<Reservation> FilterReservationsByDateEntry
        (this IQueryable<Reservation> reservations, DateTime minDateEntry, DateTime maxDateEntry) =>
            reservations.Where(r => r.DateEntry >= minDateEntry && r.DateEntry <= maxDateEntry);

    public static IQueryable<Reservation> FilterReservationsByDateExit
        (this IQueryable<Reservation> reservations, DateTime minDateExit, DateTime maxDateExit) =>
            reservations.Where(r => r.DateExit >= minDateExit && r.DateExit <= maxDateExit);

    public static IQueryable<Reservation> Sort(this IQueryable<Reservation> reservations, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return reservations;

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Reservation>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return reservations;

        return reservations.OrderBy(orderQuery);
    }
}
