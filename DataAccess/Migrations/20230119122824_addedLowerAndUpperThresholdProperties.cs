using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedLowerAndUpperThresholdProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HumidityThreshold",
                table: "DHT11Readings",
                newName: "HumidityUpperThreshold");

            migrationBuilder.RenameColumn(
                name: "UpdateValue",
                table: "DeviceUpdateEvents",
                newName: "UpperThreshold");

            migrationBuilder.AddColumn<int>(
                name: "HumidityLowerThreshold",
                table: "DHT11Readings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LowerThreshold",
                table: "DeviceUpdateEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HumidityLowerThreshold",
                table: "DHT11Readings");

            migrationBuilder.DropColumn(
                name: "LowerThreshold",
                table: "DeviceUpdateEvents");

            migrationBuilder.RenameColumn(
                name: "HumidityUpperThreshold",
                table: "DHT11Readings",
                newName: "HumidityThreshold");

            migrationBuilder.RenameColumn(
                name: "UpperThreshold",
                table: "DeviceUpdateEvents",
                newName: "UpdateValue");
        }
    }
}
