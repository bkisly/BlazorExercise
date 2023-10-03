using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorExercise.Migrations
{
    /// <inheritdoc />
    public partial class CreateDeviceCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceCategory_CategoryId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceCategory",
                table: "DeviceCategory");

            migrationBuilder.RenameTable(
                name: "DeviceCategory",
                newName: "DeviceCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceCategories",
                table: "DeviceCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceCategories_CategoryId",
                table: "Devices",
                column: "CategoryId",
                principalTable: "DeviceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceCategories_CategoryId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceCategories",
                table: "DeviceCategories");

            migrationBuilder.RenameTable(
                name: "DeviceCategories",
                newName: "DeviceCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceCategory",
                table: "DeviceCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceCategory_CategoryId",
                table: "Devices",
                column: "CategoryId",
                principalTable: "DeviceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
