using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad56ac2-4efd-4626-99f9-a518acdbb386");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dbce4e0-48ff-4231-9520-7d5a05f1f576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a037d785-94a0-4925-9159-08d169745681");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577", null, "User", "USER" },
                    { "744a95cd-b364-44bd-842d-6ca02f9fe5fa", null, "Hotel Owner", "HOTEL_OWNER" },
                    { "f51135f0-adf7-4506-960e-f10ae287f792", null, "Administrator", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bb2806b-1cf8-4dfd-9b69-ffc889f3e577");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "744a95cd-b364-44bd-842d-6ca02f9fe5fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f51135f0-adf7-4506-960e-f10ae287f792");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ad56ac2-4efd-4626-99f9-a518acdbb386", null, "Administrator", "ADMIN" },
                    { "3dbce4e0-48ff-4231-9520-7d5a05f1f576", null, "User", "USER" },
                    { "a037d785-94a0-4925-9159-08d169745681", null, "Hotel Owner", "HOTEL_OWNER" }
                });
        }
    }
}
