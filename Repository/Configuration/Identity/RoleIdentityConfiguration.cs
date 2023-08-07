using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration.Identity;

public class RoleIdentityConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData
        (
            new IdentityRole
            {
                Id = "f51135f0-adf7-4506-960e-f10ae287f792",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "744a95cd-b364-44bd-842d-6ca02f9fe5fa",
                Name = "HotelOwner",
                NormalizedName = "HOTELOWNER"
            },
            new IdentityRole
            {
                Id = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577",
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}