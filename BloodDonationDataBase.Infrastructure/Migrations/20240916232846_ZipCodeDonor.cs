using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationDataBase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ZipCodeDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Donors",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Donors");
        }
    }
}
