using Microsoft.EntityFrameworkCore.Migrations;

namespace RERERE.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "96ed66e4-13eb-4019-851e-a100a0438ac5", "admin@pslib.cz", false, true, null, "ADMIN@PSLIB.CZ", "ADMIN@PSLIB.CZ", "AQAAAAEAACcQAAAAEEuJ2YoRdAni3TXOfWqp/T571RXgT3WE//7kR9uKDI9HhvMO7qJe36TwftqNRM95iQ==", null, false, "", false, "admin@pslib.cz" },
                    { "11111111-1111-1111-1111-111111111112", 0, "b2ec4017-9cd4-48a3-9554-d980d9320500", "user@pslib.cz", false, true, null, "USER@PSLIB.CZ", "USER@PSLIB.CZ", "AQAAAAEAACcQAAAAEDIbDnpJmXdqGoJWrVMw6LYj3inTGW0mw6iMXkoCDkBYhOaGq7CxiG2cH5XXv9kwMg==", null, false, "", false, "user@pslib.cz" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TadyDorebjidlo" },
                    { 2, "TadyneDorebjidlo" },
                    { 3, "TadyhodneDorebjidlo" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorEmail", "Content", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "user@pslib.cz", "fdsoi", 1 },
                    { 2, "user@pslib.cz", "fdsoi1", 1 },
                    { 3, "admin@pslib.cz", "fdsoi2", 1 },
                    { 4, "user@pslib.cz", "fdsoi3", 2 },
                    { 5, "user@pslib.cz", "fdsoi4", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112");
        }
    }
}
