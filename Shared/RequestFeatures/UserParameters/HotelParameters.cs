using Shared.RequestFeatures.Attributes;
namespace Shared.RequestFeatures.UserParameters;

public class HotelParameters : RequestParameters
{
    public uint MinStars { get; set; } = 1;
    public uint MaxStars { get; set; } = 5;

    [SwaggerIgnore]
    public bool ValidStarsRange => MaxStars >= MinStars;

    public string? SearchTerm { get; set; }
}