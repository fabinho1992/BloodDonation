using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationDataBase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ZipCodeLength9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "NVARCHAR(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)",
                oldMaxLength: 8);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "NVARCHAR(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(9)",
                oldMaxLength: 9);
        }
    }
}
