using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasData
        (
            // Стандартные номера
            new Room
            {
                Id = new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc"),
                Price = 365,
                Quantity = 18,
                SleepingPlaces = 2,
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                RoomTypeId = new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf")
            }, 
            new Room
            {
                Id = new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7"),
                Price = 310,
                Quantity = 20,
                SleepingPlaces = 4,
                HotelId = new Guid("f934d940-f542-400b-8182-aea42a9b0773"),
                RoomTypeId = new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf")
            }, 
            new Room
            {
                Id = new Guid("684ff150-741e-4706-9306-07d4064efdb1"),
                Price = 320,
                Quantity = 14,
                SleepingPlaces = 2,
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                RoomTypeId = new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf")
            },
            new Room
            {
                Id = new Guid("7ab73b73-6712-4454-84d3-1694a61a22eb"),
                Price = 255,
                Quantity = 10,
                SleepingPlaces = 3,
                HotelId = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"),
                RoomTypeId = new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf")
            },

            // Номера люкс
            new Room
            {
                Id = new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5"),
                Price = 678,
                Quantity = 12,
                SleepingPlaces = 2,
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                RoomTypeId = new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa")
            },
            new Room
            {
                Id = new Guid("8c36266a-e422-4489-880a-c279f56340b2"),
                Price = 400,
                Quantity = 6,
                SleepingPlaces = 2,
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                RoomTypeId = new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa")
            },

            // Номера полулюкс
            new Room
            {
                Id = new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db"),
                Price = 370,
                Quantity = 8,
                SleepingPlaces = 4,
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                RoomTypeId = new Guid("386c05e6-a4a5-451f-8363-246ff66367e9")
            },
            new Room
            {
                Id = new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8"),
                Price = 450,
                Quantity = 6,
                SleepingPlaces = 2,
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                RoomTypeId = new Guid("386c05e6-a4a5-451f-8363-246ff66367e9")
            },
            new Room
            {
                Id = new Guid("4c1447d2-50f6-4397-9abb-b9b21e8661f2"),
                Price = 485,
                Quantity = 14,
                SleepingPlaces = 6,
                HotelId = new Guid("f934d940-f542-400b-8182-aea42a9b0773"),
                RoomTypeId = new Guid("386c05e6-a4a5-451f-8363-246ff66367e9")
            },
            new Room
            {
                Id = new Guid("96efe1d7-d219-4beb-a977-c5689fdfa062"),
                Price = 295,
                Quantity = 6,
                SleepingPlaces = 4,
                HotelId = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"),
                RoomTypeId = new Guid("386c05e6-a4a5-451f-8363-246ff66367e9")
            },

            // Номера премиум
            new Room
            {
                Id = new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"),
                Price = 1020,
                Quantity = 2,
                SleepingPlaces = 4,
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                RoomTypeId = new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55")
            },
            new Room
            {
                Id = new Guid("fe3b278a-3271-4a08-9b51-731d346fd8dc"),
                Price = 860,
                Quantity = 4,
                SleepingPlaces = 4,
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                RoomTypeId = new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55")
            },

            // Апартаменты
            new Room
            {
                Id = new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2"),
                Price = 1045,
                Quantity = 2,
                SleepingPlaces = 8,
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                RoomTypeId = new Guid("984c5d2c-28f4-4ecc-ad45-d3c59d16fdbf")
            }
        );
    }
}
