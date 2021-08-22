using Microsoft.EntityFrameworkCore.Migrations;

namespace signalr_core_demo.Migrations
{
    public partial class AddingUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "emailAddress",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "emailAddress",
                value: "test1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "emailAddress",
                value: "test2");

            migrationBuilder.CreateIndex(
                name: "IX_Users_emailAddress",
                table: "Users",
                column: "emailAddress",
                unique: true,
                filter: "[emailAddress] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id",
                table: "Users",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_emailAddress",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_id",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "emailAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "emailAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "emailAddress",
                value: null);
        }
    }
}
