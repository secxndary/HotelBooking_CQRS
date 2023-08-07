using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class HotelPhotoConfiguration : IEntityTypeConfiguration<HotelPhoto>
{
    public void Configure(EntityTypeBuilder<HotelPhoto> builder)
    {
        builder.HasData
        (
            // President Hotel
            new HotelPhoto
            {
                Id = new Guid("c348d19a-e17a-4d27-8ff9-f6ab68130e3a"),
                Path = @"../../../Content/Images/Hotels/president-1.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("59458cf1-d34c-46ea-b723-02b805da8ea8"),
                Path = @"../../../Content/Images/Hotels/president-2.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("df864455-1cb5-4055-80fe-02aa5a64d643"),
                Path = @"../../../Content/Images/Hotels/president-3.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("5d7dd90e-52eb-4252-9c98-85f04347fb77"),
                Path = @"../../../Content/Images/Hotels/president-4.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("a061132d-d023-45dd-af0e-b64a4621367c"),
                Path = @"../../../Content/Images/Hotels/president-5.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("d63d7704-65aa-4ba3-bca1-daedf16c4769"),
                Path = @"../../../Content/Images/Hotels/president-6.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("04c07bdb-7007-44cb-93da-88cbc804eb42"),
                Path = @"../../../Content/Images/Hotels/president-7.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("bee00602-95cd-4b33-b481-4a0c96a59a4e"),
                Path = @"../../../Content/Images/Hotels/president-8.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            },
            new HotelPhoto
            {
                Id = new Guid("bdf29223-54a6-4bd5-bcdc-acf82f191d0a"),
                Path = @"../../../Content/Images/Hotels/president-9.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("abafd7d4-6505-432a-87cd-5697610e80a3"),
                Path = @"../../../Content/Images/Hotels/president-10.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("b6f53299-7bb6-40e8-a199-a0ff89f80ed1"),
                Path = @"../../../Content/Images/Hotels/president-11.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("e82233dd-6b1e-4aac-b0f3-cc266c8b7e30"),
                Path = @"../../../Content/Images/Hotels/president-12.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            },
            new HotelPhoto
            {
                Id = new Guid("2582f52f-ee8e-4883-80c0-da66964834fc"),
                Path = @"../../../Content/Images/Hotels/president-13.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("44072262-47f2-4de3-9228-fd70b8dc6152"),
                Path = @"../../../Content/Images/Hotels/president-14.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            }, 
            new HotelPhoto
            {
                Id = new Guid("c1454523-6462-4ad3-ada9-586ac4cd15d4"),
                Path = @"../../../Content/Images/Hotels/president-15.jpeg",
                HotelId = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a")
            },
            
            // Belarus Hotel
            new HotelPhoto
            {
                Id = new Guid("3d342424-c0bb-430a-aaa5-e7f4f303218c"),
                Path = @"../../../Content/Images/Hotels/belarus-1.jpeg",
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee")
            }, 
            new HotelPhoto
            {
                Id = new Guid("e6ed8378-aab5-4092-93e3-07d71d8011d3"),
                Path = @"../../../Content/Images/Hotels/belarus-2.jpeg",
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee")
            },
            new HotelPhoto
            {
                Id = new Guid("b4df0d3f-ffea-4da9-a35c-0ea2a0a6c711"),
                Path = @"../../../Content/Images/Hotels/belarus-3.jpeg",
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee")
            }, 
            new HotelPhoto
            {
                Id = new Guid("f2bbfc71-b2ca-42b7-a010-8eb12b0cb70f"),
                Path = @"../../../Content/Images/Hotels/belarus-4.jpeg",
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee")
            }, 
            new HotelPhoto
            {
                Id = new Guid("f62ed813-562d-4e4f-95d1-ff385b11f016"),
                Path = @"../../../Content/Images/Hotels/belarus-5.jpeg",
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee")
            }, 
            new HotelPhoto
            {
                Id = new Guid("119747c5-ddf0-4424-9fbd-9b5d72436961"),
                Path = @"../../../Content/Images/Hotels/belarus-6.jpeg",
                HotelId = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee")
            },

            // Tourist Hotel
            new HotelPhoto
            {
                Id = new Guid("0f8acada-d7bd-48dc-9bcb-dab862f9d7fb"),
                Path = @"../../../Content/Images/Hotels/tourist-1.jpeg",
                HotelId = new Guid("f934d940-f542-400b-8182-aea42a9b0773")
            },
            new HotelPhoto
            {
                Id = new Guid("a1409c52-f913-484a-8818-50faf356e758"),
                Path = @"../../../Content/Images/Hotels/tourist-2.jpeg",
                HotelId = new Guid("f934d940-f542-400b-8182-aea42a9b0773")
            }, 
            new HotelPhoto
            {
                Id = new Guid("b9c30434-24b1-431e-ab90-983e94304d5b"),
                Path = @"../../../Content/Images/Hotels/tourist-3.jpeg",
                HotelId = new Guid("f934d940-f542-400b-8182-aea42a9b0773")
            }, 
            new HotelPhoto
            {
                Id = new Guid("d7493c84-ae52-489a-8b22-57263819df3b"),
                Path = @"../../../Content/Images/Hotels/tourist-4.jpeg",
                HotelId = new Guid("f934d940-f542-400b-8182-aea42a9b0773")
            },

            // Polyana Hotel
            new HotelPhoto
            {
                Id = new Guid("ebe39b18-6a9d-46d3-a46e-9edc75341e2f"),
                Path = @"../../../Content/Images/Hotels/polyana-1.jpeg",
                HotelId = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9")
            }, 
            new HotelPhoto
            {
                Id = new Guid("b79c720e-70cc-435f-a099-60fcfdef0ffd"),
                Path = @"../../../Content/Images/Hotels/polyana-2.jpeg",
                HotelId = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9")
            }, 
            new HotelPhoto
            {
                Id = new Guid("74b7273d-2eb3-4e10-825d-0113584ca033"),
                Path = @"../../../Content/Images/Hotels/polyana-3.jpeg",
                HotelId = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9")
            }
        );
    }
}
