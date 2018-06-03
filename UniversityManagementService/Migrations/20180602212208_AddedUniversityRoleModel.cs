using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementService.Migrations
{
    public partial class AddedUniversityRoleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityRoles",
                columns: table => new
                {
                    UniversityId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityRoles", x => new { x.UniversityId, x.RoleId });
                    table.ForeignKey(
                       name: "FK_UniversityRoles_Universities_UniversityId",
                       column: x => x.UniversityId,
                       principalTable: "Universities",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_UniversityRoles_Roles_RoleId",
                       column: x => x.RoleId,
                       principalTable: "Roles",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                    table.UniqueConstraint("AK_UniversityRoles_RoleId_UniversityId", x => new { x.RoleId, x.UniversityId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityRoles");
        }
    }
}
