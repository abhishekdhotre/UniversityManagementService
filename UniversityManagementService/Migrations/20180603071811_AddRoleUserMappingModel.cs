using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementService.Migrations
{
    public partial class AddRoleUserMappingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                       name: "FK_RoleUsers_Roles_RoleId",
                       column: x => x.RoleId,
                       principalTable: "Roles",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_RoleUsers_Users_UserId",
                       column: x => x.UserId,
                       principalTable: "Users",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.NoAction);
                    table.UniqueConstraint("AK_RoleUsers_RoleId_UserId", x => new { x.UserId, x.RoleId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUsers");
        }
    }
}
