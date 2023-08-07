namespace Shared.RequestFeatures.UserParameters;

public class RoomParameters : RequestParameters
{
    public RoomParameters() => OrderBy = "Price";

    public uint MinSleepingPlaces { get; set; } = 1;
    public uint MaxSleepingPlaces { get; set; } = 16;

    public uint MinPrice { get; set; }
    public uint MaxPrice { get; set; } = int.MaxValue;

    public bool ValidSleepingPlacesRange => MaxSleepingPlaces > MinSleepingPlaces;
    public bool ValidPriceRange => MaxPrice > MinPrice;
}