using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasData
        (
            new RoomType
            {
                Id = new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"),
                Name = "Стандарт",
                Description = "Стандартный классический номер"
            },
            new RoomType
            {
                Id = new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa"),
                Name = "Люкс",
                Description = "Для богатых"
            },
            new RoomType
            {
                Id = new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"),
                Name = "Полулюкс",
                Description = "Для полубогатых"
            },
            new RoomType
            {
                Id = new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55"),
                Name = "Премиум",
                Description = "Для очень богатых"
            },
            new RoomType
            {
                Id = new Guid("984c5d2c-28f4-4ecc-ad45-d3c59d16fdbf"),
                Name = "Апартаменты",
                Description = "Для большого количества гостей"
            }
        );
    }
}
