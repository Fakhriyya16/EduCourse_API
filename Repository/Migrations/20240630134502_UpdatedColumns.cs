using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Groups_GroupId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Education_GroupId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Education");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EducationId",
                table: "Groups",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Education_EducationId",
                table: "Groups",
                column: "EducationId",
                principalTable: "Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Education_EducationId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_EducationId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Education_GroupId",
                table: "Education",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Groups_GroupId",
                table: "Education",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
