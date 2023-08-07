namespace Shared.RequestFeatures.UserParameters;

public class ReservationlParameters : RequestParameters
{
    public DateTime MinDateEntry { get; set; } = DateTime.MinValue;
    public DateTime MaxDateEntry { get; set; } = DateTime.MaxValue;

    public DateTime MinDateExit { get; set; } = DateTime.MinValue;
    public DateTime MaxDateExit { get; set; } = DateTime.MaxValue;

    public bool ValidDateEntry => MaxDateEntry > MinDateEntry;
    public bool ValidDateExit => MaxDateExit > MinDateExit;
}