using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIdentityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "5495234c-ba56-45dd-b4b4-1498ed9dae1b", true, "JOHNDOE@EXAMPLE.ORG", "JOHNDOE", "18ab79cd-6a56-489f-9347-d11fdedd026c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "b8adf16a-73b4-4978-a81b-f248f2f19b7f", true, "JANEDOE@EXAMPLE.ORG", "JANEDOE", "ad1057cb-05ac-45a9-9dfa-b265ba450e16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "7040986f-2083-463c-85ef-55a7adce6ee7", true, "VALDAITSEVV@MAIL.RU", "VALDAITSEVV", "e4971ce8-881a-419e-872d-b42ee04b74c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "f5c40318-2393-49e7-a501-d3deae7a134b", true, "SHAMAN@BELSTU.BY", "SHAMAN", "a0ab07e2-1f66-4a0b-9ab5-9a516aa314c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "32dd396a-5a0b-42de-a7da-b791c5836471", true, "KATIE@MAIL.RU", "SASHASBABE", "2ed78dbc-9b06-4267-8e43-d31b7a5293a8", "sashasbabe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "79c89ca8-1c0d-4306-b82a-b66f6aae6e1e", true, "VIKTORKON@GMAIL.COM", "VIKTORRR", "0a430147-0110-4469-bd83-d2b05bee0a14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "22ccc62e-8f1f-433b-8f21-416ac4478215", true, "KROTNICHENKO@GMAIL.COM", "PRESIDENTOWNER", "a59e3352-9002-4169-b29c-e74b033e8497" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "f116917d-4b22-44d5-8d51-efcc669c02cd", true, "ROOT@EXAMPLE.ORG", "ROOT", "a0468da0-d269-4737-81fb-86c8c7746c81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "c11cab68-c6f9-4710-bf8f-31441e5acdbc", true, "VMAZENKOVA@MAIL.RU", "VMAZENKOVA", "2d6212d4-3ddb-4961-92ce-f9c3acb58f99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "bee40aa7-07fd-49d7-89a6-cd5565fe550b", true, "DEFAULT@EXAMPLE.ORG", "USER", "da78a2c6-fbba-44dd-8634-e8ae34e75bed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "88642fc4-5caf-4b4e-8fcc-2063d377a047", false, null, null, "32e30cf7-f9a6-4ed8-b2b7-46c93d05179e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "6bad762d-2cda-4667-b5cb-7461c862027b", false, null, null, "52fdd3b7-abf3-4b82-8702-d2f5c38f49ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "a346f9fd-e848-4511-a001-6f50a67228c4", false, null, null, "8a68a34c-4589-47a9-bc07-dd2383de6049" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "6130f7ca-71de-4dfb-a116-68424261834b", false, null, null, "bb0a9e38-5d3b-4d78-9ca4-8bc5159fb372" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "a33b50d5-04fc-4d3f-9abd-b2474b409497", false, null, null, "f2a8cb76-d4bf-4f6a-9717-3267ca3fbd4f", "sashasbaby" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "78a59cb7-8a08-4588-95ca-91fe3187c3e4", false, null, null, "a3b3a206-9877-4234-b821-0e7dbc051a60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "4cc65c62-aa61-4d15-bb74-457763a3c02a", false, null, null, "ac337cd4-4a87-4f68-93da-90b9c268db46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "40dbb6a5-a637-415d-9ad7-c9d59954778a", false, null, null, "cc0cf256-8d50-4712-a5e6-068c0bcff2b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "45e17164-899d-4d15-bf49-90dc761c7074", false, null, null, "a5c5ddd8-cb23-4ea7-b487-ea16c489b674" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "5189613f-4f4b-46c8-981d-7e62289ec79d", false, null, null, "eaacf330-806c-4921-8138-91913fabb4aa" });
        }
    }
}
