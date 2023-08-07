using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration.Identity;

public class UserIRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData
        (
            // Admin
            new IdentityUserRole<string>
            {
                UserId = "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                RoleId = "f51135f0-adf7-4506-960e-f10ae287f792"
            },
            // Users
            new IdentityUserRole<string>
            {
                UserId = "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            new IdentityUserRole<string>
            {
                UserId = "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            new IdentityUserRole<string>
            {
                UserId = "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            new IdentityUserRole<string>
            {
                UserId = "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            new IdentityUserRole<string>
            {
                UserId = "f94a3937-8935-48a4-81f3-4d6e33603c65",
                RoleId = "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577"
            },
            // HotelOwners
            new IdentityUserRole<string>
            {
                UserId = "c459163f-341b-4073-a7b7-067c1ceeac15",
                RoleId = "744a95cd-b364-44bd-842d-6ca02f9fe5fa"
            },
            new IdentityUserRole<string>
            {
                UserId = "42e40179-1f6c-41b7-be2f-754023e576fa",
                RoleId = "744a95cd-b364-44bd-842d-6ca02f9fe5fa"
            },
            new IdentityUserRole<string>
            {
                UserId = "ed3707a2-a416-4318-95a6-e462b10e9936",
                RoleId = "744a95cd-b364-44bd-842d-6ca02f9fe5fa"
            },
            new IdentityUserRole<string>
            {
                UserId = "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                RoleId = "744a95cd-b364-44bd-842d-6ca02f9fe5fa"
            }
        );
    }
}