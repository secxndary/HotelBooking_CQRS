using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasData
        (
            new Reservation
            {
                Id = new Guid("d013f366-32d2-419b-b413-ee71f557435f"),
                DateEntry = new DateTime(2023, 6, 10),
                DateExit = new DateTime(2023, 6, 11),
                RoomId = new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc"),
                UserId = "3a08ecca-7fbe-4886-ad58-61998c01c9e0"
            },
            new Reservation
            {
                Id = new Guid("ff8f27ee-af5d-485f-9074-0598b9e73ac4"),
                DateEntry = new DateTime(2023, 6, 13),
                DateExit = new DateTime(2023, 6, 14),
                RoomId = new Guid("4c1447d2-50f6-4397-9abb-b9b21e8661f2"),
                UserId = "3a08ecca-7fbe-4886-ad58-61998c01c9e0"
            },
            new Reservation
            {
                Id = new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061"),
                DateEntry = new DateTime(2023, 6, 9),
                DateExit = new DateTime(2023, 6, 14),
                RoomId = new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2"),
                UserId = "3a08ecca-7fbe-4886-ad58-61998c01c9e0"
            },
            new Reservation
            {
                Id = new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a"),
                DateEntry = new DateTime(2023, 6, 20),
                DateExit = new DateTime(2023, 6, 22),
                RoomId = new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"),
                UserId = "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"
            },
            new Reservation
            {
                Id = new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c"),
                DateEntry = new DateTime(2023, 7, 5),
                DateExit = new DateTime(2023, 7, 12),
                RoomId = new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"),
                UserId = "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"
            },
            new Reservation
            {
                Id = new Guid("a9c9cf7b-f141-4a38-836c-da7c4183841d"),
                DateEntry = new DateTime(2023, 7, 7),
                DateExit = new DateTime(2023, 7, 10),
                RoomId = new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7"),
                UserId = "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"
            },
            new Reservation
            {
                Id = new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf"),
                DateEntry = new DateTime(2023, 7, 10),
                DateExit = new DateTime(2023, 7, 12),
                RoomId = new Guid("684ff150-741e-4706-9306-07d4064efdb1"),
                UserId = "f94a3937-8935-48a4-81f3-4d6e33603c65"
            },
            new Reservation
            {
                Id = new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d"),
                DateEntry = new DateTime(2023, 7, 9),
                DateExit = new DateTime(2023, 7, 13),
                RoomId = new Guid("96efe1d7-d219-4beb-a977-c5689fdfa062"),
                UserId = "f94a3937-8935-48a4-81f3-4d6e33603c65"
            }
        );
    }
}
