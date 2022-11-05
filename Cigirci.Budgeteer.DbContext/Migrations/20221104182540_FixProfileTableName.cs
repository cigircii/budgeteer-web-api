using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cigirci.Budgeteer.DbContext.Migrations
{
    public partial class FixProfileTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "profile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profile",
                table: "profile",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_profile",
                table: "profile");

            migrationBuilder.RenameTable(
                name: "profile",
                newName: "Profiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "id");
        }
    }
}