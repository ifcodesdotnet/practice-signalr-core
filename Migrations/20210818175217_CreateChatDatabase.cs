using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace signalr_core_demo.Migrations
{
    public partial class CreateChatDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityStatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userDeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastOnlineTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEntityid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityStatus", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserActivityStatus_Users_UserEntityid",
                        column: x => x.UserEntityid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "firstName", "lastName" },
                values: new object[] { 1, "Ismael", "Fernandez" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "firstName", "lastName" },
                values: new object[] { 2, "Bob", "Smith" });

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityStatus_UserEntityid",
                table: "UserActivityStatus",
                column: "UserEntityid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivityStatus");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
