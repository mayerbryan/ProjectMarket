using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMarket.Api.Migrations
{
    public partial class UserDbInitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    SystemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UserPhone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    UserId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.SystemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
