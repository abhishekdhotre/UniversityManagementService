using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementService.Migrations
{
    public partial class AddRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Roles"
                , new string[] { "Name" }
                , new object[] { "President" });

            migrationBuilder.InsertData("Roles"
                , new string[] { "Name" }
                , new object[] { "Vice President" });

            migrationBuilder.InsertData("Roles"
                , new string[] { "Name" }
                , new object[] { "Manager" });

            migrationBuilder.InsertData("Roles"
                , new string[] { "Name" }
                , new object[] { "Supervisor" });

            migrationBuilder.InsertData("Roles"
                , new string[] { "Name" }
                , new object[] { "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
