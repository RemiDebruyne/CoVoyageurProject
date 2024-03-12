using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageurAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    license_plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rideid = table.Column<int>(type: "int", nullable: false),
                    ratinguserid = table.Column<int>(type: "int", nullable: false),
                    rateduserid = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ratingdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserRatingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_rating_UserRatingId",
                        column: x => x.UserRatingId,
                        principalTable: "rating",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ride",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rideDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    availableSeats = table.Column<int>(type: "int", nullable: false),
                    departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arrival = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ride", x => x.id);
                    table.ForeignKey(
                        name: "FK_ride_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    rideId = table.Column<int>(type: "int", nullable: false),
                    reservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservation_ride_rideId",
                        column: x => x.rideId,
                        principalTable: "ride",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_reservation_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "email", "firstname", "gender", "IsAdmin", "lastname", "password", "phone", "UserRatingId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kevin@mail.com", "Kevin", "M", true, "Callet", "cHN3ZGNsw6kgc3VwZXIgc2VjcsOodGU=", "0102030405", null },
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "massimo@mail.com", "Massima", "M", false, "Mao", "cHN3ZGNsw6kgc3VwZXIgc2VjcsOodGU=", "0102030405", null },
                    { 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "remi@mail.com", "Rémi", "M", false, "Debruyne", "cHN3ZGNsw6kgc3VwZXIgc2VjcsOodGU=", "0102030405", null },
                    { 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aguit@mail.com", "Aguit", "M", true, "Inan", "cHN3ZGNsw6kgc3VwZXIgc2VjcsOodGU=", "0102030405", null }
                });

            migrationBuilder.InsertData(
                table: "car",
                columns: new[] { "id", "brand", "color", "license_plate", "model", "ProfileId", "userId" },
                values: new object[,]
                {
                    { 1, "Ford", 3, "OG-666-OG", "Fiesta", null, 1 },
                    { 2, "Ford", 3, "AB-123-RT", "Fiesta", null, 2 },
                    { 3, "Ford", 3, "AB-123-RT", "Fiesta", null, 3 },
                    { 4, "Ford", 3, "AB-123-RT", "Fiesta", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "profile",
                columns: new[] { "id", "rating", "review", "UserId" },
                values: new object[,]
                {
                    { 1, 5, "Parfait", 1 },
                    { 2, 4, "Bien", 2 },
                    { 3, 3, "Moyen", 3 },
                    { 4, 2, "Mauvais", 4 }
                });

            migrationBuilder.InsertData(
                table: "ride",
                columns: new[] { "id", "arrival", "availableSeats", "creationDate", "departure", "price", "rideDate", "userId" },
                values: new object[,]
                {
                    { 1, "10h00", 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9h00", 20.00m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "10h00", 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9h00", 20.00m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "10h00", 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9h00", 20.00m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "10h00", 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9h00", 20.00m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "rating",
                columns: new[] { "id", "comment", "rateduserid", "ratingdate", "ratinguserid", "rideid", "score" },
                values: new object[,]
                {
                    { 1, "Good", 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5m },
                    { 2, "Bad", 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2m }
                });

            migrationBuilder.InsertData(
                table: "reservation",
                columns: new[] { "id", "reservationDate", "rideId", "status", "userId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 1 },
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_ProfileId",
                table: "car",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_car_userId",
                table: "car",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_profile_UserId",
                table: "profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rating_rateduserid",
                table: "rating",
                column: "rateduserid");

            migrationBuilder.CreateIndex(
                name: "IX_rating_ratinguserid",
                table: "rating",
                column: "ratinguserid");

            migrationBuilder.CreateIndex(
                name: "IX_rating_rideid",
                table: "rating",
                column: "rideid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_rideId",
                table: "reservation",
                column: "rideId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_userId",
                table: "reservation",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ride_userId",
                table: "ride",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserRatingId",
                table: "user",
                column: "UserRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_car_profile_ProfileId",
                table: "car",
                column: "ProfileId",
                principalTable: "profile",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_user_userId",
                table: "car",
                column: "userId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_user_UserId",
                table: "profile",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_ride_rideid",
                table: "rating",
                column: "rideid",
                principalTable: "ride",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_user_rateduserid",
                table: "rating",
                column: "rateduserid",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_rating_user_ratinguserid",
                table: "rating",
                column: "ratinguserid",
                principalTable: "user",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rating_user_rateduserid",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_rating_user_ratinguserid",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_ride_user_userId",
                table: "ride");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "ride");
        }
    }
}
