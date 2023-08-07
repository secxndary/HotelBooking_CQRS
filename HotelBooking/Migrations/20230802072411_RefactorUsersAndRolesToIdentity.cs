using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUsersAndRolesToIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1567fa9b-7fc8-4f4f-b4df-896397616bfe", 0, "88642fc4-5caf-4b4e-8fcc-2063d377a047", "johndoe@example.org", false, "John", "Doe", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375291234567", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32e30cf7-f9a6-4ed8-b2b7-46c93d05179e", false, "johndoe" },
                    { "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed", 0, "6bad762d-2cda-4667-b5cb-7461c862027b", "janedoe@example.org", false, "Jane", "Doe", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375447654321", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "52fdd3b7-abf3-4b82-8702-d2f5c38f49ed", false, "janedoe" },
                    { "3a08ecca-7fbe-4886-ad58-61998c01c9e0", 0, "a346f9fd-e848-4511-a001-6f50a67228c4", "valdaitsevv@mail.ru", false, "Alexander", "Valdaitsev", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375445574506", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8a68a34c-4589-47a9-bc07-dd2383de6049", false, "valdaitsevv" },
                    { "42e40179-1f6c-41b7-be2f-754023e576fa", 0, "6130f7ca-71de-4dfb-a116-68424261834b", "shaman@belstu.by", false, "Дмитрий", "Шаман", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375293749574", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bb0a9e38-5d3b-4d78-9ca4-8bc5159fb372", false, "shaman" },
                    { "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9", 0, "a33b50d5-04fc-4d3f-9abd-b2474b409497", "katie@mail.ru", false, "Katherine", "Vrublevskaya", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375333749235", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f2a8cb76-d4bf-4f6a-9717-3267ca3fbd4f", false, "sashasbaby" },
                    { "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6", 0, "78a59cb7-8a08-4588-95ca-91fe3187c3e4", "viktorkon@gmail.com", false, "Виктор", "Кондратьев", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375448569125", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a3b3a206-9877-4234-b821-0e7dbc051a60", false, "viktorrr" },
                    { "c459163f-341b-4073-a7b7-067c1ceeac15", 0, "4cc65c62-aa61-4d15-bb74-457763a3c02a", "krotnichenko@gmail.com", false, "Александр", "Кротниченко", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375333744859", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ac337cd4-4a87-4f68-93da-90b9c268db46", false, "presidentowner" },
                    { "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9", 0, "40dbb6a5-a637-415d-9ad7-c9d59954778a", "root@example.org", false, "Admin", "Root", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375449274568", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cc0cf256-8d50-4712-a5e6-068c0bcff2b8", false, "root" },
                    { "ed3707a2-a416-4318-95a6-e462b10e9936", 0, "45e17164-899d-4d15-bf49-90dc761c7074", "vmazenkova@mail.ru", false, "Василиса", "Мазенкова", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375447568124", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a5c5ddd8-cb23-4ea7-b487-ea16c489b674", false, "vmazenkova" },
                    { "f94a3937-8935-48a4-81f3-4d6e33603c65", 0, "5189613f-4f4b-46c8-981d-7e62289ec79d", "default@example.org", false, "Default", "User", false, null, null, null, "AQAAAAIAAYagAAAAEMGzPOccYwucA6sQEj5E55e0KpyBuWurkfoUDOEBTe2FNdkpwiRbKI++HV/hopSptA==", "+375294859923", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eaacf330-806c-4921-8138-91913fabb4aa", false, "user" }
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a"),
                column: "UserId",
                value: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf"),
                column: "UserId",
                value: "f94a3937-8935-48a4-81f3-4d6e33603c65");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061"),
                column: "UserId",
                value: "3a08ecca-7fbe-4886-ad58-61998c01c9e0");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("a9c9cf7b-f141-4a38-836c-da7c4183841d"),
                column: "UserId",
                value: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d"),
                column: "UserId",
                value: "f94a3937-8935-48a4-81f3-4d6e33603c65");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("d013f366-32d2-419b-b413-ee71f557435f"),
                column: "UserId",
                value: "3a08ecca-7fbe-4886-ad58-61998c01c9e0");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c"),
                column: "UserId",
                value: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("ff8f27ee-af5d-485f-9074-0598b9e73ac4"),
                column: "UserId",
                value: "3a08ecca-7fbe-4886-ad58-61998c01c9e0");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "1567fa9b-7fc8-4f4f-b4df-896397616bfe" },
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed" },
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "3a08ecca-7fbe-4886-ad58-61998c01c9e0" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "42e40179-1f6c-41b7-be2f-754023e576fa" },
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "c459163f-341b-4073-a7b7-067c1ceeac15" },
                    { "f51135f0-adf7-4506-960e-f10ae287f792", "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "ed3707a2-a416-4318-95a6-e462b10e9936" },
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "f94a3937-8935-48a4-81f3-4d6e33603c65" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "1567fa9b-7fc8-4f4f-b4df-896397616bfe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "3a08ecca-7fbe-4886-ad58-61998c01c9e0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "42e40179-1f6c-41b7-be2f-754023e576fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "c459163f-341b-4073-a7b7-067c1ceeac15" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f51135f0-adf7-4506-960e-f10ae287f792", "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", "ed3707a2-a416-4318-95a6-e462b10e9936" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", "f94a3937-8935-48a4-81f3-4d6e33603c65" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a"),
                column: "UserId",
                value: new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf"),
                column: "UserId",
                value: new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061"),
                column: "UserId",
                value: new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("a9c9cf7b-f141-4a38-836c-da7c4183841d"),
                column: "UserId",
                value: new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d"),
                column: "UserId",
                value: new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("d013f366-32d2-419b-b413-ee71f557435f"),
                column: "UserId",
                value: new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c"),
                column: "UserId",
                value: new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("ff8f27ee-af5d-485f-9074-0598b9e73ac4"),
                column: "UserId",
                value: new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc"), "Администратор программного средства", "ADMIN" },
                    { new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab"), "Пользователь системы бронирования", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"), "valdaitsevv@mail.ru", "Alexander", "Valdaitsev", "qweqwe", new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab") },
                    { new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"), "katie@mail.ru", "Katherine", "Vrublevskaya", "qweqwe", new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab") },
                    { new Guid("eb8fd43e-aa3d-4bf2-bfac-b70af06668e9"), "root@mail.ru", "Admin", "Root", "2233", new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc") },
                    { new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65"), "user@mail.ru", "Default", "User", "qweqwe", new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
