using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementService.Migrations
{
    public partial class DropRoleIdColumnFromUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
