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
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "firstName" },
                values: new object[] { 1, "Ismael" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "firstName" },
                values: new object[] { 2, "Bob" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
