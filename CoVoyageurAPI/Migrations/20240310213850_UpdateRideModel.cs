using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageurAPI.Migrations
{
    public partial class UpdateRideModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "ride",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 1,
                column: "price",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 2,
                column: "price",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 3,
                column: "price",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 4,
                column: "price",
                value: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "ride",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 1,
                column: "price",
                value: 20.00m);

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 2,
                column: "price",
                value: 20.00m);

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 3,
                column: "price",
                value: 20.00m);

            migrationBuilder.UpdateData(
                table: "ride",
                keyColumn: "id",
                keyValue: 4,
                column: "price",
                value: 20.00m);
        }
    }
}
