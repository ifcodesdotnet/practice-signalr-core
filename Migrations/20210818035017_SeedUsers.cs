using Microsoft.EntityFrameworkCore.Migrations;

namespace signalr_core_demo.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "firstName" },
                values: new object[] { 1, "Ismael" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "firstName" },
                values: new object[] { 2, "Bob" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
