using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects.OutputDtos;

namespace HotelBooking;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(HotelDto).IsAssignableFrom(type) ||
            typeof(IEnumerable<HotelDto>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }

    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context, 
        Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        if (context.Object is IEnumerable<HotelDto>)
            foreach (var hotel in (IEnumerable<HotelDto>)context.Object)
                FormatCsv(buffer, hotel);
        else
            FormatCsv(buffer, (HotelDto)context!.Object!);
        await response.WriteAsync(buffer.ToString());
    }

    private static void FormatCsv(StringBuilder buffer, HotelDto hotel)
    {
        buffer.AppendLine($"{hotel.Id},{hotel.Name},\"{hotel.Description}\"");
    }
}