using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class RoomPhotoConfiguration : IEntityTypeConfiguration<RoomPhoto>
{
    public void Configure(EntityTypeBuilder<RoomPhoto> builder)
    {
        builder.HasData
        (
            // President Hotel - Стандарт
            new RoomPhoto
            {
                Id = new Guid("8e0294f6-8b34-4822-9f0a-b9ffc71eb193"),
                Path = @"../../../Content/Images/Rooms/president-standart-bathroom.jpeg",
                RoomId = new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc")
            },
            new RoomPhoto
            {
                Id = new Guid("a5dbdace-9b51-4cff-8147-b86cbe8debd6"),
                Path = @"../../../Content/Images/Rooms/president-standart-bed.jpeg",
                RoomId = new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc")
            },

            // President Hotel - Люкс
            new RoomPhoto
            {
                Id = new Guid("1099afd2-2a88-40de-b887-9ab9357efbea"),
                Path = @"../../../Content/Images/Rooms/president-lux-bed.jpeg",
                RoomId = new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5")
            },
            new RoomPhoto
            {
                Id = new Guid("513962ee-e04b-4fc6-8316-7d7c70b94b13"),
                Path = @"../../../Content/Images/Rooms/president-lux-livingroom.jpeg",
                RoomId = new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5")
            },

            // President Hotel - Полулюкс
            new RoomPhoto
            {
                Id = new Guid("8585a06c-1e9c-499d-a700-33bf69bdff3b"),
                Path = @"../../../Content/Images/Rooms/president-semilux-bathroom.jpeg",
                RoomId = new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8")
            },
            new RoomPhoto
            {
                Id = new Guid("3edcb92d-7592-49ec-9c71-022c153a9c3d"),
                Path = @"../../../Content/Images/Rooms/president-semilux-bed.jpeg",
                RoomId = new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8")
            },
            new RoomPhoto
            {
                Id = new Guid("52e0843f-8f2e-4a7c-9c3c-ed788b062613"),
                Path = @"../../../Content/Images/Rooms/president-semilux-livingroom.jpeg",
                RoomId = new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8")
            },
            new RoomPhoto
            {
                Id = new Guid("f7fe0be5-a800-443d-93a2-bb90519c71be"),
                Path = @"../../../Content/Images/Rooms/president-semilux-livingroom-2.jpeg",
                RoomId = new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8")
            },

            // President Hotel - Апартаменты
            new RoomPhoto
            {
                Id = new Guid("135c191d-e0c9-4f65-a872-7c9f5ce70ecd"),
                Path = @"../../../Content/Images/Rooms/president-apartments-bed.jpeg",
                RoomId = new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2")
            },
            new RoomPhoto
            {
                Id = new Guid("f4f69c6f-2bf6-4e78-8c9b-21fa7902a701"),
                Path = @"../../../Content/Images/Rooms/president-apartments-kitchen.jpeg",
                RoomId = new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2")
            },
            new RoomPhoto
            {
                Id = new Guid("660e5e4a-221f-4887-8b61-c8b57afb61b5"),
                Path = @"../../../Content/Images/Rooms/president-apartments-livingroom.jpeg",
                RoomId = new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2")
            }, 
            new RoomPhoto
            {
                Id = new Guid("f63a8b8f-8b6b-407d-afa1-e632de572896"),
                Path = @"../../../Content/Images/Rooms/president-apartments-table.jpeg",
                RoomId = new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2")
            },

            // Беларусь - Полулюкс
            new RoomPhoto
            {
                Id = new Guid("0bc90b3c-70bd-447e-9f59-6fa1b7f0170e"),
                Path = @"../../../Content/Images/Rooms/belarus-semilux-bathroom.jpeg",
                RoomId = new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db")
            }, 
            new RoomPhoto
            {
                Id = new Guid("f701db8c-7575-40b9-a1f0-bc2af359a59e"),
                Path = @"../../../Content/Images/Rooms/belarus-semilux-bed.jpeg",
                RoomId = new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db")
            }, 
            new RoomPhoto
            {
                Id = new Guid("2a6cb5f8-e341-4d81-ab56-a0e61d693caf"),
                Path = @"../../../Content/Images/Rooms/belarus-semilux-livingroom.jpeg",
                RoomId = new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db")
            }, 
            new RoomPhoto
            {
                Id = new Guid("ff522e71-70a3-41f2-b462-4485df71c03d"),
                Path = @"../../../Content/Images/Rooms/belarus-semilux-table.jpeg",
                RoomId = new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db")
            },

            // Турист - Стандарт
            new RoomPhoto
            {
                Id = new Guid("67ed8c03-77aa-42fd-87c0-f3e8a93d2fc6"),
                Path = @"../../../Content/Images/Rooms/tourist-standart-bathroom.jpeg",
                RoomId = new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7")
            }, 
            new RoomPhoto
            {
                Id = new Guid("1b73584d-f785-4364-ba1c-41e45772e820"),
                Path = @"../../../Content/Images/Rooms/tourist-standart-bed.jpeg",
                RoomId = new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7")
            }
        );
    }
}
