using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelOwnerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "744a95cd-b364-44bd-842d-6ca02f9fe5fa",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "HotelOwner", "HOTELOWNER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "744a95cd-b364-44bd-842d-6ca02f9fe5fa",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Hotel Owner", "HOTEL_OWNER" });
        }
    }
}
