using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageurAPI.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_profile_UserId",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "Preferences",
                table: "profile");

            migrationBuilder.AddColumn<int>(
                name: "UserRatingId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "score",
                table: "rating",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 1,
                column: "color",
                value: 3);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 2,
                column: "color",
                value: 3);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 3,
                column: "color",
                value: 3);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 4,
                column: "color",
                value: 3);

            migrationBuilder.UpdateData(
                table: "rating",
                keyColumn: "id",
                keyValue: 1,
                column: "score",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "rating",
                keyColumn: "id",
                keyValue: 2,
                column: "score",
                value: 2m);

            migrationBuilder.CreateIndex(
                name: "IX_user_UserRatingId",
                table: "user",
                column: "UserRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_profile_UserId",
                table: "profile",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_rating_UserRatingId",
                table: "user",
                column: "UserRatingId",
                principalTable: "rating",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_rating_UserRatingId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_UserRatingId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_profile_UserId",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "UserRatingId",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "rating",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Preferences",
                table: "profile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 1,
                column: "color",
                value: 2);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 2,
                column: "color",
                value: 2);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 3,
                column: "color",
                value: 2);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "id",
                keyValue: 4,
                column: "color",
                value: 2);

            migrationBuilder.UpdateData(
                table: "profile",
                keyColumn: "id",
                keyValue: 1,
                column: "Preferences",
                value: 2);

            migrationBuilder.UpdateData(
                table: "profile",
                keyColumn: "id",
                keyValue: 2,
                column: "Preferences",
                value: 1);

            migrationBuilder.UpdateData(
                table: "profile",
                keyColumn: "id",
                keyValue: 4,
                column: "Preferences",
                value: 2);

            migrationBuilder.UpdateData(
                table: "rating",
                keyColumn: "id",
                keyValue: 1,
                column: "score",
                value: 5);

            migrationBuilder.UpdateData(
                table: "rating",
                keyColumn: "id",
                keyValue: 2,
                column: "score",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_profile_UserId",
                table: "profile",
                column: "UserId");
        }
    }
}
