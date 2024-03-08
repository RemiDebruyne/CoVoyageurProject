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
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Preferences = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.id);
                    table.ForeignKey(
                        name: "FK_profile_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_car_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_car_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    score = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ratingdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_rating_ride_rideid",
                        column: x => x.rideid,
                        principalTable: "ride",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_user_rateduserid",
                        column: x => x.rateduserid,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rating_user_ratinguserid",
                        column: x => x.ratinguserid,
                        principalTable: "user",
                        principalColumn: "id");
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
                columns: new[] { "id", "birth_date", "email", "firstname", "gender", "IsAdmin", "lastname", "password", "phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kevin@mail.com", "Kevin", "M", false, "Callet", "pswd", "0102030405" },
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "massimo@mail.com", "Massima", "M", false, "Mao", "pswd", "0102030405" },
                    { 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "remi@mail.com", "Rémi", "M", false, "Debruyne", "pswd", "0102030405" },
                    { 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aguit@mail.com", "Aguit", "M", false, "Inan", "pswd", "0102030405" }
                });

            migrationBuilder.InsertData(
                table: "car",
                columns: new[] { "id", "brand", "color", "license_plate", "model", "ProfileId", "userId" },
                values: new object[,]
                {
                    { 1, "Ford", 2, "OG-666-OG", "Fiesta", null, 1 },
                    { 2, "Ford", 2, "AB-123-RT", "Fiesta", null, 2 },
                    { 3, "Ford", 2, "AB-123-RT", "Fiesta", null, 3 },
                    { 4, "Ford", 2, "AB-123-RT", "Fiesta", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "profile",
                columns: new[] { "id", "Preferences", "rating", "review", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 5, "¨Parfait", 1 },
                    { 2, 1, 4, "Bien", 2 },
                    { 3, 0, 3, "Moyen", 3 },
                    { 4, 2, 2, "Mauvais", 4 }
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
                    { 1, "Good", 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5 },
                    { 2, "Bad", 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2 }
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
                column: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "ride");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
