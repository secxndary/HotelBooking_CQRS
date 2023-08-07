using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class FixReservationUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de2a4f87-8730-4262-91ff-1ef1980c5412", "93d84a39-3e7c-439e-8b57-9761aab170ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5f71539-e810-4a36-9fbb-80b3827d0c39", "67d21d8b-b85d-4f6a-afb4-d478381305db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67f9092c-beb2-4c53-8d9b-f6d4dca1bd0c", "e79eae36-e050-4cee-ba69-a99c2f9faff3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c27141a-f862-491b-9c67-c45336ed160e", "b4868afa-831d-4148-b29a-424704f33230" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b8de0a4-5bdc-4646-88df-698e5371c596", "d53583a7-9ab7-46f4-bfda-bb8173ee581d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6becbc76-0578-46b8-9ddc-43829e5f8518", "aa90c840-9131-485e-85d6-56d34dd89a73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a690981f-5136-4c73-80c6-2e48a35b7ed5", "98f8ec12-f6fc-427b-bcf2-f24bad1a6b80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8ba9e9e-a42f-4372-bc57-bf0a068a6453", "b88056ab-365d-41df-8529-b710a51ec5d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "616705f7-b2b0-4fca-908c-9b46703dfc75", "10511b01-ce6d-4820-9ea2-fe4422e3200a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a3a56bd-f48a-4367-afc0-0984a05827fd", "39a61a17-123c-4dd2-b8ef-6a7bc2dc7e32" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5495234c-ba56-45dd-b4b4-1498ed9dae1b", "18ab79cd-6a56-489f-9347-d11fdedd026c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b8adf16a-73b4-4978-a81b-f248f2f19b7f", "ad1057cb-05ac-45a9-9dfa-b265ba450e16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7040986f-2083-463c-85ef-55a7adce6ee7", "e4971ce8-881a-419e-872d-b42ee04b74c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5c40318-2393-49e7-a501-d3deae7a134b", "a0ab07e2-1f66-4a0b-9ab5-9a516aa314c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32dd396a-5a0b-42de-a7da-b791c5836471", "2ed78dbc-9b06-4267-8e43-d31b7a5293a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79c89ca8-1c0d-4306-b82a-b66f6aae6e1e", "0a430147-0110-4469-bd83-d2b05bee0a14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22ccc62e-8f1f-433b-8f21-416ac4478215", "a59e3352-9002-4169-b29c-e74b033e8497" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f116917d-4b22-44d5-8d51-efcc669c02cd", "a0468da0-d269-4737-81fb-86c8c7746c81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c11cab68-c6f9-4710-bf8f-31441e5acdbc", "2d6212d4-3ddb-4961-92ce-f9c3acb58f99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bee40aa7-07fd-49d7-89a6-cd5565fe550b", "da78a2c6-fbba-44dd-8634-e8ae34e75bed" });
        }
    }
}
