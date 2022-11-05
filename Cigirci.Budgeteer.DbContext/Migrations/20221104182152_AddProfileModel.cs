using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cigirci.Budgeteer.DbContext.Migrations
{
    public partial class AddProfileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "transaction",
                type: "decimal(19,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sex = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    owner_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    owner_type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "transaction",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(19,4)");
        }
    }
}