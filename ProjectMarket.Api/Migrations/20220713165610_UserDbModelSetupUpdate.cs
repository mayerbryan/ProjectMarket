using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMarket.Api.Migrations
{
    public partial class UserDbModelSetupUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserPhone",
                table: "UserClient",
                type: "int",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserClient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserClient",
                type: "int",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "UserAddress",
                table: "UserClient",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 80);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserPhone",
                table: "UserClient",
                type: "integer",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserClient",
                type: "text",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserClient",
                type: "integer",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserClient",
                type: "text",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "UserAddress",
                table: "UserClient",
                type: "text",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);
        }
    }
}
