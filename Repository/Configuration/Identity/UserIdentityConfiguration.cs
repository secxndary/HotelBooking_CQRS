using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration.Identity;

public class UserIdentityConfiguration : IEntityTypeConfiguration<UserIdentity>
{
    public void Configure(EntityTypeBuilder<UserIdentity> builder)
    {
        builder.HasData
        (
            new UserIdentity
            {
                Id = "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "johndoe@example.org",
                NormalizedUserName = "JOHNDOE",
                NormalizedEmail = "JOHNDOE@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375291234567",
            },
            new UserIdentity
            {
                Id = "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                FirstName = "Jane",
                LastName = "Doe",
                UserName = "janedoe",
                Email = "janedoe@example.org",
                NormalizedUserName = "JANEDOE",
                NormalizedEmail = "JANEDOE@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375447654321",
            },
            new UserIdentity
            {
                Id = "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                FirstName = "Alexander",
                LastName = "Valdaitsev",
                UserName = "valdaitsevv",
                Email = "valdaitsevv@mail.ru",
                NormalizedUserName = "VALDAITSEVV",
                NormalizedEmail = "VALDAITSEVV@MAIL.RU",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375445574506",
            },
            new UserIdentity
            {
                Id = "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                FirstName = "Katherine",
                LastName = "Vrublevskaya",
                UserName = "sashasbabe",
                Email = "katie@mail.ru",
                NormalizedUserName = "SASHASBABE",
                NormalizedEmail = "KATIE@MAIL.RU",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375333749235",
            },
            new UserIdentity
            {
                Id = "f94a3937-8935-48a4-81f3-4d6e33603c65",
                FirstName = "Default",
                LastName = "User",
                UserName = "user",
                Email = "default@example.org",
                NormalizedUserName = "USER",
                NormalizedEmail = "DEFAULT@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375294859923",
            },
            new UserIdentity
            {
                Id = "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                FirstName = "Admin",
                LastName = "Root",
                UserName = "root",
                Email = "root@example.org",
                NormalizedUserName = "ROOT",
                NormalizedEmail = "ROOT@EXAMPLE.ORG",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375449274568",
            },
            new UserIdentity
            {
                Id = "c459163f-341b-4073-a7b7-067c1ceeac15",
                FirstName = "Александр",
                LastName = "Кротниченко",
                UserName = "presidentowner",
                Email = "krotnichenko@gmail.com",
                NormalizedUserName = "PRESIDENTOWNER",
                NormalizedEmail = "KROTNICHENKO@GMAIL.COM",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375333744859",
            },
            new UserIdentity
            {
                Id = "42e40179-1f6c-41b7-be2f-754023e576fa",
                FirstName = "Дмитрий",
                LastName = "Шаман",
                UserName = "shaman",
                Email = "shaman@belstu.by",
                NormalizedUserName = "SHAMAN",
                NormalizedEmail = "SHAMAN@BELSTU.BY",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375293749574",
            },
            new UserIdentity
            {
                Id = "ed3707a2-a416-4318-95a6-e462b10e9936",
                FirstName = "Василиса",
                LastName = "Мазенкова",
                UserName = "vmazenkova",
                Email = "vmazenkova@mail.ru",
                NormalizedUserName = "VMAZENKOVA",
                NormalizedEmail = "VMAZENKOVA@MAIL.RU",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375447568124",
            },
            new UserIdentity
            {
                Id = "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                FirstName = "Виктор",
                LastName = "Кондратьев",
                UserName = "viktorrr",
                Email = "viktorkon@gmail.com",
                NormalizedUserName = "VIKTORRR",
                NormalizedEmail = "VIKTORKON@GMAIL.COM",
                LockoutEnabled = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==",
                PhoneNumber = "+375448569125",
            }
        );
    }
}