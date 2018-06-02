using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementService.Migrations
{
    public partial class AddedUniversityIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Universities_UniversityId",
                table: "Schools");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Universities_UniversityId",
                table: "Schools",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Universities_UniversityId",
                table: "Schools");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Schools",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Universities_UniversityId",
                table: "Schools",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
