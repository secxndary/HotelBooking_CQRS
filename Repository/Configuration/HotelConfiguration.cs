using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasData
        (
            new Hotel
            {
                Id = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                Name = "President Hotel",
                Stars = 5,
                Description = "Президентский отель Премиум-класса"
            },
            new Hotel
            {
                Id = new Guid("f934d940-f542-400b-8182-aea42a9b0773"),
                Name = "Турист",
                Stars = 3,
                Description = "Дефолтный 3-звездочный отель"
            },
            new Hotel
            {
                Id = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                Name = "Беларусь",
                Stars = 4,
                Description = "Для настоящих патриотов"
            },
            new Hotel
            {
                Id = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"),
                Name = "Поляна",
                Stars = 2,
                Description = "Лесное убежище"
            }
        );
    }
}
